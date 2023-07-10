using GlobalAI.FileEntities.Dto.UploadFile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.FileDomain.Interfaces
{
    public interface IFileServices
    {
        //public string UploadImage(UploadFileDto input);
        //public byte[] GetImage(string folder, string fileName);
        public string UploadFile(UploadFileDto input);
        public byte[] GetFile(string folder, string fileName);
        //string UploadFileID(UploadFileDto input);
        /// <summary>
        /// Tạo file dạng FormFile từ file path lưu trong db
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public FormFile GenFileFromPath(string file);

        /// <summary>
        /// Xóa file
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="fileName"></param>
        public void DeleteFile(string folder, string fileName);
        /// <summary>
        /// Xóa file bằng url
        /// </summary>
        /// <param name="url"></param>
        public void DeleteFile(string url);
    }
}
