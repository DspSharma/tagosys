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
    public interface IPostService
    {
        Task<ApiResponseModels<PostOutput>> addUpdatePost(PostInput model);
        Task<ApiResponseModels<PostOutput>> editPost(int id);
        Task<ApiResponseModels<List<PostOutput>>> postList();
        Task<ApiResponseModels<List<PostOutput>>> getPostList();
        Task<ApiResponseModels<bool>> postDeleteById(int id);
        Task<ApiResponseModels<bool>> activeInActive(int id);
    }
}
