using Imagekit.Sdk;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Service
{
    public class ImageKitService : IImageKitService
    {
        public IConfiguration _configuration { get;set; }

        public string privateKey { get; set; }
        public string publicKey { get; set; }
        public string Url { get; set; }

        private IWebHostEnvironment _environment;

        public ImageKitService(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;

            publicKey = _configuration.GetSection("ImageKit:PublicKey").Value;
            privateKey = _configuration.GetSection("ImageKit:PrivateKey").Value;
            Url = _configuration.GetSection("ImageKit:ImageStaticPath").Value;

            _environment = environment;
        }


        public ResultDelete deleteFileFromImageKit(string fileId, string imageKitFolderName = "Sahimol-Items")
        {
            string UrlEndPoint = string.Concat(Url, imageKitFolderName);
            ImagekitClient imagekit = new ImagekitClient(publicKey, privateKey, UrlEndPoint);
            ResultDelete res = imagekit.DeleteFile(fileId);
            return res;
        }

        public Result createAndUploadThumbnail(string thumbnailURL, string destinationPath)
        {
            string UrlEndPoint = Url;
            ImagekitClient imagekit = new ImagekitClient(publicKey, privateKey, UrlEndPoint);

            //string url = $"https://ik.imagekit.io/avhjqwn6o/{path}";
            WebClient client = new WebClient();

            byte[] imageData = client.DownloadData(thumbnailURL);

            string base64ImageRepresentation = Convert.ToBase64String(imageData);
            // Upload by Base64
            FileCreateRequest ob2 = new FileCreateRequest
            {
                file = base64ImageRepresentation,
                fileName = Path.GetFileName(thumbnailURL),//Guid.NewGuid().ToString(),
                folder = destinationPath
            };
            Result res = imagekit.Upload(ob2);
            return res;
        }

        public async Task<Result> uploadFileToLocal(string file, string imageKitFolderPath)
        {
            // string filename = MiscMethods.getUniqueFileNameWithTimeStamp(file.FileName);
            string UrlEndPoint = string.Concat(Url, imageKitFolderPath);
            ImagekitClient imagekit = new ImagekitClient(publicKey, privateKey, UrlEndPoint);

            using var memoryStream = new MemoryStream();
            // await file.CopyToAsync(memoryStream);
            byte[] fileByte = memoryStream.ToArray();

            string base64ImageRepresentation = Convert.ToBase64String(fileByte);

            FileCreateRequest ob2 = new FileCreateRequest
            {
                file = base64ImageRepresentation,
                //fileName = filename,
                fileName = file,
                folder = imageKitFolderPath
            };
            Result res = imagekit.Upload(ob2);
            return res;
        }


    }
}
