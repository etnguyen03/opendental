using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using CodeBase;
using OpenDentBusiness;
using static OpenDentBusiness.SheetFieldsAvailable;

namespace OpenDental {
	public partial class FormEClipboardImageCaptureDefEdit : FormODBase {
		///<summary>The eClipboardImageCaptureDef we are currently editing </summary>
		public EClipboardImageCaptureDef EClipboardImageCaptureDefCur;
		///<summary>List of all eClipboardImageCaptureDefs. Only needed to check if the selected EnumOCRCaptureType in listOCRCaptureType is already in use by a different eClipboardImageCaptureDef.</summary>
		public List<EClipboardImageCaptureDef> ListEClipboardImageCaptureDefs;
		///<summary>Gets set to true if an eClipboardImageCaptureDef has been marked for deletion. Deletion occurs in parent form.</summary>
		public bool IsDeleted=false;

		public FormEClipboardImageCaptureDefEdit(){
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
		}

		private void FormEClipboardImageCaptureDefEdit_Load(object sender,EventArgs e) {
			checkSelfPortrait.Checked=EClipboardImageCaptureDefCur.IsSelfPortrait;
			SetVisibilities();
			List<Def> listDefs=Defs.GetDefsForCategory(DefCat.EClipboardImageCapture);
			listDefinition.Items.AddList(listDefs,x=>x.ItemName);
			listDefinition.SetSelectedKey<Def>(EClipboardImageCaptureDefCur.DefNum,x=>x.DefNum,x=>Defs.GetName(DefCat.EClipboardImageCapture,x));
			textInstructions.Text=Defs.GetValue(DefCat.EClipboardImageCapture,EClipboardImageCaptureDefCur.DefNum);
			//groupFrequency start
			radioFreqOnce.Checked=EClipboardImageCaptureDefCur.Frequency==EnumEClipFreq.Once;
			radioFreqEachTime.Checked=EClipboardImageCaptureDefCur.Frequency==EnumEClipFreq.EachTime;
			radioFreqTimeSpan.Checked=EClipboardImageCaptureDefCur.Frequency==EnumEClipFreq.TimeSpan;
			Interval interval=new Interval(EClipboardImageCaptureDefCur.ResubmitInterval);
			textVIntYears.Text=interval.Years.ToString();
			textVIntMonths.Text=interval.Months.ToString();
			textVIntDays.Text=interval.Days.ToString();
			//groupFrequency end
			listOCRCaptureType.Items.AddEnums<EnumOcrCaptureType>();
			listOCRCaptureType.SetSelectedEnum(EClipboardImageCaptureDefCur.OcrCaptureType);
		}

		private void radioFreq_CheckedChanged(object sender,EventArgs e){
			labelYears.Visible=radioFreqTimeSpan.Checked;
			labelMonths.Visible=radioFreqTimeSpan.Checked;
			labelDays.Visible=radioFreqTimeSpan.Checked;
			textVIntYears.Visible=radioFreqTimeSpan.Checked;
			textVIntMonths.Visible=radioFreqTimeSpan.Checked;
			textVIntDays.Visible=radioFreqTimeSpan.Checked;
			labelTimeSpanHelp.Visible=radioFreqTimeSpan.Checked;
		}

		private void listDefinition_SelectionChangeCommitted(object sender,EventArgs e) {
			long defNum=listDefinition.GetSelectedKey<Def>(x=>x.DefNum);
			if(defNum<=0){
				textInstructions.Text="";
				return;
			}
			textInstructions.Text=Defs.GetValue(DefCat.EClipboardImageCapture,defNum);
		}

		private void checkSelfPortrait_Click(object sender,EventArgs e) {
			SetVisibilities();
		}

		private void SetVisibilities(){
			if(checkSelfPortrait.Checked){
				listDefinition.Visible=false;
				labelDefinition.Visible=false;
				textInstructions.Visible=false;
				labelInstructions.Visible=false;
			}
			else{
				listDefinition.Visible=true;
				labelDefinition.Visible=true;
				textInstructions.Visible=true;
				labelInstructions.Visible=true;
			}
		}

		private void butDefinitions_Click(object sender,EventArgs e) {
			long defNumSelected=listDefinition.GetSelectedKey<Def>(x=>x.DefNum);
			using FormEClipboardDefs formEClipboardDefs=new FormEClipboardDefs();
			formEClipboardDefs.ListEClipboardImageCaptureDefs=ListEClipboardImageCaptureDefs;
			formEClipboardDefs.ShowDialog();
			//DialogResult will always be Cancel. 
			//Changes to Defs are always saved within that form.
			listDefinition.Items.Clear();
			List<Def> listDefs=Defs.GetDefsForCategory(DefCat.EClipboardImageCapture);
			listDefinition.Items.AddList(listDefs,x=>x.ItemName);
			listDefinition.SetSelectedKey<Def>(defNumSelected,x=>x.DefNum,x=>Defs.GetName(DefCat.EClipboardImageCapture,x));
			textInstructions.Text=Defs.GetValue(DefCat.EClipboardImageCapture,defNumSelected);
		}

