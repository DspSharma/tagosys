using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostDescriptionController : BaseController
    {
        public IPostDescriptionService _postDescriptionService;
        public IPostService _postService;
        public IPageService _pageService;
        public PostDescriptionController(IPostDescriptionService postDescriptionService, IPostService postService, IPageService pageService)
        {
            _postDescriptionService = postDescriptionService;
            _postService = postService;
            _pageService = pageService;
            authorize("AddUpdatePostDescriptionForm,PostDescriptionList");
        }

        public async Task<IActionResult> AddUpdatePostDescriptionForm(int id)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/PostDescription/AddUpdatePostDescriptionForm.cshtml");
            }
            else
            {
                if (id != 0)
                {
                    var rslt = await _postDescriptionService.editPostDescription(id);
                    ViewData["postDescriptionData"] = rslt.data;
                    var pageData = await _pageService.pageList();
                    ViewData["page"] = pageData.data;
                    var postData = await _postService.postList();
                    ViewData["post"] = postData.data;
                    return View("~/Areas/Admin/Views/PostDescription/AddUpdatePostDescriptionForm.cshtml");
                }
                else
                {
                    var pageData = await _pageService.pageList();
                    ViewData["page"] = pageData.data;
                    var postData = await _postService.postList();
                    ViewData["post"] = postData.data;
                    return View("~/Areas/Admin/Views/PostDescription/AddUpdatePostDescriptionForm.cshtml");
                }
            }
            // return View("~/Areas/Admin/Views/PostDescription/AddUpdatePostDescriptionForm.cshtml");
        }

        public async Task<IActionResult> AddUpdatePostDescription([FromForm] PostdescriptionInput value)
        {
            var rslt = await _postDescriptionService.addUpdatePostDescription(value);
            if (rslt.succeed)
            {
                TempData["Success"] = "Add Successfully";
                return RedirectToAction("PostDescriptionList", "PostDescription");
            }
            else
            {
                TempData["error"] = "Your data not saved ";
                return RedirectToAction("AddUpdatePostDescriptionForm", "PostDescription");
            }

        }

        public async Task<IActionResult> PostDescriptionList()
        {
            var rslt = await _postDescriptionService.postDescriptionList();
            ViewData["postDescriptionList"] = rslt.data;
            return View("~/Areas/Admin/Views/PostDescription/PostDescriptionList.cshtml");
            // return View();
        }
        public async Task<IActionResult> ActiveInActive(int id)
        {
            var rslt = await _postDescriptionService.activeInActive(id);
            return Redirect(HttpContext.Request.Headers["Referer"]);

        }

        public async Task<IActionResult>postDescriptionById()
        {
            return View("~/Pages/postdescription.cshtml");
        }

    }
}
