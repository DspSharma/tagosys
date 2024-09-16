using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : BaseController
    {
        public ITeamService _teamService;
        
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
            authorize("AddUpdateTeamForm,teamList");
        }
        public async Task<IActionResult> AddUpdateTeamForm(int id)
        {
            if(!ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Team/AddUpdateTeamForm.cshtml");
            }
            else
            {
                if(id !=0)
                {
                    var rslt = await _teamService.editTeam(id);
                    ViewData["teamData"] = rslt.data;
                    return View("~/Areas/Admin/Views/Team/AddUpdateTeamForm.cshtml");
                }
                else
                {
                    return View("~/Areas/Admin/Views/Team/AddUpdateTeamForm.cshtml");
                }
            }
        }

        public async Task<IActionResult> addUpdateTeam([FromForm] TeamInput model)
        {
            var rslt = await _teamService.addUpdateTeam(model);
            if (rslt.succeed)
            {
                TempData["Success"] = "Add Successfully";
                return RedirectToAction("teamList", "Team");
            }
            else
            {
                TempData["error"] = "Your data not saved ";
                return RedirectToAction("AddUpdateTeamForm", "Team");
            }
            return RedirectToAction("AddUpdateTeamForm", "Team");
        }

        public async Task<IActionResult>teamList()
        {
            var rslt = await _teamService.teamList();
            ViewData["teamList"] = rslt.data;
            return View("~/Areas/Admin/Views/Team/teamList.cshtml");
            //return View();
        }

        public async Task<IActionResult> teamDeleteById(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var rslt = await _teamService.teamDeleteById(id);
                if (rslt.succeed)
                {
                    TempData["message"] = "deleted";
                }
            }
            return RedirectToAction("teamList");
        }

        public async Task<IActionResult> ActiveInActive(int id)
        {
            var rslt = await _teamService.activeInActive(id);
            return Redirect(HttpContext.Request.Headers["Referer"]);

        }


    }
}
