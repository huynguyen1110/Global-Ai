using GlobalAI.EntitiesBase.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlobalAI.ProductEntities.Dto.DanhMucBaiTin
{
    public class FilterDanhMucBaiTinDto : PagingRequestBaseDto
    {
        [FromQuery(Name = "isParent")]
        public bool IsParent{ get; set; }
        /// <summary>
        /// Trạng thái 
        /// </summary>
        [FromQuery(Name = "status")]
        public int? Status { get; set; }
        [FromQuery(Name = "parentId")]
        public int? ParentId { get; set; }
    }
}
