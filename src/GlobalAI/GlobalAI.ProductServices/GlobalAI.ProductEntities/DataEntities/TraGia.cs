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
    [Table("P_TraGia")]
    [Comment("Trả giá")]
    public class TraGia
    {
        /// <summary>
        /// Id trả giá
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id { get; set; }

        /// <summary>
        /// Id người bán (lấy userid bán sản phẩm để insert vào)
        /// </summary>
        [ColumnSnackCase(nameof(IdNguoiBan))]
        public int IdNguoiBan { get; set; }

        /// <summary>
        /// Id người mua (gstore hoặc gsaler đều mua được)
        /// </summary>
        [ColumnSnackCase(nameof(IdNguoiMua))]
        public int IdNguoiMua { get; set; }

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
        /// Giá tiền cuối cùng sau khi cả người mua và bán đã đồng ý
        /// </summary>
        [ColumnSnackCase(nameof(GiaCuoi))]
        public decimal GiaCuoi { get; set; }

        /// <summary>
        /// Nội dung khi trả giá
        /// </summary>
        [ColumnSnackCase(nameof(NoiDung), TypeName = "VARCHAR2")]
        [MaxLength(500)]
        public string NoiDung { get; set; }

        /// <summary>
        /// Trạng thái của đợt trả giá
        /// <see cref="TrangThaiTraGia"/>
        /// </summary>
        [ColumnSnackCase(nameof(Status))]
        public int Status { get; set; }

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
