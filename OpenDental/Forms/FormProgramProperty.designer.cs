﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDental {
	public partial class FormProgramProperty {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProgramProperty));
			this.butSave = new OpenDental.UI.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textProperty = new System.Windows.Forms.TextBox();
			this.textValue = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.checkIsHighSecurity = new OpenDental.UI.CheckBox();
			this.SuspendLayout();
			// 
			// butSave
			// 
			this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butSave.Location = new System.Drawing.Point(405, 135);
			this.butSave.Name = "butSave";
			this.butSave.Size = new System.Drawing.Size(75, 26);
			this.butSave.TabIndex = 0;
			this.butSave.Text = "&Save";
			this.butSave.Click += new System.EventHandler(this.butSave_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 21);
			this.label1.TabIndex = 2;
			this.label1.Text = "Property";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textProperty
			// 
			this.textProperty.Location = new System.Drawing.Point(162, 31);
			this.textProperty.Name = "textProperty";
			this.textProperty.ReadOnly = true;
			this.textProperty.Size = new System.Drawing.Size(319, 20);
			this.textProperty.TabIndex = 2;
			// 
			// textValue
			// 
			this.textValue.Location = new System.Drawing.Point(162, 74);
			this.textValue.Name = "textValue";
			this.textValue.Size = new System.Drawing.Size(319, 20);
			this.textValue.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 21);
			this.label2.TabIndex = 3;
			this.label2.Text = "Value";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkIsHighSecurity
			// 
			this.checkIsHighSecurity.Location = new System.Drawing.Point(162, 105);
			this.checkIsHighSecurity.Name = "checkIsHighSecurity";
			this.checkIsHighSecurity.Size = new System.Drawing.Size(132, 17);
			this.checkIsHighSecurity.TabIndex = 4;
			this.checkIsHighSecurity.Text = "High Security";
			this.checkIsHighSecurity.Visible = false;
			// 
			// FormProgramProperty
			// 
			this.ClientSize = new System.Drawing.Size(492, 173);
			this.Controls.Add(this.checkIsHighSecurity);
			this.Controls.Add(this.butSave);
			this.Controls.Add(this.textValue);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textProperty);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormProgramProperty";
			this.ShowInTaskbar = false;
			this.Text = "Edit Program Property";
			this.Load += new System.EventHandler(this.FormProgramProperty_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
		private OpenDental.UI.Button butSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textProperty;
		private System.Windows.Forms.TextBox textValue;
		private OpenDental.UI.CheckBox checkIsHighSecurity;
	}
}
