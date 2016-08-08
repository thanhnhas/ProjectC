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
    class UserBorrowData
    {

        public DataSet getBorrowByDataSet()
        {
            string SQL = "select * from tblBorrow";
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
                while(rd.Read())
                {
                    UserBorrow urb = new UserBorrow();
                    {
                        username = rd.GetString(0);
                        fromDate = rd.GetDateTime(1);
                        toDate = rd.GetDateTime(2);
                        status = rd.GetBoolean(3);
                        deadline = rd.GetDateTime(4);
                    };
                    borrowList.Add(urb);
                }
            }
            return borrowList;
        }
    }
}
