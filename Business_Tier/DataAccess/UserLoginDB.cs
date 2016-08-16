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
    public class UserLoginDB
    {

        //-----------------------//

        //ham dung de kiem tra role cua 1 user khi dang nhap
        public DataSet checkRole(UserLoginEn a)
        {
            string SQL =
                "select * from tblUser u, tblType t where username ='" + a.Username + "' and t.type = u.type and t.description='admin'";
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
        //ham dung de lay du lieu cua nguoi dung
        public DataSet getUsertoLogin(UserLoginEn a)
        {
            string SQL =
                "select * from tblUser where username = '" + a.Username + "' and password='" + a.Password + "'";
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
