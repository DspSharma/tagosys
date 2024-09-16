using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Public.Controllers
{
    [Area("Public")]
    public class PortfolioController : Controller
    {
        public IPostService _postService;
        public PortfolioController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> Portfolio()
        {
            return View($"~/Areas/Public/Views/Portfolio/Portfolio.cshtml");
        }

        public async Task<IActionResult> Blog()
        {
            var about = await _postService.getPostList();
            ViewData["blogData"] = about.data;
            return View($"~/Areas/Public/Views/Portfolio/Blog.cshtml");
        }
    }
}
