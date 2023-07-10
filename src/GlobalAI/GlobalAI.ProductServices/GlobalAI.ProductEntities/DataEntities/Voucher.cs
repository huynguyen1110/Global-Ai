using GlobalAI.Utils.Attributes;
using GlobalAI.Utils.ConstantVariables.Product;
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
    [Table("P_Voucher")]
    [Comment("Voucher")]
    public class Voucher
    {
        /// <summary>
        /// Id voucher
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id { get; set; }

        /// <summary>
        /// Tên voucher
        /// </summary>
        [ColumnSnackCase(nameof(Name), TypeName = "VARCHAR2")]
        [MaxLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// Ảnh voucher
        /// </summary>
        [ColumnSnackCase(nameof(Avatar), TypeName = "VARCHAR2")]
        [MaxLength(500)]
        public string Avatar { get; set; }

        /// <summary>
        /// Mô tả voucher
        /// </summary>
        [ColumnSnackCase(nameof(MoTa), TypeName = "VARCHAR2")]
        [MaxLength(500)]
        public string MoTa { get; set; }

        /// <summary>
        /// Giá trị
        /// </summary>
        [ColumnSnackCase(nameof(GiaTri))]
        public double? GiaTri { get; set; }

        /// <summary>
        /// Số lượng voucher
        /// </summary>
        [ColumnSnackCase(nameof(SoLuong))]
        public int SoLuong { get; set; }

        /// <summary>
        /// Ngày hết hạn
        /// </summary>
        [ColumnSnackCase(nameof(NgayHetHan), TypeName = "DATE")]
        public DateTime? NgayHetHan { get; set; }

        /// <summary>
        /// Trạng thái voucher
        /// </summary>
        [ColumnSnackCase(nameof(Status))]
        public int? Status { get; set; }

        #region audit
        [MaxLength(50)]
        [ColumnSnackCase(nameof(CreatedBy), TypeName = "VARCHAR2")]
        public string CreatedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(CreatedDate), TypeName = "DATE")]
        public DateTime? CreatedDate { get; set; }

        [ColumnSnackCase(nameof(Deleted))]
        public bool Deleted { get; set; }

        [MaxLength(50)]
        [ColumnSnackCase(nameof(DeletedBy), TypeName = "VARCHAR2")]
        public string DeletedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(DeletedDate), TypeName = "DATE")]
        public DateTime? DeletedDate { get; set; }

        [MaxLength(50)]
        [ColumnSnackCase(nameof(ModifiedBy), TypeName = "VARCHAR2")]
        public string ModifiedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(ModifiedDate), TypeName = "DATE")]
        public DateTime? ModifiedDate { get; set; }
        #endregion


    }
}
