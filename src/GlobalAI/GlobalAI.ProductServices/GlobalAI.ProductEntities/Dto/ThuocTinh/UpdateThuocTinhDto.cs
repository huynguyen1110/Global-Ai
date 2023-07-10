using GlobalAI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.ThuocTinh
{
    public class UpdateThuocTinhDto
    {
        private string _tenThuocTinh;

        [Required(ErrorMessage = "Id không được bỏ trống")]
        public int Id { get; set; }
        /// <summary>
        /// Nếu dùng trong add Danh mục thuộc tính thì truyền lên là 0
        /// </summary>
        [Required(ErrorMessage = "Danh mục thuộc tính không được bỏ trống")]
        public int IdDanhMucThuocTinh { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên thuộc tính không được bỏ trống")]
        public string TenThuocTinh { get => _tenThuocTinh; set => _tenThuocTinh = value?.Trim(); }
    }
}
