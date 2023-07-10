using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.Utils.ConstantVariables.Product
{
    /// <summary>
    /// Trạng thái trả giá
    /// </summary>
    public static class TrangThaiTraGia
    {
        /// <summary>
        /// Người mua đề nghị giá với người bán (Đang mặc cả)
        /// </summary>
        public const int DANG_TRA_GIA = 1;
        /// <summary>
        /// Người bán đồng ý giá người mua đề xuất (Đã trả giá xong)
        /// </summary>
        public const int DA_TRA_GIA = 2;
    }
}
