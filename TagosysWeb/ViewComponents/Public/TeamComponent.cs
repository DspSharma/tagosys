using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.ViewComponents.Public
{
    [ViewComponent(Name = "Team")]
    public class TeamComponent : ViewComponent
    {
        public ITeamService _teamService;

        public TeamComponent(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var team = await _teamService.getTeamList();
            ViewData["teamData"] = team.data;
            return View("~/Areas/Public/Views/Components/Team/Team.cshtml");
            // return View($"~/Pages/Components/Team/Team.cshtml");

        }


    }
}
