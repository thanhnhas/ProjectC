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
            else 
            {
                b.username = lbUsername.Text;
                b.toDate =  DateTime.Parse(txtGHan.Text);
                bool flag = udb.updateUserBorrow(b);
                if (flag == true)
                {
                    MessageBox.Show("Gia hạn thành công.");
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
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGrid.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
            lbUsername.Text = dataGrid.CurrentRow.Cells[2].Value.ToString();
            txtCode.Text = dataGrid.CurrentRow.Cells[3].Value.ToString();
            txtfrDate.Text = dataGrid.CurrentRow.Cells[4].Value.ToString();
            txtToDate.Text = dataGrid.CurrentRow.Cells[5].Value.ToString();
            txtStatus.Text = dataGrid.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn thoát?", "Thoát",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
                this.Close();
        }
    }
}
