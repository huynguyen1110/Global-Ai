using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri
{
    public class ViewThuocTinhGiaTriDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Id thuộc tính
        /// </summary>
        public int IdThuocTinh { get; set; }

        /// <summary>
        /// Tên thuộc tính
        /// </summary>
        public string TenThuocTinh { get; set; }

        /// <summary>
        /// Giá trị thuộc tính
        /// </summary>
        public string GiaTri { get; set; }
    }
}
