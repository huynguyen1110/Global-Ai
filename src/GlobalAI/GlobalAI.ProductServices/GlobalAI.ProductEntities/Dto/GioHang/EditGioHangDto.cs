using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.GioHang
{
    public class EditGioHangDto
    {
        /// <summary>
        /// Id Sản phẩm chi tiết
        /// </summary>
        public int? IdSanPhamChiTiet { get; set; }
        /// <summary>
        /// Số lượng sp
        /// </summary>
        public int SoLuong { get; set; }

        /// <summary>
        /// Trạng thái
        /// <see cref="TrangThaiGioHang"/>
        /// </summary>
        public int? Status { get; set; }
    }
}
