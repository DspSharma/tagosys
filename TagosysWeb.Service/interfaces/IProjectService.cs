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
    public interface IProjectService
    {
        public Task<ApiResponseModels<ProjectOutput>> addUpdateProject(ProjectInput model);

        public  Task<ApiResponseModels<List<ProjectOutput>>> projectList();
        public  Task<ApiResponseModels<List<ProjectOutput>>> getProjectList();
        public  Task<ApiResponseModels<ProjectOutput>> editProject(int id);

        public  Task<ApiResponseModels<bool>> projectDeleteById(int id);
        public  Task<ApiResponseModels<bool>> activeInActive(int id);
    }
}
