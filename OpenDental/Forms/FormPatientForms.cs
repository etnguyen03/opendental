using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CodeBase;
using OpenDental.UI;
using OpenDentBusiness;
using OpenDentBusiness.SheetFramework;

namespace OpenDental {
	public partial class FormPatientForms:FormODBase {
		public long PatNum;
		///<summary>Indicates the most recently selected Document.DocNum</summary>
		public long DocNum;
		private Patient _patient;

		public FormPatientForms() {
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
			DocNum=0;
		}

		private void FormPatientForms_Load(object sender,EventArgs e) {
			if(!ODBuild.IsDebug() && !PrefC.IsODHQ) {//if release and not HQ
				butAddEForm.Visible=false;
			}
			_patient=Patients.GetPat(PatNum);
			Text=Lan.g(this,"Patient Forms for")+" "+_patient.GetNameFL();
			LayoutMenu();
			FillGrid(refreshFromDb:true);
		}

		private void LayoutMenu() {
			menuMain.BeginUpdate();
			MenuItemOD menuItemSetup=new MenuItemOD("Setup");
			menuMain.Add(menuItemSetup);
			menuItemSetup.Add("Sheets",menuItemSheets_Click);
			if(ODBuild.IsDebug() || PrefC.IsODHQ) {
				menuItemSetup.Add("eForms",menuItemEForms_Click);
			}
			menuItemSetup.Add("Image Categories",menuItemImageCats_Click);
			menuItemSetup.Add("Options",menuItemOptions_Click);
			//if(ODBuild.IsDebug() || PrefC.IsODHQ) {
			//	menuItemSetup.Add("Import Rules",menuItemImportRules_Click);
			//}
			menuMain.EndUpdate();
		}

		private void FillGrid(bool refreshFromDb){
			//js This is an edge case pattern because we are not normally dealing with a table.
			DataTable table=new DataTable();
			if(refreshFromDb){
				table=Sheets.GetPatientFormsTable(PatNum);
			}
			else{
				List<DataRow> listDataRows2=gridMain.ListGridRows.Select(x=>(DataRow)x.Tag).ToList();//Get the list of DataRows from the grid.
				if(listDataRows2.Count>0){//The line below will throw an exception if there aren't any rows to copy.
					table=listDataRows2.CopyToDataTable();//Add them to the new DataTable. CopyToDataTable() will also copy the schema to the table.
				}
			}
			//Sort DataTable.
			if(radioSortByDateTime.Checked && table.Rows.Count>0){
				DataView dataView=table.DefaultView;
				dataView.Sort="dateTime";
				table=dataView.ToTable();
			}
			else if(radioSortByDescDateT.Checked && table.Rows.Count>0){
				DataView dataView=table.DefaultView;
				dataView.Sort="description,dateTime";
				table=dataView.ToTable();
			}
			//Get previously selected form, if one was selected.
			long sheetNumSelected=0;
			long eFormNumSelected=0;
			long docNumSelected=0;
			if(gridMain.GetSelectedIndex()!=-1) {
				DataRow dataRow=(DataRow)gridMain.ListGridRows[gridMain.GetSelectedIndex()].Tag;
				sheetNumSelected=PIn.Long(dataRow["SheetNum"].ToString());
				eFormNumSelected=PIn.Long(dataRow["EFormNum"].ToString());
				docNumSelected=PIn.Long(dataRow["DocNum"].ToString());
			}
			//Fill Grid.
			gridMain.BeginUpdate();
			gridMain.Columns.Clear();
			GridColumn col=new GridColumn(Lan.g(this,"Type"),60);
			gridMain.Columns.Add(col);
			col=new GridColumn(Lan.g(this,"Date/Time"),140,GridSortingStrategy.DateParse);
			gridMain.Columns.Add(col);
			col=new GridColumn(Lan.g(this,"Kiosk"),55,HorizontalAlignment.Center,GridSortingStrategy.AmountParse);
			gridMain.Columns.Add(col);
			col=new GridColumn(Lan.g(this,"Description"),190);
			gridMain.Columns.Add(col);
			col=new GridColumn(Lan.g(this,"Image Category"),120);
			gridMain.Columns.Add(col);
			col=new GridColumn(Lan.g(this,"Updated"),65,GridSortingStrategy.DateParse);
			gridMain.Columns.Add(col);
			gridMain.ListGridRows.Clear();
			GridRow row;
			for(int i=0;i<table.Rows.Count;i++){
				row=new GridRow();
				//Test each form for its form type
				if(table.Rows[i]["DocNum"].ToString()!="0"){
					row.Cells.Add("Document");
				}
				else if(table.Rows[i]["SheetNum"].ToString()!="0"){
					row.Cells.Add("Sheet");
				}
				else if(table.Rows[i]["EFormNum"].ToString()!="0"){
					row.Cells.Add("eForm");
				}
				row.Cells.Add(table.Rows[i]["dateTime"].ToString());
				row.Cells.Add(table.Rows[i]["showInTerminal"].ToString());
				row.Cells.Add(table.Rows[i]["description"].ToString());
				row.Cells.Add(table.Rows[i]["imageCat"].ToString());
				row.Cells.Add(table.Rows[i]["DateTSheetEdited"].ToString());
				row.Tag=table.Rows[i];
				gridMain.ListGridRows.Add(row);
			}
			gridMain.EndUpdate();
			//Set selected row if there was one selected.
			List<DataRow> listDataRows=gridMain.ListGridRows.Select(x=>(DataRow)x.Tag).ToList();
			if(sheetNumSelected!=0){
				int idx=listDataRows.FindIndex(x=>x["SheetNum"].ToString()==sheetNumSelected.ToString());
				gridMain.SetSelected(idx,true);
			}
			else if(eFormNumSelected!=0){
				int idx=listDataRows.FindIndex(x=>x["eFormNum"].ToString()==eFormNumSelected.ToString());
				gridMain.SetSelected(idx,true);
			}
			else if(docNumSelected!=0){
				int idx=listDataRows.FindIndex(x=>x["DocNum"].ToString()==docNumSelected.ToString());
				gridMain.SetSelected(idx,true);
			}
		}

