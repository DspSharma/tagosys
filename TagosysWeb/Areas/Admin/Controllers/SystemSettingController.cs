using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Core.DTO.DtoOutput;
using TagosysWeb.Core.Models;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SystemSettingController : BaseController
    {
        public ISystemSettingService _systemSettingService;
        public SystemSettingController(ISystemSettingService systemSettingService)
        {
            _systemSettingService = systemSettingService;
            authorize("AddUpdateSystemForm");
        }

        public async Task<IActionResult> AddUpdateSystemForm()
        {
            var systemEdit = await _systemSettingService.getDefaultSetting();
            ViewData["systemEdit"] = systemEdit.data;
            return View("~/Areas/Admin/Views/SystemSetting/AddUpdateSystemForm.cshtml");

        }

        public async Task<IActionResult> AddUpdateSystemSetting([FromForm] SystemsettingInput value)
        {
            var id = value.Id;
            var rslt = new ApiResponseModels<SystemsettingOutput>();
            if (id != 0)
                rslt = await _systemSettingService.addUpdateSetting(value);
            else
                rslt = await _systemSettingService.addUpdateSetting(value);
            if (rslt.succeed)
            {
                TempData["success"] = "Data updated successfully.";
                return RedirectToAction("AddUpdateSystemForm", "SystemSetting");
            }
            else
            {
                TempData["error"] = "An error occurred while updating data.";
                return RedirectToAction("AddUpdateSystemForm", "SystemSetting");
            }

        }

        public async Task<IActionResult> getSystemSetting()
        {
            var rslt = await _systemSettingService.getSystemSetting();
            var systemSettingData = rslt.data;
            
            return Ok(systemSettingData);
        }


    }
}
