using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.GioHang
{
    public class EditGioHangChiTietDto
    {
        /// <summary>
        /// Id Sản phẩm 
        /// </summary>
        [Required(ErrorMessage = "Id sản phẩm không được để trống")]
        public int IdSanPham { get; set; }
        /// <summary>
        /// Số lượng sp
        /// </summary>
        [Required(ErrorMessage = "Số lượng sản phẩm không được để trống")]
        [Range(0, int.MaxValue)]
        public int SoLuong { get; set; }
        /// <summary>
        /// List id thuộc tính
        /// </summary>
        public List<int> ThuocTinhs { get; set; }

        /// <summary>
        /// Trạng thái
        /// <see cref="TrangThaiGioHang"/>
        /// </summary>
        public int? Status { get; set; }
    }
}
