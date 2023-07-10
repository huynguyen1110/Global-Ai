using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.SanPhamChiTiet
{
    public class ViewSanPhamChiTietDto
    {
        public int Id { get; set; }
        public int IdSanPham { get; set; }
        public string MaSanPhamChiTiet { get; set; }
        public string MoTa { get; set; }
        public decimal? GiaBan { get; set; }
        public decimal? GiaChietKhau { get; set; }
        public DateTime NgayDangKi { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Status { get; set; }
        public decimal? GiaToiThieu { get; set; }
        public string Thumbnail { get; set; }
        public int? LuotXem { get; set; }
        public int? LuotBan { get; set; }
        public int? SoLuong { get; set; }
        /// <summary>
        /// Danh sách thuộc tính
        /// </summary>
        public List<ViewSanPhamChiTietThuocTinhDto> ListThuocTinh { get; set; }
    }
}
