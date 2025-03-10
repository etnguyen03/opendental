namespace OpenDental{
	partial class FormRpDentalSealantMeasure {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRpDentalSealantMeasure));
			this.butOK = new OpenDental.UI.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textYear = new OpenDental.ValidNum();
			this.SuspendLayout();
			// 
			// butOK
			// 
			this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butOK.Location = new System.Drawing.Point(232, 55);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(75, 24);
			this.butOK.TabIndex = 3;
			this.butOK.Text = "&OK";
			this.butOK.Click += new System.EventHandler(this.butOK_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Year";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textYear
			// 
			this.textYear.Location = new System.Drawing.Point(114, 12);
			this.textYear.MaxVal = 3000;
			this.textYear.MinVal = 0;
			this.textYear.Name = "textYear";
			this.textYear.ShowZero = false;
			this.textYear.Size = new System.Drawing.Size(153, 20);
			this.textYear.TabIndex = 6;
			// 
			// FormRpDentalSealantMeasure
			// 
			this.ClientSize = new System.Drawing.Size(319, 91);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.textYear);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.butOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormRpDentalSealantMeasure";
			this.Text = "UDS Report for FQHC Dental Sealant Measure";
			this.Load += new System.EventHandler(this.FormRpDentalSealantMeasure_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private OpenDental.UI.Button butOK;
		private System.Windows.Forms.Label label1;
		private ValidNum textYear;
	}
}