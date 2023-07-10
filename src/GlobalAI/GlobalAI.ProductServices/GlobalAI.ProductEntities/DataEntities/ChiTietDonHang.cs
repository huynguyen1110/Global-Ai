using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalAI.ProductEntities.DataEntities
{
    [Table("P_ChiTietDonHang")]
    [Comment("bảng chi tiết đơn hàng")]
    public class ChiTietDonHang
    {
        /// <summary>
        /// Id chi tiết đơn hàng
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id {get; set;}

        /// <summary>
        /// Id đơn hàng
        /// </summary>
        [ColumnSnackCase(nameof(IdDonHang))]
        public int IdDonHang { get; set; }

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        [ColumnSnackCase(nameof(IdSanPham))]
        public int IdSanPham { get; set; }

        /// <summary>
        /// Id sản phẩm chi tiết
        /// </summary>
        [ColumnSnackCase(nameof(IdSanPhamChiTiet))]
        public int IdSanPhamChiTiet { get; set; }

        /// <summary>
        /// Số lượng sản phẩm
        /// </summary>
        [ColumnSnackCase(nameof(SoLuong))]
        public int SoLuong { get; set; }

        /// <summary>
        /// Gpoint
        /// </summary>
        [ColumnSnackCase(nameof(GPoint))]
        public decimal? GPoint { get; set; }

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
        #endregion

    }
}
