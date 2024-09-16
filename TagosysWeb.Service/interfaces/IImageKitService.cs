using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Service.interfaces
{
    public interface IImageKitService
    {
       
        ResultDelete deleteFileFromImageKit(string fileId, string imageKitFolderName = "Sahimol-Items");
        Result createAndUploadThumbnail(string thumbnailURL, string destinationPath);
        public Task<Result> uploadFileToLocal(string file, string imageKitFolderPath);
    }
}
