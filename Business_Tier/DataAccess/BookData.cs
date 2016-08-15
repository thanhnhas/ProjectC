using Business_Tier.Entities;
using Data_Tier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier.DataAccess
{
    public class BookData
    {
        //LOAD DATASET FROM DATABASE
        public DataSet GetBookTable()
        {
            string SQL = "select b.ISBN as 'Mã ISBN', b.BookName as 'Tên Sách', a.AuthorName as 'Tác Giả', p.PublishName as 'NXB', c.Type as 'Thể loại', bs.SLGoc as 'Số Lượng' from tblBook b, tblBookStore bs, tblAuthor a, tblPublisher p, tblCatagory c where bs.ISBN = b.ISBN and a.AuthorID = b.AuthorID and p.publisherID = b.publisherID and b.CodeID = c.CodeID";
            DataSet dts = new DataSet();
            try
            {
                dts = DataProvider.ExecuteQueryWithDataSet(SQL, CommandType.Text);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return dts;
        }
        public DataSet GetBookTypeTable()
        {
            string SQL = "select d.CodeID as 'Mã thể loại' , d.Type as 'Thể loại' from tblCatagory d";
            DataSet dts = new DataSet();
            try
            {
                dts = DataProvider.ExecuteQueryWithDataSet(SQL, CommandType.Text);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return dts;
        }
        public DataSet GetPublisherTable()
        {
            string SQL = "select p.publisherID as 'Mã NXB', p.PublishName as 'Nhà xuất bản', p.Address as 'Địa chỉ', p.Phone as 'Số điện thoại' from tblPublisher p";
            DataSet dts = new DataSet();
            try
            {
                dts = DataProvider.ExecuteQueryWithDataSet(SQL, CommandType.Text);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return dts;
        }

        public DataSet GetAuthorTable()
        {
            string SQL = "select * from tblAuthor";
            DataSet dts = new DataSet();
            try
            {
                dts = DataProvider.ExecuteQueryWithDataSet(SQL, CommandType.Text);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return dts;
        }

        //DELETE ROW FROM DATABASE
        public bool DeletePublisherRow(String RowID)
        {

            string SQL = "delete from tblPublisher where publisherID='" + RowID + "'";
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public bool DeleteBookTypeRow(String RowID)
        {

            string SQL = "delete from tblCatagory where CodeID='" + RowID + "'";
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public bool DeleteBookRow(String RowID)
        {

            string SQL = "delete from tblBook where ISBN ='" + RowID + "'";
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public bool DeleteBookStoreRow(String RowID)
        {

            string SQL = "delete from tblBookStore where ISBN ='" + RowID + "'";
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        //INSERT ROW FROM DATABASE
        public bool InsertBookStoreRow(Book b)
        {
            string SQL = "insert tblBookStore values (@ISBN , @Quantity , 0)";
            SqlParameter sp1 = new SqlParameter("@ISBN", b.ISBN);
            SqlParameter sp2 = new SqlParameter("@Quantity", b.Quantity);
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, sp1,sp2);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public bool InsertBookRow(Book b)
        {
            string SQL = "insert tblBook values (@ISBN , @Name , @TypeID , @PublisherID, @AuthorID)";
            SqlParameter sp1 = new SqlParameter("@ISBN", b.ISBN);
            SqlParameter sp2 = new SqlParameter("@Name", b.Name);
            SqlParameter sp3 = new SqlParameter("@TypeID", b.TypeID);
            SqlParameter sp4 = new SqlParameter("@PublisherID", b.PublisherID);
            SqlParameter sp5 = new SqlParameter("@AuthorID", b.AuthorID);
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, sp1, sp2,sp3,sp4,sp5);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public bool InsertBookTypeRow(BookType bt)
        {
            string SQL = "insert tblCatagory values (@ID , @Name)";
            SqlParameter sp1 = new SqlParameter("@ID", bt.ID);
            SqlParameter sp2 = new SqlParameter("@Name", bt.Name);
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, sp1, sp2);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public bool InsertPublisherRow(Publisher p)
        {
            string SQL = "insert tblPublisher values (@ID , @Name , @Address, @Phone)";
            SqlParameter sp1 = new SqlParameter("@ID", p.ID);
            SqlParameter sp2 = new SqlParameter("@Name", p.Name);
            SqlParameter sp3 = new SqlParameter("@Address", p.Address);
            SqlParameter sp4 = new SqlParameter("@Phone", p.Phone);
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, sp1, sp2,sp3,sp4);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }

        //UPDATE TO DATABASE
        public bool UpdateBookRow(Book b)
        {
            String SQL = "update tblBook set BookName='" + b.Name + "' , CodeID='" + b.TypeID + "' , publisherID='" + b.PublisherID + "' , AuthorID='" + b.AuthorID + "' where ISBN='" + b.ISBN + "'";

            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public bool UpdateBookStoreRow(Book b)
        {
            String SQL = "update tblBookStore set SLGoc = '" + b.Quantity + "' where ISBN = '" + b.ISBN + "'";

            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public bool UpdateBookTypeRow(BookType bt)
        {
            String SQL = "update tblCatagory set Type='" + bt.Name + "' where CodeID ='" + bt.ID + "'";

            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public bool UpdatePublisherRow(Publisher p)
        {
            String SQL = "update tblPublisher set PublishName='" + p.Name + "', Address='" + p.Address +"', Phone='" + p.Phone +"' where publisherID='" +p.ID +"'";


            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
    }
}
