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
    public class UserRegisDB
    {
        //ham dung de them 1 user
        public bool addNewUser(UserRegisEn b)
        {

            string SQL =
                "Insert tblUser values(@ID,@PWD,2,'','','',0,2)";
            SqlParameter id = new SqlParameter("@ID", b.ID);
            SqlParameter pwd = new SqlParameter("@PWD", b.PWD);
            
            try
            {
                return DataProvider.ExecuteNonQuery(SQL, CommandType.Text, id,pwd);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        //ham dung de kiem tra ten tai khoan da ton tai hay khong
        public DataSet getUsertoCheck(UserRegisEn a)
        {
            string SQL =
                "select * from tblUser where username = '"+ a.ID +"'";
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
