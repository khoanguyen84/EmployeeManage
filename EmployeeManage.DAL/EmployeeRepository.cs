using Dapper;
using EmployeeManage.DAL.Interface;
using EmployeeManage.Domain.Requests.Employee;
using EmployeeManage.Domain.Responses;
using EmployeeManage.Domain.Responses.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EmployeeManage.DAL
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public async Task<DeleteEmployeeResult> Delete(int employeeId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", employeeId);
                return await SqlMapper.QueryFirstOrDefaultAsync<DeleteEmployeeResult>(cnn: conn,
                                 param: parameters,
                                sql: "sp_DeleteEmployee",
                                commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                return new DeleteEmployeeResult() { 

                };
            }
            
        }

        public async Task<EmployeeDetail> Get(int employeeId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", employeeId);
            return (await SqlMapper.QueryFirstOrDefaultAsync<EmployeeDetail>(cnn: conn,
                             param: parameters,
                            sql: "sp_GetEmployee",
                            commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<EmployeeView>> Gets(int departId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departId);
            return await SqlMapper.QueryAsync<EmployeeView>(cnn: conn,
                        param: parameters,
                        sql: "sp_GetEmployeesByDepartId",
                        commandType: CommandType.StoredProcedure);
        }

        public async Task<SaveEmployeeResult> Save(SaveEmployeeRequest request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@EmployeeName", request.EmployeeName);
                parameters.Add("@DoB", DateTime.Parse(request.DoB));
                parameters.Add("@Gender", request.Gender == 1);
                parameters.Add("@DepartmentId", request.DepartmentId);
                parameters.Add("@AvatarPath", request.AvatarPath);
                return (await SqlMapper.QueryFirstOrDefaultAsync<SaveEmployeeResult>(cnn: conn,
                                            sql: "sp_SaveEmployee",
                                            param: parameters,
                                            commandType: CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                return new SaveEmployeeResult()
                {
                    EmployeeId = 0,
                    Message = "Something went wrong, please try again"
                };
            }

        }

        //public async Task<IEnumerable<Department>> Search(string keyword)
        //{
        //    DynamicParameters parameters = new DynamicParameters();
        //    parameters.Add("@keyword", keyword);
        //    return await SqlMapper.QueryAsync<Department>(cnn: conn, sql: "sp_SearchDepartment",
        //                                       param: parameters,
        //                                       commandType: CommandType.StoredProcedure);
        //}
    }
}
