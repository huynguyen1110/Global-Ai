using GlobalAI.EntitiesBase.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlobalAI.ProductEntities.Dto.SanPhamChiTiet
{
    public class FilterSanPhamChiTietDto : PagingRequestBaseDto
    {
        /// <summary>
        /// Sản phẩm
        /// </summary>
        //[FromQuery(Name = "IdSanPham")]
        //public int? IdSanPham { get; set; }
        [FromQuery(Name = "SortBy")]
        public string? SortBy { get; set; }
        [FromQuery(Name = "SortOrder ")]
        public string? SortOrder { get; set; }
        /// <summary>
        /// Trạng thái 
        /// </summary>
        [FromQuery(Name = "Status")]
        public int? Status { get; set; }
    }
}
