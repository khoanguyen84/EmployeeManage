using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManage.BAL.Interface;
using EmployeeManage.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManage.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService departmentService;

        public DepartmentController(ILogger<DepartmentController> logger,
                                    IDepartmentService departmentService)
        {
            _logger = logger;
            this.departmentService = departmentService;
        }

        /// <summary>
        /// Get all department in DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/department/gets")]
        public IEnumerable<Department> Gets()
        {
            return departmentService.Gets();
        }

        /// <summary>
        /// Get department by departmentid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/department/get/{id}")]
        public Department Get(int id)
        {
            return departmentService.Get(id);
        }

        [HttpPost]
        [Route("/api/department/save")]
        public SaveDepartmentResult Save(Department request)
        {
            return departmentService.Save(request);
        }

        [HttpDelete]
        [Route("/api/department/delete/{id}")]
        public DeleteDepartmentResult Delete(int id)
        {
            return departmentService.Delete(id);
        }
    }
}
