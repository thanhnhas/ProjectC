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
    public partial class frmManageAuthor : Form
    {
        public frmManageAuthor()
        {
            InitializeComponent();
        }
        private bool addOrEdit;
        AuthorData Adt = new AuthorData();
        DataTable dtAuthor;
        Author Au = new Author();
        public void EnableTxT(int t)
        {
            bool flag;
            if (t == 0) flag = true;
            else flag = false;
            txtAuthorID.Enabled = flag;
            txtAuthorName.Enabled = flag;
            
        }
        private void frmManageAuthor_Load(object sender, EventArgs e)
        {
            dtAuthor = Adt.GetAuthorByDataSet().Tables[0];

            dtAuthor.PrimaryKey = new DataColumn[] { dtAuthor.Columns["AuthorID"] };
            bsAuthorList.DataSource = dtAuthor;
            txtAuthorID.DataBindings.Clear();
            txtAuthorName.DataBindings.Clear();
            

            txtAuthorID.DataBindings.Add("Text", bsAuthorList, "AuthorID");
            txtAuthorName.DataBindings.Add("Text", bsAuthorList, "AuthorName");
            

            dgvAuthorList.DataSource = bsAuthorList;
            bnAuthorList.BindingSource = bsAuthorList;
        }

        private void btnAuthorAdd_Click(object sender, EventArgs e)
        {
            txtAuthorID.Clear();
            txtAuthorName.Clear();
            
            this.EnableTxT(0);
            btnAuthorAdd.Enabled = false;
            btnAuthorUpdate.Enabled = false;
            addOrEdit = true;
        }

        private void btnAuthorSave_Click(object sender, EventArgs e)
        {
            bool flag;
            Au.AuthorID = txtAuthorID.Text;
            Au.AuthorName = txtAuthorName.Text;
            

            if (addOrEdit == true)
                flag = Adt.addNewAuthor(Au);
            else
                flag = Adt.updateAuthor(Au);

            if (flag == true)
            {
                MessageBox.Show("Save successful.");
                this.EnableTxT(1);
                btnAuthorAdd.Enabled = true;
                btnAuthorUpdate.Enabled = true;
            }
            else
                MessageBox.Show("Save fail.");
            this.frmManageAuthor_Load(sender, e);
        }

        private void btnAuthorUpdate_Click(object sender, EventArgs e)
        {
            
            txtAuthorName.Clear();
            this.EnableTxT(0);
            btnAuthorUpdate.Enabled = false;
            btnAuthorAdd.Enabled = false;
            addOrEdit = false;
        }

        private void btnAuthorDelete_Click(object sender, EventArgs e)
        {
            string ID = txtAuthorID.Text;
            Author b = new Author { AuthorID = ID };
            if (Adt.deleteAuthor(b))
            {
                DataRow row = dtAuthor.Rows.Find(ID);
                dtAuthor.Rows.Remove(row);
                MessageBox.Show("Successful.");

            }
            else
            {
                MessageBox.Show("Fail.");
            }
        }

        private void btnAuthorExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
