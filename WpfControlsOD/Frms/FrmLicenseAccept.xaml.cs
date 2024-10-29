using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenDentBusiness;
using WpfControls.UI;

namespace OpenDental {
	///<summary>A window for viewing and accepting a license. Includes creation of security log for audit trail purposes after license is accepted.</summary>
	public partial class FrmLicenseAccept : FrmODBase {
		private string _licenseContent;
		private string _licenseTitle;

		///<summary>Requires license content to be displayed and license title for security log entry.</summary>
		public FrmLicenseAccept(string licenseContent, string licenseTitle) {
			_licenseContent=licenseContent;
			_licenseTitle=licenseTitle;
			InitializeComponent();
			Load+=Frm_Load;
		}

		private void Frm_Load(object sender, EventArgs e) {
			Lang.F(this);
			textLicenseContent.Text=_licenseContent;
		}

		private void butAccept_Click(object sender, EventArgs e) {
			SecurityLogs.MakeLogEntry(EnumPermType.LicenseAccept, 0, _licenseTitle+" accepted by "+Security.CurUser.UserName);
			IsDialogOK=true;
		}
	}
}