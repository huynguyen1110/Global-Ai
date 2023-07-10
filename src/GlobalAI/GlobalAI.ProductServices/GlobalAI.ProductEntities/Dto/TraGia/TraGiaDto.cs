using GlobalAI.ProductEntities.Dto.ChiTietTraGia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.TraGia
{
    public class TraGiaDto
    {
        public int Id { get; set; }
        public int IdNguoiBan { get; set; }
        public int IdNguoiMua { get; set; }
        public int IdSanPham { get; set; }
        public decimal? GiaCuoi { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public List<ChiTietTraGiaDto> ChiTietTraGias { get; set; }
        #region Các thông tin khác
        /// <summary>
        /// Được duyệt bởi
        /// </summary>
        public string ApproveBy { get; set; }
        /// <summary>
        /// 1: User đang là người mua, 2: User đang là người bán ( Check theo tài khoản login để phân biệt các bản ghi có vai trò khác nhau)
        /// </summary>
        public int Type { get; set; }
        #endregion
    }
}
