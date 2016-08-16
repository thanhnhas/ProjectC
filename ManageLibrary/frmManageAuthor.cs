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
        private  bool Authorisvalid()
        {
            if (string.IsNullOrEmpty(txtAuthorID.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tác giả!", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtAuthorName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả!", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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
            btnAuthorDelete.Enabled = false;
            btnAuthorUpdate.Enabled = false;
            btnAuthorSave.Enabled = true;
            addOrEdit = true;
        }

        private void btnAuthorSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Authorisvalid() == false)
                {
                    return;
                }
                bool flag;
                Au.AuthorID = txtAuthorID.Text;
                Au.AuthorName = txtAuthorName.Text;


                if (addOrEdit == true)
                    flag = Adt.addNewAuthor(Au);
                else
                    flag = Adt.updateAuthor(Au);

                if (flag == true)
                {
                    MessageBox.Show("Đã thêm/cập nhật mã tác giả " + txtAuthorID.Text +
                            " vào dữ liệu!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.EnableTxT(1);
                    btnAuthorUpdate.Enabled = true;
                    btnAuthorAdd.Enabled = true;
                    btnAuthorSave.Enabled = false;
                    btnAuthorDelete.Enabled = true;
                }
                else
                    MessageBox.Show("Thêm thất bại do gặp lỗi, thử lại sau", "Thất bại",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.frmManageAuthor_Load(sender, e);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Mã tác giả bị trùng, vui lòng thử lại", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthorID.Focus();
            }
            
        }

        private void btnAuthorUpdate_Click(object sender, EventArgs e)
        {
            
            txtAuthorName.Clear();
            this.EnableTxT(0);
            txtAuthorID.Enabled = false;
            btnAuthorUpdate.Enabled = true;
            btnAuthorDelete.Enabled = false;
            btnAuthorAdd.Enabled = false;
            btnAuthorSave.Enabled = true;
            addOrEdit = false;
        }

        private void btnAuthorDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = txtAuthorID.Text;
                Author b = new Author { AuthorID = ID };
                if (Adt.deleteAuthor(b))
                {
                    DataRow row = dtAuthor.Rows.Find(ID);
                    dtAuthor.Rows.Remove(row);
                    MessageBox.Show("Đã xóa tác giả khỏi dữ liệu", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Xóa thất bại do gặp lỗi, thử lại sau", "Thất bại",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tác giả này còn sách trong dữ liệu, không thể xóa!\n Thử lại sau...", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnAuthorExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
