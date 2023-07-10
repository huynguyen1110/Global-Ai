using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.FileEntities.Settings
{
    public class FileConfig
    {
        /// <summary>
        /// Đường dẫn
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Giới hạn dung lượng upload
        /// </summary>
        public double LimitUpload { get; set; }
        /// <summary>
        /// Cho phép file có định dạng nào
        /// </summary>
        public string AllowExtension { get; set; }
    }
}
