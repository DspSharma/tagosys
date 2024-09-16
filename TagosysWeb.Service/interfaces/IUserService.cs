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
    public interface IUserService
    {
        public  Task<ApiResponseModels<LoggedInUserModels>> Login(UserLoginInput value);
        Task<ApiResponseModels<UserOutput>> userAdd(UserInput value);
        Task<ApiResponseModels<List<UserOutput>>> userList();
        Task<ApiResponseModels<bool>> activeInActive(int id);
    }
}
