using GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri;
using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.ThuocTinh
{
    public class ViewThuocTinhDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Id danh mục thuộc tính
        /// </summary>
        public int IdDanhMucThuocTinh { get; set; }

        /// <summary>
        /// Tên thuộc tính
        /// </summary>
        public string TenThuocTinh { get; set; }

        /// <summary>
        /// List Giá trị
        /// </summary>
        public List<ViewThuocTinhGiaTriDto> ListGiaTri { get; set; }
    }
}
