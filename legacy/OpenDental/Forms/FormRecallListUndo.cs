using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;

namespace OpenDental {
	public partial class FormRecallListUndo:FormODBase {
		public FormRecallListUndo() {
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
		}

		private void FormRecallListUndo_Load(object sender,EventArgs e) {
			odDatePicker.SetDateTime(DateTime.Today);
		}

		private void odDatePicker_DateTextChanged(object sender,EventArgs e) {
			DateTime date=odDatePicker.GetDateTime();
			if(date!=DateTime.MinValue) {
				int count=Commlogs.GetRecallUndoCount(date);
				labelCount.Text=count.ToString();
				return;
			}
			labelCount.Text="";
		}

		private void butOK_Click(object sender,EventArgs e) {
			if(!Security.IsAuthorized(EnumPermType.SecurityAdmin)) {
				return;
			}
			DateTime date=odDatePicker.GetDateTime();
			if(date==DateTime.MinValue) {
				MsgBox.Show(this,"Invalid date");
				return;
			}
			if(date < DateTime.Today.AddDays(-7)){
				if(!MsgBox.Show(this,MsgBoxButtons.OKCancel,"Date is from more than one week ago.  Continue anyway?")){
					return;
				}
			}
			if(MessageBox.Show("Delete all "+labelCount.Text+" commlog entries?","",MessageBoxButtons.OKCancel)!=DialogResult.OK) {
				return;
			}
			Commlogs.RecallUndo(date);
			SecurityLogs.MakeLogEntry(EnumPermType.CommlogEdit,0,"Recall list undo tool ran");
			MsgBox.Show(this,"Done");
			DialogResult=DialogResult.OK;
		}

	}
}