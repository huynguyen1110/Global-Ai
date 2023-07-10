using GlobalAI.ProductEntities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlobalAI.ProductEntities.Dto.DanhMucBaiTin
{
    public class TreesDanhMucBaiTinDto
    {
        public int Id { get; set; }
        public string MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public int? Status { get; set; }
        public int? ParentId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public List<TreesDanhMucBaiTinDto> Children { get; set; }
        #region Các thông tin khác

        #endregion

        //public TreesDanhMucBaiTinDto()
        //{
        //    Children = new List<TreesDanhMucBaiTinDto>();
        //}
    }
}
