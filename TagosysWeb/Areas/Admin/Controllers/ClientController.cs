using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientController : BaseController
    {
        public IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
            authorize("AddUpdateClientForm,clientList");
        }
        
        public async Task<IActionResult> AddUpdateClientForm(int id)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Client/AddUpdateClientForm.cshtml");
            }
            else
            {
                if (id != 0)
                {
                    var rslt = await _clientService.editClient(id);
                    ViewData["clientData"] = rslt.data;
                    return View("~/Areas/Admin/Views/Client/AddUpdateClientForm.cshtml");
                }
                else
                {
                    return View("~/Areas/Admin/Views/Client/AddUpdateClientForm.cshtml");
                }
            }
        }

        public async Task<IActionResult> AddUpdateClient([FromForm] ClientInput value)
        {
            var rslt = await _clientService.addUpdateClient(value);
            if (rslt.succeed)
            {
                TempData["Success"] = "Add Successfully";
                return RedirectToAction("clientList", "Client");
            }
            else
            {
                TempData["error"] = "Your data not saved ";
                return RedirectToAction("AddUpdateClientForm", "Client");
            }

        }

        public async Task<IActionResult>clientList()
        {
            var rslt = await _clientService.clientList();
            TempData["clientData"] = rslt.data;
            return View("~/Areas/Admin/Views/Client/clientList.cshtml");
        }

        public async Task<IActionResult> clientDeleteById(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var rslt = await _clientService.clientDeleteById(id);
                if (rslt.succeed)
                {
                    TempData["message"] = "deleted";
                }
            }
            return RedirectToAction("clientList");
        }

        public async Task<IActionResult> ActiveInActive(int id)
        {
            var rslt = await _clientService.activeInActive(id);
            return Redirect(HttpContext.Request.Headers["Referer"]);

        }


    }
}
