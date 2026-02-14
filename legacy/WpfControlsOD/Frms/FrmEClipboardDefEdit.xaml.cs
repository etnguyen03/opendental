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
using CodeBase;

namespace OpenDental {
	///<summary>Used with FormEClipboardDefs to modify Definitions specifically for the eClipboard. Only Definitions with Category=53 should be used with this frm.</summary>
	public partial class FrmEClipboardDefEdit:FrmODBase {
		///<summary>The current def that is being modified. Set before opening.</summary>
		public Def DefCur;
		///<summary>List of EClipboardImageCaptureDefs. Needed for testing if a Def is already assigned to an eClipboardImageCaptureDef but not yet saved to the db.</summary>
		public List<EClipboardImageCaptureDef> ListEClipboardImageCaptureDefs;

		public FrmEClipboardDefEdit() {
			InitializeComponent();
			Load+=FrmEClipboardDefEdit_Load;
		}

		private void FrmEClipboardDefEdit_Load(object sender, EventArgs e) {
			Lang.F(this);
			textName.Text=Defs.GetName(DefCat.EClipboardImageCapture,DefCur.DefNum);
			textPatInstructions.Text=Defs.GetValue(DefCat.EClipboardImageCapture,DefCur.DefNum);
		}

		private void butDelete_Click(object sender, EventArgs e) {
			if(DefCur.IsNew){
				IsDialogCancel=true;
				return;
			}
			bool isDefInUse=ListEClipboardImageCaptureDefs.Any(x => x.DefNum==DefCur.DefNum);//checks local changes.
			if(isDefInUse){//This is needed because a user may add this def to an eClipboardImageCaptureDef, but come back into this window without saving in FormEServicesEClipboard.
				MsgBox.Show(this, "Cannot delete this Definition as it's in use by the eClipboard.");
				return;
			}
			try{
				Defs.Delete(DefCur);//This will throw exceptions if there's any eClipboardImageCaptureDefs or eClipboardImageCaptures using this DefNum in db.
			}
			catch(Exception ex){
				ex.DoNothing();
				MsgBox.Show(this, "Cannot delete this Definition as it's in use by the eClipboard.");
				return;
			}
			IsDialogOK=true;
			return;
		}

		private void butSave_Click(object sender, EventArgs e) {
			if(textName.Text.IsNullOrEmpty()
				|| textPatInstructions.Text.IsNullOrEmpty())
			{
				MsgBox.Show(this, "Name and Patient Instructions may not be left empty.");
				return;
			}
			DefCur.ItemName=textName.Text;
			DefCur.ItemValue=textPatInstructions.Text;
			if(DefCur.IsNew){//Insert
				string logText=Lang.g("Defintions","Definition created:")+" "+DefCur.ItemName+" "
					+Lang.g("Defintions","with category:")+" "+DefCur.Category.GetDescription();
				SecurityLogs.MakeLogEntry(EnumPermType.DefEdit,0,logText);
				Defs.Insert(DefCur);
			}
			else{//Update
				string logText=Lang.g("Defintions","Definition edited:")+" "+DefCur.ItemName+" "
					+Lang.g("Defintions","with category:")+" "+DefCur.Category.GetDescription();
				SecurityLogs.MakeLogEntry(EnumPermType.DefEdit,0,logText);
				Defs.Update(DefCur);
			}
			IsDialogOK=true;
		}

	}
}