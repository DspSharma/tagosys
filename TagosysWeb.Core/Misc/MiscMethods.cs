using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TagosysWeb.Core.Misc
{
    public class MiscMethods
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
        // IFormFile
        public static string uploadFileToLocal(IFormFile file, string dirpath)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filepath = Path.Combine(dirpath, uniqueFileName);
            var fileStream = new FileStream(filepath, FileMode.Create);
            file.CopyTo(fileStream);
            fileStream.Dispose();
            return uniqueFileName;
            // return filepath;
        }

        public static string getUniqueFileNameWithTimeStamp(string fileName, int saveLength = 20)
        {
            string fileNameWitoutExtension = Path.GetFileNameWithoutExtension(fileName);
            if (fileNameWitoutExtension.Length > saveLength)
                fileNameWitoutExtension = fileNameWitoutExtension.Substring(0, 20);

            return string.Concat(
                DateTime.Now.ToString("ddMMyyyyHHmmssfff"),
                fileNameWitoutExtension,
                Path.GetExtension(fileName)
                );
        }


       


    }
}
