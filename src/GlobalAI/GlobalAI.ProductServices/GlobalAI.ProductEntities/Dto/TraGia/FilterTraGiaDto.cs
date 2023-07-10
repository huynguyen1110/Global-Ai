using GlobalAI.EntitiesBase.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlobalAI.ProductEntities.Dto.TraGia
{
    public class FilterTraGiaDto : PagingRequestBaseDto
    {
        /// <summary>
        /// Sản phẩm
        /// </summary>
        [FromQuery(Name = "IdSanPham")]
        public int? IdSanPham { get; set; }
        [FromQuery(Name = "GiaTien")]
        public decimal? GiaTien { get; set; }
        /// <summary>
        /// Trạng thái 
        /// </summary>
        [FromQuery(Name = "status")]
        public int? Status { get; set; }
    }
}
