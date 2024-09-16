using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TagosysWeb.ViewComponents.admin
{
    [ViewComponent(Name = "ImageUploadPopup")]
    public class ImageUploadPopup : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("~/Areas/Admin/Views/Components/ImageUploadPopup/ImageUploadPopup.cshtml");
        }
    }
}
