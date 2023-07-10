using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.SanPhamChiTiet
{
    public class ViewSanPhamChiTietThuocTinhDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Id thuộc tính giá trị
        /// </summary>
        public int IdThuocTinhGiaTri { get; set; }

        /// <summary>
        /// Giá trị
        /// </summary>
        public string GiaTri { get; set; }

        /// <summary>
        /// Tên thuộc tính
        /// </summary>
        public string TenThuocTinh { get; set; }

        /// <summary>
        /// Id Sản phẩm chi tiết
        /// </summary>
        public int IdSanPhamChiTiet { get; set; }
        /// <summary>
        /// Id thuộc tính
        /// </summary>
        public int IdThuocTinh { get; set; }
    }
}
