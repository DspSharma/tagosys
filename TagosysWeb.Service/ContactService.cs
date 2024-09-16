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
    public class ContactService : IContactService
    {
        public IUnitOfWork _unitOfWork;
        public readonly tagosyswebContext _context;
        public IMapper _mapper;

        public ContactService(IUnitOfWork unitOfWork, tagosyswebContext context, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponseModels<ContactOutput>> addUpdateContact(ContactInput model)
        {
            Contact formValue = new Contact();
            formValue.Name = model.Name;
            formValue.Email = model.Email;
            formValue.Subject = model.Subject;
            formValue.Message = model.Message;
            formValue.CreatedAt = DateTime.UtcNow;
            formValue.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.Contact.AddAsync(formValue);
            await _unitOfWork.SaveAsync();
            return new ApiResponseModels<ContactOutput>
            {
                succeed = true,
                message = "success"
            };
        }

        public async Task<ApiResponseModels<List<ContactOutput>>> contactList()
        {
            
            List<Contact> contacts = (await _unitOfWork.Contact.GetAllAsync()).ToList();
            var reslt = _mapper.Map<List<ContactOutput>>(contacts);
            return new ApiResponseModels<List<ContactOutput>>
            {
                succeed = true,
                message = "success",
                data = reslt
            };
        }



    }
}
