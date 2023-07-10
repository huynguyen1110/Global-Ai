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
    [Table("P_GioHang")]
    [Comment("Giỏ hàng")]
    public class GioHang
    {
        /// <summary>
        /// Id giỏ hàng
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id { get; set; }

        /// <summary>
        /// Id Người mua (Vì gstore và gsaler đều có thể mua hàng)
        /// (Lấy giá trị từ id trong bảng user)
        /// </summary>
        [ColumnSnackCase(nameof(IdNguoiMua))]
        public int IdNguoiMua { get; set; }

        /// <summary>
        /// Id Sản phẩm (Có thể trùng nhau)
        /// </summary>
        [ColumnSnackCase(nameof(IdSanPham))]
        public int? IdSanPham { get; set; }

        /// <summary>
        /// Id sản phẩm chi tiết
        /// </summary>
        [ColumnSnackCase(nameof(IdSanPhamChiTiet))]
        public int? IdSanPhamChiTiet { get; set; }

        /// <summary>
        /// Số lượng sp
        /// </summary>
        [ColumnSnackCase(nameof(SoLuong))]
        public int SoLuong { get; set; }

        /// <summary>
        /// Trạng thái
        /// <see cref="TrangThaiGioHang"/>
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
