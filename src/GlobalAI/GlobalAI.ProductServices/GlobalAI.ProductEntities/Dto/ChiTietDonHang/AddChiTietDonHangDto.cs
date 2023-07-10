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
    public class AddChiTietDonHangDto
    {
       
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public int IdSanPhamChiTiet { get; set; }
    }
}