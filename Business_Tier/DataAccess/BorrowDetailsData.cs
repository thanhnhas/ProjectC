using Data_Tier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Tier.Entities;

namespace Business_Tier.DataAccess
{
    public class BorrowDetailsData
    {
        //Load Thông tin danh sách sách đang mượn
        public DataSet GetBorrowListByDataSet()
        {
            string SQL = "select d.ID ,u.username, u.name as 'Tên người mượn', b.BookName as 'Tên sách',b.ISBN as 'Mã ISBN', br.todate as 'Ngày trả',d.BookID from tblBook b, tblBorrow br, tblDetail d,tblUser u where br.ID = d.borrowID and d.ISBN = b.ISBN and d.status = 'true' and br.username = u.username";
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
        //Load thông tin danh sách sách đang mượn theo username
        public DataSet GetUserBorrowListByDataSet(String username)
        {
            string SQL = "select d.ID ,u.username , u.name as 'Tên người mượn', b.BookName as 'Tên sách',b.ISBN as 'Mã ISBN', br.todate as 'Ngày trả',d.BookID from tblBook b, tblBorrow br, tblDetail d,tblUser u where br.ID = d.borrowID and d.ISBN = b.ISBN and d.status = 'true' and br.username = u.username and br.username='" + username +"'";
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
        public bool UpdateStatusTraSach(int ID)
        {
            String SQL = "";
            
                SQL = "update tblDetail set status = 'false' where ID = " + ID;
            
            
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public bool UpdateSLSach(String ISBN, Boolean TraSach)
        {
            String SQL = "";
            if (TraSach)
            {
                SQL = "update tblBookStore set SLMuon = SLMuon-1 where ISBN='" + ISBN + "'";
            }
            else
            {
                SQL = "update tblBookStore set SLMuon = SLMuon+1 where ISBN='" + ISBN + "'";
            }
            

            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public bool UpdateCountSach(String username, Boolean TraSach)
        {
            String SQL = "";
            if (TraSach)
            {
                SQL = "update tblUser set count = count-1 where username='" + username + "'";
            }
            else
            {
                SQL = "update tblUser set count = count+1 where username='" + username + "'";
            }

            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public List<String> getListBookIDBorrowingByISBN(String ISBN)
        {
            List<String> BookIDList = new List<string>();
            string sqlSelect = "select d.BookID from tblDetail d where d.ISBN = '"+ISBN+"' and d.status = 1";
            SqlDataReader rd = DataProvider.ExecuteQueryWithDataReader
                (sqlSelect, CommandType.Text);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    BookIDList.Add(rd.GetString(0));
                }
            }
            return BookIDList;
        }
        public int getLastBorrowID()
        {
            int LastID = -1;
            string sqlSelect = "select MAX(b.ID) from tblBorrow b";
            SqlDataReader rd = DataProvider.ExecuteQueryWithDataReader
                (sqlSelect, CommandType.Text);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    LastID = rd.GetInt32(0);
                }
            }
            return LastID;
        }
        public bool insertDtBorrowDetails(BorrowDetails dtBorrow)
        {          
            
            string SQL = "insert tblDetail values(@ISBN,@BookID, 1 , @BorrowID)";
            SqlParameter ISBN = new SqlParameter("@ISBN", dtBorrow.ISBN);
            SqlParameter BookID = new SqlParameter("@BookID", dtBorrow.MaSach);
            SqlParameter BorrowID = new SqlParameter("@BorrowID", dtBorrow.BorrowID);
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, ISBN, BookID, BorrowID);

            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public bool insertDtBorrow(String username, DateTime frDate, DateTime toDate)
        {

            string SQL = "insert tblBorrow values (@usernametd , @fromdate , @todate , 1)";
            SqlParameter usernametd = new SqlParameter("@usernametd", username);
            SqlParameter fromdate = new SqlParameter("@fromdate", frDate);
            SqlParameter todate = new SqlParameter("@todate", toDate);
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, usernametd, fromdate, todate);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }

        public DataSet GetBookListFullByDataSet()
        {
            string SQL = "select (bs.SLGoc - bs.SLMuon) as 'Quantity' , b.ISBN as 'Mã ISBN', b.BookName as 'Tên Sách', a.AuthorName as 'Tác Giả', p.PublishName as 'NXB', c.Type as 'Thể loại', " + 
                "  bs.SLGoc , bs.SLMuon " + 
                " from tblBook b, tblBookStore bs, tblAuthor a, tblPublisher p, tblCatagory c " + 
                "where bs.ISBN = b.ISBN and a.AuthorID = b.AuthorID and p.publisherID = b.publisherID and b.CodeID = c.CodeID";
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
        public DataSet GetBookListNameByDataSet(String bookname)
        {
            string SQL = "select (bs.SLGoc - bs.SLMuon) as 'Quantity' , b.ISBN as 'Mã ISBN', b.BookName as 'Tên Sách', a.AuthorName as 'Tác Giả', p.PublishName as 'NXB', c.Type as 'Thể loại', " +
                "  bs.SLGoc , bs.SLMuon " +
                " from tblBook b, tblBookStore bs, tblAuthor a, tblPublisher p, tblCatagory c " +
                " where b.BookName like N'%" + bookname + "%' and bs.ISBN =b.ISBN and a.AuthorID = b.AuthorID and p.publisherID = b.publisherID and b.CodeID =c.CodeID"; 
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
        public DataSet GetBookListISBNByDataSet(String ISBN)
        {
            string SQL = "select (bs.SLGoc - bs.SLMuon) as 'Quantity' , b.ISBN as 'Mã ISBN', b.BookName as 'Tên Sách', a.AuthorName as 'Tác Giả', p.PublishName as 'NXB', c.Type as 'Thể loại', " +
                "  bs.SLGoc , bs.SLMuon " +
                " from tblBook b, tblBookStore bs, tblAuthor a, tblPublisher p, tblCatagory c " +
                " where b.ISBN like N'%" + ISBN + "%' and bs.ISBN =b.ISBN and a.AuthorID = b.AuthorID and p.publisherID = b.publisherID and b.CodeID =c.CodeID";
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
        public DataSet GetBookListAuthorByDataSet(String Author)
        {
            string SQL = "select (bs.SLGoc - bs.SLMuon) as 'Quantity' , b.ISBN as 'Mã ISBN', b.BookName as 'Tên Sách', a.AuthorName as 'Tác Giả', p.PublishName as 'NXB', c.Type as 'Thể loại', " +
                "  bs.SLGoc , bs.SLMuon " +
                " from tblBook b, tblBookStore bs, tblAuthor a, tblPublisher p, tblCatagory c " +
                " where a.AuthorName like N'%" + Author + "%' and bs.ISBN =b.ISBN and a.AuthorID = b.AuthorID and p.publisherID = b.publisherID and b.CodeID =c.CodeID";
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
        public DataSet GetBorrowerDetailsByDataSet(String username)
        {
            string SQL = "select u.name , u.phone, u.address , (5 - u.count) as 'recount' from tblUser u where  u.username = '" + username + "'";
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
    }
}
