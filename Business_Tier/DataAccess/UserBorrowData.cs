using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Tier;
using System.Data.SqlClient;
using System.Data;
using Business_Tier.Entities;

namespace Business_Tier.DataAccess
{
    public class UserBorrowData
    {

        public DataSet getBorrowByDataSet(string username)
        {
            string SQL = "select d.borrowID as 'Mã HD', bo.BookName,b.username,d.ISBN,b.fromdate,b.todate,b.status from tblBook bo, tblBorrow b, tblDetail d"
                + " where b.ID = d.borrowID and d.status = 'true' and d.ISBN = bo.ISBN and b.username='"+username+"'";
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

        public List<UserBorrow> getBorrowByDataReader()
        {
            List<UserBorrow> borrowList = new List<UserBorrow>();
            string sqlSelect = "Select * from tblBorrow";
            SqlDataReader rd = DataProvider.ExecuteQueryWithDataReader(sqlSelect, CommandType.Text);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    UserBorrow urb = new UserBorrow();
                    {
                        urb.username = rd.GetString(0);
                        urb.fromDate = rd.GetString(1);
                        urb.toDate = rd.GetDateTime(2);
                        urb.status = rd.GetBoolean(3);
                        urb.bookName = rd.GetString(4);
                    };
                    borrowList.Add(urb);
                }
            }
            return borrowList;
        }
        //----------------------------------------------------------------------------
        public bool updateUserBorrow(UserBorrow b)
        {
            string SQL = "Update tblBorrow set todate=@todate,status='false' where username=@username and status ='true'";
            SqlParameter username = new SqlParameter("@username", b.username);
            SqlParameter todate = new SqlParameter("@todate", b.toDate);
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, username, todate);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
    }
}