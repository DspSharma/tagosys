using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TagosysWeb.Areas.Public.Controllers
{
    [Area("Public")]
    public class ContactController : Controller
    {
        public async Task<IActionResult> Contact()
        {
            return View($"~/Areas/Public/Views/Contact/Contact.cshtml");
        }
    }
}
