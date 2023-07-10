using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.Utils;
using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.GioHang
{
    public class AddGioHangChiTietDto
    {
        /// <summary>
        /// Id Sản phẩm
        /// </summary>
        [Required(ErrorMessage ="ID sản phẩm không được để trống")]
        public int IdSanPham { get; set; }
        /// <summary>
        /// List id thuộc tính
        /// </summary>
        public List<int> ThuocTinhs { get; set; }
        /// <summary>
        /// Số lượng sp
        /// </summary>
        [Required(ErrorMessage = "Số lượng sản phẩm không được để trống")]
        [Range(0, int.MaxValue)]
        public int SoLuong { get; set; }

        /// <summary>
        /// Trạng thái
        /// <see cref="TrangThaiGioHang"/>
        /// </summary>
        public int? Status { get; set; }
    }
}