		private void butDelete_Click(object sender,EventArgs e) {
			IsDeleted=true;
			if(EClipboardImageCaptureDefCur.IsNew){//Set to DialogResult.Cancel if IsNew and user clicked Delete.
				DialogResult=DialogResult.Cancel;
				return;
			}
			DialogResult=DialogResult.OK;
		}

		private void butSave_Click(object sender,EventArgs e) {
			//start validation.
			if(!checkSelfPortrait.Checked //not using self portrait
				&& listDefinition.SelectedIndex==-1)//no selected def
			{
				MsgBox.Show(Lan.g(this, "eClipboard Image Capture must either have a Definition selected or Is Self-Portrait checked."));
				return;
			}
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
				if((numYears*365)+(numMonths*30)+numDays>36500) {//36500 days (100 years) is well below the max value for TimeSpan of 29247 years.
					MsgBox.Show("Time span must be less than 100 years.");
					return;
				}
				if(numYears==0 && numMonths==0 && numDays==0){
					MsgBox.Show("Time span must be greater than 0 days.");
					return;
				}
			}
			//make sure selected enum from listOCRCaptureType isn't already in use by a different eClipboardImageCaptureDef for this clinic.
			EnumOcrCaptureType enumOcrCaptureTypeSelected=listOCRCaptureType.GetSelected<EnumOcrCaptureType>();
			if(enumOcrCaptureTypeSelected!=EnumOcrCaptureType.Miscellaneous){//EnumOcrCaptureType validation - If not a misc image, do this check.
				List<EClipboardImageCaptureDef> listEClipboardImageCaptureDefsForClinic=ListEClipboardImageCaptureDefs.FindAll(x=>
					x.ClinicNum==EClipboardImageCaptureDefCur.ClinicNum 
					&& x.OcrCaptureType==enumOcrCaptureTypeSelected
					&& x.EClipboardImageCaptureDefNum!=EClipboardImageCaptureDefCur.EClipboardImageCaptureDefNum);
				if(listEClipboardImageCaptureDefsForClinic.Count>0){
					//there is already an image capture def for this scanner type at this clinic.
					MsgBox.Show(Lan.g(this, "There is already an eClipboard Image Capture with the OCR Capture Type")+" "+enumOcrCaptureTypeSelected.GetDescription()+" "+Lan.g(this,"at this clinic."));
					return;
				}
			}
			if(checkSelfPortrait.Checked){//IsSelfPortrait validation
				List<EClipboardImageCaptureDef> listEClipboardImageCaptureDefsForClinic=ListEClipboardImageCaptureDefs.FindAll(x=>
					x.ClinicNum==EClipboardImageCaptureDefCur.ClinicNum 
					&& x.IsSelfPortrait
					&& x.EClipboardImageCaptureDefNum!=EClipboardImageCaptureDefCur.EClipboardImageCaptureDefNum);
				if(EClipboardImageCaptureDefCur.IsNew){
					//if this eClipboardImageCaptureDef is new, don't compare EClipboardImageCaptureDefNums, 
					//instead test if any eClipboardImageCaptureDef at this clinic is already assigned IsSelfPortrait.
					listEClipboardImageCaptureDefsForClinic=ListEClipboardImageCaptureDefs.FindAll(x=>
						x.ClinicNum==EClipboardImageCaptureDefCur.ClinicNum 
						&& x.IsSelfPortrait);
				}
				if(listEClipboardImageCaptureDefsForClinic.Count>0){
					//there is already an image capture def for this scanner type at this clinic.
					MsgBox.Show(Lan.g(this, "There is already an eClipboard Image Capture for Self-Portraits at this clinic."));
					return;
				}
			}
			//end validation.
			if(!checkSelfPortrait.Checked){
				EClipboardImageCaptureDefCur.DefNum=listDefinition.GetSelectedKey<Def>(x=>x.DefNum);
			}
			EClipboardImageCaptureDefCur.IsSelfPortrait=checkSelfPortrait.Checked;
			if(radioFreqOnce.Checked){
				EClipboardImageCaptureDefCur.Frequency=EnumEClipFreq.Once;
				EClipboardImageCaptureDefCur.ResubmitInterval=TimeSpan.Zero;
			}
			else if(radioFreqEachTime.Checked){
				EClipboardImageCaptureDefCur.Frequency=EnumEClipFreq.EachTime;
				EClipboardImageCaptureDefCur.ResubmitInterval=TimeSpan.Zero;
			}
			else if(radioFreqTimeSpan.Checked){
				EClipboardImageCaptureDefCur.Frequency=EnumEClipFreq.TimeSpan;
				Interval interval=new Interval();
				interval.Years=textVIntYears.Value;
				interval.Months=textVIntMonths.Value;
				interval.Days=textVIntDays.Value;
				TimeSpan timeSpan=interval.ToTimeSpan();
				EClipboardImageCaptureDefCur.ResubmitInterval=timeSpan;
			}
			EClipboardImageCaptureDefCur.OcrCaptureType=enumOcrCaptureTypeSelected;
			DialogResult=DialogResult.OK;
			//No need to update yet. That happens way later on FormEServicesEClipboard.
		}
	}
}