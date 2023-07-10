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
    [Table("P_SanPham")]
    [Comment("bảng sản phẩm")]
    public class SanPham
    {
        //public static string SEQ { get; } = $"SEQ_{nameof(DemoProduct).ToSnakeUpperCase()}";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id { get; set; }

        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        [ColumnSnackCase(nameof(MaSanPham))]
        public string MaSanPham { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        [StringLength(400)]
        [ColumnSnackCase(nameof(TenSanPham))]
        public string TenSanPham { get; set; } = String.Empty;

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
        /// Id danh mục
        /// </summary>
        [ColumnSnackCase(nameof(IdDanhMuc))]
        public string IdDanhMuc { get; set; }

        /// <summary>
        /// Id Gstore
        /// </summary>
        [ColumnSnackCase(nameof(IdGStore))]
        public int IdGStore { get; set; }

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

        [ColumnSnackCase(nameof(Deleted))]
        public bool Deleted { get; set; }

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
        /// Immage của sp
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
        /// Id danh mục thuộc tính
        /// </summary>
        [ColumnSnackCase(nameof(IdDanhMucThuocTinh))]
        public int? IdDanhMucThuocTinh { get; set; }

        #region audit
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
