using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.VoucherChiTiet
{
    public class VoucherChiTietDto
    {
        public int Id { get; set; }
        public string LichSuGiaTri { get; set; }
        public string LichSuMoTa { get; set; }
        public string LichSuTenVoucher { get; set; }
        public string NguoiSuDung { get; set; }
        public DateTime? NgaySuDung { get; set; }
        public DateTime? NgayGiao { get; set; }
        public string MaVoucher { get; set; }
        public int VoucherId { get; set; }
        public int? Status { get; set; }
    }
}
