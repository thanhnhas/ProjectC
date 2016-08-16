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
    public class AuthorData
    {
        public DataSet GetAuthorByDataSet()
        {
            string SQL = "select * from tblAuthor";
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
        public List<Author> GetAuthorByDataReader()
        {
            List<Author> bookList = new List<Author>();
            string sqlSelect = "select * from tblAuthor";
            SqlDataReader rd = DataProvider.ExecuteQueryWithDataReader
                (sqlSelect, CommandType.Text);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    Author p = new Author()
                    {
                        AuthorID = rd.GetString(0),
                        AuthorName = rd.GetString(1), 
                    };
                    bookList.Add(p);
                }
            }
            return bookList;
        }
        //-----------------------------------------------------------------------
        public bool addNewAuthor(Author b)
        {

            string SQL = "Insert tblAuthor values(@AuthorID,@AuthorName)";
            SqlParameter id = new SqlParameter("@AuthorID", b.AuthorID);
            SqlParameter name = new SqlParameter("@AuthorName", b.AuthorName);
            
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text,id,name);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        //--------------------------------------------------

        public bool updateAuthor(Author b)
        {
            
            string SQL = "Update tblAuthor set AuthorID=@AuthorID,AuthorName=@AuthorName where AuthorID=@AuthorID";
            SqlParameter id = new SqlParameter("@AuthorID", b.AuthorID);
            SqlParameter name = new SqlParameter("@AuthorName", b.AuthorName);
            
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, id,name);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        //--------------------------------------------------
        public bool deleteAuthor(Author b)
        {
            string SQL = "Delete tblAuthor where AuthorID=@AuthorID";
            //string SQL = "Delete Books where BookID=@ID";
            SqlParameter ID = new SqlParameter("@AuthorID", b.AuthorID);
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, ID);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
    }
}
