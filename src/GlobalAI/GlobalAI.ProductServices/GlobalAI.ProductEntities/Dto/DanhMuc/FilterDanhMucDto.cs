using GlobalAI.EntitiesBase.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlobalAI.ProductEntities.Dto.DanhMuc
{
    public class FilterDanhMucDto : PagingRequestBaseDto
    {
        public bool? IsDisplayOnHomePage { get; set; }
    }
}
