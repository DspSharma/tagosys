using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.ViewComponents.Public
{
    [ViewComponent(Name = "portfolio")]
    public class portfolioComponent : ViewComponent
    {
        public IProjectService _projectService;

        public portfolioComponent(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var team = await _projectService.getProjectList();
            ViewData["projectData"] = team.data;
            return View("~/Areas/Public/Views/Components/portfolio/portfolio.cshtml");
            //return View($"~/Pages/Components/portfolio/portfolio.cshtml");

        }
    }
}
