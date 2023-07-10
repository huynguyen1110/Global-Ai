using GlobalAI.EntitiesBase.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlobalAI.ProductEntities.Dto.VoucherChiTiet
{
    public class FilterVoucherChiTietDto : PagingRequestBaseDto
    {
        /// <summary>
        /// Trạng thái 
        /// </summary>
        [FromQuery(Name = "status")]
        public int? Status { get; set; }
    }
}
