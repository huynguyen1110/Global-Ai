using GlobalAI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri
{
    public class AddThuocTinhGiaTriDto
    {
        private string _giaTri;

        /// <summary>
        /// Nếu dùng trong add Danh mục thuộc tính thì truyền lên là 0
        /// </summary>
        [Required(ErrorMessage = "Id thuộc tính không được bỏ trống")]
        public int IdThuocTinh { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Giá trị thuộc tính không được bỏ trống")]
        public string GiaTri { get => _giaTri; set => _giaTri = value?.Trim(); }
    }
}
