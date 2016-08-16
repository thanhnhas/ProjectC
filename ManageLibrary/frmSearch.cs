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

namespace ManageLibrary
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {         
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BorrowDetailsData bdd = new BorrowDetailsData();
            if (radioButton1.Checked)
            {
                DataTable dtBook = new DataTable();
                dtBook = bdd.GetBookListISBNByDataSet(txtSearch.Text).Tables[0];
                dataGridView1.DataSource = dtBook;
                dataGridView1.Columns.Remove("Quantity");
                dataGridView1.Columns.Remove("SLGoc");
                dataGridView1.Columns.Remove("SLMuon");
            }
            if (radioButton2.Checked)
            {
                DataTable dtBook = new DataTable();
                dtBook = bdd.GetBookListNameByDataSet(txtSearch.Text).Tables[0];
                dataGridView1.DataSource = dtBook;
                dataGridView1.Columns.Remove("Quantity");
                dataGridView1.Columns.Remove("SLGoc");
                dataGridView1.Columns.Remove("SLMuon");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
