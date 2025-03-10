﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDental {
	public partial class FormLanguagesUsed {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		///<summary>Clean up any resources being used.</summary>
		protected override void Dispose(bool disposing) {
			if(disposing) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLanguagesUsed));
			this.listAvailable = new OpenDental.UI.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.listUsed = new OpenDental.UI.ListBox();
			this.textCustom = new System.Windows.Forms.TextBox();
			this.butAddCustom = new OpenDental.UI.Button();
			this.butDown = new OpenDental.UI.Button();
			this.butUp = new OpenDental.UI.Button();
			this.butDelete = new OpenDental.UI.Button();
			this.butAdd = new OpenDental.UI.Button();
			this.butSave = new OpenDental.UI.Button();
			this.comboLanguagesIndicateNone = new OpenDental.UI.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listAvailable
			// 
			this.listAvailable.Location = new System.Drawing.Point(32, 107);
			this.listAvailable.Name = "listAvailable";
			this.listAvailable.Size = new System.Drawing.Size(278, 425);
			this.listAvailable.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(30, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(281, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "All Languages";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(29, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(474, 53);
			this.label2.TabIndex = 3;
			this.label2.Text = "This window lets you define which languages will be available to assign to patien" +
    "ts.\r\nThis will not change the language of the user interface.\r\nIt will only be u" +
    "sed when interacting with patients.";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(444, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(281, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Languages used by patients";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// listUsed
			// 
			this.listUsed.Location = new System.Drawing.Point(446, 107);
			this.listUsed.Name = "listUsed";
			this.listUsed.Size = new System.Drawing.Size(278, 134);
			this.listUsed.TabIndex = 4;
			// 
			// textCustom
			// 
			this.textCustom.Location = new System.Drawing.Point(12, 23);
			this.textCustom.Name = "textCustom";
			this.textCustom.Size = new System.Drawing.Size(267, 20);
			this.textCustom.TabIndex = 11;
			// 
			// butAddCustom
			// 
			this.butAddCustom.Image = global::OpenDental.Properties.Resources.Right;
			this.butAddCustom.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAddCustom.Location = new System.Drawing.Point(308, 19);
			this.butAddCustom.Name = "butAddCustom";
			this.butAddCustom.Size = new System.Drawing.Size(75, 26);
			this.butAddCustom.TabIndex = 13;
			this.butAddCustom.Text = "Add";
			this.butAddCustom.Click += new System.EventHandler(this.butAddCustom_Click);
			// 
			// butDown
			// 
			this.butDown.Image = global::OpenDental.Properties.Resources.down;
			this.butDown.Location = new System.Drawing.Point(618, 250);
			this.butDown.Name = "butDown";
			this.butDown.Size = new System.Drawing.Size(53, 26);
			this.butDown.TabIndex = 10;
			this.butDown.Click += new System.EventHandler(this.butDown_Click);
			// 
			// butUp
			// 
			this.butUp.Image = global::OpenDental.Properties.Resources.up;
			this.butUp.Location = new System.Drawing.Point(547, 250);
			this.butUp.Name = "butUp";
			this.butUp.Size = new System.Drawing.Size(53, 26);
			this.butUp.TabIndex = 9;
			this.butUp.Click += new System.EventHandler(this.butUp_Click);
			// 
			// butDelete
			// 
			this.butDelete.Icon = OpenDental.UI.EnumIcons.DeleteX;
			this.butDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butDelete.Location = new System.Drawing.Point(446, 250);
			this.butDelete.Name = "butDelete";
			this.butDelete.Size = new System.Drawing.Size(83, 26);
			this.butDelete.TabIndex = 8;
			this.butDelete.Text = "Delete";
			this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
			// 
			// butAdd
			// 
			this.butAdd.Image = global::OpenDental.Properties.Resources.Right;
			this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butAdd.Location = new System.Drawing.Point(340, 107);
			this.butAdd.Name = "butAdd";
			this.butAdd.Size = new System.Drawing.Size(75, 26);
			this.butAdd.TabIndex = 7;
			this.butAdd.Text = "Add";
			this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
			// 
			// butSave
			// 
			this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butSave.Location = new System.Drawing.Point(651, 615);
			this.butSave.Name = "butSave";
			this.butSave.Size = new System.Drawing.Size(75, 26);
			this.butSave.TabIndex = 6;
			this.butSave.Text = "&Save";
			this.butSave.Click += new System.EventHandler(this.butSave_Click);
			// 
			// comboLanguagesIndicateNone
			// 
			this.comboLanguagesIndicateNone.Location = new System.Drawing.Point(446, 328);
			this.comboLanguagesIndicateNone.Name = "comboLanguagesIndicateNone";
			this.comboLanguagesIndicateNone.Size = new System.Drawing.Size(278, 21);
			this.comboLanguagesIndicateNone.TabIndex = 163;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(444, 295);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(281, 30);
			this.label5.TabIndex = 164;
			this.label5.Text = "Indicator that patient has no specified language\r\nCustom languages only";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(9, 46);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(272, 46);
			this.label6.TabIndex = 165;
			this.label6.Text = "Type in full name of custom language, e.g.:\r\nTamasheq, American Sign Language, Kl" +
    "ingon, etc.\r\nDo not type in an existing language, like Spanish.";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.butAddCustom);
			this.groupBox1.Controls.Add(this.textCustom);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(32, 546);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(395, 95);
			this.groupBox1.TabIndex = 167;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Custom Language";
			// 
			// FormLanguagesUsed
			// 
			this.ClientSize = new System.Drawing.Size(738, 653);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.comboLanguagesIndicateNone);
			this.Controls.Add(this.butDown);
			this.Controls.Add(this.butUp);
			this.Controls.Add(this.butDelete);
			this.Controls.Add(this.butAdd);
			this.Controls.Add(this.butSave);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.listUsed);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listAvailable);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormLanguagesUsed";
			this.ShowInTaskbar = false;
			this.Text = "Language Definitions";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLanguagesUsed_FormClosing);
			this.Load += new System.EventHandler(this.FormLanguagesUsed_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
		private OpenDental.UI.ListBox listAvailable;
		private Label label1;
		private Label label2;
		private Label label3;
		private OpenDental.UI.ListBox listUsed;
		private OpenDental.UI.Button butSave;
		private OpenDental.UI.Button butAdd;
		private OpenDental.UI.Button butDelete;
		private OpenDental.UI.Button butUp;
		private OpenDental.UI.Button butDown;
		private TextBox textCustom;
		private UI.Button butAddCustom;
		private OpenDental.UI.ComboBox comboLanguagesIndicateNone;
		private Label label5;
		private Label label6;
		private GroupBox groupBox1;
	}
}
