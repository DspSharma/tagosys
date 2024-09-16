using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TagosysWeb.Areas.Public.Controllers
{
    [Area("Public")]
    public class TeamController : Controller
    {
        public async Task<IActionResult> Team()
        {
            return View($"~/Areas/Public/Views/Team/Team.cshtml");
        }
    }
}
