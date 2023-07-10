using GlobalAI.EntitiesBase.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlobalAI.ProductEntities.Dto.Product
{
    public class FilterSortDto : PagingRequestBaseDto
    {
        /// <summary>
        /// Sản phẩm
        /// </summary>
        [FromQuery(Name = "MoiNhat")]
        public bool? MoiNhat { get; set; }
        [FromQuery(Name = "BanChay")]
        public bool? BanChay { get; set; }
    }
}
