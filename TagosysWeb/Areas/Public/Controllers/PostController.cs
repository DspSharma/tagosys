using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Public.Controllers
{
    [Area("Public")]
    public class PostController : Controller
    {
        public IPostDescriptionService _postDescriptionService;
        public PostController(IPostDescriptionService postDescriptionService)
        {
            _postDescriptionService = postDescriptionService;
        }

        public async Task<IActionResult> postDescription(int id)
        {
            var rslt = await _postDescriptionService.postDescriptionById(id);
            ViewData["postData"] = rslt.data;
            return View($"~/Areas/Public/Views/Post/postDescription.cshtml");

        }
    }
}
