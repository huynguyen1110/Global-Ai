using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.DataEntities
{
    [Table("P_SanPhamChiTietThuocTinh")]
    [Comment("bảng nối giữa Sản phẩm chi tiết & Thuộc tính giá trị")]
    public class SanPhamChiTietThuocTinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id { get; set; }

        /// <summary>
        /// Id thuộc tính giá trị
        /// </summary>
        [ColumnSnackCase(nameof(IdThuocTinhGiaTri))]
        public int IdThuocTinhGiaTri { get; set; }

        /// <summary>
        /// Id Sản phẩm chi tiết
        /// </summary>
        [ColumnSnackCase(nameof(IdSanPhamChiTiet))]
        public int IdSanPhamChiTiet { get; set; }

        #region audit
        [MaxLength(50)]
        [ColumnSnackCase(nameof(CreatedBy), TypeName = "VARCHAR2")]
        public string? CreatedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(CreatedDate), TypeName = "DATE")]
        public DateTime? CreatedDate { get; set; }

        [ColumnSnackCase(nameof(Deleted))]
        public bool Deleted { get; set; }

        [MaxLength(50)]
        [ColumnSnackCase(nameof(DeletedBy), TypeName = "VARCHAR2")]
        public string? DeletedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(DeletedDate), TypeName = "DATE")]
        public DateTime? DeletedDate { get; set; }
        #endregion
    }
}
