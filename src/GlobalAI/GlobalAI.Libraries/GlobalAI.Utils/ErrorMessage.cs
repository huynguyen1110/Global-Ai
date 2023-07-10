using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.Utils
{
    public static class ErrorMessage
    {
        public static Dictionary<int, string> ErrorMessages = new Dictionary<int, string>()
        {
            { (int)ErrorCode.NotFound, "Not found" },
            { (int)ErrorCode.UserUsernameDuplicated, "Tên đăng nhập đã tồn tại." },
            { (int)ErrorCode.UserEmailDuplicated, "Email đã được tồn tại." },
            { (int)ErrorCode.UserPhoneDuplicated, "Số điện thoại đã tồn tại." },
            { (int)ErrorCode.UserLoginNotFound, "Tên đăng nhập hoặc mật khẩu không chính xác." },

            { (int)ErrorCode.ProductDanhMucThuocTinhNotFound, "Danh mục không tồn tại" },
            { (int)ErrorCode.ProductThuocTinhNotFound, "Thuộc tính không tồn tại" },
            { (int)ErrorCode.ProductDanhMucThuocTinhInUsed, "Danh mục đang được sử dụng" },
            { (int)ErrorCode.ProductThuocTinhInUsed, "Thuộc tính đang được sử dụng" },
            { (int)ErrorCode.ProductThuocTinhGiaTriInUsed, "Giá trị thuộc tính đang được sử dụng" },
            { (int)ErrorCode.ProductDanhMucThuocTinhMaExisted, "Mã danh mục thuộc tính đã tồn tại" },
            { (int)ErrorCode.ProductThuocTinhGiaTriNotFound, "Giá trị không tồn tại" },
            { (int)ErrorCode.ProductDanhMucThuocTinhMaExisted, "Mã danh mục thuộc tính đã tồn tại" },
            { (int)ErrorCode.ProductSpChiTietNotFound, "Sản phẩm chi tiết không tồn tại" },
            { (int)ErrorCode.ProductSpChiTietDaDuocTaoDonHang, "Sản phẩm chi tiết đã được tạo đơn hàng" },
        };

        /// <summary>
        /// Lấy error message theo error code
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static string Get(int errorCode)
        {
            ErrorMessages.TryGetValue(errorCode, out string message);
            return message ?? $"Không tìm thấy mã lỗi {errorCode}";
        }
    }

}
