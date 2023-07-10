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
    [Table("P_ThuocTinhGiaTri")]
    [Comment("bảng giá trị thuộc tính")]
    public class ThuocTinhGiaTri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id { get; set; }

        /// <summary>
        /// Id thuộc tính
        /// </summary>
        [ColumnSnackCase(nameof(IdThuocTinh))]
        public int IdThuocTinh { get; set; }

        /// <summary>
        /// Tên thuộc tính
        /// </summary>
        [ColumnSnackCase(nameof(TenThuocTinh), TypeName = "VARCHAR2")]
        [MaxLength(150)]
        public string TenThuocTinh { get; set; }

        /// <summary>
        /// Giá trị thuộc tính
        /// </summary>
        [ColumnSnackCase(nameof(GiaTri), TypeName = "VARCHAR2")]
        [MaxLength(500)]
        public string GiaTri { get; set; }

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

        [MaxLength(50)]
        [ColumnSnackCase(nameof(ModifiedBy), TypeName = "VARCHAR2")]
        public string? ModifiedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(ModifiedDate), TypeName = "DATE")]
        public DateTime? ModifiedDate { get; set; }
        #endregion
    }
}
