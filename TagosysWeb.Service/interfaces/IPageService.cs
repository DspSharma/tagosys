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
    public interface IPageService
    {
         Task<ApiResponseModels<PageOutput>> addUpdatePage(PageInput model);
         Task<ApiResponseModels<PageOutput>> editPage(int id);
         Task<ApiResponseModels<List<PageOutput>>> pageList();
         Task<ApiResponseModels<bool>> activeInActive(int id);
         Task<ApiResponseModels<bool>> pageDeleteById(int id);
    }
}