		private void gridMain_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			DataRow dataRow=(DataRow)gridMain.ListGridRows[e.Row].Tag;
			//Images
			//Hold onto docNum so Image module refresh persists selection when closing FormPatientForms.
			DocNum=PIn.Long(dataRow["DocNum"].ToString());//Set to 0 if not a Document, i.e. a Sheet.
			if(DocNum!=0) {
				if(!Security.IsAuthorized(EnumPermType.ImagingModule)) {
					return;
				}
				GlobalFormOpenDental.GoToModule(EnumModuleType.Imaging,patNum:PatNum,docNum:DocNum);
				return;
			}
			//Sheets
			long sheetNum=PIn.Long(dataRow["SheetNum"].ToString());
			if(sheetNum!=0){
				Sheet sheet=Sheets.GetSheet(sheetNum);
				FormSheetFillEdit.ShowForm(sheet,FormSheetFillEdit_FormClosing);
				return;
			}
			//EForms
			long eFormNum=PIn.Long(dataRow["EFormNum"].ToString());
			if(eFormNum!=0){
				EForm eForm=EForms.GetEForm(eFormNum);
				FrmEFormFillEdit frmEFormFillEdit=new FrmEFormFillEdit();
				frmEFormFillEdit.EFormCur=eForm;
				frmEFormFillEdit.ShowDialog();
				if(frmEFormFillEdit.IsDialogCancel){
					return;
				}
				//Must have saved to db.
				//This might have included "deleting" the eForm, which we don't need to test for here.
				FillGrid(refreshFromDb:true);
				return;
			}
		}

