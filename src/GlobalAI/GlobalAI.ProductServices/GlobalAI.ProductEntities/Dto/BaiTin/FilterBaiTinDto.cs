using GlobalAI.EntitiesBase.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlobalAI.ProductEntities.Dto.BaiTin
{
    public class FilterBaiTinDto : PagingRequestBaseDto
    {
        /// <summary>
        /// Trạng thái 
        /// </summary>
        [FromQuery(Name = "status")]
        public int? Status { get; set; }
        [FromQuery(Name = "slug")]
        public string? Slug { get; set; }
        [FromQuery(Name = "tieuDe")]
        public string? TieuDe { get; set; }
        [FromQuery(Name = "idDanhMuc")]
        public int? IdDanhMuc { get; set; }
    }
}
