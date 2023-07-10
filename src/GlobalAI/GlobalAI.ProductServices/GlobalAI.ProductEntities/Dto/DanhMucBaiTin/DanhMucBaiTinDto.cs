using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.DanhMucBaiTin
{
    public class DanhMucBaiTinDto
    {
        public int Id { get; set; }
        public string MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public string Thumbnail { get; set; }
        public int Status { get; set; }
        public int? ParentId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        #region Các thông tin khác

        #endregion
    }
}
