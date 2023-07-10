using GlobalAI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.SanPhamChiTiet
{
    public class UpdateSanPhamChiTietDto
    {
        private string _moTa;
        private string _maSpChiTiet;

        [Required(ErrorMessage = "Id sản phẩm chi tiết không được bỏ trống")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Sản phẩm không được bỏ trống")]
        public int IdSanPham { get; set; }

        /// <summary>
        /// Các sp chi tiết thuộc tính bị xóa
        /// </summary>
        public List<int> ListDeleteIdSanPhamChiTietThuocTinh { get; set; }

        /// <summary>
        /// Các id thuộc tính giá trị add vào sản phẩm
        /// </summary>
        public List<int> ListAddThuocTinhGiaTri { get; set; }

        public string MaSanPhamChiTiet { get => _maSpChiTiet; set => _maSpChiTiet = value?.Trim(); }
        public int SoLuong { get; set; }
        public string MoTa { get => _moTa; set => _moTa = value?.Trim(); }
        public decimal? GiaBan { get; set; }
        public decimal? GiaChietKhau { get; set; }
        public decimal? GiaToiThieu { get; set; }
        public string Thumbnail { get; set; }
    }
}
