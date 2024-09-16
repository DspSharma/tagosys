using AutoMapper;
using Microsoft.AspNetCore.Hosting;
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
    public class TeamService : ITeamService
    {
        public IUnitOfWork _unitOfWork;
        public readonly tagosyswebContext _context;
        public IMapper _mapper;
        private IWebHostEnvironment _environment;
        public IImageService _imageService;
        public ISystemSettingService _systemSettingService;

        public TeamService(IUnitOfWork unitOfWork, tagosyswebContext context, IMapper mapper, IWebHostEnvironment environment, IImageService imageService, ISystemSettingService systemSettingService)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
            _environment = environment;
            _imageService = imageService;
            _systemSettingService = systemSettingService;
        }

        public async Task<ApiResponseModels<TeamOutput>> addUpdateTeam(TeamInput model)
        {
            Team formValue = _mapper.Map<Team>(model);
            if(formValue.Id !=0)
            {
                Team team = await _unitOfWork.Team.GetByIdAsync(model.Id);
                if(model.Image !=null)
                {
                    if(model.ImageFile !=null)
                    {
                        await _imageService.deleteUploadImageLocal(team.Image);
                        team.Image = model.Image;
                    }
                    else
                    {
                        team.Image = model.Image;
                    }
                }
                team.Name = model.Name;
                team.ProfessionField = model.ProfessionField;
                team.Dob = model.Dob;
                team.City = model.City;
                team.State = model.State;
                team.Address = model.Address;
                team.Email = model.Email;
                team.Mobile = model.Mobile;
                team.Designation = model.Designation;
                team.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.SaveAsync();
            }
            else
            {
                await _imageService.activeImage(formValue.Image);
                formValue.Image = model.Image;
                formValue.IsActive = false;
                formValue.CreatedAt = DateTime.UtcNow;
                formValue.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.Team.AddAsync(formValue);
                await _unitOfWork.SaveAsync();
            }
            return new ApiResponseModels<TeamOutput>
            {
                succeed = true,
                message = "success"
            };
        }

        public async Task<ApiResponseModels<TeamOutput>> editTeam(int id)
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            Team team = await _unitOfWork.Team.GetByIdAsync(id);
            var rslt = _mapper.Map<TeamOutput>(team);
            if(rslt !=null)
            {
                var thumbImage = team.Image;
                rslt.LocalImage = res.imageThumbFolder + thumbImage;
            }
            return new ApiResponseModels<TeamOutput>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }

        public async Task<ApiResponseModels<List<TeamOutput>>> teamList()
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            List<Team> team = (await _unitOfWork.Team.GetAllAsync()).ToList();
            var reslt = _mapper.Map<List<TeamOutput>>(team);
            foreach (var teams in reslt)
            {

                var thumbImage = teams.Image;
                teams.LocalImage = res.imageThumbFolder + thumbImage;

            }
            return new ApiResponseModels<List<TeamOutput>>
            {
                succeed = true,
                message = "success",
                data = reslt
            };
        }

        public async Task<ApiResponseModels<List<TeamOutput>>>getTeamList()
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            List<Team> team = _unitOfWork.Team.GetWhere(x => x.IsActive == true).ToList();
            var rslt = _mapper.Map<List<TeamOutput>>(team);
            foreach (var teams in rslt)
            {

                var thumbImage = teams.Image;
                teams.LocalImage = res.imageThumbFolder + thumbImage;

            }
            return new ApiResponseModels<List<TeamOutput>>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }

        public async Task<ApiResponseModels<bool>> teamDeleteById(int id)
        {
            Team team = await _unitOfWork.Team.GetByIdAsync(id);
            if (team.Id == id)
            {

                await _imageService.deleteUploadImageLocal(team.Image);
                _unitOfWork.Team.Remove(team);
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
            Team team = await _unitOfWork.Team.GetByIdAsync(id);
            if (team.IsActive == true)
            {
                team.IsActive = false;
            }
            else
            {
                team.IsActive = true;
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
