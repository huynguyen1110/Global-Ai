using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.TraGia
{
    public class AddTraGiaDto
    {
        //be tu lay
        public int IdNguoiBan { get; set; }
        //be tu lay
        //public int IdNguoiMua { get; set; }
        public int IdSanPham { get; set; }
        public decimal? GiaCuoi { get; set; }
        //be tu lay
        //public int Status { get; set; }

        /// <summary>
        /// chi tiet tra gia
        /// </summary>
        /// //be tu lay
        //public string Usertype { get; set; }
        //be tu lay
        //public int IdTraGia { get; set; }
        // be tu lay
        //public int Status { get; set; }
        public decimal? GiaTien { get; set; }
    }
}
