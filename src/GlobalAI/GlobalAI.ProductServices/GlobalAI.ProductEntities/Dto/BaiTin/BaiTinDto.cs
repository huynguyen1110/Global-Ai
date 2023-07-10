using GlobalAI.ProductEntities.Dto.ChiTietTraGia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.BaiTin
{
    public class BaiTinDto
    {
        public int Id { get; set; }
        public int IdDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public string MoTa { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string Thumbnail { get; set; }
        public string Slug { get; set; }
        public DateTime? NgayDang { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        #region Các thông tin khác

        #endregion
    }
}
