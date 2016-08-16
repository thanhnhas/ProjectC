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
    public partial class frmManageUsers : Form
    {
        public String Name;
        public frmManageUsers(String name)
        {
            InitializeComponent();
            this.Name = name;
        }
        private bool addOrEdit;
        UserData udt = new UserData();
        DataTable dtUser;
        Users u = new Users();
        public void EnableTxT(int t)
        {
            bool flag;
            if (t == 0) flag = true;
            else flag = false;
            txtUsername.Enabled = flag;
            txtUserPassword.Enabled = flag;
            txtName.Enabled = flag;
            rdtAdmin.Enabled = flag;
            rdtUser.Enabled = flag;
            txtUserAddress.Enabled = flag;
            txtUserPhone.Enabled = flag;
            txtUserCount.Enabled = flag;
        }
        public bool isValid()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập Username!", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtUserAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtUserPassword.Text) || txtUserPassword.Text.Length < 6 || txtUserPassword.Text.Length > 30)
            {
                MessageBox.Show("Vui lòng nhập Password và Password lớn hơn 6 ký tự, nhỏ hơn 30 ký tự!", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtUserPhone.Text) || txtUserPhone.Text.Length < 8 || txtUserPhone.Text.Length > 11)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại và số điện thoại từ 8 đến 11 số!", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên!", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            

            return true;
        }
       
        private void frmManageBorrowers_Load(object sender, EventArgs e)
        {
            dtUser = udt.GetUserByDataSet().Tables[0];

            dtUser.PrimaryKey = new DataColumn[] { dtUser.Columns["username"] };
            bsUser.DataSource = dtUser;
            txtUsername.DataBindings.Clear();
            txtUserPassword.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtUserPhone.DataBindings.Clear();
            txtUsertype.DataBindings.Clear();
            txtUserCount.DataBindings.Clear();
            txtUserAddress.DataBindings.Clear();
            

            txtUsername.DataBindings.Add("Text", bsUser, "Username");
            txtUserPassword.DataBindings.Add("Text", bsUser, "Password");
            txtName.DataBindings.Add("Text", bsUser, "Full Name");
            txtUserPhone.DataBindings.Add("Text", bsUser, "Phone Number");
            txtUsertype.DataBindings.Add("Text", bsUser, "Account Type");
            txtUserAddress.DataBindings.Add("Text", bsUser, "Address");
            txtUserCount.DataBindings.Add("Text", bsUser, "Count");
            if (txtUsertype.Text == "admin")
            {
                rdtAdmin.Checked = true;
            }
            else
            {
                rdtUser.Checked = false;
            }
            dgwUser.DataSource = bsUser;
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {            
            txtUsername.Clear();
            txtUserPassword.Clear();
            txtName.Clear();
            txtUserAddress.Clear();
            txtUserPhone.Clear();
            txtUserCount.Clear();
            txtUserCount.Text = "0";
            
            this.EnableTxT(0);
            txtUserCount.Enabled = false;
            btnUserUpdate.Enabled = false;
            btnUserDelete.Enabled = false;
            btnUserSave.Enabled = true;
            rdtUser.Checked = true;
            txtUsername.Focus();
            addOrEdit = true;

        }

        private void btnUserSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValid() == false)
                {
                    return;
                }
                bool flag;
                if (rdtAdmin.Checked)
                {
                    u.UserType = 1;
                }
                else
                {
                    u.UserType = 2;
                }
                u.UserName = txtUsername.Text;
                u.UserPassword = txtUserPassword.Text;
                u.Name = txtName.Text;
                u.UserAddress = txtUserAddress.Text;
                u.UserPhone = txtUserPhone.Text;
                u.UserCount = int.Parse(txtUserCount.Text);

                if (addOrEdit == true)
                    flag = udt.addNewUser(u);
                else
                    flag = udt.updateUser(u);

                if (flag == true)
                {
                    MessageBox.Show("Đã thêm/cập nhật tài khoản " + txtUsername.Text +
                            " vào dữ liệu", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.EnableTxT(1);
                    btnUserUpdate.Enabled = true;
                    btnUserAdd.Enabled = true;
                    btnUserSave.Enabled = false;
                    btnUserDelete.Enabled = true;
                }
                else
                    MessageBox.Show("Thêm thất bại do gặp lỗi, thử lại sau", "Thất bại",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.frmManageBorrowers_Load(sender, e);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Username bị trùng, vui lòng thử lại", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
            }
            

        }

        private void btnUserUpdate_Click(object sender, EventArgs e)
        {
            this.EnableTxT(0);
            txtUsername.Enabled = false;
            btnUserUpdate.Enabled = true;
            btnUserDelete.Enabled = false;
            btnUserAdd.Enabled = false;
            btnUserSave.Enabled = true;
            txtUserPassword.Enabled = true;
            txtUserCount.Enabled = false;
            addOrEdit = false;
        }

        private void btnUserDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                if (username.ToLower().Equals(Name.ToLower()))
                {
                    MessageBox.Show("Bạn Không Thể Xóa Chính Mình!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Users b = new Users { UserName = username };
                if (udt.deleteUser(b))
                {
                    DataRow row = dtUser.Rows.Find(username);
                    dtUser.Rows.Remove(row);
                    MessageBox.Show("Đã xóa tài khoản khỏi dữ liệu", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Xóa thất bại do gặp lỗi, thử lại sau", "Thất bại",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Tài khoàn này còn đang mượn sách, không thể xóa!\n Thử lại sau...", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnUserCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            btnUserAdd_Click(null, null);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            btnUserDelete_Click(null, null);
        }

        

        private void txtUsertype_TextChanged(object sender, EventArgs e)
        {
            if (txtUsertype.Text == "admin")
            {
                rdtAdmin.Checked = true;
            }
            else
            {
                rdtUser.Checked = true;
            }
        }

        private void txtUserPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Char.IsDigit(e.KeyChar) --> kiểm tra xem phím vừa nhập vào textbox có phải là ký tự số hay không, hàm này trả về kiểu bool
            //Char.IsContro(e.KeyChar)-- > kiểm tra xem phím vừa nhập vào textbox có phải là các ký tự điều khiển
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
