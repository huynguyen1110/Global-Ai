using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    [Table("P_BaiTin")]
    [Comment("Bảng bài tin")]
    public class BaiTin
    {
        /// <summary>
        /// Id bài tin
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id { get; set; }


        /// <summary>
        /// Id danh mục bài tin
        /// </summary>
        [ColumnSnackCase(nameof(IdDanhMuc))]
        public int IdDanhMuc { get; set; }

        /// <summary>
        /// Tiêu đề
        /// </summary>
        [ColumnSnackCase(nameof(TieuDe), TypeName = "VARCHAR2")]
        [MaxLength(250)]
        public string TieuDe { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        [ColumnSnackCase(nameof(MoTa), TypeName = "VARCHAR2")]
        [MaxLength(1000)]
        public string MoTa { get; set; }

        /// <summary>
        /// Nội dung
        /// </summary>
        [ColumnSnackCase(nameof(NoiDung), TypeName = "CLOB")]
        public string NoiDung { get; set; }

        /// <summary>
        /// Thumbnail bài viết
        /// </summary>
        [ColumnSnackCase(nameof(Thumbnail), TypeName = "VARCHAR2")]
        [MaxLength(500)]
        public string Thumbnail { get; set; }

        /// <summary>
        /// Slug
        /// </summary>
        [ColumnSnackCase(nameof(Slug), TypeName = "VARCHAR2")]
        [MaxLength(500)]
        public string Slug { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        [ColumnSnackCase(nameof(Status))]
        public int? Status { get; set; }

        [ColumnSnackCase(nameof(NgayDang))]
        public DateTime? NgayDang { get; set; }

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
