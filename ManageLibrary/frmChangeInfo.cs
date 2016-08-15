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
    public partial class frmChangeInfo : Form
    {
        public frmChangeInfo(string s)
        {
            InitializeComponent();
            txtUsername.Text = s;
        }
        //đổi thông tin
        UserData udt = new UserData();
        DataTable dtUser;
        Users u = new Users();
        private void frmChangeInfo_Load(object sender, EventArgs e)
        {
            dtUser = udt.GetUserByUsername(txtUsername.Text).Tables[0];
            dtUser.PrimaryKey = new DataColumn[] { dtUser.Columns["username"] };
            txtName.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtAddress.DataBindings.Add("Text", dtUser, "Address");
            txtPhone.DataBindings.Add("Text", dtUser, "Phone Number");
            txtName.DataBindings.Add("Text", dtUser, "Full Name");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = false;
            if (txtAddress.Text.Equals("") || txtName.Text.Equals("") || txtPhone.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }
            else
            {
                u.UserName = txtUsername.Text;
                u.Name = txtName.Text;
                u.UserAddress = txtAddress.Text;
                u.UserPhone = txtPhone.Text;
                bool flag = udt.updateInfoUser(u);
                if (flag == true)
                {
                    MessageBox.Show("Cập nhật thông tin thành công.");
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn thoát?", "Thoát",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
                this.Close();
        }


        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Char.IsDigit(e.KeyChar) --> kiểm tra xem phím vừa nhập vào textbox có phải là ký tự số hay không, hàm này trả về kiểu bool
            //Char.IsContro(e.KeyChar)-- > kiểm tra xem phím vừa nhập vào textbox có phải là các ký tự điều khiển
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
