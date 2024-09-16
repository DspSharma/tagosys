using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Data.DBContext;
using TagosysWeb.Data.UnitOfWork;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : BaseController
    {
        public readonly tagosyswebContext _Context;
        public IUnitOfWork _unitOfWork;
      
        public IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        const string SessionId = "Id";
        const string SessionEmail = "Email";
        const string SessionRole = "UserType";

        public AuthController(tagosyswebContext context,IUnitOfWork unitOfWork,IUserService userService,IHttpContextAccessor contextAccessor)
        {
            _Context = context;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _contextAccessor = contextAccessor;

            authorize("UserList");
        }



        public async Task<IActionResult> Login()
        {
            return View("~/Areas/Admin/Views/Auth/Login.cshtml");
        }

        public async Task<IActionResult> AuthLogin([FromForm] UserLoginInput value)
        {

            var rslt = await _userService.Login(value);
            if (rslt.succeed)
            {
                _contextAccessor.HttpContext.Session.SetInt32("id", rslt.data.Id);
                _contextAccessor.HttpContext.Session.SetInt32("usertype", rslt.data.UserType);
                ViewData["UserData"] = rslt.data.UserType;
                if (rslt.data.UserType == 1)
                {
                    return RedirectToAction("ProjectList", "Project", new { area = "Admin" });
                }
            }
            else
            {
                TempData["error"] = "Your Email Id Or Password Is Incorect";

            }
            return RedirectToAction("Login", "Auth");

        }

        public async Task<IActionResult> Register([FromForm] UserInput value)
        {
            if(!ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Auth/Register.cshtml");
            }
            else
            {
                var rslt = await _userService.userAdd(value);
                if(rslt.succeed)
                {
                    return View("~/Areas/Admin/Views/Auth/Login.cshtml");
                }
                else
                {
                    return View("~/Areas/Admin/Views/Auth/Register.cshtml");
                }

            }
           // return View("~/Areas/Admin/Views/Auth/Register.cshtml");
        }
        public async Task<IActionResult>UserList()
        {
            var rslt = await _userService.userList();
            ViewData["userList"] = rslt.data;
            return View("~/Areas/Admin/Views/Auth/UserList.cshtml");
        }

        public async Task<IActionResult> ActiveInActive(int id)
        {
            var rslt = await _userService.activeInActive(id);
            return Redirect(HttpContext.Request.Headers["Referer"]);

        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("../Auth/Login");
        }


    }
}
