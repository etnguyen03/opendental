namespace OpenDental{
	partial class FormWebFormSetup {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWebFormSetup));
			this.groupConstructURL = new OpenDental.UI.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.labelConstructInfo = new System.Windows.Forms.Label();
			this.butCopyToClipboard = new OpenDental.UI.Button();
			this.butNavigateTo = new OpenDental.UI.Button();
			this.checkDisableTypedSig = new OpenDental.UI.CheckBox();
			this.checkAutoFillNameAndBirthdate = new OpenDental.UI.CheckBox();
			this.textURLs = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboClinic = new OpenDental.UI.ComboBoxClinicPicker();
			this.butNextForms = new OpenDental.UI.Button();
			this.textNextForms = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textRedirectURL = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.butSavePrefs = new OpenDental.UI.Button();
			this.butChange = new OpenDental.UI.Button();
			this.butDelete = new OpenDental.UI.Button();
			this.butWebformBorderColor = new System.Windows.Forms.Button();
			this.butAdd = new OpenDental.UI.Button();
			this.labelBorderColor = new System.Windows.Forms.Label();
			this.gridMain = new OpenDental.UI.GridOD();
			this.textboxWebHostAddress = new System.Windows.Forms.TextBox();
			this.labelWebhostURL = new System.Windows.Forms.Label();
			this.butUpdate = new OpenDental.UI.Button();
			this.butSave = new OpenDental.UI.Button();
			this.checkDisableSigsPref = new OpenDental.UI.CheckBox();
			this.groupPrefs = new OpenDental.UI.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.checkAutoFillNameBDPref = new OpenDental.UI.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.labelDateFormat = new System.Windows.Forms.Label();
			this.comboDateFormat = new OpenDental.UI.ComboBox();
			this.checkEnableAutoDownload = new OpenDental.UI.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.groupConstructURL.SuspendLayout();
			this.groupPrefs.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupConstructURL
			// 
			this.groupConstructURL.Controls.Add(this.label9);
			this.groupConstructURL.Controls.Add(this.label14);
			this.groupConstructURL.Controls.Add(this.label13);
			this.groupConstructURL.Controls.Add(this.label12);
			this.groupConstructURL.Controls.Add(this.label11);
			this.groupConstructURL.Controls.Add(this.label10);
			this.groupConstructURL.Controls.Add(this.labelConstructInfo);
			this.groupConstructURL.Controls.Add(this.butCopyToClipboard);
			this.groupConstructURL.Controls.Add(this.butNavigateTo);
			this.groupConstructURL.Controls.Add(this.checkDisableTypedSig);
			this.groupConstructURL.Controls.Add(this.checkAutoFillNameAndBirthdate);
			this.groupConstructURL.Controls.Add(this.textURLs);
			this.groupConstructURL.Controls.Add(this.label2);
			this.groupConstructURL.Controls.Add(this.comboClinic);
			this.groupConstructURL.Controls.Add(this.butNextForms);
			this.groupConstructURL.Controls.Add(this.textNextForms);
			this.groupConstructURL.Controls.Add(this.label1);
			this.groupConstructURL.Controls.Add(this.textRedirectURL);
			this.groupConstructURL.Controls.Add(this.label3);
			this.groupConstructURL.Location = new System.Drawing.Point(366, 224);
			this.groupConstructURL.Name = "groupConstructURL";
			this.groupConstructURL.Size = new System.Drawing.Size(764, 461);
			this.groupConstructURL.TabIndex = 75;
			this.groupConstructURL.Text = "Construct URL";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(260, 204);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(79, 18);
			this.label14.TabIndex = 88;
			this.label14.Text = "(DTS=Y)";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(261, 183);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(337, 18);
			this.label13.TabIndex = 87;
			this.label13.Text = "from previous form (AFNAB=N if no). Only works with Next Forms";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(124, 159);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(117, 18);
			this.label12.TabIndex = 86;
			this.label12.Text = "Clinic (CID)";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(241, 79);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(444, 47);
			this.label11.TabIndex = 85;
			this.label11.Text = resources.GetString("label11.Text");
			this.label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(112, 262);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(128, 18);
			this.label10.TabIndex = 84;
			this.label10.Text = "Redirect (ReturnURL)";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelConstructInfo
			// 
			this.labelConstructInfo.Location = new System.Drawing.Point(12, 33);
			this.labelConstructInfo.Name = "labelConstructInfo";
			this.labelConstructInfo.Size = new System.Drawing.Size(747, 47);
			this.labelConstructInfo.TabIndex = 83;
			this.labelConstructInfo.Text = resources.GetString("labelConstructInfo.Text");
			// 
			// butCopyToClipboard
			// 
			this.butCopyToClipboard.Location = new System.Drawing.Point(364, 431);
			this.butCopyToClipboard.Name = "butCopyToClipboard";
			this.butCopyToClipboard.Size = new System.Drawing.Size(115, 24);
			this.butCopyToClipboard.TabIndex = 78;
			this.butCopyToClipboard.Text = "Copy to Clipboard";
			this.butCopyToClipboard.Click += new System.EventHandler(this.butCopyToClipboard_Click);
			// 
			// butNavigateTo
			// 
			this.butNavigateTo.Location = new System.Drawing.Point(241, 431);
			this.butNavigateTo.Name = "butNavigateTo";
			this.butNavigateTo.Size = new System.Drawing.Size(117, 24);
			this.butNavigateTo.TabIndex = 79;
			this.butNavigateTo.Text = "Navigate to URL(s)";
			this.butNavigateTo.Click += new System.EventHandler(this.butNavigateTo_Click);
			// 
			// checkDisableTypedSig
			// 
			this.checkDisableTypedSig.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkDisableTypedSig.Location = new System.Drawing.Point(35, 205);
			this.checkDisableTypedSig.Name = "checkDisableTypedSig";
			this.checkDisableTypedSig.Size = new System.Drawing.Size(220, 18);
			this.checkDisableTypedSig.TabIndex = 44;
			this.checkDisableTypedSig.Text = "Disable Typed Signature";
			this.checkDisableTypedSig.CheckedChanged += new System.EventHandler(this.checkDisableTypedSig_CheckChanged);
			// 
			// checkAutoFillNameAndBirthdate
			// 
			this.checkAutoFillNameAndBirthdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkAutoFillNameAndBirthdate.Location = new System.Drawing.Point(68, 183);
			this.checkAutoFillNameAndBirthdate.Name = "checkAutoFillNameAndBirthdate";
			this.checkAutoFillNameAndBirthdate.Size = new System.Drawing.Size(187, 18);
			this.checkAutoFillNameAndBirthdate.TabIndex = 43;
			this.checkAutoFillNameAndBirthdate.Text = "Auto Fill Name and Birthdate";
			this.checkAutoFillNameAndBirthdate.CheckedChanged += new System.EventHandler(this.checkAutoFillNameAndBirthdate_CheckedChanged);
			// 
			// textURLs
			// 
			this.textURLs.Location = new System.Drawing.Point(241, 288);
			this.textURLs.MaxLength = 100000;
			this.textURLs.Multiline = true;
			this.textURLs.Name = "textURLs";
			this.textURLs.ReadOnly = true;
			this.textURLs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textURLs.Size = new System.Drawing.Size(444, 137);
			this.textURLs.TabIndex = 42;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(160, 289);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 18);
			this.label2.TabIndex = 41;
			this.label2.Text = "URLs";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboClinic
			// 
			this.comboClinic.HqDescription = "None";
			this.comboClinic.IncludeUnassigned = true;
			this.comboClinic.Location = new System.Drawing.Point(204, 157);
			this.comboClinic.Name = "comboClinic";
			this.comboClinic.Size = new System.Drawing.Size(217, 21);
			this.comboClinic.TabIndex = 38;
			this.comboClinic.SelectionChangeCommitted += new System.EventHandler(this.ComboClinic_SelectionChangeCommitted);
			// 
			// butNextForms
			// 
			this.butNextForms.Location = new System.Drawing.Point(689, 130);
			this.butNextForms.Name = "butNextForms";
			this.butNextForms.Size = new System.Drawing.Size(70, 20);
			this.butNextForms.TabIndex = 19;
			this.butNextForms.Text = "Next Forms";
			this.butNextForms.Click += new System.EventHandler(this.butNextForms_Click);
			// 
			// textNextForms
			// 
			this.textNextForms.Location = new System.Drawing.Point(241, 130);
			this.textNextForms.MaxLength = 100;
			this.textNextForms.Name = "textNextForms";
			this.textNextForms.ReadOnly = true;
			this.textNextForms.Size = new System.Drawing.Size(444, 20);
			this.textNextForms.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(123, 131);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 18);
			this.label1.TabIndex = 5;
			this.label1.Text = "Next Forms (NFID)";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textRedirectURL
			// 
			this.textRedirectURL.Location = new System.Drawing.Point(241, 262);
			this.textRedirectURL.MaxLength = 100;
			this.textRedirectURL.Name = "textRedirectURL";
			this.textRedirectURL.Size = new System.Drawing.Size(444, 20);
			this.textRedirectURL.TabIndex = 1;
			this.textRedirectURL.TextChanged += new System.EventHandler(this.textRedirectURL_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(241, 225);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(507, 34);
			this.label3.TabIndex = 2;
			this.label3.Text = "When a patient completes their form, they can be automatically redirected back to" +
    " the office website. Enter the full URL (Example: https://opendental.com) where " +
    "patients should be redirected to.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// butSavePrefs
			// 
			this.butSavePrefs.Location = new System.Drawing.Point(649, 160);
			this.butSavePrefs.Name = "butSavePrefs";
			this.butSavePrefs.Size = new System.Drawing.Size(75, 24);
			this.butSavePrefs.TabIndex = 74;
			this.butSavePrefs.Text = "Save";
			this.butSavePrefs.Click += new System.EventHandler(this.butSavePrefs_Click);
			// 
			// butChange
			// 
			this.butChange.Location = new System.Drawing.Point(272, 91);
			this.butChange.Name = "butChange";
			this.butChange.Size = new System.Drawing.Size(75, 24);
			this.butChange.TabIndex = 72;
			this.butChange.Text = "Change";
			this.butChange.Click += new System.EventHandler(this.butChange_Click);
			// 
			// butDelete
			// 
			this.butDelete.Icon = OpenDental.UI.EnumIcons.DeleteX;
			this.butDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butDelete.Location = new System.Drawing.Point(221, 427);
			this.butDelete.Name = "butDelete";
			this.butDelete.Size = new System.Drawing.Size(75, 24);
			this.butDelete.TabIndex = 58;
			this.butDelete.Text = "Remove";
			this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
			// 
			// butWebformBorderColor
			// 
			this.butWebformBorderColor.BackColor = System.Drawing.Color.RoyalBlue;
			this.butWebformBorderColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butWebformBorderColor.Location = new System.Drawing.Point(241, 91);
			this.butWebformBorderColor.Name = "butWebformBorderColor";
			this.butWebformBorderColor.Size = new System.Drawing.Size(24, 24);
			this.butWebformBorderColor.TabIndex = 71;
			this.butWebformBorderColor.UseVisualStyleBackColor = false;
			this.butWebformBorderColor.Click += new System.EventHandler(this.butWebformBorderColor_Click);
			// 
			// butAdd
			// 
			this.butAdd.Icon = OpenDental.UI.EnumIcons.Add;
			this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAdd.Location = new System.Drawing.Point(221, 166);
			this.butAdd.Name = "butAdd";
			this.butAdd.Size = new System.Drawing.Size(75, 24);
			this.butAdd.TabIndex = 57;
			this.butAdd.Text = "&Add";
			this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
			// 
			// labelBorderColor
			// 
			this.labelBorderColor.Location = new System.Drawing.Point(129, 93);
			this.labelBorderColor.Name = "labelBorderColor";
			this.labelBorderColor.Size = new System.Drawing.Size(111, 19);
			this.labelBorderColor.TabIndex = 48;
			this.labelBorderColor.Text = "Border Color";
			this.labelBorderColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gridMain
			// 
			this.gridMain.HasLinkDetect = false;
			this.gridMain.Location = new System.Drawing.Point(15, 79);
			this.gridMain.Name = "gridMain";
			this.gridMain.SelectionMode = OpenDental.UI.GridSelectionMode.MultiExtended;
			this.gridMain.Size = new System.Drawing.Size(200, 480);
			this.gridMain.TabIndex = 56;
			this.gridMain.Title = "Available Web Forms";
			this.gridMain.TranslationName = "TableSheetDefs";
			this.gridMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridMain_MouseUp);
			// 
			// textboxWebHostAddress
			// 
			this.textboxWebHostAddress.Location = new System.Drawing.Point(241, 40);
			this.textboxWebHostAddress.Name = "textboxWebHostAddress";
			this.textboxWebHostAddress.Size = new System.Drawing.Size(445, 20);
			this.textboxWebHostAddress.TabIndex = 45;
			this.textboxWebHostAddress.TextChanged += new System.EventHandler(this.textboxWebHostAddress_TextChanged);
			// 
			// labelWebhostURL
			// 
			this.labelWebhostURL.Location = new System.Drawing.Point(109, 40);
			this.labelWebhostURL.Name = "labelWebhostURL";
			this.labelWebhostURL.Size = new System.Drawing.Size(131, 19);
			this.labelWebhostURL.TabIndex = 46;
			this.labelWebhostURL.Text = "Host Server Address";
			this.labelWebhostURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butUpdate
			// 
			this.butUpdate.Location = new System.Drawing.Point(221, 296);
			this.butUpdate.Name = "butUpdate";
			this.butUpdate.Size = new System.Drawing.Size(75, 24);
			this.butUpdate.TabIndex = 76;
			this.butUpdate.Text = "Update";
			this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
			// 
			// butSave
			// 
			this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butSave.Location = new System.Drawing.Point(1144, 660);
			this.butSave.Name = "butSave";
			this.butSave.Size = new System.Drawing.Size(75, 24);
			this.butSave.TabIndex = 77;
			this.butSave.Text = "&Save";
			this.butSave.Click += new System.EventHandler(this.butSave_Click);
			// 
			// checkDisableSigsPref
			// 
			this.checkDisableSigsPref.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkDisableSigsPref.Location = new System.Drawing.Point(5, 120);
			this.checkDisableSigsPref.Name = "checkDisableSigsPref";
			this.checkDisableSigsPref.Size = new System.Drawing.Size(250, 16);
			this.checkDisableSigsPref.TabIndex = 78;
			this.checkDisableSigsPref.Text = "Disable Web Form Signatures";
			this.checkDisableSigsPref.CheckedChanged += new System.EventHandler(this.checkDisableWebFormSignatures_CheckedChanged);
			// 
			// groupPrefs
			// 
			this.groupPrefs.Controls.Add(this.label15);
			this.groupPrefs.Controls.Add(this.checkAutoFillNameBDPref);
			this.groupPrefs.Controls.Add(this.label8);
			this.groupPrefs.Controls.Add(this.labelDateFormat);
			this.groupPrefs.Controls.Add(this.comboDateFormat);
			this.groupPrefs.Controls.Add(this.checkEnableAutoDownload);
			this.groupPrefs.Controls.Add(this.textboxWebHostAddress);
			this.groupPrefs.Controls.Add(this.butSavePrefs);
			this.groupPrefs.Controls.Add(this.labelBorderColor);
			this.groupPrefs.Controls.Add(this.checkDisableSigsPref);
			this.groupPrefs.Controls.Add(this.butWebformBorderColor);
			this.groupPrefs.Controls.Add(this.butChange);
			this.groupPrefs.Controls.Add(this.labelWebhostURL);
			this.groupPrefs.Location = new System.Drawing.Point(366, 12);
			this.groupPrefs.Name = "groupPrefs";
			this.groupPrefs.Size = new System.Drawing.Size(764, 199);
			this.groupPrefs.TabIndex = 79;
			this.groupPrefs.Text = "Preferences";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(258, 158);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(256, 34);
			this.label15.TabIndex = 88;
			this.label15.Text = "causes the Name and Birthdate box below in Construct URL to be checked by default" +
    "";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkAutoFillNameBDPref
			// 
			this.checkAutoFillNameBDPref.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkAutoFillNameBDPref.Location = new System.Drawing.Point(68, 161);
			this.checkAutoFillNameBDPref.Name = "checkAutoFillNameBDPref";
			this.checkAutoFillNameBDPref.Size = new System.Drawing.Size(187, 18);
			this.checkAutoFillNameBDPref.TabIndex = 83;
			this.checkAutoFillNameBDPref.Text = "Auto Fill Name and Birthdate";
			this.checkAutoFillNameBDPref.CheckedChanged += new System.EventHandler(this.checkAutoFillNameBDPref_CheckedChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(240, 3);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(448, 32);
			this.label8.TabIndex = 82;
			this.label8.Text = "Do not change this Address. It should be:\r\nhttps://opendentalsoft.com/WebHostSync" +
    "h/SheetsSynch.asmx";
			this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// labelDateFormat
			// 
			this.labelDateFormat.Location = new System.Drawing.Point(109, 65);
			this.labelDateFormat.Name = "labelDateFormat";
			this.labelDateFormat.Size = new System.Drawing.Size(131, 19);
			this.labelDateFormat.TabIndex = 81;
			this.labelDateFormat.Text = "Date Format";
			this.labelDateFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboDateFormat
			// 
			this.comboDateFormat.Location = new System.Drawing.Point(241, 65);
			this.comboDateFormat.Name = "comboDateFormat";
			this.comboDateFormat.Size = new System.Drawing.Size(180, 21);
			this.comboDateFormat.TabIndex = 80;
			this.comboDateFormat.SelectionChangeCommitted += new System.EventHandler(this.comboDateFormat_SelectionChangeCommitted);
			// 
			// checkEnableAutoDownload
			// 
			this.checkEnableAutoDownload.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkEnableAutoDownload.Location = new System.Drawing.Point(5, 140);
			this.checkEnableAutoDownload.Name = "checkEnableAutoDownload";
			this.checkEnableAutoDownload.Size = new System.Drawing.Size(250, 16);
			this.checkEnableAutoDownload.TabIndex = 79;
			this.checkEnableAutoDownload.Text = "Enable automatic download of web forms";
			this.checkEnableAutoDownload.CheckedChanged += new System.EventHandler(this.checkDisableAutoDownload_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 27);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(268, 49);
			this.label4.TabIndex = 80;
			this.label4.Text = "This is a list of all Web Forms that have been uploaded to the web server and are" +
    " currently available for patients to fill out";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(221, 197);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(133, 63);
			this.label5.TabIndex = 81;
			this.label5.Text = "Only Patient Forms and Medical Histories can be added, not Consent forms";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(220, 324);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(134, 63);
			this.label6.TabIndex = 82;
			this.label6.Text = "If changes were made to a form, this sends the updated version to the web server";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(219, 456);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(135, 48);
			this.label7.TabIndex = 83;
			this.label7.Text = "Remove selected form from the web server";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(29, 336);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(174, 79);
			this.label9.TabIndex = 89;
			this.label9.Text = "Additional parameters:\r\nDOID=Dental Office ID\r\nRKID=Registration Key ID\r\nWSDID=We" +
    "bSheetDefID";
			// 
			// FormWebFormSetup
			// 
			this.ClientSize = new System.Drawing.Size(1230, 696);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupPrefs);
			this.Controls.Add(this.butSave);
			this.Controls.Add(this.butUpdate);
			this.Controls.Add(this.groupConstructURL);
			this.Controls.Add(this.butDelete);
			this.Controls.Add(this.butAdd);
			this.Controls.Add(this.gridMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormWebFormSetup";
			this.Text = "Web Form Setup";
			this.Load += new System.EventHandler(this.FormWebFormSetup_Load);
			this.Shown += new System.EventHandler(this.FormWebFormSetup_Shown);
			this.groupConstructURL.ResumeLayout(false);
			this.groupConstructURL.PerformLayout();
			this.groupPrefs.ResumeLayout(false);
			this.groupPrefs.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TextBox textboxWebHostAddress;
		private System.Windows.Forms.Label labelWebhostURL;
		private System.Windows.Forms.Label labelBorderColor;
		private System.Windows.Forms.Button butWebformBorderColor;
		private OpenDental.UI.Button butChange;
		private OpenDental.UI.GridOD gridMain;
		private OpenDental.UI.Button butDelete;
		private OpenDental.UI.Button butAdd;
		private UI.Button butSavePrefs;
		private OpenDental.UI.GroupBox groupConstructURL;
		private System.Windows.Forms.TextBox textRedirectURL;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textNextForms;
		private System.Windows.Forms.Label label1;
		private UI.Button butNextForms;
		private UI.ComboBoxClinicPicker comboClinic;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textURLs;
		private UI.Button butUpdate;
		private OpenDental.UI.CheckBox checkAutoFillNameAndBirthdate;
		private UI.Button butSave;
		private OpenDental.UI.CheckBox checkDisableTypedSig;
		private UI.Button butCopyToClipboard;
		private UI.Button butNavigateTo;
		private OpenDental.UI.CheckBox checkDisableSigsPref;
		private OpenDental.UI.GroupBox groupPrefs;
		private OpenDental.UI.CheckBox checkEnableAutoDownload;
		private UI.ComboBox comboDateFormat;
		private System.Windows.Forms.Label labelDateFormat;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label labelConstructInfo;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private UI.CheckBox checkAutoFillNameBDPref;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label9;
	}
}