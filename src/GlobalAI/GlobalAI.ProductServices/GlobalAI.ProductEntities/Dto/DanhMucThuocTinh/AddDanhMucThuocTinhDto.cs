using GlobalAI.ProductEntities.Dto.ThuocTinh;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.DanhMucThuocTinh
{
    public class AddDanhMucThuocTinhDto
    {
        private string _ma;
        private string _ten;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã danh mục không được bỏ trống")]
        public string Ma { get => _ma; set => _ma = value?.Trim(); }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên danh mục không được bỏ trống")]
        public string Ten { get => _ten; set => _ten = value?.Trim(); }

        /// <summary>
        /// Danh sách các thuộc tính
        /// </summary>
        public List<AddThuocTinhDto> ListThuocTinh { get; set; }

    }


}
