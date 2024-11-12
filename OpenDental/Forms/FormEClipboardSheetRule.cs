using CodeBase;
using OpenDentBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDental {
	public partial class FormEClipboardSheetRule:FormODBase {
		///<summary>List of the selected SheetDefs to ignore. Sheets only.</summary>
		private List<SheetDef> _listSheetDefs;
		///<summary>The eClipboardSheetDef we are currently editing. Must be set before opening this form.</summary>
		public EClipboardSheetDef EClipboardSheetDefCur;
		///<summary>List of the currently in use EClipboardSheetDefs from the parent form. Used for listSheetsToIgnore, not needed for eForms.</summary>
		public List<EClipboardSheetDef> ListEClipboardSheetDefs;
		///<summary>Gets set to true if an eClipboardSheetDef has been marked for deletion. Deletion occurs in parent form.</summary>
		public bool IsDeleted=false;

		public FormEClipboardSheetRule() {
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
		}

		private void FormEClipboardSheetRule_Load(object sender,EventArgs e) {
			//Get the name of the sheet
			if(EClipboardSheetDefCur.SheetDefNum!=0){
				List<long> listSheetDefNumsIgnored=EClipboardSheetDefs.GetListIgnoreSheetDefNums(EClipboardSheetDefCur);
				_listSheetDefs=SheetDefs.GetWhere(x=>listSheetDefNumsIgnored.Contains(x.SheetDefNum));
				textSheet.Text=SheetDefs.GetDescription(EClipboardSheetDefCur.SheetDefNum);
			}
			else{//EForm
				listSheetsToIgnore.Visible=false;
				butSelectSheetsToIgnore.Visible=false;
				labelSheetsToIgnore.Visible=false;
				EFormDef eFormDef=EFormDefs.GetFirstOrDefault(x=>x.EFormDefNum==EClipboardSheetDefCur.EFormDefNum);
				if(eFormDef!=null){
					textSheet.Text=eFormDef.Description;
				}
			}
			radioBehaviorNew.Checked=EClipboardSheetDefCur.PrefillStatus==PrefillStatuses.New;
			radioBehaviorPreFill.Checked=EClipboardSheetDefCur.PrefillStatus==PrefillStatuses.PreFill;
			//groupFrequency start
			radioFreqOnce.Checked=EClipboardSheetDefCur.Frequency==EnumEClipFreq.Once;
			radioFreqEachTime.Checked=EClipboardSheetDefCur.Frequency==EnumEClipFreq.EachTime;
			radioFreqTimeSpan.Checked=EClipboardSheetDefCur.Frequency==EnumEClipFreq.TimeSpan;
			Interval interval=new Interval(EClipboardSheetDefCur.ResubmitInterval);
			textVIntYears.Text=interval.Years.ToString();
			textVIntMonths.Text=interval.Months.ToString();
			textVIntDays.Text=interval.Days.ToString();
			//groupFrequency end
			if(EClipboardSheetDefCur.MinAge>0) {
				textMinAge.Text=EClipboardSheetDefCur.MinAge.ToString();
			}
			if(EClipboardSheetDefCur.MaxAge>0) {
				textMaxAge.Text=EClipboardSheetDefCur.MaxAge.ToString();
			}
			if(EClipboardSheetDefCur.EFormDefNum!=0){//if this eClipboardSheetDef is an eForm, skip setting up listSheetsToIgnore.
				return;
			}
			listSheetsToIgnore.Visible=EClipboardSheetDefCur.Frequency==EnumEClipFreq.Once;
			listSheetsToIgnore.Items.Clear();
			listSheetsToIgnore.Items.AddStrings(_listSheetDefs.Select(x => x.Description).ToList());
			butSelectSheetsToIgnore.Visible=EClipboardSheetDefCur.Frequency==EnumEClipFreq.Once;
			labelSheetsToIgnore.Visible=EClipboardSheetDefCur.Frequency==EnumEClipFreq.Once;
		}

		///<summary>Only displays when the behavior Once is selected. When a patient fills out the selected sheet, they won't be prompted to fill out any Sheets to Ignore, even if these are in the Sheets in Use list.</summary>
		private void butSelectSheetsToIgnore_Click(object sender,EventArgs e) {
			if(EClipboardSheetDefCur.SheetDefNum==0){
				return;
			}
			FrmSheetPicker frmSheetPicker=new FrmSheetPicker();
			frmSheetPicker.AllowMultiSelect=true;
			SheetDef sheetDef=SheetDefs.GetFirstOrDefault(x=>x.SheetDefNum==EClipboardSheetDefCur.SheetDefNum);
			//Add any sheet defs that are ignoring this sheet def. We don't want to allow chaining ignores.
			frmSheetPicker.ListSheetDefNumsExclude=ListEClipboardSheetDefs
				.Where(x => x.IgnoreSheetDefNums!=null && x.IgnoreSheetDefNums.Contains(POut.Long(EClipboardSheetDefCur.SheetDefNum)))
				.Select(x => x.SheetDefNum)
				.ToList();
			//Add this sheet def too, the rule shouldn't be able to ignore itself.
			frmSheetPicker.ListSheetDefNumsExclude.Add(EClipboardSheetDefCur.SheetDefNum);
			//Sets the list of sheets the sheet picker window will display.
			frmSheetPicker.ListSheetDefs=SheetDefs.GetCustomForType(sheetDef.SheetType);
			frmSheetPicker.ListSheetDefsSelected=frmSheetPicker.ListSheetDefs.Where(x => _listSheetDefs.Select(y => y.SheetDefNum).Contains(x.SheetDefNum)).ToList();
			frmSheetPicker.SheetType=sheetDef.SheetType;
			frmSheetPicker.HideKioskButton=true;
			frmSheetPicker.AllowMultiSelect=true;
			frmSheetPicker.RequireSelection=false;
			frmSheetPicker.ShowDialog();
			if(!frmSheetPicker.IsDialogOK) {
				return;
			}
			_listSheetDefs=frmSheetPicker.ListSheetDefsSelected;
			listSheetsToIgnore.Items.Clear();
			listSheetsToIgnore.Items.AddStrings(_listSheetDefs.Select(x => x.Description).ToList());
		}

		private void radioFreq_CheckedChanged(object sender,EventArgs e){
			if(EClipboardSheetDefCur.SheetDefNum!=0){//Sheets only, SheetsToIgnore doesn't apply to eForms.
				butSelectSheetsToIgnore.Visible=radioFreqOnce.Checked;
				listSheetsToIgnore.Visible=radioFreqOnce.Checked;
				labelSheetsToIgnore.Visible=radioFreqOnce.Checked;
			}
			labelYears.Visible=radioFreqTimeSpan.Checked;
			labelMonths.Visible=radioFreqTimeSpan.Checked;
			labelDays.Visible=radioFreqTimeSpan.Checked;
			textVIntYears.Visible=radioFreqTimeSpan.Checked;
			textVIntMonths.Visible=radioFreqTimeSpan.Checked;
			textVIntDays.Visible=radioFreqTimeSpan.Checked;
			labelTimeSpanHelp.Visible=radioFreqTimeSpan.Checked;
		}

/*		private void butChangeForm_Click(object sender,EventArgs e) {
			if(EClipboardSheetDefCur.SheetDefNum!=0) {//Sheets
				FrmSheetPicker frmSheetPicker=new FrmSheetPicker();
				List<SheetDef> listSheetDefs=new List<SheetDef>();
				listSheetDefs.AddRange(SheetDefs.GetCustomForType(SheetTypeEnum.PatientForm));
				listSheetDefs.AddRange(SheetDefs.GetCustomForType(SheetTypeEnum.MedicalHistory));
				listSheetDefs.AddRange(SheetDefs.GetCustomForType(SheetTypeEnum.Consent));
				//Clear any custom sheet defs that don't have a mobile layout
				listSheetDefs.RemoveAll(x => !x.HasMobileLayout);
				for(int i = 0;i<ListEClipboardSheetDefs.Count;i++) {
					//Remove any current sheets in use from the list of sheet defs available to add.
					EClipboardSheetDef eClipboardSheetDef2=ListEClipboardSheetDefs[i];
					if(eClipboardSheetDef2.SheetDefNum==0 || eClipboardSheetDef2 is null) {//If SheetDefNum==0, this is an eForm.
						continue;
					}
					if(listSheetDefs.Select(x => x.SheetDefNum).Contains(eClipboardSheetDef2.SheetDefNum)) {
						listSheetDefs.RemoveAll(x => x.SheetDefNum==eClipboardSheetDef2.SheetDefNum);
					}
				}
				frmSheetPicker.ListSheetDefs=listSheetDefs;
				frmSheetPicker.ShowDialog();
				if(!frmSheetPicker.IsDialogOK) {
					return;
				}
				List<SheetDef> listSheetDefsSelected=frmSheetPicker.ListSheetDefsSelected;
				long sheetDefNum=listSheetDefsSelected[0].SheetDefNum;//listSheetDefsSelected can only contain 1 SheetDef since frmSheetPicker.MultiSelect is not set to true.
				EClipboardSheetDefCur.SheetDefNum=sheetDefNum;
				_listSheetDefs=new List<SheetDef>();//clear sheets to ignore if they change the sheet.
				textSheet.Text=SheetDefs.GetDescription(EClipboardSheetDefCur.SheetDefNum);
				listSheetsToIgnore.Items.Clear();
			}
			else {//eForms
				FrmEFormPicker frmEFormPicker=new FrmEFormPicker();
				frmEFormPicker.ShowDialog();
				if(!frmEFormPicker.IsDialogOK) {
					return;
				}
				EFormDef eFormDef=frmEFormPicker.EFormDefSelected;
				EClipboardSheetDefCur.EFormDefNum=eFormDef.EFormDefNum;
				textSheet.Text=eFormDef.Description;
			}
		}*/

		private void butDelete_Click(object sender,EventArgs e) {
			IsDeleted=true;
			if(EClipboardSheetDefCur.IsNew){//Set to DialogResult.Cancel if IsNew and user clicked Delete.
				DialogResult=DialogResult.Cancel;
				return;
			}
			DialogResult=DialogResult.OK;
		}

		private void butSave_Click(object sender,EventArgs e) {
			if(radioFreqTimeSpan.Checked){
				if(!textVIntYears.IsValid()
					|| !textVIntMonths.IsValid()
					|| !textVIntDays.IsValid())
				{
					MsgBox.Show("Please fix entry errors first.");
					return;
				}
				int numYears=textVIntYears.Value;
				int numMonths=textVIntMonths.Value;
				int numDays=textVIntDays.Value;
				if(numYears+(numMonths/12)+(numDays/365)>29000){//29000 years is the max value for TimeSpan. Shouldn't actually happen.
					MsgBox.Show("Time span must be less than 29,000 years.");
					return;
				}
				if(numYears==0 && numMonths==0 && numDays==0){
					MsgBox.Show("Time span must be greater than 0 days.");
					return;
				}
			}
			bool isMinAgeBlank=textMinAge.Text.IsNullOrEmpty();
			int minAge=-1;
			if(!isMinAgeBlank && !int.TryParse(textMinAge.Text,out minAge)) {
				MsgBox.Show(this,"The minimum age must be a valid whole number.");
				return;
			}
			if(!isMinAgeBlank && minAge<1) {
				MsgBox.Show(this,"The minimum age must be greater than 0.");
				return;
			}
			bool isMaxAgeBlank=textMaxAge.Text.IsNullOrEmpty();
			int maxAge=-1;
			if(!isMaxAgeBlank && !int.TryParse(textMaxAge.Text,out maxAge)) {
				MsgBox.Show(this,"The maximum age must be a valid whole number.");
				return;
			}
			if(!isMaxAgeBlank && maxAge<1) {
				MsgBox.Show(this,"The maximum age must be greater than 0.");
				return;
			}
			if(!isMaxAgeBlank && !isMinAgeBlank && maxAge<minAge) {
				MsgBox.Show(this,"The maximum age must be greater than the minimum age.");
				return;
			}
			//End Validation
			if(radioBehaviorNew.Checked){
				EClipboardSheetDefCur.PrefillStatus=PrefillStatuses.New;
			}
			else if(radioBehaviorPreFill.Checked){
				EClipboardSheetDefCur.PrefillStatus=PrefillStatuses.PreFill;
			}
			if(radioFreqOnce.Checked){
				EClipboardSheetDefCur.Frequency=EnumEClipFreq.Once;
				EClipboardSheetDefCur.ResubmitInterval=TimeSpan.Zero;
			}
			else if(radioFreqEachTime.Checked){
				EClipboardSheetDefCur.Frequency=EnumEClipFreq.EachTime;
				EClipboardSheetDefCur.ResubmitInterval=TimeSpan.Zero;
			}
			else if(radioFreqTimeSpan.Checked){
				EClipboardSheetDefCur.Frequency=EnumEClipFreq.TimeSpan;
				Interval interval=new Interval();
				interval.Years=textVIntYears.Value;
				interval.Months=textVIntMonths.Value;
				interval.Days=textVIntDays.Value;
				TimeSpan timeSpan=interval.ToTimeSpan();
				EClipboardSheetDefCur.ResubmitInterval=timeSpan;
			}
			if(EClipboardSheetDefCur.SheetDefNum!=0){
				EClipboardSheetDefCur.IgnoreSheetDefNums=string.Join(",",_listSheetDefs.Select(x => POut.Long(x.SheetDefNum)));
			}
			EClipboardSheetDefCur.MinAge=minAge;
			EClipboardSheetDefCur.MaxAge=maxAge;
			//EClipboardSheetDefs.Update(_eSheet);
			DialogResult=DialogResult.OK;
		}

	}
}