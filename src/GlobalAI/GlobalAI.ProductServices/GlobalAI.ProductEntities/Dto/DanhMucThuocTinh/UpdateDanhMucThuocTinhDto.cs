using GlobalAI.ProductEntities.Dto.ThuocTinh;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.DanhMucThuocTinh
{
    public class UpdateDanhMucThuocTinhDto
    {
        private string _ma;
        private string _ten;

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã danh mục không được bỏ trống")]
        public string Ma { get => _ma; set => _ma = value?.Trim(); }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên danh mục không được bỏ trống")]
        public string Ten { get => _ten; set => _ten = value?.Trim(); }

    }


}
