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
using Data_Tier;

namespace ManageLibrary
{
    public partial class frmNewBook : Form
    {
        public frmNewBook(string username)
        {
            InitializeComponent();
            lbusername.Text = username;
        }
        NewBookStore bdt = new NewBookStore();
        NewBook nb = new NewBook();
        //đề nghị thêm sách
        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            bool check = true;
            if (txtAuthor.Text.Equals("") || txtYear.Text.Equals("") || txtBookName.Text.Equals("") || txtDescription.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
                txtBookName.Focus();
                check = false;
            }
            else if (int.Parse(txtYear.Text) <= 0)
            {
                MessageBox.Show("Năm xuất bản không hợp lệ");
                txtYear.Focus();
                check = false;
            }
            else if (check)
            {
                nb.username = lbusername.Text;
                nb.BookName = txtBookName.Text;
                nb.author = txtAuthor.Text;
                nb.description = txtDescription.Text;
                nb.year = txtYear.Text;
                nb.status = false;
                if (bdt.addNewSuggest(nb))
                {
                    MessageBox.Show("Lời đề nghị đã được gửi");
                    txtAuthor.Clear();
                    txtBookName.Clear();
                    txtDescription.Clear();
                    txtYear.Clear();
                }
                else
                {
                    MessageBox.Show("Không thể gửi. Vui lòng thử lại!!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
