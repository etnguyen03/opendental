namespace OpenDental{
	partial class FormPatientForms {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatientForms));
			this.label1 = new System.Windows.Forms.Label();
			this.butPreFill = new OpenDental.UI.Button();
			this.butImport = new OpenDental.UI.Button();
			this.butTerminal = new OpenDental.UI.Button();
			this.butAddSheet = new OpenDental.UI.Button();
			this.gridMain = new OpenDental.UI.GridOD();
			this.menuMain = new OpenDental.UI.MenuOD();
			this.butCopy = new OpenDental.UI.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.butAddEForm = new OpenDental.UI.Button();
			this.groupSortBy = new OpenDental.UI.GroupBox();
			this.radioSortByDateTime = new System.Windows.Forms.RadioButton();
			this.radioSortByDescDateT = new System.Windows.Forms.RadioButton();
			this.groupSortBy.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(91, 661);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(173, 18);
			this.label1.TabIndex = 10;
			this.label1.Text = "from form into database";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// butPreFill
			// 
			this.butPreFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butPreFill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butPreFill.Location = new System.Drawing.Point(12, 627);
			this.butPreFill.Name = "butPreFill";
			this.butPreFill.Size = new System.Drawing.Size(75, 24);
			this.butPreFill.TabIndex = 11;
			this.butPreFill.Text = "Pre-Fill";
			this.butPreFill.Click += new System.EventHandler(this.butPreFill_Click);
			// 
			// butImport
			// 
			this.butImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butImport.Location = new System.Drawing.Point(12, 658);
			this.butImport.Name = "butImport";
			this.butImport.Size = new System.Drawing.Size(75, 24);
			this.butImport.TabIndex = 9;
			this.butImport.Text = "Import";
			this.butImport.Click += new System.EventHandler(this.butImport_Click);
			// 
			// butTerminal
			// 
			this.butTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butTerminal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butTerminal.Location = new System.Drawing.Point(198, 565);
			this.butTerminal.Name = "butTerminal";
			this.butTerminal.Size = new System.Drawing.Size(75, 24);
			this.butTerminal.TabIndex = 7;
			this.butTerminal.Text = "Kiosk";
			this.butTerminal.Click += new System.EventHandler(this.butTerminal_Click);
			// 
			// butAddSheet
			// 
			this.butAddSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butAddSheet.Icon = OpenDental.UI.EnumIcons.Add;
			this.butAddSheet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAddSheet.Location = new System.Drawing.Point(12, 565);
			this.butAddSheet.Name = "butAddSheet";
			this.butAddSheet.Size = new System.Drawing.Size(87, 24);
			this.butAddSheet.TabIndex = 6;
			this.butAddSheet.Text = "Add Sheet";
			this.butAddSheet.Click += new System.EventHandler(this.butAddSheet_Click);
			// 
			// gridMain
			// 
			this.gridMain.AllowSortingByColumn = true;
			this.gridMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridMain.Location = new System.Drawing.Point(12, 98);
			this.gridMain.Name = "gridMain";
			this.gridMain.Size = new System.Drawing.Size(722, 456);
			this.gridMain.TabIndex = 4;
			this.gridMain.Title = "Patient Forms and Medical Histories";
			this.gridMain.TranslationName = "FormPatientForms";
			this.gridMain.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridMain_CellDoubleClick);
			// 
			// menuMain
			// 
			this.menuMain.Dock = System.Windows.Forms.DockStyle.Top;
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(745, 24);
			this.menuMain.TabIndex = 12;
			// 
			// butCopy
			// 
			this.butCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butCopy.Location = new System.Drawing.Point(12, 596);
			this.butCopy.Name = "butCopy";
			this.butCopy.Size = new System.Drawing.Size(75, 24);
			this.butCopy.TabIndex = 13;
			this.butCopy.Text = "Copy";
			this.butCopy.Click += new System.EventHandler(this.butCopy_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Location = new System.Drawing.Point(90, 631);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(381, 18);
			this.label2.TabIndex = 14;
			this.label2.Text = "Make a copy, but pull new info from the database where possible.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// butAddEForm
			// 
			this.butAddEForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butAddEForm.Icon = OpenDental.UI.EnumIcons.Add;
			this.butAddEForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAddEForm.Location = new System.Drawing.Point(105, 565);
			this.butAddEForm.Name = "butAddEForm";
			this.butAddEForm.Size = new System.Drawing.Size(87, 24);
			this.butAddEForm.TabIndex = 15;
			this.butAddEForm.Text = "Add eForm";
			this.butAddEForm.Click += new System.EventHandler(this.butAddEForm_Click);
			// 
			// groupSortBy
			// 
			this.groupSortBy.BackColor = System.Drawing.Color.White;
			this.groupSortBy.Controls.Add(this.radioSortByDateTime);
			this.groupSortBy.Controls.Add(this.radioSortByDescDateT);
			this.groupSortBy.Location = new System.Drawing.Point(12, 30);
			this.groupSortBy.Name = "groupSortBy";
			this.groupSortBy.Size = new System.Drawing.Size(290, 62);
			this.groupSortBy.TabIndex = 251;
			this.groupSortBy.Text = "Sort forms by";
			// 
			// radioSortByDateTime
			// 
			this.radioSortByDateTime.Checked = true;
			this.radioSortByDateTime.Location = new System.Drawing.Point(24, 18);
			this.radioSortByDateTime.Name = "radioSortByDateTime";
			this.radioSortByDateTime.Size = new System.Drawing.Size(184, 18);
			this.radioSortByDateTime.TabIndex = 252;
			this.radioSortByDateTime.TabStop = true;
			this.radioSortByDateTime.Text = "Date and Time";
			this.radioSortByDateTime.UseVisualStyleBackColor = true;
			this.radioSortByDateTime.Click += new System.EventHandler(this.radioSortByDateTime_Click);
			// 
			// radioSortByDescDateT
			// 
			this.radioSortByDescDateT.Location = new System.Drawing.Point(24, 38);
			this.radioSortByDescDateT.Name = "radioSortByDescDateT";
			this.radioSortByDescDateT.Size = new System.Drawing.Size(236, 18);
			this.radioSortByDescDateT.TabIndex = 251;
			this.radioSortByDescDateT.Text = "Description, then Date/Time";
			this.radioSortByDescDateT.UseVisualStyleBackColor = true;
			this.radioSortByDescDateT.Click += new System.EventHandler(this.radioSortByDescriptionDateTime_Click);
			// 
			// FormPatientForms
			// 
			this.ClientSize = new System.Drawing.Size(745, 696);
			this.Controls.Add(this.groupSortBy);
			this.Controls.Add(this.butAddEForm);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.butCopy);
			this.Controls.Add(this.butPreFill);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.butImport);
			this.Controls.Add(this.butTerminal);
			this.Controls.Add(this.butAddSheet);
			this.Controls.Add(this.gridMain);
			this.Controls.Add(this.menuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormPatientForms";
			this.Text = "Patient Forms and Medical Histories";
			this.Load += new System.EventHandler(this.FormPatientForms_Load);
			this.groupSortBy.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private OpenDental.UI.GridOD gridMain;
		private OpenDental.UI.Button butAddSheet;
		private OpenDental.UI.Button butTerminal;
		private OpenDental.UI.Button butImport;
		private System.Windows.Forms.Label label1;
		private OpenDental.UI.Button butPreFill;
		private UI.MenuOD menuMain;
		private UI.Button butCopy;
		private System.Windows.Forms.Label label2;
		private UI.Button butAddEForm;
		private UI.GroupBox groupSortBy;
		private System.Windows.Forms.RadioButton radioSortByDateTime;
		private System.Windows.Forms.RadioButton radioSortByDescDateT;
	}
}