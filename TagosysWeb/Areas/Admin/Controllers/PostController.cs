using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : BaseController
    {
        public IPostService _postService;
        public IPageService _pageService;
        public PostController(IPostService postService, IPageService pageService)
        {
            _postService = postService;
            _pageService = pageService;
            authorize("AddUpdatePostForm,postList");
        }

        public async Task<IActionResult> AddUpdatePostForm(int id)
        {
            if(!ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Post/AddUpdatePostForm.cshtml");
            }
            else
            {
                if (id != 0)
                {
                    var rslt = await _postService.editPost(id);
                    ViewData["postData"] = rslt.data;
                    var pageData = await _pageService.pageList();
                    ViewData["page"] = pageData.data;
                    return View("~/Areas/Admin/Views/Post/AddUpdatePostForm.cshtml");
                }
                else
                {
                    var pageData = await _pageService.pageList();
                    ViewData["page"] = pageData.data;
                    return View("~/Areas/Admin/Views/Post/AddUpdatePostForm.cshtml");
                }
            }
            //return View("~/Areas/Admin/Views/Post/AddUpdatePostForm.cshtml");
        }

        public async Task<IActionResult> AddUpdatePost([FromForm] PostInput value)
        {
            var rslt = await _postService.addUpdatePost(value);
            if (rslt.succeed)
            {
                TempData["Success"] = "Add Successfully";
                return RedirectToAction("postList", "Post");
            }
            else
            {
                TempData["error"] = "Your data not saved ";
                return RedirectToAction("AddUpdatePostForm", "Post");
            }

        }
        public async Task<IActionResult> postList()
        {
            var rslt = await _postService.postList();
            ViewData["postList"] = rslt.data;
            return View("~/Areas/Admin/Views/Post/postList.cshtml");
        }

        public async Task<IActionResult> ActiveInActive(int id)
        {
            var rslt = await _postService.activeInActive(id);
            return Redirect(HttpContext.Request.Headers["Referer"]);

        }



    }
}
