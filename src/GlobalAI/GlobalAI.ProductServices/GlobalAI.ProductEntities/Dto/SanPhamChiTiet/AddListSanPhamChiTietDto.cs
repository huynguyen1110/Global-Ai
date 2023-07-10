using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.SanPhamChiTiet
{
    /// <summary>
    /// Dùng để add 1 hoặc nhiều sp chi tiết vào sản phẩm
    /// </summary>
    public class AddListSanPhamChiTietDto
    {
        /// <summary>
        /// Id sản phẩm
        /// </summary>
        [Required(ErrorMessage = "Id sản phẩm không được bỏ trống")]
        public int IdSanPham { get; set; }
        /// <summary>
        /// Danh sách sản phẩm chi tiết
        /// </summary>
        [Required(ErrorMessage = "Phải có sản phẩm chi tiết")]
        public List<AddSanPhamChiTietDto> ListSanPhamChiTiet { get; set; }
    }
}
