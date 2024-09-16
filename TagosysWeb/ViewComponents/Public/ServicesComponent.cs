using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.ViewComponents.Public
{
    [ViewComponent(Name = "Services")]
    public class ServicesComponent : ViewComponent
    {
        public IPostService _postService;
        public ServicesComponent(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var about = await _postService.getPostList();
            ViewData["aboutData"] = about.data;
            return View("~/Areas/Public/Views/Components/Services/Services.cshtml");
            //return View($"~/Pages/Components/About/About.cshtml");

        }
    }
}
