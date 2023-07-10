using GlobalAI.ProductEntities.Dto.VoucherChiTiet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.ChiTietDonHang
{
    public class DonHangChiTietDto
    {
        public int Id { get; set; }
        public int IdDonHang { get; set; }
        public int IdSanPham { get; set; }
        public int IdSanPhamChiTiet { get; set; }
        public int SoLuong { get; set; }
        public decimal? GPoint { get; set; }
    }
}
