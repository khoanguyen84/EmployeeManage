using EmployeeManage.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeManage.DAL
{
    public class BaseRepository
    {
        protected  IDbConnection conn;
        public BaseRepository()
        {
            conn = new SqlConnection(Common.ConnectionString);
        }
    }
}
