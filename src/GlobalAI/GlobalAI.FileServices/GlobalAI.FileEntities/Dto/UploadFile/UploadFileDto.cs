using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.FileEntities.Dto.UploadFile
{
    public class UploadFileDto
    {
        /// <summary>
        /// File
        /// </summary>
        public IFormFile File { get; set; }
        /// <summary>
        /// Tên thư mục muốn lưu
        /// </summary>
        public string Folder { get; set; }
    }
}
