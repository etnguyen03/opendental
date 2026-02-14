
namespace OpenDental {
	partial class FormEClipboardSheetRule {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEClipboardSheetRule));
			this.labelMinAge = new System.Windows.Forms.Label();
			this.labelMaxAge = new System.Windows.Forms.Label();
			this.textMinAge = new System.Windows.Forms.TextBox();
			this.textMaxAge = new System.Windows.Forms.TextBox();
			this.labelSheet = new System.Windows.Forms.Label();
			this.textSheet = new System.Windows.Forms.TextBox();
			this.butSave = new OpenDental.UI.Button();
			this.butSelectSheetsToIgnore = new OpenDental.UI.Button();
			this.labelSheetsToIgnore = new System.Windows.Forms.Label();
			this.listSheetsToIgnore = new OpenDental.UI.ListBox();
			this.butDelete = new OpenDental.UI.Button();
			this.labelMinAgeHelp = new System.Windows.Forms.Label();
			this.groupBehavior = new OpenDental.UI.GroupBox();
			this.labelBehaviorNewHelp = new System.Windows.Forms.Label();
			this.labelBehaviorPreFillHelp = new System.Windows.Forms.Label();
			this.radioBehaviorPreFill = new System.Windows.Forms.RadioButton();
			this.radioBehaviorNew = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
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
			this.groupBehavior.SuspendLayout();
			this.groupFrequency.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelMinAge
			// 
			this.labelMinAge.Location = new System.Drawing.Point(14, 291);
			this.labelMinAge.Name = "labelMinAge";
			this.labelMinAge.Size = new System.Drawing.Size(120, 20);
			this.labelMinAge.TabIndex = 1;
			this.labelMinAge.Text = "Minimum Age";
			this.labelMinAge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelMaxAge
			// 
			this.labelMaxAge.Location = new System.Drawing.Point(14, 316);
			this.labelMaxAge.Name = "labelMaxAge";
			this.labelMaxAge.Size = new System.Drawing.Size(120, 20);
			this.labelMaxAge.TabIndex = 2;
			this.labelMaxAge.Text = "Maximum Age";
			this.labelMaxAge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textMinAge
			// 
			this.textMinAge.Location = new System.Drawing.Point(136, 292);
			this.textMinAge.Name = "textMinAge";
			this.textMinAge.Size = new System.Drawing.Size(35, 20);
			this.textMinAge.TabIndex = 7;
			// 
			// textMaxAge
			// 
			this.textMaxAge.Location = new System.Drawing.Point(136, 317);
			this.textMaxAge.Name = "textMaxAge";
			this.textMaxAge.Size = new System.Drawing.Size(35, 20);
			this.textMaxAge.TabIndex = 8;
			// 
			// labelSheet
			// 
			this.labelSheet.Location = new System.Drawing.Point(30, 9);
			this.labelSheet.Name = "labelSheet";
			this.labelSheet.Size = new System.Drawing.Size(100, 20);
			this.labelSheet.TabIndex = 11;
			this.labelSheet.Text = "Form";
			this.labelSheet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textSheet
			// 
			this.textSheet.Location = new System.Drawing.Point(136, 10);
			this.textSheet.Name = "textSheet";
			this.textSheet.ReadOnly = true;
			this.textSheet.Size = new System.Drawing.Size(144, 20);
			this.textSheet.TabIndex = 12;
			// 
			// butSave
			// 
			this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butSave.Location = new System.Drawing.Point(539, 468);
			this.butSave.Name = "butSave";
			this.butSave.Size = new System.Drawing.Size(75, 24);
			this.butSave.TabIndex = 13;
			this.butSave.Text = "&Save";
			this.butSave.UseVisualStyleBackColor = true;
			this.butSave.Click += new System.EventHandler(this.butSave_Click);
			// 
			// butSelectSheetsToIgnore
			// 
			this.butSelectSheetsToIgnore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSelectSheetsToIgnore.Location = new System.Drawing.Point(319, 343);
			this.butSelectSheetsToIgnore.Name = "butSelectSheetsToIgnore";
			this.butSelectSheetsToIgnore.Size = new System.Drawing.Size(60, 24);
			this.butSelectSheetsToIgnore.TabIndex = 20;
			this.butSelectSheetsToIgnore.Text = "Edit";
			this.butSelectSheetsToIgnore.UseVisualStyleBackColor = true;
			this.butSelectSheetsToIgnore.Click += new System.EventHandler(this.butSelectSheetsToIgnore_Click);
			// 
			// labelSheetsToIgnore
			// 
			this.labelSheetsToIgnore.Location = new System.Drawing.Point(14, 341);
			this.labelSheetsToIgnore.Name = "labelSheetsToIgnore";
			this.labelSheetsToIgnore.Size = new System.Drawing.Size(120, 20);
			this.labelSheetsToIgnore.TabIndex = 19;
			this.labelSheetsToIgnore.Text = "Sheets to Ignore";
			this.labelSheetsToIgnore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// listSheetsToIgnore
			// 
			this.listSheetsToIgnore.Location = new System.Drawing.Point(136, 343);
			this.listSheetsToIgnore.Name = "listSheetsToIgnore";
			this.listSheetsToIgnore.SelectionMode = OpenDental.UI.SelectionMode.None;
			this.listSheetsToIgnore.Size = new System.Drawing.Size(177, 95);
			this.listSheetsToIgnore.TabIndex = 21;
			this.listSheetsToIgnore.Text = "listSheetsToIgnore";
			// 
			// butDelete
			// 
			this.butDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butDelete.Icon = OpenDental.UI.EnumIcons.DeleteX;
			this.butDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butDelete.Location = new System.Drawing.Point(12, 468);
			this.butDelete.Name = "butDelete";
			this.butDelete.Size = new System.Drawing.Size(81, 24);
			this.butDelete.TabIndex = 80;
			this.butDelete.TabStop = false;
			this.butDelete.Text = "Delete";
			this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
			// 
			// labelMinAgeHelp
			// 
			this.labelMinAgeHelp.Location = new System.Drawing.Point(177, 292);
			this.labelMinAgeHelp.Name = "labelMinAgeHelp";
			this.labelMinAgeHelp.Size = new System.Drawing.Size(136, 20);
			this.labelMinAgeHelp.TabIndex = 81;
			this.labelMinAgeHelp.Text = "or leave blank";
			this.labelMinAgeHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBehavior
			// 
			this.groupBehavior.BackColor = System.Drawing.Color.White;
			this.groupBehavior.Controls.Add(this.labelBehaviorNewHelp);
			this.groupBehavior.Controls.Add(this.labelBehaviorPreFillHelp);
			this.groupBehavior.Controls.Add(this.radioBehaviorPreFill);
			this.groupBehavior.Controls.Add(this.radioBehaviorNew);
			this.groupBehavior.Location = new System.Drawing.Point(50, 36);
			this.groupBehavior.Name = "groupBehavior";
			this.groupBehavior.Size = new System.Drawing.Size(536, 68);
			this.groupBehavior.TabIndex = 250;
			this.groupBehavior.Text = "Behavior";
			// 
			// labelBehaviorNewHelp
			// 
			this.labelBehaviorNewHelp.Location = new System.Drawing.Point(103, 40);
			this.labelBehaviorNewHelp.Name = "labelBehaviorNewHelp";
			this.labelBehaviorNewHelp.Size = new System.Drawing.Size(380, 19);
			this.labelBehaviorNewHelp.TabIndex = 255;
			this.labelBehaviorNewHelp.Text = "Do not use this unless you actually want the form to be blank every time.";
			this.labelBehaviorNewHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelBehaviorPreFillHelp
			// 
			this.labelBehaviorPreFillHelp.Location = new System.Drawing.Point(103, 18);
			this.labelBehaviorPreFillHelp.Name = "labelBehaviorPreFillHelp";
			this.labelBehaviorPreFillHelp.Size = new System.Drawing.Size(380, 19);
			this.labelBehaviorPreFillHelp.TabIndex = 254;
			this.labelBehaviorPreFillHelp.Text = "Form will be pre-filled with information from the database if possible.";
			this.labelBehaviorPreFillHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radioBehaviorPreFill
			// 
			this.radioBehaviorPreFill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioBehaviorPreFill.Location = new System.Drawing.Point(27, 19);
			this.radioBehaviorPreFill.Name = "radioBehaviorPreFill";
			this.radioBehaviorPreFill.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioBehaviorPreFill.Size = new System.Drawing.Size(70, 18);
			this.radioBehaviorPreFill.TabIndex = 252;
			this.radioBehaviorPreFill.Text = "Pre-fill";
			this.radioBehaviorPreFill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioBehaviorPreFill.UseVisualStyleBackColor = true;
			// 
			// radioBehaviorNew
			// 
			this.radioBehaviorNew.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioBehaviorNew.Location = new System.Drawing.Point(27, 41);
			this.radioBehaviorNew.Name = "radioBehaviorNew";
			this.radioBehaviorNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioBehaviorNew.Size = new System.Drawing.Size(70, 18);
			this.radioBehaviorNew.TabIndex = 251;
			this.radioBehaviorNew.Text = "New";
			this.radioBehaviorNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioBehaviorNew.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(177, 317);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 20);
			this.label1.TabIndex = 251;
			this.label1.Text = "or leave blank";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.groupFrequency.Location = new System.Drawing.Point(50, 109);
			this.groupFrequency.Name = "groupFrequency";
			this.groupFrequency.Size = new System.Drawing.Size(536, 177);
			this.groupFrequency.TabIndex = 256;
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
			// FormEClipboardSheetRule
			// 
			this.ClientSize = new System.Drawing.Size(626, 504);
			this.Controls.Add(this.groupFrequency);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBehavior);
			this.Controls.Add(this.labelMinAgeHelp);
			this.Controls.Add(this.butDelete);
			this.Controls.Add(this.listSheetsToIgnore);
			this.Controls.Add(this.butSelectSheetsToIgnore);
			this.Controls.Add(this.labelSheetsToIgnore);
			this.Controls.Add(this.butSave);
			this.Controls.Add(this.textSheet);
			this.Controls.Add(this.labelSheet);
			this.Controls.Add(this.textMaxAge);
			this.Controls.Add(this.textMinAge);
			this.Controls.Add(this.labelMaxAge);
			this.Controls.Add(this.labelMinAge);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEClipboardSheetRule";
			this.Text = "eClipboard Sheet Rule";
			this.Load += new System.EventHandler(this.FormEClipboardSheetRule_Load);
			this.groupBehavior.ResumeLayout(false);
			this.groupFrequency.ResumeLayout(false);
			this.groupFrequency.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelMinAge;
		private System.Windows.Forms.Label labelMaxAge;
		private System.Windows.Forms.TextBox textMinAge;
		private System.Windows.Forms.TextBox textMaxAge;
		private System.Windows.Forms.Label labelSheet;
		private System.Windows.Forms.TextBox textSheet;
		private UI.Button butSave;
		private UI.Button butSelectSheetsToIgnore;
		private System.Windows.Forms.Label labelSheetsToIgnore;
		private UI.ListBox listSheetsToIgnore;
		private UI.Button butDelete;
		private System.Windows.Forms.Label labelMinAgeHelp;
		private UI.GroupBox groupBehavior;
		private System.Windows.Forms.RadioButton radioBehaviorPreFill;
		private System.Windows.Forms.RadioButton radioBehaviorNew;
		private System.Windows.Forms.Label labelBehaviorPreFillHelp;
		private System.Windows.Forms.Label labelBehaviorNewHelp;
		private System.Windows.Forms.Label label1;
		private UI.GroupBox groupFrequency;
		private System.Windows.Forms.Label labelFreqHelp;
		private System.Windows.Forms.RadioButton radioFreqOnce;
		private System.Windows.Forms.RadioButton radioFreqEachTime;
		private System.Windows.Forms.RadioButton radioFreqTimeSpan;
		private ValidNum textVIntMonths;
		private System.Windows.Forms.Label labelMonths;
		private ValidNum textVIntYears;
		private System.Windows.Forms.Label labelYears;
		private ValidNum textVIntDays;
		private System.Windows.Forms.Label labelDays;
		private System.Windows.Forms.Label labelTimeSpanHelp;
	}
}