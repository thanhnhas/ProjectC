namespace ManageLibrary
{
    partial class frmManageUsers
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgwUser = new System.Windows.Forms.DataGridView();
            this.btnUserCancel = new System.Windows.Forms.Button();
            this.btnUserDelete = new System.Windows.Forms.Button();
            this.btnUserUpdate = new System.Windows.Forms.Button();
            this.btnUserSave = new System.Windows.Forms.Button();
            this.btnUserAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUsertype = new System.Windows.Forms.Label();
            this.rdtUser = new System.Windows.Forms.RadioButton();
            this.rdtAdmin = new System.Windows.Forms.RadioButton();
            this.txtUserCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bsUser = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwUser)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsUser)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgwUser);
            this.groupBox2.Location = new System.Drawing.Point(21, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1026, 192);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách độc giả";
            // 
            // dgwUser
            // 
            this.dgwUser.AllowUserToAddRows = false;
            this.dgwUser.AllowUserToDeleteRows = false;
            this.dgwUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwUser.Location = new System.Drawing.Point(6, 21);
            this.dgwUser.MultiSelect = false;
            this.dgwUser.Name = "dgwUser";
            this.dgwUser.ReadOnly = true;
            this.dgwUser.RowTemplate.Height = 24;
            this.dgwUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwUser.Size = new System.Drawing.Size(1014, 171);
            this.dgwUser.TabIndex = 0;
            // 
            // btnUserCancel
            // 
            this.btnUserCancel.Location = new System.Drawing.Point(830, 298);
            this.btnUserCancel.Name = "btnUserCancel";
            this.btnUserCancel.Size = new System.Drawing.Size(117, 50);
            this.btnUserCancel.TabIndex = 5;
            this.btnUserCancel.Text = "Thoát";
            this.btnUserCancel.UseVisualStyleBackColor = true;
            this.btnUserCancel.Click += new System.EventHandler(this.btnUserCancel_Click);
            // 
            // btnUserDelete
            // 
            this.btnUserDelete.Location = new System.Drawing.Point(653, 298);
            this.btnUserDelete.Name = "btnUserDelete";
            this.btnUserDelete.Size = new System.Drawing.Size(117, 50);
            this.btnUserDelete.TabIndex = 4;
            this.btnUserDelete.Text = "Xóa";
            this.btnUserDelete.UseVisualStyleBackColor = true;
            this.btnUserDelete.Click += new System.EventHandler(this.btnUserDelete_Click);
            // 
            // btnUserUpdate
            // 
            this.btnUserUpdate.Location = new System.Drawing.Point(475, 298);
            this.btnUserUpdate.Name = "btnUserUpdate";
            this.btnUserUpdate.Size = new System.Drawing.Size(117, 50);
            this.btnUserUpdate.TabIndex = 3;
            this.btnUserUpdate.Text = "Sửa";
            this.btnUserUpdate.UseVisualStyleBackColor = true;
            this.btnUserUpdate.Click += new System.EventHandler(this.btnUserUpdate_Click);
            // 
            // btnUserSave
            // 
            this.btnUserSave.Enabled = false;
            this.btnUserSave.Location = new System.Drawing.Point(308, 298);
            this.btnUserSave.Name = "btnUserSave";
            this.btnUserSave.Size = new System.Drawing.Size(117, 50);
            this.btnUserSave.TabIndex = 2;
            this.btnUserSave.Text = "Lưu";
            this.btnUserSave.UseVisualStyleBackColor = true;
            this.btnUserSave.Click += new System.EventHandler(this.btnUserSave_Click);
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.Location = new System.Drawing.Point(134, 298);
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Size = new System.Drawing.Size(117, 50);
            this.btnUserAdd.TabIndex = 1;
            this.btnUserAdd.Text = "Thêm";
            this.btnUserAdd.UseVisualStyleBackColor = true;
            this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUsertype);
            this.groupBox1.Controls.Add(this.rdtUser);
            this.groupBox1.Controls.Add(this.rdtAdmin);
            this.groupBox1.Controls.Add(this.txtUserCount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUserAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUserPhone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUserPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1040, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tài khoản";
            // 
            // txtUsertype
            // 
            this.txtUsertype.AutoSize = true;
            this.txtUsertype.ForeColor = System.Drawing.SystemColors.Control;
            this.txtUsertype.Location = new System.Drawing.Point(518, 178);
            this.txtUsertype.Name = "txtUsertype";
            this.txtUsertype.Size = new System.Drawing.Size(48, 17);
            this.txtUsertype.TabIndex = 19;
            this.txtUsertype.Text = "gbgh4";
            this.txtUsertype.TextChanged += new System.EventHandler(this.txtUsertype_TextChanged);
            // 
            // rdtUser
            // 
            this.rdtUser.AutoSize = true;
            this.rdtUser.Checked = true;
            this.rdtUser.Location = new System.Drawing.Point(308, 178);
            this.rdtUser.Name = "rdtUser";
            this.rdtUser.Size = new System.Drawing.Size(77, 21);
            this.rdtUser.TabIndex = 7;
            this.rdtUser.TabStop = true;
            this.rdtUser.Tag = "Type";
            this.rdtUser.Text = "Độc giả";
            this.rdtUser.UseVisualStyleBackColor = true;
            // 
            // rdtAdmin
            // 
            this.rdtAdmin.AutoSize = true;
            this.rdtAdmin.Location = new System.Drawing.Point(166, 180);
            this.rdtAdmin.Name = "rdtAdmin";
            this.rdtAdmin.Size = new System.Drawing.Size(110, 21);
            this.rdtAdmin.TabIndex = 6;
            this.rdtAdmin.Tag = "Type";
            this.rdtAdmin.Text = "Quản trị viên";
            this.rdtAdmin.UseVisualStyleBackColor = true;
            // 
            // txtUserCount
            // 
            this.txtUserCount.Enabled = false;
            this.txtUserCount.Location = new System.Drawing.Point(634, 130);
            this.txtUserCount.Name = "txtUserCount";
            this.txtUserCount.Size = new System.Drawing.Size(304, 22);
            this.txtUserCount.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(518, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Số sách mượn :";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(127, 130);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(304, 22);
            this.txtName.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tên :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Loại tài khoản :";
            // 
            // txtUserAddress
            // 
            this.txtUserAddress.Enabled = false;
            this.txtUserAddress.Location = new System.Drawing.Point(634, 33);
            this.txtUserAddress.Name = "txtUserAddress";
            this.txtUserAddress.Size = new System.Drawing.Size(304, 22);
            this.txtUserAddress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Địa Chỉ :";
            // 
            // txtUserPhone
            // 
            this.txtUserPhone.Enabled = false;
            this.txtUserPhone.Location = new System.Drawing.Point(634, 84);
            this.txtUserPhone.Name = "txtUserPhone";
            this.txtUserPhone.Size = new System.Drawing.Size(304, 22);
            this.txtUserPhone.TabIndex = 3;
            this.txtUserPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserPhone_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số Điện Thoại  :";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Enabled = false;
            this.txtUserPassword.Location = new System.Drawing.Point(127, 84);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.Size = new System.Drawing.Size(304, 22);
            this.txtUserPassword.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password :";
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(127, 33);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(304, 22);
            this.txtUsername.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username :";
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 580);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnUserCancel);
            this.Controls.Add(this.btnUserDelete);
            this.Controls.Add(this.btnUserUpdate);
            this.Controls.Add(this.btnUserSave);
            this.Controls.Add(this.btnUserAdd);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản Lý Tài Khoản";
            this.Load += new System.EventHandler(this.frmManageBorrowers_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwUser)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgwUser;
        private System.Windows.Forms.Button btnUserCancel;
        private System.Windows.Forms.Button btnUserDelete;
        private System.Windows.Forms.Button btnUserUpdate;
        private System.Windows.Forms.Button btnUserSave;
        private System.Windows.Forms.Button btnUserAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUserPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource bsUser;
        private System.Windows.Forms.TextBox txtUserCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdtUser;
        private System.Windows.Forms.RadioButton rdtAdmin;
        private System.Windows.Forms.Label txtUsertype;
    }
}