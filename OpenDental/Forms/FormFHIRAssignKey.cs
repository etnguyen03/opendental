using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using CodeBase;
using OpenDental.UI;
using OpenDentBusiness;
using WebServiceSerializer;

namespace OpenDental {
	public partial class FormFHIRAssignKey:FormODBase {

		public FormFHIRAssignKey() {
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
		}

		private void ButOK_Click(object sender,EventArgs e) {
			if(textKey.Text=="") {
				MsgBox.Show(this,"Please enter an API key.");
				return;
			}
			//Display license and require acceptance or kick out if user declines
			FrmLicenseAccept frmLicenseAccept=new FrmLicenseAccept(Properties.Resources.OpenDentalApiEndUserLicense, "Open Dental API End User License");
			if(!frmLicenseAccept.ShowDialog()) {
				MsgBox.Show(this, "You must accept the terms to add an API key.");
				return;
			}
			string officeData=PayloadHelper.CreatePayload(PayloadHelper.CreatePayloadContent(textKey.Text,"APIKey"),eServiceCode.FHIR);
			string result;
			Cursor=Cursors.WaitCursor;
			try {
				result=WebServiceMainHQProxy.GetWebServiceMainHQInstance().AssignFHIRAPIKey(officeData);
				PayloadHelper.CheckForError(result);
			}
			catch(Exception ex) {
				MsgBox.Show(ex.Message);
				Cursor=Cursors.Default;
				return;
			}
			SecurityLogs.MakeLogEntry(EnumPermType.Setup, 0, "New API key "+textKey.Text+" added by "+Security.CurUser.UserName);
			string message=WebSerializer.DeserializeTag<string>(result,"Response");
			MsgBox.Show(this,message);
			DialogResult=DialogResult.OK;
		}

	}
}