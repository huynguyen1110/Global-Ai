
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.ThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.SanPhamChiTiet
{
    public class GetSanPhamChiTietGioHangDto
    {

        private string _moTa;
        public int? IdSanPham { get; set; }
        public int? IdSanPhamChiTiet { get; set; }
        public string TenSanPham { get; set; }
        public Dictionary<String, AddThuocTinhGiaTriDto> ThuocTinhs { get; set; }
        public int IdGStore { get; set; }
        public int? IdDanhMucThuocTinh { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get => _moTa; set => _moTa = value?.Trim(); }
        public decimal? GiaBan { get; set; }
        public decimal? GiaChietKhau { get; set; }
        public decimal? GiaToiThieu { get; set; }
        public string Thumbnail { get; set; }
    }
}
