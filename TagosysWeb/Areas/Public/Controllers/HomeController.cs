using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Public.Controllers
{
    [Area("Public")]
    public class HomeController : Controller
    {
        public IPostDescriptionService _postDescriptionService;
        public HomeController(IPostDescriptionService postDescriptionService)
        {
            _postDescriptionService = postDescriptionService;
        }

        

        public IActionResult index()
        {
            return View($"~/Areas/Public/Views/Home/index.cshtml");
        }

        public async Task<IActionResult> Mobileapp()
        {
            return View($"~/Areas/Public/Views/Home/Mobileapp.cshtml");
        }
        public async Task<IActionResult> RefundPolicy()
        {
            return View($"~/Areas/Public/Views/Home/RefundPolicy.cshtml");
        }
        public async Task<IActionResult> Terms()
        {
            return View($"~/Areas/Public/Views/Home/Terms.cshtml");
        }

        public async Task<IActionResult> Privacy()
        {
            return View($"~/Areas/Public/Views/Home/Privacy.cshtml");
        }
    }
}
