using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.ChiTietTraGia
{
    public class ChiTietTraGiaDto
    {
        public int Id { get; set; }
        public int IdTraGia { get; set; }
        public int LoaiTraGia { get; set; }
        public string Usertype { get; set; }
        public decimal? GiaTien { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
