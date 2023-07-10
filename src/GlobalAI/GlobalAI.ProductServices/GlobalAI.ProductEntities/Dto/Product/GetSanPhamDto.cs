using GlobalAI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.Product
{
    public class GetSanPhamDto
    {
        public int Id { get; set; } 
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MoTa { get; set; } = String.Empty;
        public decimal GiaBan { get; set; }
        public decimal GiaChietKhau { get; set; }
        public string IdDanhMuc { get; set; }
        public decimal? GiaToiThieu { get; set; }
        public string thumbnail { get;set; }
        public int IdGStore { get; set; }
        public DateTime NgayDangKi { get; set; }
        public DateTime NgayDuyet { get; set; }

    }
}
