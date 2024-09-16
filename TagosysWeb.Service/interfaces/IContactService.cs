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
    public interface IContactService
    {
        Task<ApiResponseModels<ContactOutput>> addUpdateContact(ContactInput model);
        Task<ApiResponseModels<List<ContactOutput>>> contactList();
    }
}
