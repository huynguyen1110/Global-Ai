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
    [Table("P_SanPhamChiTiet")]
    [Comment("bảng sản phẩm chi tiết")]
    public class SanPhamChiTiet
    {
        //public static string SEQ { get; } = $"SEQ_{nameof(DemoProduct).ToSnakeUpperCase()}";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id { get; set; }

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        [ColumnSnackCase(nameof(IdSanPham))]
        public int IdSanPham { get; set; }

        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        [ColumnSnackCase(nameof(MaSanPhamChiTiet))]
        public string MaSanPhamChiTiet { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        [ColumnSnackCase(nameof(MoTa))]
        [StringLength(1000)]
        public string MoTa { get; set; } = String.Empty;

        /// <summary>
        /// Giá bán
        /// </summary>
        [ColumnSnackCase(nameof(GiaBan))]
        public decimal? GiaBan { get; set; }

        /// <summary>
        /// Giá chiết khấu
        /// </summary>
        [ColumnSnackCase(nameof(GiaChietKhau))]
        public decimal? GiaChietKhau { get; set; }

        /// <summary>
        /// Ngày đăng ký
        /// </summary>
        [ColumnSnackCase(nameof(NgayDangKi))]
        public DateTime NgayDangKi { get; set; }

        /// <summary>
        /// Ngày duyệt
        /// </summary>
        [ColumnSnackCase(nameof(NgayDuyet))]
        public DateTime? NgayDuyet { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        [ColumnSnackCase(nameof(Status))]
        public int Status { get; set; }

        /// <summary>
        /// Giá tối thiểu
        /// </summary>
        [ColumnSnackCase(nameof(GiaToiThieu))]
        public decimal? GiaToiThieu { get; set; }

        /// <summary>
        /// Immage của chi tiết sp
        /// </summary>
        [ColumnSnackCase(nameof(Thumbnail))]
        public string Thumbnail { get; set; }

        /// <summary>
        /// Lượt xem sp
        /// </summary>
        [ColumnSnackCase(nameof(LuotXem))]
        public int? LuotXem { get; set; }

        /// <summary>
        /// Lượt bán sp
        /// </summary>
        [ColumnSnackCase(nameof(LuotBan))]
        public int? LuotBan { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        [ColumnSnackCase(nameof(SoLuong))]
        public int? SoLuong { get; set; }


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
