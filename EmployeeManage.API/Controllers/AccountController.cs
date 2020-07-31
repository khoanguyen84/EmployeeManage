using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManage.API.DbContext;
using EmployeeManage.BAL.Interface;
using EmployeeManage.Domain;
using EmployeeManage.Domain.Requests.Account;
using EmployeeManage.Domain.Responses.Account;
using EmployeeManage.Domain.Responses.Departments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManage.API.Controllers
{
    /// <summary>
    /// Department API
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        
        private readonly ILogger<DepartmentController> _logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(ILogger<DepartmentController> logger,
                                    UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        [Route("/api/account/login")]
        public async Task<LoginResult> Login(LoginRequest request)
        {
            var result = new LoginResult()
            {
                Message = "something went wrong, please try again",
                Success = false,
                UserId = string.Empty
            };

            var siginResult =  await signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            if (siginResult.Succeeded)
            {
                var user = await userManager.FindByNameAsync(request.Email);
                if(user != null)
                {
                    result.Success = siginResult.Succeeded;
                    result.UserId = user.Id;
                    result.Message = "Login success";
                }
            }

            return result;
        }

        [HttpPost]
        [Route("/api/account/register")]
        public async Task<RegisterResult> Register(RegisterRequest request)
        {
            var result = new RegisterResult()
            {
                Message = "something went wrong, please try again",
                Success = false
            };

            var user = new ApplicationUser()
            {
                Email = request.Email,
                UserName = request.Email
            };
            var registerResult = await userManager.CreateAsync(user, request.Password);
            if (registerResult.Succeeded)
            {
                result.Message = "Register success";
                result.Success = registerResult.Succeeded;
            }
            return result;
        }

    }
}

