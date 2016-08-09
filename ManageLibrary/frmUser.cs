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
        private void frmUser_Load(object sender, EventArgs e)
        {
           dtUser = udt.GetUserByUsername(txtUsernme.Text).Tables[0];
            dtUser.PrimaryKey = new DataColumn[] { dtUser.Columns["username"] };
            txtAddress.DataBindings.Add("Text",dtUser ,"Address");
            txtPhone.DataBindings.Add("Text", dtUser, "Phone Number");
            txtEmail.DataBindings.Add("Text", dtUser, "Email");
            txtPhone.Enabled = false;
            txtAddress.Enabled = false;
            txtEmail.Enabled = false;
            txtUsernme.Enabled = false;
        }
    }
    
}
