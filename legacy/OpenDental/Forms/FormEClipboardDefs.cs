using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CodeBase;
using OpenDental.UI;
using OpenDentBusiness;

namespace OpenDental {
	public partial class FormEClipboardDefs:FormODBase {
		///<summary>List of EClipboardImageCaptureDefs. Needed for testing if a Def is already assigned to an eClipboardImageCaptureDef in this form's child window: FrmEClipboardDefEdit</summary>
		public List<EClipboardImageCaptureDef> ListEClipboardImageCaptureDefs;
		///<summary>We don't fire off a signal to update the Def cache on other computers until we close this window. Keeps track of whether there are any new or modified Defs.</summary>
		private bool _isChangedDefCache;

		public FormEClipboardDefs() {
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
		}

		private void FormEClipboardDefs_Load(object sender,EventArgs e) {
			if(!PrefC.HasClinicsEnabled){
				labelWarning.Visible=false;
			}
			FillGrid();
		}

		///<summary>Fills grid on this form with Defs.</summary>
		private void FillGrid() {
			//Get all 'EClipboardImageCapture' defcat definitions. These are the images that patients may be prompted to submit when checking in via eClipboard.
			List<Def> listDefs=Defs.GetDefsForCategory(DefCat.EClipboardImageCapture);
			gridDefs.BeginUpdate();
			gridDefs.Columns.Clear();
			GridColumn col;
			col=new GridColumn(Lan.g(this,"Name"),120);
			gridDefs.Columns.Add(col);
			col=new GridColumn(Lan.g(this,"Patient Instructions"),240);
			gridDefs.Columns.Add(col);
			gridDefs.ListGridRows.Clear();
			GridRow row;
			for(int i = 0;i<listDefs.Count;i++) {
				Def def=listDefs[i];
				row=new GridRow();
				row.Cells.Add(def.ItemName);
				row.Cells.Add(def.ItemValue);
				row.Tag=def;
				gridDefs.ListGridRows.Add(row);
			}
			gridDefs.EndUpdate();
		}

		private void butAdd_Click(object sender,EventArgs e) {
			Def def=new Def();
			def.Category=DefCat.EClipboardImageCapture;
			def.IsNew=true;
			def.ItemOrder=Defs.GetDefsForCategory(DefCat.EClipboardImageCapture).Count();
			FrmEClipboardDefEdit frmEClipboardDefEdit=new FrmEClipboardDefEdit();
			frmEClipboardDefEdit.DefCur=def;
			frmEClipboardDefEdit.ShowDialog();
			if(!frmEClipboardDefEdit.IsDialogOK){
				return;
			}
			_isChangedDefCache|=true;
			Defs.RefreshCache();
			FillGrid();
		}

		private void gridDefinitions_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			Def def=(Def)gridDefs.ListGridRows[e.Row].Tag;
			FrmEClipboardDefEdit frmEClipboardDefEdit=new FrmEClipboardDefEdit();
			frmEClipboardDefEdit.DefCur=def;
			frmEClipboardDefEdit.ListEClipboardImageCaptureDefs=ListEClipboardImageCaptureDefs;
			frmEClipboardDefEdit.ShowDialog();
			if(!frmEClipboardDefEdit.IsDialogOK){
				return;
			}
			_isChangedDefCache|=true;
			Defs.RefreshCache();
			FillGrid();
		}

		private void FormEClipboardDefs_FormClosed(object sender,FormClosedEventArgs e) {
			if(_isChangedDefCache){
				DataValid.SetInvalid(InvalidType.Defs);
			}
		}

	}
}