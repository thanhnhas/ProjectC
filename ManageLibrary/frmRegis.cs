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
using System.Text.RegularExpressions;
namespace ManageLibrary
{
    public partial class frmRegis : Form
    {
        public frmRegis()
        {
            InitializeComponent();
            Random r1 = new Random();
            txtCapcha.Text = "" + r1.Next(1, 999);
        }
        DataTable dt = new DataTable();
        UserRegisDB urd = new UserRegisDB();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string pwd = txtPwd.Text;
            string repwd = txtRePwd.Text;
            lbShowErrPwd.Visible = false;
            lbShowErrID.Visible = false;
            lbShowErrCap.Visible = false;
            UserRegisEn ure = new UserRegisEn { ID = id };
            int c = urd.getUsertoCheck(ure).Tables[0].Rows.Count;
            if (c == 0)
            {
                if (txtID.Text != "")
                {
                    if (Regex.IsMatch(id, "^[a-zA-Z0-9]+$", RegexOptions.IgnoreCase))
                    {
                        if (txtID.Text.Length >= 6 && txtID.Text.Length < 13)
                        {
                            if (pwd.Length >= 6)
                            {
                                if (pwd == repwd)
                                {
                                    if (txtReCap.Text == txtCapcha.Text)
                                    {
                                        UserRegisEn b = new UserRegisEn { ID = id, PWD = pwd };
                                        urd.addNewUser(b);
                                        MessageBox.Show("Đăng ký tài khoản thành công");
                                        frmLogin f2 = new frmLogin();
                                        f2.Show();
                                        this.Close();
                                    }
                                    else
                                    {
                                        lbShowErrCap.Visible = true;
                                        lbShowErrCap.ForeColor = System.Drawing.Color.Red;
                                        lbShowErrCap.Text = "Capcha không khớp.";
                                        txtReCap.Focus();
                                    }
                                }
                                else
                                {
                                    lbShowErrPwd.Visible = true;
                                    lbShowErrPwd.ForeColor = System.Drawing.Color.Red;
                                    lbShowErrPwd.Text = "Xác nhận mật khẩu không chính xác!";
                                    txtPwd.Focus();
                                }
                            }
                            else
                            {
                                lbShowErrPwd.Visible = true;
                                lbShowErrPwd.ForeColor = System.Drawing.Color.Red;
                                lbShowErrPwd.Text = "Mật khẩu phải dài hơn 6 ký tự";
                                txtPwd.Focus();
                            }
                        }
                        else
                        {
                            lbShowErrID.Visible = true;
                            lbShowErrID.ForeColor = System.Drawing.Color.Red;
                            lbShowErrID.Text = "Nhập ít chữ 6 ký tự và không dài quá 13 ký tự";
                            txtID.Focus();
                        }
                    }
                    else
                    {
                        lbShowErrID.Visible = true;
                        lbShowErrID.ForeColor = System.Drawing.Color.Red;
                        lbShowErrID.Text = "Tên đăng nhập không hợp lệ, chỉ dùng ký tự và số và không có khoảng trắng";
                        txtID.Focus();
                    }
                }
                else
                {
                    lbShowErrID.Visible = true;
                    lbShowErrID.ForeColor = System.Drawing.Color.Red;
                    lbShowErrID.Text = "Tài khoản không được để trống";
                    txtID.Focus();
                }
            }
            else
            {
                lbShowErrID.Visible = true;
                lbShowErrID.ForeColor = System.Drawing.Color.Red;
                lbShowErrID.Text = "Tài khoản đã tồn tại. Xin hãy thử lại";
                txtID.Focus();
            }
        }
        private void btnReCap_Click(object sender, EventArgs e)
        {
            Random r1 = new Random();
            txtCapcha.Text = "" + r1.Next(1000, 9999);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string message = "Bạn có thực sự muốn thoát?";
            string caption = "Thoát";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                Application.Restart();              
            }
        }
    }
}