		private void menuItemSheets_Click(object sender,EventArgs e) {
			if(!Security.IsAuthorized(EnumPermType.Setup)) {
				return;
			}
			using FormSheetDefs formSheetDefs=new FormSheetDefs();
			formSheetDefs.ShowDialog();
			SecurityLogs.MakeLogEntry(EnumPermType.Setup,0,"Sheets");
			FillGrid(refreshFromDb:false);
		}

		private void menuItemEForms_Click(object sender,EventArgs e) {
			if(!Security.IsAuthorized(EnumPermType.Setup)) {
				return;
			}
			FrmEFormDefs frmEFormDefs=new FrmEFormDefs();
			frmEFormDefs.ShowDialog();
			SecurityLogs.MakeLogEntry(EnumPermType.Setup,0,"EForms");
			FillGrid(refreshFromDb:false);
		}

		private void menuItemImageCats_Click(object sender,EventArgs e) {
			if(!Security.IsAuthorized(EnumPermType.DefEdit)) {
				return;
			}
			using FormDefinitions formDefinitions=new FormDefinitions(DefCat.ImageCats);
			formDefinitions.ShowDialog();
			SecurityLogs.MakeLogEntry(EnumPermType.DefEdit,0,"Defs");
			FillGrid(refreshFromDb:true);
		}

		private void menuItemOptions_Click(object sender,EventArgs e) {
			if(!Security.IsAuthorized(EnumPermType.Setup)) {
				return;
			}
			FrmSheetSetup frmSheetSetup=new FrmSheetSetup();
			frmSheetSetup.ShowDialog();
			SecurityLogs.MakeLogEntry(EnumPermType.Setup,0,"ShowForms");
			FillGrid(refreshFromDb:true);
		}

		private void radioSortByDateTime_Click(object sender,EventArgs e) {
			//Refill gridMain without pulling from the db.
			FillGrid(refreshFromDb:false);
		}

		private void radioSortByDescriptionDateTime_Click(object sender,EventArgs e) {
			//Refill gridMain without pulling from the db.
			FillGrid(refreshFromDb:false);
		}

		//private void menuItemImportRules_Click(object sender,EventArgs e) {
		//	if(!Security.IsAuthorized(EnumPermType.Setup)) {
		//		return;
		//	}
		//	FrmEFormImportRules frmEFormImportRules=new FrmEFormImportRules();
		//	frmEFormImportRules.ShowDialog();
		//	SecurityLogs.MakeLogEntry(EnumPermType.Setup,0,"EForm Import Rules");
		//	FillGrid();
		//}

