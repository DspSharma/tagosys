using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Data.UnitOfWork;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : BaseController
    {
        public IUnitOfWork _unitOfWork;
        public IContactService _contactService;

        public ContactController(IUnitOfWork unitOfWork, IContactService contactService)
        {
            _unitOfWork = unitOfWork;
            _contactService = contactService;
             authorize("contactList");
        }

        public async Task<IActionResult> contactList()
        {
            var rslt = await _contactService.contactList();
            ViewData["contactList"] = rslt.data;
            return View("~/Areas/Admin/Views/Contact/contactList.cshtml");
            
        }
        public async Task<IActionResult> AddUpdateContact([FromForm] ContactInput value)
        {

            var rslt = await _contactService.addUpdateContact(value);
            if (rslt.succeed)
            {
                TempData["success"] = "Add Successfully";

            }
            else
            {
                TempData["error"] = "Your data not saved";
            }
            return Redirect(HttpContext.Request.Headers["Referer"]);

        }
    }
}
