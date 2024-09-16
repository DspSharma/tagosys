using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Data.UnitOfWork;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : BaseController
    {


        public IProjectService _projectService;
        public IUnitOfWork _unitOfWork;
       

        public ProjectController(IProjectService projectService, IUnitOfWork unitOfWork)
        {
            _projectService = projectService;
            _unitOfWork = unitOfWork;
            authorize("AddUpdateProjectForm,ProjectList");

        }


        public async Task<IActionResult> AddUpdateProject([FromForm] ProjectInput value)
        {
            var rslt = await _projectService.addUpdateProject(value);
            if (rslt.succeed)
            {
                TempData["Success"] = "Add Successfully";
                return RedirectToAction("ProjectList", "Project");
            }
            else
            {
                TempData["error"] = "Your data not saved ";
                return RedirectToAction("AddUpdateProjectForm", "Project");
            }

        }

        public async Task<IActionResult> AddUpdateProjectForm(int id)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Project/AddUpdateProjectForm.cshtml");
            }
            else
            {
                if (id != 0)
                {
                    var rslt = await _projectService.editProject(id);
                    ViewData["projectData"] = rslt.data;
                    return View("~/Areas/Admin/Views/Project/AddUpdateProjectForm.cshtml");
                }
                else
                {
                    return View("~/Areas/Admin/Views/Project/AddUpdateProjectForm.cshtml");
                }
            }

        }

        public async Task<IActionResult> ProjectList()
        {
            var rslt = await _projectService.projectList();
            ViewData["projectList"] = rslt.data;
            return View("~/Areas/Admin/Views/Project/ProjectList.cshtml");
            // return View();
        }

        public async Task<IActionResult> projectDeleteById(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var rslt = await _projectService.projectDeleteById(id);
                if (rslt.succeed)
                {
                    TempData["message"] = "deleted";
                }
            }
            return RedirectToAction("ProjectList");
        }

        public async Task<IActionResult> ActiveInActive(int id)
        {
            var rslt = await _projectService.activeInActive(id);
            return Redirect(HttpContext.Request.Headers["Referer"]);

        }

       

    }
}