		private void butAddSheet_Click(object sender,EventArgs e) {
			FrmSheetPicker frmSheetPicker=new FrmSheetPicker();
			frmSheetPicker.AllowMultiSelect=true;
			frmSheetPicker.SheetType=SheetTypeEnum.PatientForm;
			frmSheetPicker.ShowDialog();
			if(!frmSheetPicker.IsDialogOK) {
				return;
			}
			SheetDef sheetDef;
			Sheet sheet=null;//only useful if not Terminal
			bool isPatUsingEClipboard=MobileAppDevices.PatientIsAlreadyUsingDevice(PatNum);
			for(int i=0;i<frmSheetPicker.ListSheetDefsSelected.Count;i++) {
				sheetDef=frmSheetPicker.ListSheetDefsSelected[i];
				if(frmSheetPicker.DoKioskSend && isPatUsingEClipboard && !sheetDef.HasMobileLayout) {
					if(!MsgBox.Show(MsgBoxButtons.YesNo,$"The patient is currently using an eClipboard to fill out forms, but the " +
						$"{sheetDef.Description} sheet does not have a mobile layout and cannot be used with eClipboard. " +
						$"If you add this form to the patient's list it will not be shown in eClipboard. Do you still want to add this form?")) {
						continue;
					}
				}
				sheet=SheetUtil.CreateSheet(sheetDef,PatNum);
				if(SheetDefs.ContainsGrids(sheetDef,"ProcsWithFee","ProcsNoFee")) {
					using FormSheetProcSelect formSheetProcSelect=new FormSheetProcSelect();
					formSheetProcSelect.PatNum=PatNum;
					formSheetProcSelect.ShowDialog();
					if(formSheetProcSelect.DialogResult==DialogResult.OK) {
						SheetParameter.SetParameter(sheet,"ListProcNums",formSheetProcSelect.ListProcNumsSelected);
					}
				}
				//Will display FormApptsOther for the user to select an appointment or procedures to display on the sheet.
				SheetUtilL.SetApptProcParamsForSheet(sheet,sheetDef,PatNum);
				SheetParameter.SetParameter(sheet,"PatNum",PatNum);
				SheetFiller.FillFields(sheet);
				SheetUtil.CalculateHeights(sheet);
				if(frmSheetPicker.DoKioskSend) {
					sheet.InternalNote="";//because null not ok
					sheet.ShowInTerminal=(byte)(Sheets.GetBiggestShowInTerminal(PatNum)+1);
					Sheets.SaveNewSheet(sheet);//save each sheet.
					Sheets.SaveParameters(sheet);
					//Create mobile notification to update eClipboard device with new sheet.
					if(isPatUsingEClipboard && sheetDef.HasMobileLayout) {
						MobileNotifications.CI_AddSheet(sheet.PatNum,sheet.SheetNum);
					}
				}
			}
			if(frmSheetPicker.DoKioskSend) {
				//do not show a dialog now.  User will need to click the terminal button.
				FillGrid(refreshFromDb:true);
				Signalods.SetInvalid(InvalidType.Kiosk);
			}
			else if(sheet!=null) {
				FormSheetFillEdit.ShowForm(sheet,FormSheetFillEdit_FormClosing);
			}
		}

		private void butAddEForm_Click(object sender,EventArgs e) {
			FrmEFormPicker frmEFormPicker=new FrmEFormPicker();
			frmEFormPicker.ShowDialog();
			if(frmEFormPicker.IsDialogCancel){
				return;
			}
			EFormDef eFormDef=frmEFormPicker.EFormDefSelected;
			//fields already attached
			EForm eForm=EForms.CreateEFormFromEFormDef(eFormDef,PatNum,EnumEFormStatus.None);//sets IsNew=true
			eForm.DateTimeShown=DateTime.Now;
			EFormFiller.FillFields(eForm);
			EForms.TranslateFields(eForm,_patient.Language);
			FrmEFormFillEdit frmEFormFillEdit=new FrmEFormFillEdit();
			frmEFormFillEdit.EFormCur=eForm;
			frmEFormFillEdit.ShowDialog();
			if(frmEFormFillEdit.IsDialogCancel){
				//This could include "deleting" the new eForm, which would then never have made it to the db at all.
				return;
			}
			//must have saved to db.
			FillGrid(refreshFromDb:true);
		}

		private void butTerminal_Click(object sender,EventArgs e) {
			//<List>.All() returns true for an empty list.
			List<DataRow> listDataRows=gridMain.ListGridRows.Select(x=>(DataRow)x.Tag).ToList();//Get the list of DataRows from the grid.
			if(listDataRows.All(x=>x["showInTerminal"].ToString()=="")){
				MsgBox.Show(this,"No forms for this patient are set to show in the kiosk.");
				return;
			}
			if(PrefC.GetLong(PrefName.ProcessSigsIntervalInSecs)==0) {
				MsgBox.Show(this,"Cannot open kiosk unless process signal interval is set. To set it, go to Setup > Miscellaneous.");
				return;
			}
			if(ODEnvironment.IsCloudServer) {
				//Thinfinity messes up window ordering so sometimes FormOpenDental is visible in Kiosk mode.
				for(int i=0;i<Application.OpenForms.Count;i++) {
					Application.OpenForms[i].Visible=false;
				}
			}
			using FormTerminal formTerminal=new FormTerminal();
			formTerminal.IsSimpleMode=true;
			formTerminal.PatNum=PatNum;
			formTerminal.ShowDialog();
			if(ODEnvironment.IsCloudServer) {
				for(int i=0;i<Application.OpenForms.Count;i++) {
					Application.OpenForms[i].Visible=true;
				}
			}
			FillGrid(refreshFromDb:true);
		}

