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
            UserLoginEn b = new UserLoginEn { Username = us, Password = pwd};
            int c = ul.getUsertoLogin(b).Tables[0].Rows.Count;
            int d = ul.checkRole(b).Tables[0].Rows.Count;
            if (c != 0)
            {
                if (d != 0)
                {
                    frmAdmin mngAdmin = new frmAdmin();
                    DialogResult r = mngAdmin.ShowDialog();
                } else
                {
                    frmUser mngUser = new frmUser();
                    DialogResult r = mngUser.ShowDialog();
                }
            }
            if (c==0)
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không hợp lệ!");
                txtUsername.Focus();
            }
        }
    }
}
