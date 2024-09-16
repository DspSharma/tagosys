using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.ViewComponents.Public
{
    [ViewComponent(Name = "Postdescription")]
    public class PostdescriptionComponent : ViewComponent
    {
        public IPostDescriptionService _postDescriptionService;
        public PostdescriptionComponent(IPostDescriptionService postDescriptionService)
        {
            _postDescriptionService = postDescriptionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var team = await _postDescriptionService.postDescriptionById(id);
            ViewData["projectData"] = team.data;
            return View($"~/Pages/Components/Postdescription/Postdescription.cshtml");

        }
    }
}