		private void butPreFill_Click(object sender,EventArgs e) {
			if(gridMain.SelectedIndices.Length !=1) {
				MsgBox.Show(this,"Please select one completed sheet from the list above first.");
				return;
			}
			DataRow dataRow=(DataRow)gridMain.ListGridRows[gridMain.SelectedIndices[0]].Tag;
			long sheetNum=PIn.Long(dataRow["SheetNum"].ToString());
			if(sheetNum==0) {
				MsgBox.Show(this,"Must select a sheet.");
				return;
			}
			Sheet sheet=Sheets.GetSheet(sheetNum);
			if(sheet==null) {
				MsgBox.Show(this,"The selected sheet has been deleted by another workstation.");
				return;
			}
			SheetDef sheetDefOriginal=SheetDefs.GetSheetDef(sheet.SheetDefNum,hasExceptions:false);
			if(sheetDefOriginal==null) {
				//We could not find the sheetDef which this sheet was based on.
				//Prompt the user, asking if they would like to manually select a sheet def.
				if(!MsgBox.Show(this, MsgBoxButtons.YesNo, "Sheet Def not found. Unable to pre-fill. Would you like to select the correct Sheet Def manually?")) {
					return;//If the user chose not to pick a sheetDef, return.
				}
				//Find SheetDefs of the same type as the sheet we are pre-filling, and allow the user to select one.
				List<SheetDef> listSheetDefs=SheetDefs.GetCustomForType(sheet.SheetType);
				FrmSheetPicker frmSheetPicker=new FrmSheetPicker();
				frmSheetPicker.SheetType=sheet.SheetType;
				frmSheetPicker.ListSheetDefs=listSheetDefs;
				frmSheetPicker.IsPreFill=true;
				frmSheetPicker.ShowDialog();
				if(!frmSheetPicker.IsDialogOK) {
					return;//If the user cancelled, return.
				}
				sheetDefOriginal=frmSheetPicker.ListSheetDefsSelected.First();
				sheet.SheetDefNum=sheetDefOriginal.SheetDefNum;
			}
			Sheet sheetNew=Sheets.PreFillSheetFromPreviousAndDatabase(sheetDefOriginal,sheet);
			sheetNew.IsNew=true;
			using FormSheetFillEdit formSheetFillEdit=new FormSheetFillEdit();
			formSheetFillEdit.SheetCur=sheetNew;
			formSheetFillEdit.ShowDialog();
			//If they press ok, the form is inserted, so refresh the grid, make a security log, and select the new entry.
			if(formSheetFillEdit.DialogResult==DialogResult.OK) {
				SecurityLogs.MakeLogEntry(EnumPermType.Copy,PatNum,"Patient form "+sheet.Description+" from "+sheet.DateTimeSheet.ToString()+" copied via Pre-Fill");
				FillGrid(refreshFromDb:true);
				//Select the newly added sheet.
				for(int i=0;i<gridMain.ListGridRows.Count;i++) {
					dataRow=(DataRow)gridMain.ListGridRows[i].Tag;
					if(dataRow["SheetNum"].ToString()==sheetNew.SheetNum.ToString()) {
						gridMain.SetSelected(i,true);
						break;
					}
				}
			}
		}

