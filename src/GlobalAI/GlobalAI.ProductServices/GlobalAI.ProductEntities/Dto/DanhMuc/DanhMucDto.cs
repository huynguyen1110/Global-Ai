using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.DanhMuc
{
    public class DanhMucDto
    {
        public int Id { get; set; }
        public string IdDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public bool IsDisplayOnHomePage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        #region Các thông tin khác

        #endregion
    }
}
