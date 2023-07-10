using GlobalAI.ProductEntities.Dto.DanhMucBaiTin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.BaiTin
{
    public class UpdateBaiTinDto : CreateBaiTin
    {
        public int Id { get; set; }
    }
}
