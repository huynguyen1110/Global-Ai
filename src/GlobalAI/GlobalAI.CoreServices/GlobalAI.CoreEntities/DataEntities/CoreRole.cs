using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreEntities.DataEntities
{
    [Table("C_ROLE")]
    [Comment("Bảng role")]
    public class CoreRole
    {
        [Key]
        [ColumnSnackCase(nameof(Id))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Mã role
        /// </summary>
        [MaxLength(25)]
        [ColumnSnackCase(nameof(Code), TypeName = "VARCHAR2")]
        public string Code { get; set; } = String.Empty;

        /// <summary>
        /// Tên role
        /// </summary>
        [MaxLength(100)]
        [ColumnSnackCase(nameof(Name), TypeName = "VARCHAR2")]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Mô tả cho role
        /// </summary>
        [MaxLength(250)]
        [ColumnSnackCase(nameof(Description), TypeName = "VARCHAR2")]
        public string Description { get; set; } = String.Empty;

        #region audit
        [ColumnSnackCase(nameof(Deleted))]
        public bool Deleted { get; set; }


        [MaxLength(50)]
        [ColumnSnackCase(nameof(CreatedBy), TypeName = "VARCHAR2")]
        public string? CreatedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(CreatedDate), TypeName = "DATE")]
        public DateTime? CreatedDate { get; set; }

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
