using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.ViewComponents.Public
{
    [ViewComponent(Name = "About")]
    public class AboutComponent : ViewComponent
    {
        public IPostService _postService;
        public AboutComponent(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var about = await _postService.getPostList();
            ViewData["aboutData"] = about.data;
            return View("~/Areas/Public/Views/Components/About/About.cshtml");
            //return View($"~/Pages/Components/About/About.cshtml");

        }

    }
}
