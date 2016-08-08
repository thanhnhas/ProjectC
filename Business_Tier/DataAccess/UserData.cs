using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using Data_Tier;
using System.Data;
using Business_Tier.Entities;

namespace Business_Tier.DataAccess
{
    public class UserData
    {
        //-----------------------------------------------------------------
        public DataSet GetUserByDataSet()
        {
            string SQL = "select u.username as 'Username' , u.name as 'Full Name' , u.phone as 'Phone Number' ,t.description as 'Account Type',u.address as 'Address',s.name as 'Status' from tblUser u, tblType t,tblStatus s where u.type = t.type and s.statusID=u.status";
            DataSet dsUser = new DataSet();
            try
            {
                dsUser = DataProvider.ExecuteQueryWithDataSet(SQL, CommandType.Text);

            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            return dsUser;
        }
        //-----------------------------------------------------------------
        public List<Users> GetUserByDataReader()
        {
            List<Users> bookList = new List<Users>();
            string sqlSelect = "select * from tblUser";
            SqlDataReader rd = DataProvider.ExecuteQueryWithDataReader
                (sqlSelect, CommandType.Text);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    Users p = new Users()
                    {
                        UserName = rd.GetString(0),
                        UserPassword = rd.GetString(1),
                        Name = rd.GetString(2),
                        UserType = rd.GetInt32(3),
                        UserAddress = rd.GetString(4),
                        UserPhone = rd.GetString(5),
                        UserCount = rd.GetInt32(6),
                        UserStatus = rd.GetInt32(7),
                    };
                    bookList.Add(p);
                }
            }
            return bookList;
        }
        //-----------------------------------------------------------------------
        public bool addNewUser(Users b)
        {

            string SQL = "Insert tblUser values(@username,@password,@type,@name,@address,@phone,@count,@status)";
            SqlParameter username = new SqlParameter("@username", b.UserName);
            SqlParameter password = new SqlParameter("@password", b.UserPassword);
            SqlParameter type = new SqlParameter("@type", b.UserType);
            SqlParameter name = new SqlParameter("@name", b.Name);
            SqlParameter address = new SqlParameter("@address", b.UserAddress);
            SqlParameter phone = new SqlParameter("@phone", b.UserPhone);
            SqlParameter count = new SqlParameter("@count", b.UserCount);
            SqlParameter status = new SqlParameter("@status", b.UserStatus);
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, username, password, type, name, address, phone, count, status);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        //--------------------------------------------------
        /*
        public bool updateBook(Users b)
        {
            string SQL = "Update Books set BookTitle=@Title,BookQuantity =@Quantity,BookPrice=@Price where BookID=@ID";
            SqlParameter id = new SqlParameter("@ID", b.BookID);
            SqlParameter title = new SqlParameter("@Title", b.BookTitle);
            SqlParameter quantity = new SqlParameter("@Quantity", b.BookQuantity);
            SqlParameter price = new SqlParameter("@Price", b.BookPrice);
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, id, title, quantity, price);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        //--------------------------------------------------
        public bool deleteBook(Users b)
        {
            string SQL = "Delete Books where BookID=@ID";
            SqlParameter id = new SqlParameter("@ID", b.BookID);
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, id);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        */
    }
}
