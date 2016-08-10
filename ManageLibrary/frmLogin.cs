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

namespace ManageLibrary
{
    public partial class frmLogin : Form
    {
        DataTable dt = new DataTable();
        UserLogin ul = new UserLogin();

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
                        this.Hide();
                        mngAdmin.ShowDialog();
                    }
                    else
                    {
                        frmUser mngUser = new frmUser(txtUsername.Text);
                        this.Hide();
                        mngUser.ShowDialog();
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
            frmAdmin mngAdmin = new frmAdmin(txtUsername.Text);
            this.Hide();
            mngAdmin.ShowDialog();
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
    }
}
