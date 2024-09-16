using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Core.DTO.DtoOutput;
using TagosysWeb.Core.Models;

namespace TagosysWeb.Service.interfaces
{
    public interface ISystemSettingService
    {
        Task<ApiResponseModels<SystemsettingOutput>> addUpdateSetting(SystemsettingInput value);
        Task<ImageEndpointModel> getEndpoint();
        Task<ApiResponseModels<SystemsettingOutput>> getDefaultSetting();
        Task<ApiResponseModels<SystemsettingOutput>> getSystemSetting();
    }
}
