using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.DanhMucThuocTinh
{
    public class ViewDanhMucThuocTinhDto
    {
        /// <summary>
        /// Id danh mục thuộc tính
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Mã danh mục thuộc tính
        /// </summary>
        public string Ma { get; set; }

        /// <summary>
        /// Tên danh mục thuộc tính
        /// </summary>
        public string Ten { get; set; }
    }
}
