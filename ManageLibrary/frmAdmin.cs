using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageLibrary
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }
        public frmAdmin(string s)
        {
            InitializeComponent();
            label4.Text = s;
        }

        private void btnManageBorrowers_Click(object sender, EventArgs e)
        {
            frmManageUsers mus = new frmManageUsers();
            mus.ShowDialog();
        }
    }
}
