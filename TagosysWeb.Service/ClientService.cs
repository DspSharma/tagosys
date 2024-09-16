using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Core.DTO.DtoOutput;
using TagosysWeb.Core.Models;
using TagosysWeb.Data.DBContext;
using TagosysWeb.Data.Entities;
using TagosysWeb.Data.UnitOfWork;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Service
{
    public class ClientService : IClientService
    {
        public IUnitOfWork _unitOfWork;
        public readonly tagosyswebContext _context;
        public IMapper _mapper;
        public ISystemSettingService _systemSettingService;
        public IImageService _imageService;

        public ClientService(IUnitOfWork unitOfWork, tagosyswebContext context, IMapper mapper, ISystemSettingService systemSettingService, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
            _systemSettingService = systemSettingService;
            _imageService = imageService;
        }



        public async Task<ApiResponseModels<ClientOutput>> addUpdateClient(ClientInput model)
        {

            // ImageEndpointModel res = await _systemsettingService.getEndpoint();
            Client formValue = _mapper.Map<Client>(model);
            if (formValue.Id != 0)
            {
                Client client = await _unitOfWork.Client.GetByIdAsync(model.Id);
                if (model.Image != null)
                {

                    if (model.ImageFile != null)
                    {

                         await _imageService.deleteUploadImageLocal(client.Image);
                        client.Image = model.Image;
                    }
                    else
                    {
                        client.Image = model.Image;
                    }
                }

                client.Name = model.Name;
                client.Country = model.Country;
                client.Rating = model.Rating;
                client.Tittle = model.Tittle;
                client.Description = model.Description;

                client.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.SaveAsync();
            }
            else
            {
                
                await _imageService.activeImage(formValue.Image);
                formValue.Image = model.Image;
                formValue.IsActive = false;
                formValue.CreatedAt = DateTime.UtcNow;
                formValue.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.Client.AddAsync(formValue);
                await _unitOfWork.SaveAsync();
            }
            return new ApiResponseModels<ClientOutput>
            {
                succeed = true,
                message = "success"
            };
        }
        public async Task<ApiResponseModels<ClientOutput>> editClient(int id)
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            Client client = await _unitOfWork.Client.GetByIdAsync(id);
            var rslt = _mapper.Map<ClientOutput>(client);
            if (rslt != null)
            {

                var thumbImage = client.Image;
                rslt.LocalImage = res.imageThumbFolder + thumbImage;
            }
            return new ApiResponseModels<ClientOutput>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }

        public async Task<ApiResponseModels<List<ClientOutput>>> clientList()
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            List<Client> clients = (await _unitOfWork.Client.GetAllAsync()).ToList();
            var rslt = _mapper.Map<List<ClientOutput>>(clients);
            foreach (var client in rslt)
            {
                var thumbImage = client.Image;
                client.LocalImage = res.imageThumbFolder + thumbImage;
            }
            return new ApiResponseModels<List<ClientOutput>>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }

        public async Task<ApiResponseModels<List<ClientOutput>>> getClientList()
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            List<Client> clients = _unitOfWork.Client.GetWhere(x=>x.IsActive == true).ToList();
            var rslt = _mapper.Map<List<ClientOutput>>(clients);
            foreach (var client in rslt)
            {
                var thumbImage = client.Image;
                client.LocalImage = res.imageThumbFolder + thumbImage;
            }
            return new ApiResponseModels<List<ClientOutput>>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }
        public async Task<ApiResponseModels<bool>> clientDeleteById(int id)
        {
            Client client = await _unitOfWork.Client.GetByIdAsync(id);
            if (client.Id == id)
            {

                await _imageService.deleteUploadImageLocal(client.Image);
                _unitOfWork.Client.Remove(client);
                await _unitOfWork.SaveAsync();
            }
            return new ApiResponseModels<bool>
            {
                succeed = true,
                message = "success"
            };
        }

        public async Task<ApiResponseModels<bool>> activeInActive(int id)
        {
            Client client = await _unitOfWork.Client.GetByIdAsync(id);
            if (client.IsActive == true)
            {
                client.IsActive = false;
            }
            else
            {
                client.IsActive = true;
            }
            await _unitOfWork.SaveAsync();
            return new ApiResponseModels<bool>
            {
                succeed = true,
                message = "success"
            };
        }


    }
}
