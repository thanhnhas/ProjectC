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
    //function new book
    public class NewBookStore
    {
        public bool addNewSuggest(NewBook b)
        {
            string SQL = "Insert tblSuggest values(@username,@BookName,@author,@year,@description,@status)";
            SqlParameter username = new SqlParameter("@username", b.username);
            SqlParameter BookName = new SqlParameter("@BookName", b.BookName);
            SqlParameter author = new SqlParameter("@author", b.author);
            SqlParameter year = new SqlParameter("@year", b.year);
            SqlParameter description = new SqlParameter("@description", b.description);
            SqlParameter status = new SqlParameter("@status", b.status);
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, username, BookName, author, year, description, status);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public DataSet GetSuggestTable()
        {
            string SQL = "select * from tblSuggest where status='false'";
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

        public bool AcceptSuggest(String ID)
        {
            string SQL = "Update tblSuggest set status='True' where ID=@ID";
            SqlParameter WID= new SqlParameter("@ID", ID);            
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, WID);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }

    }
}
