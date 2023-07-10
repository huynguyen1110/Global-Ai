using GlobalAI.ProductEntities.Dto.ChiTietTraGia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.Product
{
    public class SanPhamHomePageDto
    {
        public int Id { get; set; }
        public string MaSanPham { get; set; }
        public string MaSanPhamChiTiet { get; set; }
        public string TenSanPham { get; set; }
        public string? MoTa { get; set; }
        public decimal? GiaBan { get; set; }
        public decimal? GiaChietKhau { get; set; }
        public decimal? GiaToiThieu { get; set; }
        public string IdDanhMuc { get; set; }
        public string thumbnail { get; set; }
        public int IdGStore { get; set; }
        public int Status { get; set; }
        public int? LuotXem { get; set; }
        public int? LuotBan { get; set; }
        public DateTime NgayDangKi { get; set; }
        public DateTime? NgayDuyet { get; set; }
        #region Các thông tin khác
        /// <summary>
        /// Được duyệt bởi
        /// </summary>
        public string ApproveBy { get; set; }
        /// <summary>
        /// 1: User đang là người mua, 2: User đang là người bán ( Check theo tài khoản login để phân biệt các bản ghi có vai trò khác nhau)
        /// </summary>
        public int Type { get; set; }
        #endregion
    }
}

