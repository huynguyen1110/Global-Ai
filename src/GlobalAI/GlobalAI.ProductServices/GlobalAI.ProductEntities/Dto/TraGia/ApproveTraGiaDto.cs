using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.TraGia
{
    public class ApproveTraGiaDto
    {
        public int Id { get; set; }
        public int IdChiTietTraGia { get; set; }
        public int Status { get; set; }
    }
}
