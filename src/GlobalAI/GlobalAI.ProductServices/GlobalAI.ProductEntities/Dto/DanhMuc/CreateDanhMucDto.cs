using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.DanhMuc
{
    public class CreateDanhMucDto
    {
        public string IdDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public bool IsDisplayOnHomePage { get; set; }
    }
}
