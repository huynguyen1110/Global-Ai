using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.VoucherChiTiet
{
    public class CreateVoucherChiTietDto
    {
        public int Id { get; set; }
        public int VoucherId { get; set; }
        /// <summary>
        /// random
        /// </summary>
        //public string MaVoucher { get; set; }
        public DateTime? NgayGiao { get; set; }
        public DateTime? NgaySuDung { get; set; }
        public string NguoiSuDung { get; set; }
        /// <summary>
        /// be tu xac dinh
        /// </summary>
        //public int? Status { get; set; }
    }
}
