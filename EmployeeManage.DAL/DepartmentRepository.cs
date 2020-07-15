using Dapper;
using EmployeeManage.DAL.Interface;
using EmployeeManage.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EmployeeManage.DAL
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DeleteDepartmentResult Delete(int departmentId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departmentId);
            return SqlMapper.Query<DeleteDepartmentResult>(cnn: conn,
                             param: parameters,
                            sql: "sp_DeleteDepartment",
                            commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public Department Get(int departmentId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departmentId);
            return SqlMapper.Query<Department>(cnn: conn,
                             param: parameters,
                            sql: "sp_GetDepartment", 
                            commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<Department> Gets()
        {
            //string sql = @"SELECT [DepartmentId] ,[DepartmentName]  FROM [dbo].[Department]";
            //return SqlMapper.Query<Department>(conn, sql, CommandType.Text);
            return SqlMapper.Query<Department>(conn, "sp_GetDepartments", CommandType.StoredProcedure);
        }

        public SaveDepartmentResult Save(Department request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DepartmentId", request.DepartmentId);
                parameters.Add("@DeparmentName", request.DepartmentName);
                return SqlMapper.Query<SaveDepartmentResult>(cnn: conn, sql: "sp_SaveDepartment",
                                            param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new SaveDepartmentResult()
                {
                    DepartmentId = 0,
                    Message = "Something went wrong, please try again"
                };
            }

        }
    }
}
