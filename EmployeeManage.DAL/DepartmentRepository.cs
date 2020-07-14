using Dapper;
using EmployeeManage.DAL.Interface;
using EmployeeManage.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManage.DAL
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public bool Delete(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Department Get(int departmentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> Gets()
        {
            //string sql = @"SELECT [DepartmentId] ,[DepartmentName]  FROM [dbo].[Department]";
            //return SqlMapper.Query<Department>(conn, sql, CommandType.Text);
            return SqlMapper.Query<Department>(conn, "sp_GetDepartments", CommandType.StoredProcedure);
        }

        public int Save(Department request)
        {
            throw new NotImplementedException();
        }
    }
}
