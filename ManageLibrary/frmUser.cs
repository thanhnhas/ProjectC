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
        public frmUser()
        {
            InitializeComponent();
        }
        private bool check;
        UserData udt = new UserData();
        DataTable dtUser;
        Users urs = new Users();
        public void EnableTXT(int n)
        {
            bool flag;
            if (n == 0) flag = true;
            else flag = false;
            txtUsernme.Enabled = flag;
            txtEmail.Enabled = flag;
            txtPhone.Enabled = flag;
            txtAddress.Enabled = flag;
        }
    }
}
