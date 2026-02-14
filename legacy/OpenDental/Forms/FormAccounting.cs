using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using OpenDental.UI;
using OpenDentBusiness;
using CodeBase;
using System.Collections.Generic;
using OpenDental.Thinfinity;
using System.Linq;

namespace OpenDental{
	/// <summary>By default, shows all active accounts. Can be found at Manage->Accounting.</summary>
	public partial class FormAccounting:FormODBase {
		//private Account[] AccountList;
		private DataTable _tableAccounts;

		///<summary></summary>
		public FormAccounting()
		{
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
		}

		private void FormAccounting_Load(object sender,EventArgs e) {
			System.Windows.Forms.Screen screen=System.Windows.Forms.Screen.FromControl(this);//automatically returns screen that contains largest portion of this form
			Height=screen.WorkingArea.Height;
			Top=screen.WorkingArea.Top;
			LayoutMenu();
			LayoutToolBar();
			textDate.Text=DateTime.Today.ToShortDateString();
			FillGrid();
		}

		private void LayoutMenu() {
			menuMain.BeginUpdate();
			//Setup-----------------------------------------------------------------------------------------------------------
			MenuItemOD menuItemSetup=new MenuItemOD("Setup");
			menuMain.Add(menuItemSetup);
			menuItemSetup.Add("Open Dental", menuItemOpenDental_Click);
			if(!ODEnvironment.IsCloudInstance) {
				menuItemSetup.Add("QuickBooks", menuItemQuickBooks_Click);
			}
			menuItemSetup.Add("QuickBooks Online", menuItemQuickBooksOnline_Click);
			//Lock-----------------------------------------------------------------------------------------------------------
			menuMain.Add(new MenuItemOD("Lock",menuItemLock_Click));
			//Reports--------------------------------------------------------------------------------------------------------
			MenuItemOD menuItemReports=new MenuItemOD("Reports");
			menuMain.Add(menuItemReports);
			menuItemReports.Add("General Ledger Detail",menuItemGL_Click);
			menuItemReports.Add("Balance Sheet",menuItemBalSheet_Click);
			menuItemReports.Add("Profit and Loss",menuItemProfitLoss_Click);
			menuMain.EndUpdate();
		}

		private void menuItemOpenDental_Click(Object sender, EventArgs e) {
			using FormAccountingSetup formAccountingSetup=new FormAccountingSetup();
			formAccountingSetup.ShowDialog();
		}

		private void menuItemQuickBooks_Click(Object sender, EventArgs e) {
			using FormQuickBooksSetup formQuickBooksSetup=new FormQuickBooksSetup();
			formQuickBooksSetup.ShowDialog();
		}

		private void menuItemQuickBooksOnline_Click(Object sender, EventArgs e) {
			if(!Programs.IsEnabled(ProgramName.QuickBooksOnline)) {
				MsgBox.Show(this,"QuickBooks Online must be enabled in Program Links first.");
				return;
			}
			using FormQuickBooksOnlineSetup formQuickBooksOnlineSetup=new FormQuickBooksOnlineSetup();
			formQuickBooksOnlineSetup.ShowDialog();
		}

		///<summary>Causes the toolbar to be laid out again.</summary>
		public void LayoutToolBar() {
			ToolBarMain.Buttons.Clear();
			ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Add"),EnumIcons.Add,"","Add"));
			ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Edit"),1,Lan.g(this,"Edit Selected Account"),"Edit"));
			ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Export .txt"),2,Lan.g(this,"Export the Chart of Accounts as a tab delimited .txt file"),"Export .txt"));
			ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Export .csv"),2,Lan.g(this,"Export the Chart of Accounts as a comma delimited .csv file"),"Export .csv"));
		}
		private void menuItemLock_Click(object sender,EventArgs e) {
			if(!Security.IsAuthorized(EnumPermType.SecurityAdmin)) {
				return;
			}
			FrmAccountingLock frmAccountingLock=new FrmAccountingLock();
			frmAccountingLock.ShowDialog();
			if(frmAccountingLock.IsDialogOK==true){
				SecurityLogs.MakeLogEntry(EnumPermType.SecurityAdmin,0,"Accounting Lock Changed");
			}
		}

		private void menuItemGL_Click(object sender,EventArgs e) {
			using FormRpAccountingGenLedg formRpAccountingGenLedg=new FormRpAccountingGenLedg();
			formRpAccountingGenLedg.ShowDialog();
		}

		private void menuItemBalSheet_Click(object sender,EventArgs e) {
			using FormRpAccountingBalanceSheet formRpAccountingBalanceSheet=new FormRpAccountingBalanceSheet();
			formRpAccountingBalanceSheet.ShowDialog();
		}

		private void menuItemProfitLoss_Click(object sender, EventArgs e){
			using FormRpAccountingProfitLoss formRpAccountingProfitLoss=new FormRpAccountingProfitLoss();
			formRpAccountingProfitLoss.ShowDialog();
		}
		
