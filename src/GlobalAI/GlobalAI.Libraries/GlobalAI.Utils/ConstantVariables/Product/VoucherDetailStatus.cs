using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.Utils.ConstantVariables.Product
{
    /// <summary>
    /// Trạng thái của voucher detail
    /// </summary>
    public static class VoucherDetailStatus
    {
        /// <summary>
        /// Voucher detail vừa đc khởi tạo
        /// </summary>
        public const int KHOI_TAO = 1;
        /// <summary>
        /// Voucher detail đã được giao cho khách
        /// </summary>
        public const int DA_GIAO = 2;
        /// <summary>
        /// Voucher detail đã được khách sử dụng
        /// </summary>
        public const int DA_SU_DUNG = 3;
        /// <summary>
        /// Voucher detail bị khóa kích hoạt
        /// </summary>
        public const int DA_KHOA = 4;

    }
}