		private void butCopy_Click(object sender,EventArgs e) {
			if(gridMain.SelectedIndices.Length!=1) {
				MsgBox.Show(this,"Please select one completed sheet from the list above first.");
				return;
			}
			DataRow dataRow=(DataRow)gridMain.ListGridRows[gridMain.SelectedIndices[0]].Tag;
			long sheetNum=PIn.Long(dataRow["SheetNum"].ToString());
			if(sheetNum==0) {
				MsgBox.Show(this,"Must select a sheet.");
				return;
			}
			Sheet sheet=Sheets.GetSheet(sheetNum);
			Sheet sheet2=sheet.Copy();
			sheet2.DateTimeSheet=DateTime.Now;
			sheet2.SheetFields=new List<SheetField>(sheet.SheetFields);
			for(int i=0;i<sheet2.SheetFields.Count;i++){
				sheet2.SheetFields[i].IsNew=true;
				if(sheet2.SheetFields[i].FieldType==SheetFieldType.SigBox){
					sheet2.SheetFields[i].FieldValue="";//clear signatures
				}
				//no need to set SheetNums here.  That's done from inside FormSheetFillEdit
			}
			sheet2.IsNew=true;
			using FormSheetFillEdit formSheetFillEdit=new FormSheetFillEdit();
			formSheetFillEdit.SheetCur=sheet2;
			formSheetFillEdit.ShowDialog();
			if(formSheetFillEdit.DialogResult==DialogResult.OK || formSheetFillEdit.DidChangeSheet) {
				FillGrid(refreshFromDb:true);
				for(int i=0;i<gridMain.ListGridRows.Count;i++){
					dataRow=(DataRow)gridMain.ListGridRows[i].Tag;
					if(dataRow["SheetNum"].ToString()==sheet2.SheetNum.ToString()){
						gridMain.SetSelected(i,true);
					}
				}
				SecurityLogs.MakeLogEntry(EnumPermType.Copy,PatNum,"Patient form "+sheet.Description+" from "+sheet.DateTimeSheet.ToString()+" copied");
			}
		}

		private void butImport_Click(object sender,EventArgs e) {
			if(gridMain.SelectedIndices.Length !=1) {
				MsgBox.Show(this,"Please select one completed form from the list above first.");
				return;
			}
			DataRow dataRow=(DataRow)gridMain.ListGridRows[gridMain.SelectedIndices[0]].Tag;
			long docNum=PIn.Long(dataRow["DocNum"].ToString());
			if(docNum!=0) {
				//document=Documents.GetByNum(docNum);
				//Pdf importing broke with dot net 4.0 and was enver reimplemented.
				//See FormSheetImport.Load() region Acro 
				//string extens=Path.GetExtension(doc.FileName);
				//if(extens.ToLower()!=".pdf") {
				//	MsgBox.Show(this,"Only pdf's and sheets can be imported into the database.");
				//	return;
				//}
				MsgBox.Show(this,"PDFs cannot be imported into the database.");
				return;
			}
			long sheetNum=PIn.Long(dataRow["SheetNum"].ToString());
			long eFormNum=PIn.Long(dataRow["EFormNum"].ToString());
			Sheet sheet=null;
			if(sheetNum!=0) {
				sheet=Sheets.GetSheet(sheetNum);
				if(!SheetDefs.IsWebFormAllowed(sheet.SheetType)) {
					MsgBox.Show(this,"For now, only sheets of type 'PatientForm' and 'MedicalHistory' can be imported.");
					return;
				}
			}
			//if(ODBuild.IsDebug() || PrefC.IsODHQ) {
				//this is for testing the new automatic import
				//	MsgBox.Show(this,"Done");
				//	return;
			//}
			EForm eForm=null;
			if(eFormNum!=0){
				eForm=EForms.GetEForm(eFormNum);
			}
			using FormSheetImport formSheetImport=new FormSheetImport();
			formSheetImport.SheetCur=sheet;
			formSheetImport.EFormCur=eForm;
			formSheetImport.ShowDialog();
			//No need to refresh grid because no changes could have been made.
		}

		/// <summary>Event handler for closing FormSheetFillEdit when it is non-modal.</summary>
		private void FormSheetFillEdit_FormClosing(object sender,FormClosingEventArgs e) {
			if(((FormSheetFillEdit)sender).DialogResult==DialogResult.OK || ((FormSheetFillEdit)sender).DidChangeSheet) {
				FillGrid(refreshFromDb:true);
			}
		}

	}
}