using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;

namespace GlobalAI.ProductEntities.Dto.Product
{
    /// <summary>
    /// GStore/Admin xem chi tiết thông tin sp để cập nhật thông tin
    /// </summary>
    public class ViewAdminSanPhamDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        public string MaSanPham { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string TenSanPham { get; set; } = String.Empty;

        /// <summary>
        /// Mô tả
        /// </summary>
        public string MoTa { get; set; } = String.Empty;

        /// <summary>
        /// Giá bán
        /// </summary>
        public decimal? GiaBan { get; set; }

        /// <summary>
        /// Giá chiết khấu
        /// </summary>
        public decimal? GiaChietKhau { get; set; }

        /// <summary>
        /// Giá tối thiểu
        /// </summary>
        public decimal? GiaToiThieu { get; set; }


        /// <summary>
        /// Id danh mục
        /// </summary>
        public string IdDanhMuc { get; set; }

        /// <summary>
        /// Id Gstore
        /// </summary>
        public int IdGStore { get; set; }

        /// <summary>
        /// Ngày đăng ký
        /// </summary>
        public DateTime NgayDangKi { get; set; }

        /// <summary>
        /// Ngày duyệt
        /// </summary>
        public DateTime? NgayDuyet { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Immage của sp
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// Lượt xem sp
        /// </summary>
        public int? LuotXem { get; set; }

        /// <summary>
        /// Lượt bán sp
        /// </summary>
        public int? LuotBan { get; set; }

        /// <summary>
        /// Id danh mục thuộc tính
        /// </summary>
        public int? IdDanhMucThuocTinh { get; set; }

        /// <summary>
        /// Danh sách sp chi tiết
        /// </summary>
        public List<ViewSanPhamChiTietDto> ListSanPhamChiTiet { get; set; }
    }
}
