namespace Retailer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBirthdate = new System.Windows.Forms.MaskedTextBox();
            this.txtWalletid = new System.Windows.Forms.MaskedTextBox();
            this.dataGridShow = new System.Windows.Forms.DataGridView();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblFrozen = new System.Windows.Forms.Label();
            this.lblSponsor_id = new System.Windows.Forms.Label();
            this.lblShare = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.retailersDate = new System.Windows.Forms.DateTimePicker();
            this.txtFrozen = new System.Windows.Forms.TextBox();
            this.txtShare = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblProvince = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFname = new System.Windows.Forms.Label();
            this.lblWalletid = new System.Windows.Forms.Label();
            this.txtSponsor_id = new System.Windows.Forms.MaskedTextBox();
            this.lblmsg = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBox_City = new System.Windows.Forms.ComboBox();
            this.comboBox_Province = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.walletid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.province = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frozen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sponsor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.share = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShow)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBirthdate
            // 
            this.txtBirthdate.Location = new System.Drawing.Point(158, 142);
            this.txtBirthdate.Margin = new System.Windows.Forms.Padding(4);
            this.txtBirthdate.Mask = "00/00/0000";
            this.txtBirthdate.Name = "txtBirthdate";
            this.txtBirthdate.Size = new System.Drawing.Size(132, 23);
            this.txtBirthdate.TabIndex = 44;
            // 
            // txtWalletid
            // 
            this.txtWalletid.Location = new System.Drawing.Point(158, 35);
            this.txtWalletid.Margin = new System.Windows.Forms.Padding(4);
            this.txtWalletid.Mask = "0000-0000-000";
            this.txtWalletid.Name = "txtWalletid";
            this.txtWalletid.Size = new System.Drawing.Size(132, 23);
            this.txtWalletid.TabIndex = 41;
            // 
            // dataGridShow
            // 
            this.dataGridShow.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridShow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.walletid,
            this.fname,
            this.lname,
            this.birthdate,
            this.address,
            this.province,
            this.city,
            this.balance,
            this.frozen,
            this.sponsor_id,
            this.share,
            this.email,
            this.password,
            this.type});
            this.dataGridShow.EnableHeadersVisualStyles = false;
            this.dataGridShow.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridShow.Location = new System.Drawing.Point(326, 0);
            this.dataGridShow.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridShow.Name = "dataGridShow";
            this.dataGridShow.ReadOnly = true;
            this.dataGridShow.Size = new System.Drawing.Size(895, 666);
            this.dataGridShow.TabIndex = 64;
            this.dataGridShow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridShow_CellContentClick);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(408, 119);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 16);
            this.lblResult.TabIndex = 63;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(51, 478);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(36, 16);
            this.lblType.TabIndex = 62;
            this.lblType.Text = "Type";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(158, 414);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(132, 23);
            this.txtEmail.TabIndex = 52;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(158, 446);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(132, 23);
            this.txtPassword.TabIndex = 53;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(158, 478);
            this.txtType.Margin = new System.Windows.Forms.Padding(4);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(132, 23);
            this.txtType.TabIndex = 54;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(41, 277);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(53, 16);
            this.lblBalance.TabIndex = 58;
            this.lblBalance.Text = "Balance";
            // 
            // lblFrozen
            // 
            this.lblFrozen.AutoSize = true;
            this.lblFrozen.Location = new System.Drawing.Point(49, 318);
            this.lblFrozen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFrozen.Name = "lblFrozen";
            this.lblFrozen.Size = new System.Drawing.Size(47, 16);
            this.lblFrozen.TabIndex = 57;
            this.lblFrozen.Text = "Frozen";
            // 
            // lblSponsor_id
            // 
            this.lblSponsor_id.AutoSize = true;
            this.lblSponsor_id.Location = new System.Drawing.Point(26, 350);
            this.lblSponsor_id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSponsor_id.Name = "lblSponsor_id";
            this.lblSponsor_id.Size = new System.Drawing.Size(69, 16);
            this.lblSponsor_id.TabIndex = 56;
            this.lblSponsor_id.Text = "Sponsor_id";
            // 
            // lblShare
            // 
            this.lblShare.AutoSize = true;
            this.lblShare.Location = new System.Drawing.Point(54, 382);
            this.lblShare.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShare.Name = "lblShare";
            this.lblShare.Size = new System.Drawing.Size(41, 16);
            this.lblShare.TabIndex = 55;
            this.lblShare.Text = "Share";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(58, 414);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(40, 16);
            this.lblEmail.TabIndex = 54;
            this.lblEmail.Text = "Email";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(30, 449);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(64, 16);
            this.lblPassword.TabIndex = 53;
            this.lblPassword.Text = "Password";
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Location = new System.Drawing.Point(32, 142);
            this.lblBirthdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(62, 16);
            this.lblBirthdate.TabIndex = 52;
            this.lblBirthdate.Text = "Birthdate";
            // 
            // retailersDate
            // 
            this.retailersDate.Location = new System.Drawing.Point(25, 4);
            this.retailersDate.Margin = new System.Windows.Forms.Padding(4);
            this.retailersDate.Name = "retailersDate";
            this.retailersDate.Size = new System.Drawing.Size(265, 23);
            this.retailersDate.TabIndex = 40;
            // 
            // txtFrozen
            // 
            this.txtFrozen.Location = new System.Drawing.Point(158, 318);
            this.txtFrozen.Margin = new System.Windows.Forms.Padding(4);
            this.txtFrozen.Name = "txtFrozen";
            this.txtFrozen.Size = new System.Drawing.Size(132, 23);
            this.txtFrozen.TabIndex = 49;
            // 
            // txtShare
            // 
            this.txtShare.Location = new System.Drawing.Point(158, 382);
            this.txtShare.Margin = new System.Windows.Forms.Padding(4);
            this.txtShare.Name = "txtShare";
            this.txtShare.Size = new System.Drawing.Size(132, 23);
            this.txtShare.TabIndex = 51;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Location = new System.Drawing.Point(158, 175);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(132, 23);
            this.txtAddress.TabIndex = 45;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(158, 277);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(132, 23);
            this.txtBalance.TabIndex = 48;
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(158, 109);
            this.txtLname.Margin = new System.Windows.Forms.Padding(4);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(132, 23);
            this.txtLname.TabIndex = 43;
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(158, 70);
            this.txtFname.Margin = new System.Windows.Forms.Padding(4);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(132, 23);
            this.txtFname.TabIndex = 42;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(62, 244);
            this.lblCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(32, 16);
            this.lblCity.TabIndex = 41;
            this.lblCity.Text = "City";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(39, 175);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(55, 16);
            this.lblAddress.TabIndex = 40;
            this.lblAddress.Text = "Address";
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(36, 209);
            this.lblProvince.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(58, 16);
            this.lblProvince.TabIndex = 39;
            this.lblProvince.Text = "Province";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(23, 109);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(71, 16);
            this.lblLastName.TabIndex = 38;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Location = new System.Drawing.Point(22, 77);
            this.lblFname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(72, 16);
            this.lblFname.TabIndex = 37;
            this.lblFname.Text = "First Name";
            // 
            // lblWalletid
            // 
            this.lblWalletid.AutoSize = true;
            this.lblWalletid.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalletid.Location = new System.Drawing.Point(22, 42);
            this.lblWalletid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWalletid.Name = "lblWalletid";
            this.lblWalletid.Size = new System.Drawing.Size(59, 16);
            this.lblWalletid.TabIndex = 36;
            this.lblWalletid.Text = "WalletID";
            // 
            // txtSponsor_id
            // 
            this.txtSponsor_id.Location = new System.Drawing.Point(158, 350);
            this.txtSponsor_id.Margin = new System.Windows.Forms.Padding(4);
            this.txtSponsor_id.Mask = "0000-0000-000";
            this.txtSponsor_id.Name = "txtSponsor_id";
            this.txtSponsor_id.Size = new System.Drawing.Size(132, 23);
            this.txtSponsor_id.TabIndex = 50;
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblmsg.Location = new System.Drawing.Point(348, 17);
            this.lblmsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 25);
            this.lblmsg.TabIndex = 69;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(112, 597);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 48);
            this.btnClear.TabIndex = 56;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(215)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.comboBox_City);
            this.panel1.Controls.Add(this.comboBox_Province);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.retailersDate);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.txtWalletid);
            this.panel1.Controls.Add(this.lblWalletid);
            this.panel1.Controls.Add(this.txtSponsor_id);
            this.panel1.Controls.Add(this.lblFname);
            this.panel1.Controls.Add(this.txtBirthdate);
            this.panel1.Controls.Add(this.txtFname);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.lblLastName);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtLname);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblBirthdate);
            this.panel1.Controls.Add(this.txtType);
            this.panel1.Controls.Add(this.lblAddress);
            this.panel1.Controls.Add(this.lblFrozen);
            this.panel1.Controls.Add(this.lblBalance);
            this.panel1.Controls.Add(this.lblSponsor_id);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.lblShare);
            this.panel1.Controls.Add(this.lblProvince);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.txtFrozen);
            this.panel1.Controls.Add(this.txtShare);
            this.panel1.Controls.Add(this.lblCity);
            this.panel1.Controls.Add(this.txtBalance);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 666);
            this.panel1.TabIndex = 71;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.Info;
            this.btnAdd.Location = new System.Drawing.Point(12, 526);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 40);
            this.btnAdd.TabIndex = 67;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(230)))), ((int)(((byte)(118)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(10, 597);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 48);
            this.btnSave.TabIndex = 66;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(115)))), ((int)(((byte)(116)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(220, 597);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 48);
            this.btnCancel.TabIndex = 65;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboBox_City
            // 
            this.comboBox_City.FormattingEnabled = true;
            this.comboBox_City.Location = new System.Drawing.Point(158, 243);
            this.comboBox_City.Name = "comboBox_City";
            this.comboBox_City.Size = new System.Drawing.Size(132, 24);
            this.comboBox_City.TabIndex = 47;
            // 
            // comboBox_Province
            // 
            this.comboBox_Province.FormattingEnabled = true;
            this.comboBox_Province.Location = new System.Drawing.Point(158, 206);
            this.comboBox_Province.Name = "comboBox_Province";
            this.comboBox_Province.Size = new System.Drawing.Size(132, 24);
            this.comboBox_Province.TabIndex = 46;
            this.comboBox_Province.SelectedIndexChanged += new System.EventHandler(this.comboBox_Province_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Info;
            this.btnDelete.Location = new System.Drawing.Point(220, 526);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 40);
            this.btnDelete.TabIndex = 64;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.Info;
            this.btnEdit.Location = new System.Drawing.Point(112, 526);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 40);
            this.btnEdit.TabIndex = 63;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 150;
            // 
            // walletid
            // 
            this.walletid.DataPropertyName = "walletid";
            this.walletid.HeaderText = "Wallet ID";
            this.walletid.Name = "walletid";
            this.walletid.ReadOnly = true;
            this.walletid.Width = 150;
            // 
            // fname
            // 
            this.fname.DataPropertyName = "FName";
            this.fname.HeaderText = "First Name";
            this.fname.Name = "fname";
            this.fname.ReadOnly = true;
            this.fname.Width = 150;
            // 
            // lname
            // 
            this.lname.DataPropertyName = "LName";
            this.lname.HeaderText = "Last Name";
            this.lname.Name = "lname";
            this.lname.ReadOnly = true;
            this.lname.Width = 150;
            // 
            // birthdate
            // 
            this.birthdate.DataPropertyName = "Birthdate";
            this.birthdate.HeaderText = "Birthdate";
            this.birthdate.Name = "birthdate";
            this.birthdate.ReadOnly = true;
            // 
            // address
            // 
            this.address.DataPropertyName = "Address";
            this.address.HeaderText = "Address";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // province
            // 
            this.province.DataPropertyName = "Province";
            this.province.HeaderText = "Province";
            this.province.Name = "province";
            this.province.ReadOnly = true;
            // 
            // city
            // 
            this.city.DataPropertyName = "City";
            this.city.HeaderText = "City";
            this.city.Name = "city";
            this.city.ReadOnly = true;
            // 
            // balance
            // 
            this.balance.DataPropertyName = "Balance";
            this.balance.HeaderText = "Balance";
            this.balance.Name = "balance";
            this.balance.ReadOnly = true;
            this.balance.Width = 50;
            // 
            // frozen
            // 
            this.frozen.DataPropertyName = "Frozen";
            this.frozen.HeaderText = "Frozen";
            this.frozen.Name = "frozen";
            this.frozen.ReadOnly = true;
            this.frozen.Width = 50;
            // 
            // sponsor_id
            // 
            this.sponsor_id.DataPropertyName = "Sponsor_Id";
            this.sponsor_id.HeaderText = "Sponsor_id";
            this.sponsor_id.Name = "sponsor_id";
            this.sponsor_id.ReadOnly = true;
            this.sponsor_id.Width = 200;
            // 
            // share
            // 
            this.share.DataPropertyName = "Share";
            this.share.HeaderText = "Share";
            this.share.Name = "share";
            this.share.ReadOnly = true;
            // 
            // email
            // 
            this.email.DataPropertyName = "Email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // password
            // 
            this.password.DataPropertyName = "Password";
            this.password.HeaderText = "Password";
            this.password.Name = "password";
            this.password.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "Type";
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1220, 668);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.dataGridShow);
            this.Controls.Add(this.lblResult);
            this.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Retailer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShow)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion





        private System.Windows.Forms.DateTimePicker retailersDate;
        private System.Windows.Forms.MaskedTextBox txtWalletid;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.MaskedTextBox txtBirthdate;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtFrozen;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.MaskedTextBox txtSponsor_id;
        private System.Windows.Forms.TextBox txtShare;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtType;

        private System.Windows.Forms.Label lblResult;

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblWalletid;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblFrozen;
        private System.Windows.Forms.Label lblSponsor_id;
        private System.Windows.Forms.Label lblShare;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.DataGridView dataGridShow;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox comboBox_City;
        private System.Windows.Forms.ComboBox comboBox_Province;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn walletid;
        private System.Windows.Forms.DataGridViewTextBoxColumn fname;
        private System.Windows.Forms.DataGridViewTextBoxColumn lname;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn province;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn frozen;
        private System.Windows.Forms.DataGridViewTextBoxColumn sponsor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn share;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;


    }
}

