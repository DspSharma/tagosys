using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : BaseController
    {
        public IPageService _pageService;
        public PageController(IPageService pageService)
        {
            _pageService = pageService;
            authorize("AddUpdatePageForm,pageList");
        }
        public async Task<IActionResult> AddUpdatePageForm(int id)
        {
            if (!ModelState.IsValid)
            {
               
                return View("~/Areas/Admin/Views/Page/AddUpdatePageForm.cshtml");
            }
            else
            {
                if (id != 0)
                {
                    var rslt = await _pageService.editPage(id);
                   
                    ViewData["pageData"] = rslt.data;
                   
                    return View("~/Areas/Admin/Views/Page/AddUpdatePageForm.cshtml");
                }
                else
                {
                    
                    return View("~/Areas/Admin/Views/Page/AddUpdatePageForm.cshtml");
                }
            }
        }

        public async Task<IActionResult> AddUpdatePage([FromForm] PageInput value)
        {
            var rslt = await _pageService.addUpdatePage(value);
            if (rslt.succeed)
            {
                TempData["Success"] = "Add Successfully";
                return RedirectToAction("pageList", "Page");
            }
            else
            {
                TempData["error"] = "Your data not saved ";
                return RedirectToAction("AddUpdatePageForm", "Page");
            }

        }

        public async Task<IActionResult>pageList()
        {
            var rslt = await _pageService.pageList();
            ViewData["pageList"] = rslt.data;
            return View("~/Areas/Admin/Views/Page/pageList.cshtml");
        }
        public async Task<IActionResult> pageDeleteById(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var rslt = await _pageService.pageDeleteById(id);
                if (rslt.succeed)
                {
                    TempData["message"] = "deleted";
                }
            }
            return RedirectToAction("pageList");
        }
        public async Task<IActionResult> ActiveInActive(int id)
        {
            var rslt = await _pageService.activeInActive(id);
            return Redirect(HttpContext.Request.Headers["Referer"]);

        }

    }
}
