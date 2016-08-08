using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Tier;
using Business_Tier;

namespace ManageLibrary
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }
        DT_User udt = new DT_User();
        DataTable dtUser;
        Users u = new Users();
        public void EnableTxT(int t)
        {
            bool flag;
            if (t == 0) flag = true;
            else flag = false;
            txtUsername.Enabled = flag;
            txtUserPassword.Enabled = flag;
            txtUsertype.Enabled = flag;
            txtName.Enabled = flag;
            txtUserAddress.Enabled = flag;
            txtUserPhone.Enabled = flag;
            txtUserCount.Enabled = flag;
            txtUserStatus.Enabled = flag;

        }
       
        private void frmManageBorrowers_Load(object sender, EventArgs e)
        {
            dtUser = udt.getUser();
            dtUser.PrimaryKey = new DataColumn[] { dtUser.Columns["username"] };
            bsUser.DataSource = dtUser;
            txtUsername.DataBindings.Clear();
            txtUserPassword.DataBindings.Clear();
            txtUsertype.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtUserAddress.DataBindings.Clear();
            txtUserPhone.DataBindings.Clear();
            txtUserCount.DataBindings.Clear();
            txtUserStatus.DataBindings.Clear();
            
            

            txtUsername.DataBindings.Add("Text", bsUser, "username");
            txtUserPassword.DataBindings.Add("Text", bsUser, "password");
            txtUsertype.DataBindings.Add("Text", bsUser, "type");
            txtName.DataBindings.Add("Text", bsUser, "name");
            txtUserAddress.DataBindings.Add("Text", bsUser, "address");
            txtUserPhone.DataBindings.Add("Text", bsUser, "phone");
            txtUserCount.DataBindings.Add("Text", bsUser, "count");
            txtUserStatus.DataBindings.Add("Text", bsUser, "status");


            dgwUser.DataSource = bsUser;
            bnUser.BindingSource = bsUser;
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {            
            txtUsername.Clear();
            txtUserPassword.Clear();
            txtUsertype.Clear();
            txtName.Clear();
            txtUserAddress.Clear();
            txtUserPhone.Clear();
            txtUserCount.Clear();
            txtUserStatus.Clear();
            this.EnableTxT(0);
            btnUserAdd.Enabled = false;

        }

        private void btnUserSave_Click(object sender, EventArgs e)
        {
            bool flag;
            u.UserName = txtUsername.Text;
            u.UserPassword = txtUserPassword.Text;
            u.UserType = int.Parse(txtUsertype.Text);
            u.Name = txtName.Text;
            u.UserAddress = txtUserAddress.Text;
            u.UserPhone = txtUserPhone.Text;
            u.UserCount = int.Parse(txtUserCount.Text);
            u.UserStatus = int.Parse(txtUserStatus.Text);
            
            flag=udt.AddUser(u);

            if (flag == true)
            {
                MessageBox.Show("Save successful.");
                this.EnableTxT(1);
                btnUserAdd.Enabled = true;
            }
            else
                MessageBox.Show("Save fail.");
            this.frmManageBorrowers_Load( sender,  e);

        }

        
    }
}
