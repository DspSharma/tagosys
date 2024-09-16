using AutoMapper;
using Newtonsoft.Json.Linq;
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
    public class PageService : IPageService
    {
        public IUnitOfWork _unitOfWork;
        public readonly tagosyswebContext _context;
        public IMapper _mapper;

        public PageService(IUnitOfWork unitOfWork, tagosyswebContext context, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponseModels<PageOutput>>addUpdatePage(PageInput model)
        {
            Page formValue = _mapper.Map<Page>(model);
            int duplicateData = _unitOfWork.Page.GetWhere(x => x.Tittle == formValue.Tittle).Count();
            if (duplicateData > 0)
            {
                return new ApiResponseModels<PageOutput>
                {
                    succeed = false,
                    message = "Tittle is already exits",
                };
            }
            else
            {
                if (formValue.Id != 0)
                {
                    Page page = await _unitOfWork.Page.GetByIdAsync(model.Id);
                    page.Tittle = model.Tittle;
                    formValue.UpdatedAt = DateTime.UtcNow;
                    await _unitOfWork.SaveAsync();
                }
                else
                {
                   
                    formValue.Tittle = model.Tittle;
                    formValue.IsActive = false;
                    formValue.CreatedAt = DateTime.UtcNow;
                    formValue.UpdatedAt = DateTime.UtcNow;
                    await _unitOfWork.Page.AddAsync(formValue);
                    await _unitOfWork.SaveAsync();


                }
               
            }
            return new ApiResponseModels<PageOutput>
            {
                succeed = true,
                message = "success"
            };
        }

        public async Task<ApiResponseModels<List<PageOutput>>> pageList()
        {
            
            List<Page> pages = (await _unitOfWork.Page.GetAllAsync()).ToList();
            var reslt = _mapper.Map<List<PageOutput>>(pages);
           
            return new ApiResponseModels<List<PageOutput>>
            {
                succeed = true,
                message = "success",
                data = reslt
            };
        }
        public async Task<ApiResponseModels<PageOutput>> editPage(int id)
        {
           
            Page page = await _unitOfWork.Page.GetByIdAsync(id);
            var rslt = _mapper.Map<PageOutput>(page);
           
            return new ApiResponseModels<PageOutput>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }
        public async Task<ApiResponseModels<bool>> pageDeleteById(int id)
        {
            Page page = await _unitOfWork.Page.GetByIdAsync(id);
          
                _unitOfWork.Page.Remove(page);
                await _unitOfWork.SaveAsync();
           
            return new ApiResponseModels<bool>
            {
                succeed = true,
                message = "success"
            };
        }

        public async Task<ApiResponseModels<bool>> activeInActive(int id)
        {
            Page page = await _unitOfWork.Page.GetByIdAsync(id);
            if (page.IsActive == true)
            {
                page.IsActive = false;
            }
            else
            {
                page.IsActive = true;
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
