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

namespace GlobalAI.ProductEntities.Dto.ChiTietDonHang
{
    public class GetChiTietDonHangDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Id đơn hàng
        /// </summary>
        public int IdDonHang { get; set; }

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public int IdSanPham { get; set; }

        /// <summary>
        /// Số lượng sản phẩm
        /// </summary>
        public int SoLuong { get; set; }

       
    }
}
