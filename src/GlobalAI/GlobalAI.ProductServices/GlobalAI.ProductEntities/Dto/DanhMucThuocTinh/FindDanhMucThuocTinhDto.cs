using GlobalAI.EntitiesBase.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.DanhMucThuocTinh
{
    public class FindDanhMucThuocTinhDto : PagingRequestBaseDto
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
