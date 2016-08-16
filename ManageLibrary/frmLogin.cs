using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Tier.DataAccess;
using Business_Tier.Entities;
using System.Text.RegularExpressions;
using System.Threading;

namespace ManageLibrary
{
    public partial class frmLogin : Form
    {
        UserLoginDB ul = new UserLoginDB();

        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string us = txtUsername.Text;
            string pwd = txtPassword.Text;
            if (Regex.IsMatch(us, "^[a-zA-Z0-9]+$", RegexOptions.IgnoreCase))
            {
                UserLoginEn b = new UserLoginEn { Username = us, Password = pwd };
                int c = ul.getUsertoLogin(b).Tables[0].Rows.Count;
                int d = ul.checkRole(b).Tables[0].Rows.Count;
                if (c != 0)
                {
                    if (d != 0)
                    {
                        frmAdmin mngAdmin = new frmAdmin(txtUsername.Text);
                        mngAdmin.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmUser mngUser = new frmUser(txtUsername.Text);
                        mngUser.Show();
                        this.Hide();
                    }
                }
                if (c == 0)
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu sai");
                    txtUsername.Focus();
                }
            }else
            {
                MessageBox.Show("Tên đăng nhập không hợp lệ, chỉ dùng ký tự và số và không có khoảng trắng");
                txtUsername.Focus();
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmRegis frmRegis = new frmRegis();
            this.Hide();
            frmRegis.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string message = "Bạn có thực sự muốn thoát?";       
            string caption = "Thoát";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            // Set the border to a three-dimensional border.
            label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            // Set the border to a three-dimensional border.
            label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            // Set the border to a three-dimensional border.
            label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            // Set the border to a three-dimensional border.
            label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
//*