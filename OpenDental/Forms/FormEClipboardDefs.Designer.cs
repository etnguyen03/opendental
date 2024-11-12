namespace OpenDental {
	partial class FormEClipboardDefs {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEClipboardDefs));
			this.gridDefs = new OpenDental.UI.GridOD();
			this.butImageAdd = new OpenDental.UI.Button();
			this.labelWarning = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// gridDefs
			// 
			this.gridDefs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gridDefs.Location = new System.Drawing.Point(12, 27);
			this.gridDefs.Name = "gridDefs";
			this.gridDefs.Size = new System.Drawing.Size(451, 492);
			this.gridDefs.TabIndex = 0;
			this.gridDefs.Title = "Image Definitions";
			this.gridDefs.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridDefinitions_CellDoubleClick);
			// 
			// butImageAdd
			// 
			this.butImageAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butImageAdd.Icon = OpenDental.UI.EnumIcons.Add;
			this.butImageAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butImageAdd.Location = new System.Drawing.Point(12, 525);
			this.butImageAdd.Name = "butImageAdd";
			this.butImageAdd.Size = new System.Drawing.Size(82, 24);
			this.butImageAdd.TabIndex = 505;
			this.butImageAdd.Text = "Add";
			this.butImageAdd.UseVisualStyleBackColor = true;
			this.butImageAdd.Click += new System.EventHandler(this.butAdd_Click);
			// 
			// labelWarning
			// 
			this.labelWarning.ForeColor = System.Drawing.Color.Red;
			this.labelWarning.Location = new System.Drawing.Point(12, 4);
			this.labelWarning.Name = "labelWarning";
			this.labelWarning.Size = new System.Drawing.Size(451, 20);
			this.labelWarning.TabIndex = 506;
			this.labelWarning.Text = "Modifications made here will affect all clinics.";
			this.labelWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormEClipboardDefs
			// 
			this.ClientSize = new System.Drawing.Size(475, 561);
			this.Controls.Add(this.labelWarning);
			this.Controls.Add(this.butImageAdd);
			this.Controls.Add(this.gridDefs);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEClipboardDefs";
			this.Text = "eClipboard Defs";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEClipboardDefs_FormClosed);
			this.Load += new System.EventHandler(this.FormEClipboardDefs_Load);
			this.ResumeLayout(false);

		}

		#endregion
		private UI.GridOD gridDefs;
		private UI.Button butImageAdd;
		private System.Windows.Forms.Label labelWarning;
	}
}