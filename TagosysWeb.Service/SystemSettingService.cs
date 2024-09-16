using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Core.DTO.DtoOutput;
using TagosysWeb.Core.Misc;
using TagosysWeb.Core.Models;
using TagosysWeb.Data.DBContext;
using TagosysWeb.Data.Entities;
using TagosysWeb.Data.UnitOfWork;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Service
{
    public class SystemSettingService : ISystemSettingService
    {

        public IUnitOfWork _unitOfWork;
        public tagosyswebContext _context;
        public IMapper _mapper;
      //  public IImageService _imageService;

        public SystemSettingService(IUnitOfWork unitOfWork, tagosyswebContext context, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
           // _imageService = imageService;
        }


        public async Task<ApiResponseModels<SystemsettingOutput>> addUpdateSetting(SystemsettingInput model)
        {
            Systemsetting formValue = _mapper.Map<Systemsetting>(model);
            if (formValue.Id != 0)
            {
                Systemsetting systemsetting = await _unitOfWork.Systemsetting.GetByIdAsync(model.Id);
                if (model.Logo != null)
                {
                    if (model.ImageFile != null)
                    {
                        systemsetting.Logo = model.Logo;
                    }
                    else
                    {
                        systemsetting.Logo = model.Logo;
                    }
                }
                systemsetting.Name = model.Name;
                systemsetting.Mobile = model.Mobile;
                systemsetting.Email = model.Email;
                systemsetting.FacebookUrl = model.FacebookUrl;
                systemsetting.InstagramUrl = model.InstagramUrl;
                systemsetting.YouTubeUrl = model.YouTubeUrl;
                systemsetting.TwitterUrl = model.TwitterUrl;
                systemsetting.MapUrl = model.MapUrl;
                systemsetting.RegisteredOfficeAddress = model.RegisteredOfficeAddress;
                systemsetting.OperationalOfficeAddress = model.OperationalOfficeAddress;
                systemsetting.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.SaveAsync();
            }
            else
            {
               // await _imageService.activeImage(formValue.Logo);
                formValue.Logo = model.Logo;
                formValue.IsActive = false;
                formValue.CreatedAt = DateTime.UtcNow;
                formValue.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.Systemsetting.AddAsync(formValue);
                await _unitOfWork.SaveAsync();
            }
            return new ApiResponseModels<SystemsettingOutput>
            {
                succeed = true,
                message = "success"
            };
        }

        public async Task<ApiResponseModels<SystemsettingOutput>> getDefaultSetting()
        {
            ImageEndpointModel res = await getEndpoint();
            Systemsetting Editsetting = (await _unitOfWork.Systemsetting.GetAllAsync()).FirstOrDefault();
            var rslt = _mapper.Map<SystemsettingOutput>(Editsetting);
            if (rslt != null)
            {
                var localLogo = rslt.Logo;
                rslt.LocalImage = res.imageOrgFolder + localLogo;
            }
            return new ApiResponseModels<SystemsettingOutput>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }

        public async Task<ApiResponseModels<SystemsettingOutput>> getSystemSetting()
        {
            ImageEndpointModel res = await getEndpoint();
            Systemsetting systemsetting = (await _unitOfWork.Systemsetting.GetAllAsync()).FirstOrDefault();
            var rslt = _mapper.Map<SystemsettingOutput>(systemsetting);
            if (rslt != null)
            {
                var localLogo = rslt.Logo;
               
                rslt.LocalImage = res.imageOrgFolder + localLogo;
            }
            return new ApiResponseModels<SystemsettingOutput>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }
        public async Task<ImageEndpointModel> getEndpoint()
        {
           
            return new ImageEndpointModel()
            {
                imageOrgFolder = "/TagosysImage/original/",
                imageThumbFolder = "/TagosysImage/Thumbnail/",
               
            };

        }
    }
}