		private void ToolBarMain_ButtonClick(object sender,OpenDental.UI.ODToolBarButtonClickEventArgs e) {
			switch(e.Button.Tag.ToString()) {
				case "Add":
					Add_Click();
					break;
				case "Edit":
					Edit_Click();
					break;
				case "Export .txt":
					Export_Click("\t");
					break;
				case "Export .csv":
					Export_Click(",");
					break;
			}
		}

		private void FillGrid(){
			Accounts.RefreshCache();
			gridMain.BeginUpdate();
			gridMain.Columns.Clear();
			GridColumn col=new GridColumn(Lan.g("TableChartOfAccounts","Type"),70);
			gridMain.Columns.Add(col);
			col=new GridColumn(Lan.g("TableChartOfAccounts","Description"),170);
			gridMain.Columns.Add(col);
			col=new GridColumn(Lan.g("TableChartOfAccounts","Balance"),80,HorizontalAlignment.Right);
			gridMain.Columns.Add(col);
			col=new GridColumn(Lan.g("TableChartOfAccounts","Bank Number"),100);
			gridMain.Columns.Add(col);
			col=new GridColumn(Lan.g("TableChartOfAccounts","Inactive"),70,HorizontalAlignment.Center);
			gridMain.Columns.Add(col);
			gridMain.ListGridRows.Clear();
			GridRow row;
			if(!textDate.IsValid()){//error
				_tableAccounts=Accounts.GetFullList(DateTime.Today,checkInactive.Checked);
			}
			else{
				_tableAccounts=Accounts.GetFullList(PIn.Date(textDate.Text),checkInactive.Checked);
			}
			for(int i=0;i<_tableAccounts.Rows.Count;i++){
				row=new GridRow();
				row.Cells.Add(_tableAccounts.Rows[i]["type"].ToString());
				row.Cells.Add(_tableAccounts.Rows[i]["Description"].ToString());
				row.Cells.Add(_tableAccounts.Rows[i]["balance"].ToString());
				row.Cells.Add(_tableAccounts.Rows[i]["BankNumber"].ToString());
				row.Cells.Add(_tableAccounts.Rows[i]["inactive"].ToString());				
				if(i<_tableAccounts.Rows.Count-1//if not the last row
					&& _tableAccounts.Rows[i]["type"].ToString() != _tableAccounts.Rows[i+1]["type"].ToString())
				{
					row.ColorLborder=Color.Black;
				}
				row.ColorBackG=Color.FromArgb(PIn.Int(_tableAccounts.Rows[i]["color"].ToString()));
				gridMain.ListGridRows.Add(row);
			}
			gridMain.EndUpdate();
		}

		private void Add_Click() {
			Account account=new Account();
			account.AcctType=AccountType.Asset;
			account.AccountColor=Color.White;
			FrmAccountEdit frmAccountEdit=new FrmAccountEdit(account);
			frmAccountEdit.IsNew=true;
			frmAccountEdit.ShowDialog();
			FillGrid();
		}

		private void Edit_Click() {
			if(gridMain.GetSelectedIndex()==-1){
				MsgBox.Show(this,"Please pick an account first.");
				return;
			}
			long accountNum=PIn.Long(_tableAccounts.Rows[gridMain.GetSelectedIndex()]["AccountNum"].ToString());
			if(accountNum==0) {
				MsgBox.Show(this,"This account is generated automatically, and cannot be edited.");
				return;
			}
			Account account=Accounts.GetAccount(accountNum);
			FrmAccountEdit frmAccountEdit=new FrmAccountEdit(account);
			frmAccountEdit.ShowDialog();
			//FrmAccountEdit frmAccountEdit=new FrmAccountEdit(account);
			//frmAccountEdit.ShowDialog();
			FillGrid();
			for(int i=0;i<_tableAccounts.Rows.Count;i++){
				if(_tableAccounts.Rows[i]["AccountNum"].ToString()==accountNum.ToString()){
					gridMain.SetSelected(i,true);
				}
			}
		}

