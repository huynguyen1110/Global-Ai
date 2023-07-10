using GlobalAI.ProductEntities.Dto.VoucherChiTiet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.Voucher
{
    public class CreateVoucherDto
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string MoTa { get; set; }
        public double? GiaTri { get; set; }
        public int SoLuong { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public List<CreateVoucherChiTietDto> VoucherChiTiets { get; set; }
    }
}
