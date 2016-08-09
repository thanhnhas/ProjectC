﻿using System;
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
using System.Data;

namespace ManageLibrary
{
    public partial class frmChangeInfo : Form
    {
        public frmChangeInfo(string s)
        {
            InitializeComponent();
            txtUsername.Text = s;
        }

        UserData udt = new UserData();
        DataTable dtUser;
        Users u = new Users();
        private void frmChangeInfo_Load(object sender, EventArgs e)
        {
            dtUser = udt.GetUserByUsername(txtUsername.Text).Tables[0];
            dtUser.PrimaryKey = new DataColumn[] { dtUser.Columns["username"] };
            txtAddress.DataBindings.Add("Text", dtUser, "Address");
            txtPhone.DataBindings.Add("Text", dtUser, "Phone Number");
            txtName.DataBindings.Add("Text", dtUser, "Full Name");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = false;
            u.UserName = txtUsername.Text;
            u.Name = txtName.Text;
            u.UserAddress = txtAddress.Text;
            u.UserPhone = txtPhone.Text;
            bool  flag = udt.updateInfoUser(u);
            if (flag == true)
            {
                MessageBox.Show("Save successful.");
            }
            else
            {
                MessageBox.Show("Save fail.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}