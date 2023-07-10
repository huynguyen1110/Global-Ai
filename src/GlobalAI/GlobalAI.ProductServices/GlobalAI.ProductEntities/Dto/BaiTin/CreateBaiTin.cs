using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.BaiTin
{
    public class CreateBaiTin
    {
   
        public int IdDanhMuc { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string Thumbnail { get; set; }
        public string Slug { get; set; }
        public string MoTa { get; set; }
    }
}
