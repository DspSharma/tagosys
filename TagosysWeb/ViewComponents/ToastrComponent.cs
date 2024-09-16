using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TagosysWeb.ViewComponents
{
    [ViewComponent(Name = "Toaster")]
    public class ToastrComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Areas/Public/Views/Components/Toaster/Toaster.cshtml");
            //return View("~/Pages/Components/Toaster/Toaster.cshtml");

        }
    }
}
