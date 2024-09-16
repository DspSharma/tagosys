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
    public interface IImageService
    {
        public Task<ApiResponseModels<ImagekitfileOutput>> addUpdateUploadImage(ImagekitfileInput value);

        public Task<ApiResponseModels<ImagekitfileOutput>> activeImage(string fileName);
        Task<ApiResponseModels<ImagekitfileOutput>> deleteUploadImageLocal(string fileName);


    }
}
