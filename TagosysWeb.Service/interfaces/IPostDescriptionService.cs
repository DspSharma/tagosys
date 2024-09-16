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
    public interface IPostDescriptionService
    {
        Task<ApiResponseModels<PostdescriptionOutput>> addUpdatePostDescription(PostdescriptionInput model);
        Task<ApiResponseModels<PostdescriptionOutput>> editPostDescription(int id);
        Task<ApiResponseModels<List<PostdescriptionOutput>>> postDescriptionList();
        Task<ApiResponseModels<List<PostdescriptionOutput>>> postDescriptionById(int id);
        Task<ApiResponseModels<bool>> postDescriptionDeleteById(int id);
        Task<ApiResponseModels<bool>> activeInActive(int id);

    }
}
