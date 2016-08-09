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
        public frmUser(string s)
        {
            InitializeComponent();
            label1.Text = s;
        }
    }
}
