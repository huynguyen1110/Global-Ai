using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.DataEntities
{
    [Table("P_DanhMucBaiTin")]
    [Comment("Bảng danh mục bài tin")]
    public class DanhMucBaiTin
    {
        /// <summary>
        /// Id danh mục
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id { get; set; }

        /// <summary>
        /// Mã danh mục
        /// </summary>
        [ColumnSnackCase(nameof(MaDanhMuc), TypeName = "VARCHAR2")]
        [MaxLength(50)]
        public string MaDanhMuc { get; set; }        

        /// <summary>
        /// Tên danh mục
        /// </summary>
        [ColumnSnackCase(nameof(TenDanhMuc), TypeName = "VARCHAR2")]
        [MaxLength(120)]
        public string TenDanhMuc { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        [ColumnSnackCase(nameof(Status))]
        public int? Status { get; set; }

        /// <summary>
        /// Parent id
        /// </summary>
        [ColumnSnackCase(nameof(ParentId))]
        public int? ParentId { get; set; }

        /// <summary>
        /// Thumbnail
        /// </summary>
        [ColumnSnackCase(nameof(Thumbnail), TypeName = "VARCHAR2")]
        [MaxLength(500)]
        public string Thumbnail { get; set; }

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
