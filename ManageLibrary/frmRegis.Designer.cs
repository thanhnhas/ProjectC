namespace ManageLibrary
{
    partial class frmRegis
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbShowErrID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRePwd = new System.Windows.Forms.TextBox();
            this.lbShowErrPwd = new System.Windows.Forms.Label();
            this.txtReCap = new System.Windows.Forms.TextBox();
            this.lbShowErrCap = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReCap = new System.Windows.Forms.Button();
            this.txtCapcha = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài khoản :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu :";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(375, 15);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(191, 22);
            this.txtID.TabIndex = 0;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(375, 63);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(232, 22);
            this.txtPwd.TabIndex = 1;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(240, 262);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 28);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(508, 262);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbShowErrID
            // 
            this.lbShowErrID.AutoSize = true;
            this.lbShowErrID.Location = new System.Drawing.Point(291, 43);
            this.lbShowErrID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbShowErrID.Name = "lbShowErrID";
            this.lbShowErrID.Size = new System.Drawing.Size(79, 17);
            this.lbShowErrID.TabIndex = 6;
            this.lbShowErrID.Text = "lbShowMsg";
            this.lbShowErrID.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Xác nhận mật khẩu :";
            // 
            // txtRePwd
            // 
            this.txtRePwd.Location = new System.Drawing.Point(375, 95);
            this.txtRePwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRePwd.Name = "txtRePwd";
            this.txtRePwd.PasswordChar = '*';
            this.txtRePwd.Size = new System.Drawing.Size(232, 22);
            this.txtRePwd.TabIndex = 2;
            // 
            // lbShowErrPwd
            // 
            this.lbShowErrPwd.AutoSize = true;
            this.lbShowErrPwd.Location = new System.Drawing.Point(375, 128);
            this.lbShowErrPwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbShowErrPwd.Name = "lbShowErrPwd";
            this.lbShowErrPwd.Size = new System.Drawing.Size(46, 17);
            this.lbShowErrPwd.TabIndex = 9;
            this.lbShowErrPwd.Text = "label5";
            this.lbShowErrPwd.Visible = false;
            // 
            // txtReCap
            // 
            this.txtReCap.Location = new System.Drawing.Point(361, 220);
            this.txtReCap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtReCap.Name = "txtReCap";
            this.txtReCap.Size = new System.Drawing.Size(91, 22);
            this.txtReCap.TabIndex = 4;
            // 
            // lbShowErrCap
            // 
            this.lbShowErrCap.AutoSize = true;
            this.lbShowErrCap.Location = new System.Drawing.Point(461, 224);
            this.lbShowErrCap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbShowErrCap.Name = "lbShowErrCap";
            this.lbShowErrCap.Size = new System.Drawing.Size(46, 17);
            this.lbShowErrCap.TabIndex = 12;
            this.lbShowErrCap.Text = "label3";
            this.lbShowErrCap.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(375, 166);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Capcha";
            // 
            // btnReCap
            // 
            this.btnReCap.Location = new System.Drawing.Point(535, 188);
            this.btnReCap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReCap.Name = "btnReCap";
            this.btnReCap.Size = new System.Drawing.Size(41, 28);
            this.btnReCap.TabIndex = 3;
            this.btnReCap.Text = "Đổi";
            this.btnReCap.UseVisualStyleBackColor = true;
            this.btnReCap.Click += new System.EventHandler(this.btnReCap_Click);
            // 
            // txtCapcha
            // 
            this.txtCapcha.Location = new System.Drawing.Point(295, 192);
            this.txtCapcha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCapcha.Name = "txtCapcha";
            this.txtCapcha.ReadOnly = true;
            this.txtCapcha.Size = new System.Drawing.Size(231, 22);
            this.txtCapcha.TabIndex = 10;
            this.txtCapcha.TabStop = false;
            // 
            // frmRegis
            // 
            this.AcceptButton = this.btnRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(844, 308);
            this.Controls.Add(this.btnReCap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbShowErrCap);
            this.Controls.Add(this.txtReCap);
            this.Controls.Add(this.txtCapcha);
            this.Controls.Add(this.lbShowErrPwd);
            this.Controls.Add(this.txtRePwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbShowErrID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRegis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbShowErrID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRePwd;
        private System.Windows.Forms.Label lbShowErrPwd;
        private System.Windows.Forms.TextBox txtReCap;
        private System.Windows.Forms.Label lbShowErrCap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReCap;
        private System.Windows.Forms.TextBox txtCapcha;
    }
}