namespace OpenDental{
	partial class FormRecallListUndo {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecallListUndo));
			this.butOK = new OpenDental.UI.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.odDatePicker = new OpenDental.UI.ODDatePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.labelCount = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// butOK
			// 
			this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butOK.Location = new System.Drawing.Point(447, 227);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(75, 24);
			this.butOK.TabIndex = 3;
			this.butOK.Text = "&OK";
			this.butOK.Click += new System.EventHandler(this.butOK_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(510, 60);
			this.label1.TabIndex = 4;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// odDatePicker
			// 
			this.odDatePicker.BackColor = System.Drawing.Color.Transparent;
			this.odDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.odDatePicker.Location = new System.Drawing.Point(24, 76);
			this.odDatePicker.Name = "odDatePicker";
			this.odDatePicker.Size = new System.Drawing.Size(227, 23);
			this.odDatePicker.TabIndex = 9;
			this.odDatePicker.DateTextChanged += new System.EventHandler(this.odDatePicker_DateTextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(18, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 18);
			this.label2.TabIndex = 6;
			this.label2.Text = "Date";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(268, 230);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 18);
			this.label3.TabIndex = 7;
			this.label3.Text = "Patients Affected:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelCount
			// 
			this.labelCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCount.Location = new System.Drawing.Point(375, 230);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(68, 18);
			this.labelCount.TabIndex = 8;
			this.labelCount.Text = "100";
			this.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormRecallListUndo
			// 
			this.ClientSize = new System.Drawing.Size(534, 261);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.labelCount);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.odDatePicker);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.butOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormRecallListUndo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Recall List Undo";
			this.Load += new System.EventHandler(this.FormRecallListUndo_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private OpenDental.UI.Button butOK;
		private System.Windows.Forms.Label label1;
		private UI.ODDatePicker odDatePicker;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelCount;
	}
}