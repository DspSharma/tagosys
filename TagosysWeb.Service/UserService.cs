using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public tagosyswebContext _context;
        public IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, tagosyswebContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ApiResponseModels<LoggedInUserModels>> Login(UserLoginInput value)
        {
            //User userData = _unitOfWork.User.GetWhere(x => x.Email == value.Email && x.Password == value.Password).FirstOrDefault();
            User userData = _unitOfWork.User.GetWhere(x => x.Email == value.Email && x.Password == value.Password && x.IsActive == true).FirstOrDefault();
            if (userData == null)
            {
                return new ApiResponseModels<LoggedInUserModels>
                {
                    succeed = false,
                    message = "No user found"
                };
            }

            LoggedInUserModels user = _mapper.Map<LoggedInUserModels>(userData);
            var rslt = new ApiResponseModels<LoggedInUserModels>
            {
                succeed = true,
                message = "success",
                data = user
            };
            return rslt;
        }
        public async Task<ApiResponseModels<UserOutput>> userAdd(UserInput value)
        {
            User formValue = _mapper.Map<User>(value);
            int duplicateData = _unitOfWork.User.GetWhere(x => x.Email == formValue.Email).Count();
            if (duplicateData > 0)
            {
                return new ApiResponseModels<UserOutput>
                {
                    succeed = false,
                    message = "Email or Mobile is already exits",
                };
            }
            formValue.IsActive = false;
            formValue.CreatedAt = DateTime.UtcNow;
            formValue.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.User.AddAsync(formValue);
            await _unitOfWork.SaveAsync();
            return new ApiResponseModels<UserOutput>
            {
                succeed = true,
                message = "success"
            };
        }

        public async Task<ApiResponseModels<List<UserOutput>>> userList()
        {
            List<User> user = (await _unitOfWork.User.GetAllAsync()).ToList();
            var rslt = _mapper.Map<List<UserOutput>>(user);
            return new ApiResponseModels<List<UserOutput>>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }

        public async Task<ApiResponseModels<bool>> activeInActive(int id)
        {
            User user = await _unitOfWork.User.GetByIdAsync(id);
            if (user.IsActive == true)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
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
