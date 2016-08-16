using Business_Tier.DataAccess;
using Business_Tier.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageLibrary
{
    public partial class frm_UpdateBook : Form
    {
        public frm_UpdateBook()
        {
            InitializeComponent();
        }
        BookData bd = new BookData();
        NewBookStore nb = new NewBookStore();
        DataTable BookDTB,BookTypeDTB, PublisherDTB, AuthorDTB, SuggestDTB;
        List<String> DTcbbBookTypeName, DTcbbBookTypeID ,
             DTcbbAuthorName, DTcbbAuthorID, DTcbbPublisherName, DTcbbPublisherID;
        bool IsBookAddNew = false, IsBookTypeAddNew = false, IsPublisherAddNew = false;

        private void frm_UpdateBook_Load(object sender, EventArgs e)
        {
            //GET DATATABLE FROM DATABASE
            BookDTB = bd.GetBookTable().Tables[0];
            BookTypeDTB = bd.GetBookTypeTable().Tables[0];
            PublisherDTB = bd.GetPublisherTable().Tables[0];
            AuthorDTB = bd.GetAuthorTable().Tables[0];
            SuggestDTB = nb.GetSuggestTable().Tables[0];
            //SET DATASOURCE TO DATAGRIDVIEW
            dgvBook.DataSource = BookDTB;
            dgvBookType.DataSource = BookTypeDTB;
            dgvPublisher.DataSource = PublisherDTB;
            dgvSuggestList.DataSource = SuggestDTB;
            dgvSuggestColumnsDelete();
            //COMBOBOX DATA
            GetSourceCbb();


            //TEXTBOX BINDING
            TXTBookDataBindings();
            TXTBookTypeDataBindings();
            TXTPublisherDataBindings();
            TXTSuggestDataBindings();

            //SET TEXTBOX IS READONLY
            TXTBookSetReadOnly();
            TXTBookTypeSetReadOnly();
            TXTPublisherSetReadOnly();
            TXTSuggestSetReadOnly();        

        }
        //GET SOURCE FOR COMBOBOX
        void GetSourceCbb()
        {
            var ra = AuthorDTB.CreateDataReader();
            DTcbbAuthorName = new List<string>();
            DTcbbAuthorID = new List<string>();
            if (ra.HasRows)
            {
                while (ra.Read())
                {
                    DTcbbAuthorID.Add(ra.GetString(0));
                    DTcbbAuthorName.Add(ra.GetString(1));
                }
            }
            var rb = BookTypeDTB.CreateDataReader();
            DTcbbBookTypeID = new List<string>();
            DTcbbBookTypeName= new List<string>();
            if (rb.HasRows)
            {
                while (rb.Read())
                {
                    DTcbbBookTypeID.Add(rb.GetString(0));
                    DTcbbBookTypeName.Add(rb.GetString(1));
                }
            }
            var rp = PublisherDTB.CreateDataReader();
            DTcbbPublisherID = new List<string>();
            DTcbbPublisherName = new List<string>();
            if (rb.HasRows)
            {
                while (rp.Read())
                {
                    DTcbbPublisherID.Add(rp.GetString(0));
                    DTcbbPublisherName.Add(rp.GetString(1));
                }
            }
        }

        //DATABINDING TEXTBOX [BOOK]
        void TXTBookDataBindings()
        {
            txtBookISBN.DataBindings.Clear();
            txtBookName.DataBindings.Clear();
            cbbBookType.DataBindings.Clear();
            cbbAuthor.DataBindings.Clear();
            cbbPublisher.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();
            txtBookISBN.DataBindings.Add("Text", BookDTB, "Mã ISBN");
            txtBookName.DataBindings.Add("Text", BookDTB, "Tên Sách");
            cbbBookType.DataBindings.Add("Text", BookDTB, "Thể loại");
            cbbAuthor.DataBindings.Add("Text", BookDTB, "Tác Giả");
            cbbPublisher.DataBindings.Add("Text", BookDTB, "NXB");
            txtQuantity.DataBindings.Add("Text", BookDTB, "Số Lượng");
        }

        //DATABINDING TEXTBOX [BOOKTYPE]
        void TXTBookTypeDataBindings()
        {
            txtBookTypeID.DataBindings.Clear();
            txtBookTypeName.DataBindings.Clear();
            txtBookTypeID.DataBindings.Add("Text", BookTypeDTB, "Mã thể loại");
            txtBookTypeName.DataBindings.Add("Text", BookTypeDTB, "Thể loại");
        }

        //DATABINDING TEXTBOX [PUBLISHER]
        void TXTPublisherDataBindings()
        {
            txtPublisherID.DataBindings.Clear();
            txtPublisherName.DataBindings.Clear();
            txtPublisherPhone.DataBindings.Clear();
            txtPublisherAddress.DataBindings.Clear();
            txtPublisherID.DataBindings.Add("Text", PublisherDTB, "Mã NXB");
            txtPublisherName.DataBindings.Add("Text", PublisherDTB, "Nhà xuất bản");
            txtPublisherPhone.DataBindings.Add("Text", PublisherDTB, "Số điện thoại");
            txtPublisherAddress.DataBindings.Add("Text", PublisherDTB, "Địa chỉ");
        }

        //DATABINDING TEXTBOX [SUGGEST]
        void TXTSuggestDataBindings()
        {
            txtSuggestID.DataBindings.Clear();
            txtSuggestUsername.DataBindings.Clear();
            txtSuggestBook.DataBindings.Clear();
            txtSuggestAuthorName.DataBindings.Clear();
            txtSuggestYear.DataBindings.Clear();
            txtSuggestDescription.DataBindings.Clear();
            txtSuggestStatus.DataBindings.Clear();

            txtSuggestID.DataBindings.Add("Text", SuggestDTB, "ID");
            txtSuggestUsername.DataBindings.Add("Text", SuggestDTB, "username");
            txtSuggestBook.DataBindings.Add("Text", SuggestDTB, "BookName");
            txtSuggestAuthorName.DataBindings.Add("Text", SuggestDTB, "Author");
            txtSuggestYear.DataBindings.Add("Text", SuggestDTB, "Year");
            txtSuggestDescription.DataBindings.Add("Text", SuggestDTB, "Description");
            txtSuggestStatus.DataBindings.Add("Text", SuggestDTB, "status");
        }

        //DELETE COLUMNS [SUGGEST]
        void dgvSuggestColumnsDelete()
        {
            dgvSuggestList.Columns.Remove("ID");
            dgvSuggestList.Columns.Remove("status");
            dgvSuggestList.Columns.Remove("Description");
        }

        //READONLY TEXTBOX [SUGGEST]
        void TXTSuggestSetReadOnly()
        {
            txtSuggestAuthorName.ReadOnly = true;
            txtSuggestBook.ReadOnly = true;
            txtSuggestDescription.ReadOnly = true;
            txtSuggestID.ReadOnly = true;
            txtSuggestStatus.ReadOnly = true;
            txtSuggestUsername.ReadOnly = true;
            txtSuggestYear.ReadOnly = true;
            
        }

        //READONLY TEXTBOX [BOOK]
        void TXTBookSetReadOnly()
        {
            txtBookISBN.ReadOnly = true;
            txtBookName.ReadOnly = true;
            cbbBookType.Enabled = false;
            cbbAuthor.Enabled = false;
            cbbPublisher.Enabled = false;
            txtQuantity.ReadOnly = true;
        }

        //EDITABLE TEXTBOX [BOOK]
        void TXTBookSetEditable()
        {
            txtBookISBN.ReadOnly = false;
            txtBookName.ReadOnly = false;
            cbbBookType.Enabled = true;
            cbbAuthor.Enabled = true;
            cbbPublisher.Enabled = true;
            txtQuantity.ReadOnly = false;
        }

        //CLEAR TEXTBOX [BOOK]
        void TXTBookClear()
        { 
            txtBookISBN.Clear();
            txtBookName.Clear();
            txtQuantity.Clear();
            cbbAuthor.DataSource = DTcbbAuthorName;
            cbbBookType.DataSource = DTcbbBookTypeName;
            cbbPublisher.DataSource = DTcbbPublisherName;         
        }

        //READONLY TEXTBOX [BOOKTYPE]
        void TXTBookTypeSetReadOnly()
        {
            txtBookTypeID.ReadOnly = true;
            txtBookTypeName.ReadOnly = true;
        }

        //EDITABLE TEXTBOX [BOOKTYPE]
        void TXTBookTypeSetEditable()
        {
            txtBookTypeID.ReadOnly = false;
            txtBookTypeName.ReadOnly = false;
        }

        //CLEAR TEXTBOX [BOOKTYPE]
        void TXTBookTypeClear()
        {
            txtBookTypeID.Clear();
            txtBookTypeName.Clear();
        }

        //READONLY TEXTBOX [PUBLISHER]
        void TXTPublisherSetReadOnly()
        {
            txtPublisherID.ReadOnly = true;
            txtPublisherName.ReadOnly = true;
            txtPublisherPhone.ReadOnly = true;
            txtPublisherAddress.ReadOnly = true;
        } 
              
        //EDITABLE TEXTBOX [PUBLISHER]
        void TXTPublisherSetEditable()
        {
            txtPublisherID.ReadOnly = false;
            txtPublisherName.ReadOnly = false;
            txtPublisherPhone.ReadOnly = false;
            txtPublisherAddress.ReadOnly = false;
        }

        //CLEAR TEXTBOX [PUBLISHER]
        void TXTPublisherClear()
        {
            txtPublisherID.Clear();
            txtPublisherName.Clear();
            txtPublisherPhone.Clear();
            txtPublisherAddress.Clear();
        }


        /*------------------- HANDLE NUMBER ----------------*/
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPublisherPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /*------------------------- PUBLISHER MANAGEMENT -----------------------*/
        //VALIDATE DATA
        bool validPublisher(Publisher p)
        {
            if (p.ID == "" || p.Name == "" || p.Address =="" || p.Phone == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Missing Information",
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (p.ID.Length < 4 || p.ID.Length > 8)
            {
                MessageBox.Show("ID phải có độ dài từ 4 -> 8 kí tự", "ID Format",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (p.Name.Length > 30)
            {
                MessageBox.Show("Tên không được vượt quá 30 kí tự", "Name Format",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (p.Phone.Length < 8 || p.Phone.Length > 11)
            {
                MessageBox.Show("Số điện thoại phải có từ 8 -> 11 số", "Phone Number Format",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }
        //CLEAR TEXTBOX AND SET TEXTBOX IS EDITABE -> SET SAVE STATE: ADD NEW
        private void btnAddPublisher_Click(object sender, EventArgs e)
        {
            IsPublisherAddNew = true;
            TXTPublisherClear();
            TXTPublisherSetEditable();
            btnSavePublisher.Enabled = true;
            btnEditPublisher.Enabled = false;
            btnDeletePublisher.Enabled = false;
        }
        //SAVE DATA FROM TEXTBOX TO DATABASE
        private void btnSavePublisher_Click(object sender, EventArgs e)
        {
            String ID = txtPublisherID.Text;
            String Name = txtPublisherName.Text;
            String Address = txtPublisherAddress.Text;
            String Phone = txtPublisherPhone.Text;
            Publisher p = new Publisher { ID = ID , Name = Name , Address = Address , Phone = Phone};
            if (!validPublisher(p)) return;
            if (IsPublisherAddNew)
            {
                try
                {
                    bool flag = bd.InsertPublisherRow(p);
                    if (flag)
                    {
                        MessageBox.Show("Đã thêm NXB " + Name + 
                            " vào dữ liệu", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_UpdateBook_Load(null, null);
                        btnDeletePublisher.Enabled = true;
                        btnEditPublisher.Enabled = true;
                        btnAddPublisher.Enabled = true;
                        btnSavePublisher.Enabled = false;
                        TXTPublisherSetReadOnly();
                        IsPublisherAddNew = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại do gặp lỗi, thử lại sau", "Thất bại",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Mã nhà xuất bản bị trùng, vui lòng thử lại", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPublisherID.Focus();
                }
               
            }
            else
            {
                bool flag = bd.UpdatePublisherRow(p);
                if (flag)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_UpdateBook_Load(null, null);
                    btnDeletePublisher.Enabled = true;
                    btnEditPublisher.Enabled = true;
                    btnAddPublisher.Enabled = true;
                    btnSavePublisher.Enabled = false;
                    TXTPublisherSetReadOnly();
                    IsPublisherAddNew = false;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại do gặp lỗi, thử lại sau", "Thất bại", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                frm_UpdateBook_Load(null, null);
                btnDeletePublisher.Enabled = true;
                btnEditPublisher.Enabled = true;
                btnAddPublisher.Enabled = true;
                btnSavePublisher.Enabled = false;
                TXTPublisherSetReadOnly();
                IsPublisherAddNew = false;

            }
            
        }
        //SET TEXTBOX IS EDITABLE -> SET SAVE STATE: UPDATE
        private void btnEditPublisher_Click(object sender, EventArgs e)
        {
            IsPublisherAddNew = false;
            TXTPublisherSetEditable();
            txtPublisherID.ReadOnly = true;
            btnSavePublisher.Enabled = true;
            btnAddPublisher.Enabled = false;
            btnDeletePublisher.Enabled = false;
        }
        //DELETE ROW SELECTED 
        private void btnDeletePublisher_Click(object sender, EventArgs e)
        {
            String ID = txtPublisherID.Text;
            String Name = txtPublisherName.Text;
            String message = "Bạn có thật sự muốn xóa NXB " + Name + " khỏi dữ liệu ?";
            String caption = "Xác thực trước khi xóa";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    bool flag = bd.DeletePublisherRow(ID);
                    if (flag)
                    {
                        MessageBox.Show("Đã xóa nhà xuất bản " + Name + " khỏi dữ liệu",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_UpdateBook_Load(null,null);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại do gặp lỗi, thử lại sau", "Thất bại",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Nhà xuất bản này đang được tham chiếu ở một số cuốn sách."+
                        "\nHãy đảm bảo Nhà xuất bản này không được sử dụng trước khi xóa.\nThử lại sau...", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        

        //CLOSE FORM
        private void btnClosePublisher_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /*------------------------- BOOK TYPE MANAGEMENT -----------------------*/
        //VALIDATE DATA
        bool validBookType(BookType bt)
        {
            if (bt.ID == "" || bt.Name == "")
            {
                MessageBox.Show("Vui lòng nhập mã và tên thể loại", "Missing Information",
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (bt.ID.Length < 2 || bt.ID.Length > 6)
            {
                MessageBox.Show("ID phải có độ dài từ 2 -> 6 kí tự", "ID Format",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (bt.Name.Length > 30)
            {
                MessageBox.Show("Tên không được vượt quá 30 kí tự", "Name Format",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }           
            return true;
        }
        //CLEAR TEXTBOX AND SET TEXTBOX IS EDITABE -> SET SAVE STATE: ADD NEW
        private void btnAddBookType_Click(object sender, EventArgs e)
        {
            IsBookTypeAddNew = true;
            TXTBookTypeClear();
            TXTBookTypeSetEditable();
            btnSaveBookType.Enabled = true;
            btnEditBookType.Enabled = false;
            btnDeleteBookType.Enabled = false;
        }


        //SAVE DATA FROM TEXTBOX TO DATABASE
        private void btnSaveBookType_Click(object sender, EventArgs e)
        {
            String ID = txtBookTypeID.Text;
            String Name = txtBookTypeName.Text;
            BookType bt = new BookType { ID = ID, Name = Name};
            if (!validBookType(bt)) return;
            if (IsBookTypeAddNew)
            {
                try
                {
                    bool flag = bd.InsertBookTypeRow(bt);
                    if (flag)
                    {
                        MessageBox.Show("Đã thêm thể loại " + Name + " vào dữ liệu", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_UpdateBook_Load(null, null);
                        btnDeleteBookType.Enabled = true;
                        btnEditBookType.Enabled = true;
                        btnAddBookType.Enabled = true;
                        btnSaveBookType.Enabled = false;
                        TXTBookTypeSetReadOnly();
                        IsBookTypeAddNew = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại do gặp lỗi, thử lại sau", "Thất bại",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Mã thể loại bị trùng, vui lòng thử lại", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPublisherID.Focus();
                }
            }
            else
            {
                bool flag = bd.UpdateBookTypeRow(bt);
                if (flag)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_UpdateBook_Load(null, null);
                    btnDeleteBookType.Enabled = true;
                    btnEditBookType.Enabled = true;
                    btnAddBookType.Enabled = true;
                    btnSaveBookType.Enabled = false;
                    TXTBookTypeSetReadOnly();
                    IsBookTypeAddNew = false;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại do gặp lỗi, thử lại sau", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
            }
            
        }
       

        //SET TEXTBOX IS EDITABLE -> SET SAVE STATE: UPDATE
        private void btnEditBookType_Click(object sender, EventArgs e)
        {
            IsBookTypeAddNew = false;
            TXTBookTypeSetEditable();
            txtBookTypeID.ReadOnly = true;
            btnSaveBookType.Enabled = true;
            btnAddBookType.Enabled = false;
            btnDeleteBookType.Enabled = false;
        }
        //DELETE ROW SELECTED 
        private void btnDeleteBookType_Click(object sender, EventArgs e)
        {
            String ID = txtBookTypeID.Text;
            String Name = txtBookTypeName.Text;
            String message = "Bạn có thật sự muốn xóa thể loại " + Name + " khỏi dữ liệu ?";
            String caption = "Xác thực trước khi xóa";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    bool flag = bd.DeleteBookTypeRow(ID);
                    if (flag)
                    {
                        MessageBox.Show("Đã xóa thể loại " + Name + " khỏi dữ liệu", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_UpdateBook_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại do gặp lỗi, thử lại sau", "Thất bại",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Thể loại này đang được tham chiếu ở một số cuốn sách."+
                        "\nHãy đảm bảo thể loại này không được sử dụng trước khi xóa.\nThử lại sau...",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //CLOSE FORM
        private void btnCloseBookType_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /*------------------------- BOOK MANAGEMENT -----------------------*/
        //VALIDATE DATA
        bool validBook(Book b)
        {
            if (b.ISBN == "" || b.Name == "" || b.Quantity == 0)
            {
                MessageBox.Show("Vui lòng không để trống thông  tin", "Missing Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (b.ISBN.Length < 4 || b.ISBN.Length > 13)
            {
                MessageBox.Show("ISBN phải có độ dài từ 4 -> 13 kí tự", "ISBN Format",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (b.Name.Length > 30)
            {
                MessageBox.Show("Tên không được vượt quá 30 kí tự", "Name Format",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }
        //CLEAR TEXTBOX AND SET TEXTBOX IS EDITABE -> SET SAVE STATE: ADD NEW
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            IsBookAddNew = true;
            TXTBookClear();
            TXTBookSetEditable();
            btnSaveBook.Enabled = true;
            btnEditBook.Enabled = false;
            btnDeleteBook.Enabled = false;
        }



        //SAVE DATA FROM TEXTBOX TO DATABASE
        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            String ISBN = txtBookISBN.Text;
            String Name = txtBookName.Text;
            String TypeID = DTcbbBookTypeID[cbbBookType.SelectedIndex];
            String AuthorID = DTcbbAuthorID[cbbAuthor.SelectedIndex];
            String PublisherID = DTcbbPublisherID[cbbPublisher.SelectedIndex];
            int Quantity = int.Parse( 0 + txtQuantity.Text);
            Book b = new Book
            {
                ISBN = ISBN,
                Name = Name,
                TypeID = TypeID,
                AuthorID = AuthorID,
                PublisherID = PublisherID,
                Quantity = Quantity
            };
            if (!validBook(b)) return;
            if (IsBookAddNew)
            {
                try
                {
                    bool flag = bd.InsertBookStoreRow(b);
                    bool flag2 = bd.InsertBookRow(b);
                    if (flag && flag2)
                    {
                        MessageBox.Show("Đã thêm sách " + Name + " vào dữ liệu", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_UpdateBook_Load(null, null);
                        btnDeleteBook.Enabled = true;
                        btnEditBook.Enabled = true;
                        btnAddBook.Enabled = true;
                        btnSaveBook.Enabled = false;
                        TXTBookSetReadOnly();
                        IsBookAddNew = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại do gặp lỗi, thử lại sau", "Thất bại",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Mã ISBN sách bị trùng, vui lòng thử lại", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBookISBN.Focus();
                }
            }
            else
            {
                bool flag = bd.UpdateBookRow(b);
                bool flag2 = bd.UpdateBookStoreRow(b);
                if (flag && flag2)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_UpdateBook_Load(null, null);
                    btnDeleteBook.Enabled = true;
                    btnEditBook.Enabled = true;
                    btnAddBook.Enabled = true;
                    btnSaveBook.Enabled = false;
                    TXTBookSetReadOnly();
                    IsBookAddNew = false;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại do gặp lỗi, thử lại sau", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            
        }
        //SET TEXTBOX IS EDITABLE -> SET SAVE STATE: UPDATE
        private void btnEditBook_Click(object sender, EventArgs e)
        {
            int AuthorIndex = DTcbbAuthorName.IndexOf(cbbAuthor.Text);
            int TypeIndex = DTcbbBookTypeName.IndexOf(cbbBookType.Text);
            int PublisherIndex = DTcbbPublisherName.IndexOf(cbbPublisher.Text);
            cbbAuthor.DataSource = DTcbbAuthorName;
            cbbBookType.DataSource = DTcbbBookTypeName;
            cbbPublisher.DataSource = DTcbbPublisherName;
            cbbAuthor.SelectedIndex = AuthorIndex;
            cbbBookType.SelectedIndex = TypeIndex;
            cbbPublisher.SelectedIndex = PublisherIndex;
            IsBookAddNew = false;
            TXTBookSetEditable();
            txtBookISBN.ReadOnly = true;
            btnSaveBook.Enabled = true;
            btnAddBook.Enabled = false;
            btnDeleteBook.Enabled = false;
        }
        //DELETE ROW SELECTED 
        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            String ID = txtBookISBN.Text;
            String Name = txtBookName.Text;
            String message = "Bạn có thật sự muốn xóa sách " + Name + " khỏi dữ liệu ?";
            String caption = "Xác thực trước khi xóa";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    bool flag = bd.DeleteBookRow(ID);
                    bool flag2 = bd.DeleteBookStoreRow(ID);
                    if (flag && flag2)
                    {
                        MessageBox.Show("Đã xóa sách " + Name + " khỏi dữ liệu", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_UpdateBook_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại do gặp lỗi, thử lại sau", "Thất bại", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Không thể xóa sách này, Sách đang cho mượn ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //CLOSE FORM
        private void btnCloseBook_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        /*------------------- SUGGEST MANAGEMENT ---------------------*/

        //ACCEPT SUGGEST REQUEST
        private void btnSuggestAccept_Click(object sender, EventArgs e)
        {
            String ID = txtSuggestID.Text;
            bool isAccepted = bool.Parse(txtSuggestStatus.Text);
            if (isAccepted)
            {
                MessageBox.Show("Đề xuất này đã được duyệt :)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                bool flag = nb.AcceptSuggest(ID);
                if (flag)
                {
                    MessageBox.Show("Đã duyệt đề xuất thành công", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_UpdateBook_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Duyệt đề xuất thất bại do gặp lỗi, vui lòng thử lại", "Thất bại",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cơ sở dữ liệu lỗi, vui lòng thử lại", "Thất bại",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
        // CLOSE FORM
        private void btnSuggestExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //RELOAD FORM
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            frm_UpdateBook_Load(null, null);
        }
    }
}
