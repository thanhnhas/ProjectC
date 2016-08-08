using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Data_Tier
{
    public class DataProvider
    {
        public static string getConnectionString()
        {
            string strConnection = ConfigurationManager.
                ConnectionStrings["DTBooks"].ConnectionString;
            return strConnection;
        }

        public static DataSet ExecuteQueryWithDataSet(string strSQL,
        CommandType cmdType,
        params SqlParameter[] param)
        {
            SqlConnection cnn = new SqlConnection(getConnectionString());
            SqlCommand cmd = new SqlCommand(strSQL, cnn);
            cmd.CommandType = cmdType;
            cmd.Parameters.AddRange(param);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public static SqlDataReader ExecuteQueryWithDataReader(string strSQL,
            CommandType cmdType, params SqlParameter[] param)
        {
            SqlDataReader rd = null;
            SqlConnection cnn = new SqlConnection(getConnectionString());
            SqlCommand cmd = new SqlCommand(strSQL, cnn);
            cmd.CommandType = cmdType;
            cmd.Parameters.AddRange(param);
            try
            {
                cnn.Open();
                rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            return rd;
        }
        //ExecuteNonQuery
        public static bool ExecuteNonQuery(string strSQL,
            CommandType cmdType, params SqlParameter[] paramList)
        {
            bool result = false;
            SqlConnection cnn = new SqlConnection(getConnectionString());
            SqlCommand cmd = new SqlCommand(strSQL, cnn);
            cmd.CommandType = cmdType;
            cmd.Parameters.AddRange(paramList);
            try
            {
                cnn.Open();
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }
        /*
        public DataTable getUser()
        {
            string SQL = "select * from tblUser";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtEmp = new DataTable();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                da.Fill(dtEmp);
            }
            catch (Exception se)
            {

                throw new Exception(se.Message);
            }
            finally { cnn.Close(); }
            return dtEmp;
        }
        public bool AddUser(Users e)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Insert tblUser values(@username,@password,@type,@name,@address,@phone,@count,@status)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@username", e.UserName);
            cmd.Parameters.AddWithValue("@password", e.UserPassword);
            cmd.Parameters.AddWithValue("@type", e.UserType);
            cmd.Parameters.AddWithValue("@name", e.Name);
            cmd.Parameters.AddWithValue("@address", e.UserAddress);
            cmd.Parameters.AddWithValue("@phone", e.UserPhone);
            cmd.Parameters.AddWithValue("@count", e.UserCount);
            cmd.Parameters.AddWithValue("@status", e.UserStatus);

            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;

        }
        */
    }
}
