using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.ChiTietTraGia
{
    public class AddChiTietTraGiaDto
    {
        public int IdTraGia { get; set; }
        public int LoaiTraGia { get; set; }
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
