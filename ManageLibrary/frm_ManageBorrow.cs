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
    public partial class frm_ManageBorrow : Form
    {
        public frm_ManageBorrow()
        {
            InitializeComponent();
        }
        BorrowDetailsData mbd = new BorrowDetailsData();
        DataTable BangDanhSachMuon;
        DataTable BangDanhSachSach;
        DataTable ThongTinDocGia;
        bool TraSach,PhieuMoi = false;
        int LastBRID;
        String searchBy = "tensach";
        void loadDSMuon()
        {
            //Load bảng danh sách các cuốn sách có trong thư viện
            BangDanhSachSach = mbd.GetBookListFullByDataSet().Tables[0];
            dgvKetQuaTimSach.DataSource = BangDanhSachSach;
            BindingTextboxMuon();
        }
        void loadDSTra()
        {
            //Load Bảng danh sách các cuốn sách được mượn
            lbSachDocGia.Text = "Danh sách sách đang cho mượn";
            BangDanhSachMuon = mbd.GetBorrowListByDataSet().Tables[0];
            dgvDanhSachMuon.DataSource = BangDanhSachMuon;
            BindingTextboxTra();
        }
        private void frm_ManageBorrow_Load(object sender, EventArgs e)
        {

            loadDSMuon();
            loadDSTra();
            //xóa cột
            xoaCotdgvTra();
            xoaCotdgvMuon();

        }
        void BindingTextboxTra()
        {
            txtTenSachTra.DataBindings.Clear();
            txtISBNTra.DataBindings.Clear();
            txtMaSachTra.DataBindings.Clear();
            txtThoiHanTra.DataBindings.Clear();
            txtMaMuon.DataBindings.Clear();
            txtTenSachTra.DataBindings.Add("Text", BangDanhSachMuon, "Tên sách");
            txtISBNTra.DataBindings.Add("Text", BangDanhSachMuon, "Mã ISBN");
            txtMaSachTra.DataBindings.Add("Text", BangDanhSachMuon, "BookID");
            txtThoiHanTra.DataBindings.Add("Text", BangDanhSachMuon, "Ngày trả");
            txtMaMuon.DataBindings.Add("Text", BangDanhSachMuon, "ID");
        }
        void BindingTextboxMuon()
        {
            txtTenSachMuon.DataBindings.Clear();
            txtISBNMuon.DataBindings.Clear();
            txtSoluong.DataBindings.Clear();
            txtTacGia.DataBindings.Clear();
            txtNXB.DataBindings.Clear();
            txtTheLoai.DataBindings.Clear();
            txtTenSachMuon.DataBindings.Add("Text", BangDanhSachSach, "Tên sách");
            txtISBNMuon.DataBindings.Add("Text", BangDanhSachSach, "Mã ISBN");
            txtSoluong.DataBindings.Add("Text", BangDanhSachSach, "Quantity");
            txtTacGia.DataBindings.Add("Text", BangDanhSachSach, "Tác giả");
            txtTheLoai.DataBindings.Add("Text", BangDanhSachSach, "Thể loại");
            txtNXB.DataBindings.Add("Text", BangDanhSachSach, "NXB");
        }

        void xoaCotdgvMuon()
        {
            //Xóa cột ở bảng danh sách sách          
           
            dgvKetQuaTimSach.Columns.Remove("SLGoc");
            dgvKetQuaTimSach.Columns.Remove("SLMuon");
            dgvKetQuaTimSach.Columns.Remove("Quantity");

        }
        void xoaCotdgvTra()
        {

            //xóa cột ở bảng danh sách mượn
            dgvDanhSachMuon.Columns.Remove("BookID");
            dgvDanhSachMuon.Columns.Remove("ID");
            dgvDanhSachMuon.Columns.Remove("username");
        }
        //Hiện thực nút tìm kiếm -> hiện thị danh sách các cuốn sách đang mượn của độc giả được tìm thấy
        private void btnTimKiemDocGia_Click(object sender, EventArgs e)
        {
            String searchname = txtMaDocGia.Text;
            if (searchname == null || searchname == "")
            {
                MessageBox.Show("Vui lòng nhập username cần tìm",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                loadDSTra();
            }
            else
            {
                BangDanhSachMuon = mbd.GetUserBorrowListByDataSet(searchname).Tables[0];
                if (BangDanhSachMuon.Rows.Count == 0)
                {
                    MessageBox.Show("Không có thông tin người dùng " + searchname + " trong danh sách mượn",
                        "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loadDSTra();
                }
                else
                {
                    lbSachDocGia.Text = "Danh sách sách mượn của độc giả " + searchname.ToUpper();
                    BindingTextboxTra();
                    dgvDanhSachMuon.DataSource = BangDanhSachMuon;
                    xoaCotdgvTra();
                }

            }

        }
        //Hiện thực nút tìm kiếm bằng phím Enter

        private void txtMaDocGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnTimKiemDocGia_Click(null, null);
            }
        }
        //Hiện thực nút Trả sách -> Xóa phiếu mượn của độc giả khỏi database
        private void btnTraSach_Click(object sender, EventArgs e)
        {
            TraSach = true;
            int ID = int.Parse(txtMaMuon.Text);
            String ISBN = txtISBNTra.Text;
            txtMaDocGia.DataBindings.Clear();
            txtMaDocGia.DataBindings.Add("Text", BangDanhSachMuon, "username");
            String username = txtMaDocGia.Text;
            String message = "Hãy đảm bảo đúng sách được trả ?";
            String caption = "Thực hiện trả sách";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool flag = mbd.UpdateStatusTraSach(ID);
                bool flag2 = mbd.UpdateSLSach(ISBN, TraSach);
                bool flag3 = mbd.UpdateCountSach(username, TraSach);
                if (flag && flag2 && flag3)
                {
                    MessageBox.Show("Sách đã được trả, cập nhật thư viện thành công",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_ManageBorrow_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Phát sinh lỗi trong quá trình thực hiện, thử lại sau",
                        "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

       

        //Thiết lập tìm kiếm theo tên sách, tác giả hay ISBN
        private void rdtTenSach_Click(object sender, EventArgs e)
        {
            searchBy = "tensach";
            txtTimSach.Text = "Nhập tên sách cần tìm";
        }

        private void rdtISBN_Click(object sender, EventArgs e)
        {
            searchBy = "isbn";
            txtTimSach.Text = "Nhập ISBN sách cần tìm";
        }

        private void rdtTacGia_Click(object sender, EventArgs e)
        {
            searchBy = "tacgia";
            txtTimSach.Text = "Nhập tác giả sách cần tìm";
        }

        // Hiện chỉ dẫn tìm kiếm khi không focus vào ô tìm kiếm
        private void txtTimSach_Leave(object sender, EventArgs e)
        {
            if (txtTimSach.Text == "")
            {
                if (rdtTenSach.Checked)
                {
                    txtTimSach.Text = "Nhập tên sách cần tìm";

                }
                if (rdtISBN.Checked)
                {
                    txtTimSach.Text = "Nhập ISBN sách cần tìm";
                }

                if (rdtTacGia.Checked)
                {
                    txtTimSach.Text = "Nhập tác giả sách cần tìm";
                }
            }
            

        }

        //Xóa chỉ dẫn tìm kiếm khi người dùng nhập dữ liệu
        private void txtTimSach_Enter(object sender, EventArgs e)
        {
            txtTimSach.Text = "";
        }

        //Hiện thực nút tìm sách -> hiện thị danh sách các cuốn sách theo tiêu chí tìm kiếm
        private void btnTimSach_Click(object sender, EventArgs e)
        {
            String keyword = txtTimSach.Text;
            if (keyword == "" || keyword == null 
                || keyword == "Nhập tên sách cần tìm" 
                || keyword == "Nhập ISBN sách cần tìm" 
                || keyword == "Nhập tác giả sách cần tìm")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu bạn cần tìm kiếm",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
            else
            {
                if (searchBy == "tensach")
                {
                    BangDanhSachSach = mbd.GetBookListNameByDataSet(keyword).Tables[0];
                    dgvKetQuaTimSach.DataSource = BangDanhSachSach;
                    xoaCotdgvMuon();
                    BindingTextboxMuon();
                }
                if (searchBy == "isbn")
                {
                    BangDanhSachSach = mbd.GetBookListISBNByDataSet(keyword).Tables[0];
                    dgvKetQuaTimSach.DataSource = BangDanhSachSach;
                    xoaCotdgvMuon();
                    BindingTextboxMuon();
                }
                if (searchBy == "tacgia")
                {
                    BangDanhSachSach = mbd.GetBookListAuthorByDataSet(keyword).Tables[0];
                    dgvKetQuaTimSach.DataSource = BangDanhSachSach;
                    xoaCotdgvMuon();
                    BindingTextboxMuon();
                }

            }

        }

        //Hiện thực nút tìm kiếm sách bằng thao tác enter
        private void txtTimSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnTimSach_Click(null, null);
            }
        }

        //Hiện thực nút Fill details -> điền thông tin độc giả vào phiếu
        private void btnFillDetails_Click(object sender, EventArgs e)
        {
            String username = txtMaDocGiaPhieu.Text;
            if (username == "" || username == null)
            {
                MessageBox.Show("Vui lòng nhập username cần tìm",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
            else
            {
                ThongTinDocGia = mbd.GetBorrowerDetailsByDataSet(username).Tables[0];
                if (ThongTinDocGia.Rows.Count == 0)
                {
                    MessageBox.Show("Không có thông tin người dùng " + username + " trong hệ thống",
                        "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtSDT.DataBindings.Clear();
                    txtTenDocGia.DataBindings.Clear();
                    txtDiaChi.DataBindings.Clear();
                    lbrecount.DataBindings.Clear();
                    txtSDT.DataBindings.Add("Text", ThongTinDocGia, "phone");
                    txtTenDocGia.DataBindings.Add("Text", ThongTinDocGia, "name");
                    txtDiaChi.DataBindings.Add("Text", ThongTinDocGia, "address");
                    lbrecount.DataBindings.Add("Text", ThongTinDocGia, "recount");
                    btnPhieuMoi.Enabled = true;
                }
            }
            txtMaDocGiaPhieu.ReadOnly = true;
            
        }
        //Hiện thực nút fill details bằng thao tác enter
        private void txtMaDocGiaPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnFillDetails_Click(null, null);
            }
        }

        private void tabQL_SelectedIndexChanged(object sender, EventArgs e)
        {
            frm_ManageBorrow_Load(null, null);
        }

        private void btnNhapMoiDocGia_Click(object sender, EventArgs e)
        {
            txtMaDocGiaPhieu.Clear();
            txtDiaChi.Clear();
            txtTenDocGia.Clear();
            txtSDT.Clear();
            lbrecount.Text = "";
            btnChoMuon.Text = "Thêm vào phiếu";
            txtMaDocGiaPhieu.ReadOnly = false;
            btnPhieuMoi.Enabled = true;
        }

        private void btnLamTuoi_Click(object sender, EventArgs e)
        {
            frm_ManageBorrow_Load(null, null);
        }

        private void btnPhieuMoi_Click(object sender, EventArgs e)
        {
            if (txtTenDocGia.Text == null || txtTenDocGia.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin độc giả trước khi tạo phiếu mượn mới", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDocGiaPhieu.Focus();
                return;
            }
            btnFillDetails_Click(null, null);
            String username = txtMaDocGiaPhieu.Text;
            int recount = Int32.Parse(lbrecount.Text);
            DateTime frDate = dtpNgayMuonSach.Value;
            DateTime toDate = dtpNgayTraSach.Value;
            if (recount > 0)
            {

                bool flag = mbd.insertDtBorrow(username, frDate, toDate);
                LastBRID = mbd.getLastBorrowID();
                if (flag)
                {
                    MessageBox.Show("Phiếu mượn mới được tạo thành công với ID: " + LastBRID, "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PhieuMoi = true;
                    btnChoMuon.Text = "Thêm vào phiếu " + LastBRID;
                    btnPhieuMoi.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Có lỗi trong quá trình khởi tạo phiếu mượn", "Thất bại", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    PhieuMoi = false;

                }
            }
            else
            {
                
               MessageBox.Show("Bạn đã mượn đủ số lượng sách cho phép, không thể tạo phiếu mượn", "Thất bại", 
                   MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
            }
            


        }

        public bool BookIDexisted(String BookID, String ISBN)
        {
            List<String> BookIDList = mbd.getListBookIDBorrowingByISBN(ISBN);
            if (BookIDList == null) return false;
            for (int i = 0; i< BookIDList.Count; i++)
            {
                if (BookIDList[i] == BookID) return true;
            }
            return false;
        }

        private void rdtTenSach_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnChoMuon_Click(object sender, EventArgs e)
        {
            String MaSach = txtMaSachMuon.Text;
            String username = txtMaDocGiaPhieu.Text;
            String ISBN = txtISBNMuon.Text;
            DateTime frDate = dtpNgayMuonSach.Value;
            DateTime toDate = dtpNgayTraSach.Value;


            if (txtTenDocGia.Text == null || txtTenDocGia.Text == "" || !PhieuMoi)
            {
                MessageBox.Show("Vui lòng điền thông tin độc giả và tạo phiếu mượn mới", "Thiếu thông tin", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDocGiaPhieu.Focus();
            }
            else
            {
                if (MaSach == null || MaSach == "")
                {
                    MessageBox.Show("Vui lòng nhập vào mã ghi trên sách", "Thiếu thông tin", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSachMuon.Focus();
                }
                else
                {
                    bool isexist = BookIDexisted(MaSach, ISBN);
                    int SoLuong = Int32.Parse(txtSoluong.Text);
                    int recount = Int32.Parse(lbrecount.Text);
                    if (SoLuong > 0 && recount > 0 && !isexist)
                    {
                        
                        TraSach = false;
                        BorrowDetails dtBorrow = new BorrowDetails { MaSach = MaSach, ISBN = ISBN,
                            username = username, BorrowID = LastBRID };
                        bool flag2 = mbd.insertDtBorrowDetails(dtBorrow);
                        bool flag3 = mbd.UpdateCountSach(dtBorrow.username, TraSach);
                        bool flag4 = mbd.UpdateSLSach(dtBorrow.ISBN, TraSach);
                        if (flag2 && flag3 && flag4)
                        {
                            MessageBox.Show("Đã thêm sách có ISBN " + dtBorrow.ISBN + " vào phiếu mượn có ID "
                                + dtBorrow.BorrowID + " thành công", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi trong quá trình thêm sách", "Thất bại",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        txtSDT.DataBindings.Clear();
                        txtTenDocGia.DataBindings.Clear();
                        txtDiaChi.DataBindings.Clear();
                        lbrecount.DataBindings.Clear();
                        txtSDT.DataBindings.Add("Text", ThongTinDocGia, "phone");
                        txtTenDocGia.DataBindings.Add("Text", ThongTinDocGia, "name");
                        txtDiaChi.DataBindings.Add("Text", ThongTinDocGia, "address");
                        lbrecount.DataBindings.Add("Text", ThongTinDocGia, "recount");
                    }
                    else
                    {
                        if (SoLuong <= 0)
                        {
                            MessageBox.Show("Số lượng sách này đã hết", "Thất bại", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        if (recount <= 0)
                        {
                            MessageBox.Show("Bạn đã mượn đủ số lượng sách cho phép, vui lòng trả sách đã mượn nếu muốn mượn tiếp", "Thất bại",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        if (isexist)
                        {
                            MessageBox.Show("Mã Sách này đã có người mượn, vui lòng kiểm tra lại", "Thất bại",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    

                }
            }
            
        }
    }
}
