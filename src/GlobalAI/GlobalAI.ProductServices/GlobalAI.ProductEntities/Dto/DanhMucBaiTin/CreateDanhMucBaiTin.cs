﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.DanhMucBaiTin
{
    public class CreateDanhMucBaiTin
    {
        public string MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public int? ParentId { get; set; }
        public string Thumbnail { get; set; }
    }
}
