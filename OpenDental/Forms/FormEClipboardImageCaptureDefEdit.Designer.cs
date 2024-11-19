namespace OpenDental{
	partial class FormEClipboardImageCaptureDefEdit {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEClipboardImageCaptureDefEdit));
			this.listOCRCaptureType = new OpenDental.UI.ListBox();
			this.labelInstructions = new System.Windows.Forms.Label();
			this.textInstructions = new System.Windows.Forms.TextBox();
			this.labelDefinition = new System.Windows.Forms.Label();
			this.butDelete = new OpenDental.UI.Button();
			this.labelOCRCaptureType = new System.Windows.Forms.Label();
			this.butSave = new OpenDental.UI.Button();
			this.checkSelfPortrait = new OpenDental.UI.CheckBox();
			this.groupFrequency = new OpenDental.UI.GroupBox();
			this.labelTimeSpanHelp = new System.Windows.Forms.Label();
			this.textVIntDays = new OpenDental.ValidNum();
			this.labelDays = new System.Windows.Forms.Label();
			this.textVIntMonths = new OpenDental.ValidNum();
			this.labelMonths = new System.Windows.Forms.Label();
			this.radioFreqTimeSpan = new System.Windows.Forms.RadioButton();
			this.textVIntYears = new OpenDental.ValidNum();
			this.labelFreqHelp = new System.Windows.Forms.Label();
			this.radioFreqOnce = new System.Windows.Forms.RadioButton();
			this.labelYears = new System.Windows.Forms.Label();
			this.radioFreqEachTime = new System.Windows.Forms.RadioButton();
			this.listDefinition = new OpenDental.UI.ListBox();
			this.butDefinitions = new OpenDental.UI.Button();
			this.groupFrequency.SuspendLayout();
			this.SuspendLayout();
			// 
			// listOCRCaptureType
			// 
			this.listOCRCaptureType.Location = new System.Drawing.Point(130, 334);
			this.listOCRCaptureType.Name = "listOCRCaptureType";
			this.listOCRCaptureType.Size = new System.Drawing.Size(180, 95);
			this.listOCRCaptureType.TabIndex = 92;
			this.listOCRCaptureType.Text = "listOCRCaptureType";
			// 
			// labelInstructions
			// 
			this.labelInstructions.Location = new System.Drawing.Point(317, 6);
			this.labelInstructions.Name = "labelInstructions";
			this.labelInstructions.Size = new System.Drawing.Size(87, 20);
			this.labelInstructions.TabIndex = 91;
			this.labelInstructions.Text = "Instructions";
			this.labelInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textInstructions
			// 
			this.textInstructions.Location = new System.Drawing.Point(317, 28);
			this.textInstructions.MaxLength = 256;
			this.textInstructions.Multiline = true;
			this.textInstructions.Name = "textInstructions";
			this.textInstructions.ReadOnly = true;
			this.textInstructions.Size = new System.Drawing.Size(188, 95);
			this.textInstructions.TabIndex = 89;
			// 
			// labelDefinition
			// 
			this.labelDefinition.Location = new System.Drawing.Point(130, 6);
			this.labelDefinition.Name = "labelDefinition";
			this.labelDefinition.Size = new System.Drawing.Size(108, 20);
			this.labelDefinition.TabIndex = 82;
			this.labelDefinition.Text = "Definition";
			this.labelDefinition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// butDelete
			// 
			this.butDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butDelete.Icon = OpenDental.UI.EnumIcons.DeleteX;
			this.butDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butDelete.Location = new System.Drawing.Point(12, 463);
			this.butDelete.Name = "butDelete";
			this.butDelete.Size = new System.Drawing.Size(81, 24);
			this.butDelete.TabIndex = 81;
			this.butDelete.TabStop = false;
			this.butDelete.Text = "Delete";
			this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
			// 
			// labelOCRCaptureType
			// 
			this.labelOCRCaptureType.Location = new System.Drawing.Point(12, 332);
			this.labelOCRCaptureType.Name = "labelOCRCaptureType";
			this.labelOCRCaptureType.Size = new System.Drawing.Size(115, 20);
			this.labelOCRCaptureType.TabIndex = 7;
			this.labelOCRCaptureType.Text = "OCR Capture Type";
			this.labelOCRCaptureType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butSave
			// 
			this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butSave.Location = new System.Drawing.Point(531, 463);
			this.butSave.Name = "butSave";
			this.butSave.Size = new System.Drawing.Size(75, 24);
			this.butSave.TabIndex = 3;
			this.butSave.Text = "&Save";
			this.butSave.Click += new System.EventHandler(this.butSave_Click);
			// 
			// checkSelfPortrait
			// 
			this.checkSelfPortrait.Location = new System.Drawing.Point(130, 127);
			this.checkSelfPortrait.Name = "checkSelfPortrait";
			this.checkSelfPortrait.Size = new System.Drawing.Size(146, 20);
			this.checkSelfPortrait.TabIndex = 504;
			this.checkSelfPortrait.Text = "Is Self-Portrait";
			this.checkSelfPortrait.Click += new System.EventHandler(this.checkSelfPortrait_Click);
			// 
			// groupFrequency
			// 
			this.groupFrequency.BackColor = System.Drawing.Color.White;
			this.groupFrequency.Controls.Add(this.labelTimeSpanHelp);
			this.groupFrequency.Controls.Add(this.textVIntDays);
			this.groupFrequency.Controls.Add(this.labelDays);
			this.groupFrequency.Controls.Add(this.textVIntMonths);
			this.groupFrequency.Controls.Add(this.labelMonths);
			this.groupFrequency.Controls.Add(this.radioFreqTimeSpan);
			this.groupFrequency.Controls.Add(this.textVIntYears);
			this.groupFrequency.Controls.Add(this.labelFreqHelp);
			this.groupFrequency.Controls.Add(this.radioFreqOnce);
			this.groupFrequency.Controls.Add(this.labelYears);
			this.groupFrequency.Controls.Add(this.radioFreqEachTime);
			this.groupFrequency.Location = new System.Drawing.Point(44, 150);
			this.groupFrequency.Name = "groupFrequency";
			this.groupFrequency.Size = new System.Drawing.Size(536, 177);
			this.groupFrequency.TabIndex = 505;
			this.groupFrequency.Text = "Frequency";
			// 
			// labelTimeSpanHelp
			// 
			this.labelTimeSpanHelp.Location = new System.Drawing.Point(103, 80);
			this.labelTimeSpanHelp.Name = "labelTimeSpanHelp";
			this.labelTimeSpanHelp.Size = new System.Drawing.Size(226, 19);
			this.labelTimeSpanHelp.TabIndex = 264;
			this.labelTimeSpanHelp.Text = "Specify a custom frequency.";
			this.labelTimeSpanHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textVIntDays
			// 
			this.textVIntDays.Location = new System.Drawing.Point(86, 150);
			this.textVIntDays.MaxVal = 365;
			this.textVIntDays.Name = "textVIntDays";
			this.textVIntDays.Size = new System.Drawing.Size(51, 20);
			this.textVIntDays.TabIndex = 263;
			// 
			// labelDays
			// 
			this.labelDays.Location = new System.Drawing.Point(25, 149);
			this.labelDays.Name = "labelDays";
			this.labelDays.Size = new System.Drawing.Size(60, 20);
			this.labelDays.TabIndex = 262;
			this.labelDays.Text = "Days";
			this.labelDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textVIntMonths
			// 
			this.textVIntMonths.Location = new System.Drawing.Point(86, 126);
			this.textVIntMonths.MaxVal = 12;
			this.textVIntMonths.Name = "textVIntMonths";
			this.textVIntMonths.Size = new System.Drawing.Size(51, 20);
			this.textVIntMonths.TabIndex = 261;
			// 
			// labelMonths
			// 
			this.labelMonths.Location = new System.Drawing.Point(25, 125);
			this.labelMonths.Name = "labelMonths";
			this.labelMonths.Size = new System.Drawing.Size(60, 20);
			this.labelMonths.TabIndex = 260;
			this.labelMonths.Text = "Months";
			this.labelMonths.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// radioFreqTimeSpan
			// 
			this.radioFreqTimeSpan.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioFreqTimeSpan.Location = new System.Drawing.Point(4, 81);
			this.radioFreqTimeSpan.Name = "radioFreqTimeSpan";
			this.radioFreqTimeSpan.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioFreqTimeSpan.Size = new System.Drawing.Size(93, 18);
			this.radioFreqTimeSpan.TabIndex = 256;
			this.radioFreqTimeSpan.Text = "Time Span";
			this.radioFreqTimeSpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioFreqTimeSpan.UseVisualStyleBackColor = true;
			this.radioFreqTimeSpan.CheckedChanged += new System.EventHandler(this.radioFreq_CheckedChanged);
			// 
			// textVIntYears
			// 
			this.textVIntYears.Location = new System.Drawing.Point(86, 103);
			this.textVIntYears.Name = "textVIntYears";
			this.textVIntYears.Size = new System.Drawing.Size(51, 20);
			this.textVIntYears.TabIndex = 259;
			// 
			// labelFreqHelp
			// 
			this.labelFreqHelp.Location = new System.Drawing.Point(11, 17);
			this.labelFreqHelp.Name = "labelFreqHelp";
			this.labelFreqHelp.Size = new System.Drawing.Size(252, 19);
			this.labelFreqHelp.TabIndex = 254;
			this.labelFreqHelp.Text = "Form will be submitted by patient:";
			this.labelFreqHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radioFreqOnce
			// 
			this.radioFreqOnce.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioFreqOnce.Location = new System.Drawing.Point(4, 38);
			this.radioFreqOnce.Name = "radioFreqOnce";
			this.radioFreqOnce.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioFreqOnce.Size = new System.Drawing.Size(93, 18);
			this.radioFreqOnce.TabIndex = 252;
			this.radioFreqOnce.Text = "Once";
			this.radioFreqOnce.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioFreqOnce.UseVisualStyleBackColor = true;
			this.radioFreqOnce.CheckedChanged += new System.EventHandler(this.radioFreq_CheckedChanged);
			// 
			// labelYears
			// 
			this.labelYears.Location = new System.Drawing.Point(25, 102);
			this.labelYears.Name = "labelYears";
			this.labelYears.Size = new System.Drawing.Size(60, 20);
			this.labelYears.TabIndex = 258;
			this.labelYears.Text = "Years";
			this.labelYears.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// radioFreqEachTime
			// 
			this.radioFreqEachTime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioFreqEachTime.Location = new System.Drawing.Point(4, 59);
			this.radioFreqEachTime.Name = "radioFreqEachTime";
			this.radioFreqEachTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioFreqEachTime.Size = new System.Drawing.Size(93, 18);
			this.radioFreqEachTime.TabIndex = 251;
			this.radioFreqEachTime.Text = "Each Visit";
			this.radioFreqEachTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioFreqEachTime.UseVisualStyleBackColor = true;
			this.radioFreqEachTime.CheckedChanged += new System.EventHandler(this.radioFreq_CheckedChanged);
			// 
			// listDefinition
			// 
			this.listDefinition.Location = new System.Drawing.Point(130, 28);
			this.listDefinition.Name = "listDefinition";
			this.listDefinition.Size = new System.Drawing.Size(180, 95);
			this.listDefinition.TabIndex = 506;
			this.listDefinition.Text = "listDefinition";
			this.listDefinition.SelectionChangeCommitted += new System.EventHandler(this.listDefinition_SelectionChangeCommitted);
			// 
			// butDefinitions
			// 
			this.butDefinitions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butDefinitions.Location = new System.Drawing.Point(0, 0);
			this.butDefinitions.Name = "butDefinitions";
			this.butDefinitions.Size = new System.Drawing.Size(64, 24);
			this.butDefinitions.TabIndex = 514;
			this.butDefinitions.Text = "Setup";
			this.butDefinitions.UseVisualStyleBackColor = true;
			this.butDefinitions.Click += new System.EventHandler(this.butDefinitions_Click);
			// 
			// FormEClipboardImageCaptureDefEdit
			// 
			this.ClientSize = new System.Drawing.Size(618, 499);
			this.Controls.Add(this.butDefinitions);
			this.Controls.Add(this.listDefinition);
			this.Controls.Add(this.groupFrequency);
			this.Controls.Add(this.checkSelfPortrait);
			this.Controls.Add(this.listOCRCaptureType);
			this.Controls.Add(this.labelInstructions);
			this.Controls.Add(this.textInstructions);
			this.Controls.Add(this.labelDefinition);
			this.Controls.Add(this.butDelete);
			this.Controls.Add(this.labelOCRCaptureType);
			this.Controls.Add(this.butSave);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEClipboardImageCaptureDefEdit";
			this.Text = "eClipboard Image Capture Def Edit";
			this.Load += new System.EventHandler(this.FormEClipboardImageCaptureDefEdit_Load);
			this.groupFrequency.ResumeLayout(false);
			this.groupFrequency.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private OpenDental.UI.Button butSave;
		private System.Windows.Forms.Label labelOCRCaptureType;
		private UI.Button butDelete;
		private System.Windows.Forms.Label labelDefinition;
		private System.Windows.Forms.TextBox textInstructions;
		private System.Windows.Forms.Label labelInstructions;
		private UI.ListBox listOCRCaptureType;
		private UI.CheckBox checkSelfPortrait;
		private UI.GroupBox groupFrequency;
		private System.Windows.Forms.Label labelTimeSpanHelp;
		private ValidNum textVIntDays;
		private System.Windows.Forms.Label labelDays;
		private ValidNum textVIntMonths;
		private System.Windows.Forms.Label labelMonths;
		private System.Windows.Forms.RadioButton radioFreqTimeSpan;
		private ValidNum textVIntYears;
		private System.Windows.Forms.Label labelFreqHelp;
		private System.Windows.Forms.RadioButton radioFreqOnce;
		private System.Windows.Forms.Label labelYears;
		private System.Windows.Forms.RadioButton radioFreqEachTime;
		private UI.ListBox listDefinition;
		private UI.Button butDefinitions;
	}
}