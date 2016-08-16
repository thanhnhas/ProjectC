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
using Business_Tier.DataAccess;
using Business_Tier.Entities;

namespace ManageLibrary
{
    public partial class frmUserManageBook : Form
    {
        public frmUserManageBook(string username)
        {
            InitializeComponent();
            lbUsername.Text = username;
        }
        UserBorrow b = new UserBorrow();
        DataTable dtBorrow;
        UserBorrowData udb = new UserBorrowData();
        //xin gia hạn
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TimeSpan songay = txtGHan.Value - txtToDate.Value;
            int ngay = Convert.ToInt32(songay.TotalDays);
            string check = txtStatus.Text;
             if (ngay >= 10)
            {
                MessageBox.Show("Bạn không được gia hạn thêm quá 10 ngày");
                txtGHan.Focus();
            }
             else if(ngay <= 0)
            {
                MessageBox.Show("Ngày gia hạn không hợp lệ");
                txtGHan.Focus();
            }
            else 
            {
                b.username = lbUsername.Text;
                b.toDate =  DateTime.Parse(txtGHan.Text);
                bool flag = udb.updateUserBorrow(b);
                if (flag == true)
                {
                    MessageBox.Show("Gia hạn thành công.");
                    frmUserManageBook_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Bạn đã hết lượt gia hạn");
                }
            }
        }

        private void frmUserManageBook_Load(object sender, EventArgs e)
        {
            dtBorrow = udb.getBorrowByDataSet(lbUsername.Text).Tables[0];
            //dtBorrow.PrimaryKey = new DataColumn[] { dtBorrow.Columns["username"] };
            dataGrid.DataSource = dtBorrow;
            txtStatus.Enabled = false;
            txtfrDate.Enabled = false;
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtID.Enabled = false;
            txtToDate.Enabled = false;
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            lbUsername.DataBindings.Clear();
            txtCode.DataBindings.Clear();
            txtfrDate.DataBindings.Clear();
            txtToDate.DataBindings.Clear();
            txtStatus.DataBindings.Clear();
            txtID.DataBindings.Add("Text", dtBorrow, "Mã HD");
            txtName.DataBindings.Add("Text", dtBorrow, "Bookname");
            lbUsername.DataBindings.Add("Text", dtBorrow, "username");
            txtCode.DataBindings.Add("Text", dtBorrow, "ISBN");
            txtfrDate.DataBindings.Add("Text", dtBorrow, "fromdate");
            txtToDate.DataBindings.Add("Text", dtBorrow, "todate");
            txtStatus.DataBindings.Add("Text", dtBorrow, "status");
            if(dtBorrow.Rows.Count == 0)
            {
                btnUpdate.Enabled = false;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
                this.Close();
        }

       
    }
}
