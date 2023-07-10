using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;
using System.ComponentModel.DataAnnotations;

namespace GlobalAI.ProductEntities.Dto.Product
{
    public class AddSanPhamDto
    {
        private string _maSanPham;
        private string _tenSanPham;
        private string _moTa;

        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã sản phẩm không được bỏ trống")]
        public string MaSanPham { get => _maSanPham ; set => _maSanPham = value?.Trim(); }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên sản phẩm không được bỏ trống")]
        public string TenSanPham { get => _tenSanPham; set => _tenSanPham = value?.Trim(); }
        
        /// <summary>
        /// Mô tả
        /// </summary>
        public string MoTa { get => _moTa; set => _moTa = value?.Trim(); }

        public string IdDanhMuc { get; set; }

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
        /// Danh mục thuộc tính
        /// </summary>
        [Required(ErrorMessage = "Danh mục thuộc tính không được bỏ trống")]
        public int IdDanhMucThuocTinh { get; set; }

        public DateTime NgayDangKi { get; set; }
        public DateTime NgayDuyet { get; set; }

        public string Thumbnail { get; set; }

        /// <summary>
        /// Danh sách Sản phẩm chi tiết
        /// </summary>
        public List<AddSanPhamChiTietDto> ListChiTiet { get; set; }

    }
}

