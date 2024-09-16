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
    public interface IClientService
    {
        Task<ApiResponseModels<ClientOutput>> editClient(int id);
        Task<ApiResponseModels<ClientOutput>> addUpdateClient(ClientInput model);
        Task<ApiResponseModels<List<ClientOutput>>> clientList();
        Task<ApiResponseModels<bool>> clientDeleteById(int id);
        Task<ApiResponseModels<bool>> activeInActive(int id);
        Task<ApiResponseModels<List<ClientOutput>>> getClientList();
    }
}
