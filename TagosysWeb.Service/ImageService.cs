using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Core.DTO.DtoOutput;
using TagosysWeb.Core.Misc;
using TagosysWeb.Core.Models;
using TagosysWeb.Data.DBContext;
using TagosysWeb.Data.Entities;
using TagosysWeb.Data.UnitOfWork;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Service
{
    public class ImageService : IImageService
    {
        public IUnitOfWork _unitOfWork;
        public readonly tagosyswebContext _baseContext;
        public IMapper _mapper;
        private IWebHostEnvironment _environment;
        public IImageKitService _imageKitService;
        public ISystemSettingService _systemSettingService;

        public ImageService(IUnitOfWork unitOfWork, tagosyswebContext baseContext, IMapper mapper, IWebHostEnvironment environment, IImageKitService imageKitService, ISystemSettingService systemSettingService)
        {
            _unitOfWork = unitOfWork;
            _baseContext = baseContext;
            _mapper = mapper;
            _environment = environment;
            _imageKitService = imageKitService;
            _systemSettingService = systemSettingService;
        }



        public async Task<ApiResponseModels<ImagekitfileOutput>> addUpdateUploadImage(ImagekitfileInput value)
        {
            try
            {
                
                ImageEndpointModel res = await _systemSettingService.getEndpoint();
                string imageUrl = "";
                string imagefileId = "";
                Imagekitfile formValueimageKitFile = new Imagekitfile();

                if (value.ImageFile != null && value.ImageFile.Length > 0)
                {
                    var file = value.ImageFile;
                    string fileName = MiscMethods.getUniqueFileNameWithTimeStamp(file.FileName);
                    string imageOrgFolder = "original";
                    string imageThumbFolder = "Thumbnail";
                    var rootPath = _environment.WebRootPath;
                    var parentFolderName = "TagosysImage";
                    var parentFolderPath = Path.Combine(rootPath, parentFolderName);
                    var subdomainOrgFolderPath = Path.Combine(parentFolderPath, imageOrgFolder);
                    var subdomainThumbFolderPath = Path.Combine(parentFolderPath, imageThumbFolder);
                    if (!Directory.Exists(subdomainOrgFolderPath))
                    {
                        Directory.CreateDirectory(subdomainOrgFolderPath);
                    }
                    if (!Directory.Exists(subdomainThumbFolderPath))
                    {
                        Directory.CreateDirectory(subdomainThumbFolderPath);
                    }
                    string orgFilePath = Path.Combine(subdomainOrgFolderPath, fileName);
                    using (var stream = new FileStream(orgFilePath, FileMode.Create))
                    {
                        value.ImageFile.CopyTo(stream);
                    }
                    string thumbFilePath = Path.Combine(subdomainThumbFolderPath, fileName);
                    using (var stream = new FileStream(thumbFilePath, FileMode.Create))
                    {
                        value.ImageFile.CopyTo(stream);
                    }

                    //------------------- Local Folder End

                    Result imageKitRes = await _imageKitService.uploadFileToLocal(fileName, res.imageOrgFolder);

                    
                    formValueimageKitFile = _mapper.Map<Imagekitfile>(value);
                    formValueimageKitFile.FileName = fileName;
                    formValueimageKitFile.OriginalFileId = imagefileId;
                    formValueimageKitFile.ThumbnailFileId = imagefileId;
                    formValueimageKitFile.CreatedAt = DateTime.UtcNow;
                    formValueimageKitFile.UpdatedAt = DateTime.UtcNow;
                    formValueimageKitFile.IsActive = false;
                    await _unitOfWork.Imagekitfile.AddAsync(formValueimageKitFile);
                    await _unitOfWork.SaveAsync();
                }
                var rslt = _mapper.Map<ImagekitfileOutput>(formValueimageKitFile);
                var uploadOutput = _mapper.Map<ImagekitfileOutput>(rslt);
                uploadOutput.LocalImagePath = res.imageThumbFolder + rslt.FileName;
                return new ApiResponseModels<ImagekitfileOutput>
                {
                    succeed = true,
                    message = "success",
                    data = uploadOutput
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
                return new ApiResponseModels<ImagekitfileOutput>
                {
                    succeed = false,
                    message = "An error occurred: " + ex.Message,
                    data = null
                };
            }
        }

        public async Task<ApiResponseModels<ImagekitfileOutput>> deleteUploadImageLocal(string fileName)
        {
            try
            {
                //string subdomain = MiscMethods.getSubDomainName();
                string wwwRootPath = _environment.WebRootPath;
                string destinationFolder = Path.Combine(_environment.WebRootPath, "TagosysImage");
                string[] subfolders = Directory.GetDirectories(destinationFolder);

                foreach (var subfolder in subfolders)
                {
                    string subfolderName = Path.GetFileName(subfolder);
                    Console.WriteLine($"Files in subfolder '{subfolderName}':");
                    string subfolderPath = Path.Combine(destinationFolder, subfolderName);
                    string filePath = Path.Combine(subfolderPath, fileName);

                    if (File.Exists(filePath))
                    {
                        Imagekitfile imagekitfile = _unitOfWork.Imagekitfile.GetWhere(x => x.FileName == fileName).FirstOrDefault();
                        File.Delete(filePath);
                        _unitOfWork.Imagekitfile.Remove(imagekitfile);
                        await _unitOfWork.SaveAsync();
                    }
                }

                return new ApiResponseModels<ImagekitfileOutput>
                {
                    succeed = true,
                    message = "Success"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new ApiResponseModels<ImagekitfileOutput>
                {
                    succeed = false,
                    message = ex.Message
                };
            }
        }

        public async Task<ApiResponseModels<ImagekitfileOutput>> activeImage(string fileName)
        {
            //ImageEndpointModel res = await _systemsettingService.getEndpoint();
            Imagekitfile imagekitfile = _unitOfWork.Imagekitfile.GetWhere(x => x.FileName == fileName).FirstOrDefault();

            if (imagekitfile != null)
            {
                imagekitfile.IsActive = true;
            }

            return new ApiResponseModels<ImagekitfileOutput>
            {
                succeed = true,
                message = "success"
            };
        }


    }
}
