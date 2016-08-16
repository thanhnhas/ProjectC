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
    public partial class frmUser : Form
    {
        public frmUser(string s)
        {
            InitializeComponent();
            txtUsernme.Text = s;
        }
        UserData udt = new UserData();
        DataTable dtUser;
        Users u = new Users();
        private void loadData()
            //load form
        {
            dtUser = udt.GetUserByUsername(txtUsernme.Text).Tables[0];
            //dtUser.PrimaryKey = new DataColumn[] { dtUser.Columns["username"] };
            txtPassword.DataBindings.Clear();
            txtUsernme.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtPassword.DataBindings.Add("Text", dtUser, "Password");
            txtAddress.DataBindings.Add("Text", dtUser, "Address");
            txtPhone.DataBindings.Add("Text", dtUser, "Phone Number");
            txtFullName.DataBindings.Add("Text", dtUser, "Full Name");
        }
        public void frmUser_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            frmChangeInfo mngChange = new frmChangeInfo(txtUsernme.Text);
            mngChange.ShowDialog();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            frmChangePass ChangePass = new frmChangePass(txtUsernme.Text,txtPassword.Text);
            ChangePass.ShowDialog();
        }

        private void btnSuggest_Click(object sender, EventArgs e)
        {
            frmNewBook suggest = new frmNewBook(txtUsernme.Text);
            suggest.ShowDialog();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            frmUserManageBook mnb = new frmUserManageBook(txtUsernme.Text);
            mnb.ShowDialog();
        }

     

        private void frmUser_Activated(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn đăng xuất?", "Thoát",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Application.Restart();
            }
        }
    }
    
}