		///<summary>Takes in either a comma or tab delimiter to determine if the export should be .csv or .txt. Passing in a comma is for .csv and passing in a tab is for .txt.</summary>
		private void Export_Click(string delimiter) {
			if(gridMain.ListGridRows.Count==0) {
				MessageBox.Show(Lan.g(this,"Nothing to export"));
				return;
			}
			string filePath;
			if(!ODBuild.IsThinfinity() && ODCloudClient.IsAppStream) {
				filePath=ODFileUtils.CombinePaths(Path.GetTempPath(),"ODAccountExport.xls");
			}
			else {
				saveFileDialog=new SaveFileDialog();
				saveFileDialog.AddExtension=true;
				saveFileDialog.FilterIndex=0;
				if(delimiter=="\t") {
					saveFileDialog.Filter="Text files(*.txt)|*.txt|All files(*.*)|*.*";
				}
				else {
					saveFileDialog.Filter="CSV files(*.csv)|*.csv|All files(*.*)|*.*";
				}
				saveFileDialog.FileName=gridMain.Title;
				if(ODEnvironment.IsCloudServer) {
					if(saveFileDialog.ShowDialog()!=DialogResult.OK) { 
						return;
					}
					if(saveFileDialog.FileName.IsNullOrEmpty()) {
						MsgBox.Show("Failed to save the file.");
						return;
					}
					filePath=ODFileUtils.CombinePaths(Path.GetTempPath(),saveFileDialog.FileName.Split('\\').Last());
				}
				else {
					Cursor=Cursors.WaitCursor;//Checking the directory can take time, so set cursor to loading wheel
					if(!Directory.Exists(PrefC.GetString(PrefName.ExportPath))) {
						try {
							Directory.CreateDirectory(PrefC.GetString(PrefName.ExportPath));
							saveFileDialog.InitialDirectory=PrefC.GetString(PrefName.ExportPath);
						}
						catch {
							//initialDirectory will be blank
						}
					}
					else{
						saveFileDialog.InitialDirectory=PrefC.GetString(PrefName.ExportPath);
					}
					Cursor=Cursors.Default;
					if(saveFileDialog.ShowDialog()!=DialogResult.OK) {
						saveFileDialog.Dispose();
						return;
					}
					filePath=saveFileDialog.FileName;
					saveFileDialog.Dispose();
				}
			}
			StreamWriter streamWriter=null;
			try {
				streamWriter=new StreamWriter(filePath,false);
			}
			catch {
				MessageBox.Show(Lan.g(this,"File in use by another program.  Close and try again."));
				return;
			}
			String line="";
			for(int i=0;i<gridMain.Columns.Count;i++) {
				string columnCaption=gridMain.Columns[i].Heading;
				//Check for columns that start with special characters that spreadsheet programs treat differently than simply displaying them.
				if(columnCaption.StartsWith("-") || columnCaption.StartsWith("=")) {
					//Adding a space to the beginning of the cell will trick the spreadsheet program into not treating it uniquely.
					columnCaption=" "+columnCaption;
				}
				line+=columnCaption;
				if(i<gridMain.Columns.Count-1) {
					line+=delimiter;
				}
			}
			try {
				streamWriter.WriteLine(line);
			}
			catch {
				MessageBox.Show(Lan.g(this,"File in use by another program.  Close and try again."));
				return;
			}
			string cell;
			for(int i=0;i<gridMain.ListGridRows.Count;i++) {
				line="";
				for(int j=0;j<gridMain.Columns.Count;j++) {
					cell=gridMain.ListGridRows[i].Cells[j].Text;
					cell=cell.Replace("\r","");
					cell=cell.Replace("\n","");
					cell=cell.Replace("\t","");
					cell=cell.Replace("\"","");
					if(delimiter=="," && cell.Contains(",")) {
						cell='"'+cell+'"';//Surround with quotes so Excel does not split into two cells
					}
					line+=cell;
					if(j<gridMain.Columns.Count-1) {
						line+=delimiter;
					}
				}
				try {
					streamWriter.WriteLine(line);
				}
				catch {
					MessageBox.Show(Lan.g(this,"File in use by another program.  Close and try again."));
					return;
				}
			}
			streamWriter.Close();
			streamWriter.Dispose();
			if(ODBuild.IsThinfinity()) {
				ThinfinityUtils.ExportForDownload(filePath);
			}
			else if(ODCloudClient.IsAppStream) {
				CloudClientL.ExportForCloud(filePath);
			}
			else {
				MessageBox.Show(Lan.g(this,"File created successfully"));
			}
		}

		private void gridMain_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			long accountNum=PIn.Long(_tableAccounts.Rows[e.Row]["AccountNum"].ToString());
			if(accountNum==0) {
				MsgBox.Show(this,"This account is generated automatically, and there is currently no way to view the detail.  It is the sum of all income minus all expenses for all previous years.");
				return;
			}
			DateTime asofDate; 
			if(!textDate.IsValid()) {//error
				asofDate=DateTime.Today;
			}
			else{
				asofDate=PIn.Date(textDate.Text);
			}
			Account account=Accounts.GetAccount(accountNum);
			using FormJournal formJournal=new FormJournal(account);
			formJournal.DateInitialAsOf=asofDate;
			formJournal.ShowDialog();
			FillGrid();
			for(int i=0;i<_tableAccounts.Rows.Count;i++) {
				if(_tableAccounts.Rows[i]["AccountNum"].ToString()==accountNum.ToString()) {
					gridMain.SetSelected(i,true);
				}
			}
		}

		private void checkInactive_Click(object sender,EventArgs e) {
			FillGrid();
		}

		private void butRefresh_Click(object sender,EventArgs e) {
			FillGrid();
		}

		private void butToday_Click(object sender,EventArgs e) {
			textDate.Text=DateTime.Today.ToShortDateString();
			FillGrid();
		}
	}
}





















