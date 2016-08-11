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
    public partial class frmChangePass : Form
    {
        public frmChangePass(string username,string password)
        {
            InitializeComponent();
            lbusername.Text = username;
            lbpassword.Text = password;
        }
        UserData udt = new UserData();
        DataTable dtUser;
        Users u = new Users();
        private void frmChangePass_Load(object sender, EventArgs e)
        {
            txtPassNew.Clear();
            txtPassOld.Clear();
            txtPassConfirm.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (txtPassOld.Text.Equals("") || txtPassNew.Text.Equals("") || txtPassConfirm.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
                check = false;
            }
            if (!txtPassOld.Text.Equals(lbpassword.Text))
            {
                MessageBox.Show("Mật khẩu cũ không đúng");
                txtPassOld.Focus();
                check = false;
            }
            else if (txtPassNew.Text.Length < 6 || txtPassNew.Text.Length > 20)
            {
                MessageBox.Show("Mật khẩu có độ dài từ 6-20 ký tự");
                txtPassNew.Focus();
                check = false;
            }
            else if (!txtPassConfirm.Text.Equals(txtPassNew.Text))
            {
                MessageBox.Show("Mật khẩu xác nhận không hợp lệ");
                txtPassConfirm.Clear();
                txtPassNew.Clear();
                txtPassNew.Focus();
                check = false;
            }
            else if (check)
            {
                u.UserName = lbusername.Text;
                u.UserPassword = txtPassNew.Text;
                if (udt.updatePassword(u))
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật mật khẩu không thành công");
                }
            }
        }
    }
}
