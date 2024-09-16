using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace TagosysWeb.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        List<string> authenitcateAction { get; set; }
        List<string> authorizeAction { get; set; } = new List<string>();


        public void authenticate(string actions)
        {
            string[] actionsArr = actions.Split(",");
            this.authenitcateAction = actionsArr.ToList();
        }

        public void authorize(string actions)
        {
            string[] actionsArr = actions.Split(",");
            this.authorizeAction = actionsArr.ToList();
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var httpContextAccessor = new HttpContextAccessor();

            string id = httpContextAccessor.HttpContext.Session.GetString("id");
            int? userType = httpContextAccessor.HttpContext.Session.GetInt32("usertype");
            //var controller = httpContextAccessor.HttpContext.Request.RouteValues["controller"].ToString();
            string currentAction = httpContextAccessor.HttpContext.Request.RouteValues["action"].ToString();

            if (this.authorizeAction.Contains(currentAction) && string.IsNullOrEmpty(id))
            {
                Response.Redirect("../Auth/Login");
            }
            else if (this.authorizeAction.Contains(currentAction) && !string.IsNullOrEmpty(id))
            {
                if (userType != 1)
                    Response.Redirect("../Auth/Login");
            }
        }
    }
}
