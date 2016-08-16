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
        public frmAdmin(String name)
        {
            InitializeComponent();
            lbName.Text = name.ToUpper();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            new frmManageUsers(lbName.Text).ShowDialog();
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            new frmManageAuthor().ShowDialog();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            new frm_UpdateBook().ShowDialog();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            new frm_ManageBorrow().ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }

        

        private void lbLogout_MouseHover(object sender, EventArgs e)
        {
            lbLogout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbLogout.BackColor = Color.Yellow;
        }

        private void lbLogout_MouseLeave(object sender, EventArgs e)
        {
            lbLogout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbLogout.BackColor = Color.Linen;
        }

        private void lbLogout_Click(object sender, EventArgs e)
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
