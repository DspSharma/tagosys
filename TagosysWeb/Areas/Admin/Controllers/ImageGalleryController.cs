using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Data.UnitOfWork;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImageGalleryController : Controller
    {
        public IUnitOfWork _unitOfWork;
        public IImageService _imageService;

        public ImageGalleryController(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        public async Task<IActionResult> ImageUpload([FromForm] ImagekitfileInput value)
        {

            var rslt = await _imageService.addUpdateUploadImage(value);
            return Ok(rslt);

        }
    }
}
