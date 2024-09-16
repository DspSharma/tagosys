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
    public class ProjectService : IProjectService
    {
        public IUnitOfWork _unitOfWork;
        public readonly tagosyswebContext _context;
        public IMapper _mapper;
        public ISystemSettingService _systemSettingService;
        public IImageService _imageService;

        public ProjectService(IUnitOfWork unitOfWork, tagosyswebContext context, IMapper mapper, ISystemSettingService systemSettingService, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
            _systemSettingService = systemSettingService;
            _imageService = imageService;
           
        }

        public async Task<ApiResponseModels<ProjectOutput>> addUpdateProject(ProjectInput model)
        {
            Project formValue = _mapper.Map<Project>(model);
            if (formValue.Id != 0)
            {
                Project project = await _unitOfWork.Project.GetByIdAsync(model.Id);
                if (model.Image != null)
                {
                    if (model.ImageFile != null)
                    {
                        await _imageService.deleteUploadImageLocal(project.Image);
                        project.Image = model.Image;
                    }
                    else
                    {
                        project.Image = model.Image;
                    }
                }
                project.ProjectName = model.ProjectName;
                project.Description = model.Description;
                project.ProjectUrl = model.ProjectUrl;

                project.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.SaveAsync();
            }
            else
            {
                await _imageService.activeImage(formValue.Image);
                formValue.Image = model.Image;
                formValue.IsActive = false;
                formValue.CreatedAt = DateTime.UtcNow;
                formValue.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.Project.AddAsync(formValue);
                await _unitOfWork.SaveAsync();
            }
            return new ApiResponseModels<ProjectOutput>
            {
                succeed = true,
                message = "success"
            };
        }

        public async Task<ApiResponseModels<ProjectOutput>> editProject(int id)
        {
           ImageEndpointModel res = await _systemSettingService.getEndpoint();
            Project project = await _unitOfWork.Project.GetByIdAsync(id);
            var rslt = _mapper.Map<ProjectOutput>(project);
            if (rslt != null)
            {
                var thumbImage = project.Image;
                rslt.LocalImage = res.imageThumbFolder + thumbImage;
            }
            return new ApiResponseModels<ProjectOutput>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }

        public async Task<ApiResponseModels<List<ProjectOutput>>> projectList()
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            List<Project> projects = (await _unitOfWork.Project.GetAllAsync()).ToList();
            var reslt = _mapper.Map<List<ProjectOutput>>(projects);
            foreach (var teams in reslt)
            {

                var thumbImage = teams.Image;
                teams.LocalImage = res.imageThumbFolder + thumbImage;

            }
            return new ApiResponseModels<List<ProjectOutput>>
            {
                succeed = true,
                message = "success",
                data = reslt
            };
        }

        public async Task<ApiResponseModels<List<ProjectOutput>>> getProjectList()
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            List<Project> projects = _unitOfWork.Project.GetWhere(x => x.IsActive == true).ToList();
            var rslt = _mapper.Map<List<ProjectOutput>>(projects);
            foreach (var teams in rslt)
            {

                var thumbImage = teams.Image;
                teams.LocalImage = res.imageThumbFolder + thumbImage;

            }
            return new ApiResponseModels<List<ProjectOutput>>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }

        public async Task<ApiResponseModels<bool>> projectDeleteById(int id)
        {
            Project project = await _unitOfWork.Project.GetByIdAsync(id);
            if (project.Id == id)
            {

                await _imageService.deleteUploadImageLocal(project.Image);
                _unitOfWork.Project.Remove(project);
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
            Project project = await _unitOfWork.Project.GetByIdAsync(id);
            if (project.IsActive == true)
            {
                project.IsActive = false;
            }
            else
            {
                project.IsActive = true;
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
