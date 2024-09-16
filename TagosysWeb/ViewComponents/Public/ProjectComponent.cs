using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.ViewComponents.Public
{
    [ViewComponent(Name = "Project")]
    public class ProjectComponent : ViewComponent
    {
        public IProjectService _projectService;

        public ProjectComponent(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var team = await _projectService.getProjectList();
            ViewData["projectData"] = team.data;
            return View("~/Areas/Public/Views/Components/Project/Project.cshtml");
            // return View($"~/Pages/Components/Project/Project.cshtml");

        }
    }
}
