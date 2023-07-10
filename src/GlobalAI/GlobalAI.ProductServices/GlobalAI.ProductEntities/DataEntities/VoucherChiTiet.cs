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
    [Table("P_Voucher_ChiTiet")]
    [Comment("Voucher chi tiết")]
    public class VoucherChiTiet
    {
        /// <summary>
        /// Id voucher chi tiết
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id { get; set; }

        /// <summary>
        /// Id Voucher
        /// </summary>
        [ColumnSnackCase(nameof(VoucherId))]
        public int VoucherId { get; set; }

        /// <summary>
        /// Mã voucher
        /// </summary>
        [ColumnSnackCase(nameof(MaVoucher), TypeName = "VARCHAR2")]
        [MaxLength(150)]
        public string MaVoucher { get; set; }

        /// <summary>
        /// Ngày giao (Ngày user nhận voucher)
        /// </summary>
        [ColumnSnackCase(nameof(NgayGiao), TypeName = "DATE")]
        public DateTime? NgayGiao { get; set; }

        /// <summary>
        /// Ngày sử dụng (Ngày user sử dụng voucher)
        /// </summary>
        [ColumnSnackCase(nameof(NgaySuDung), TypeName = "DATE")]
        public DateTime? NgaySuDung { get; set; }

        /// <summary>
        /// Username của user sử dụng voucher
        /// </summary>
        [ColumnSnackCase(nameof(NguoiSuDung), TypeName = "VARCHAR2")]
        [MaxLength(150)]
        public string NguoiSuDung { get; set; }

        /// <summary>
        /// Tên voucher (Lưu lại khi user sử dụng voucher)
        /// </summary>
        [ColumnSnackCase(nameof(LichSuTenVoucher), TypeName = "VARCHAR2")]
        [MaxLength(250)]
        public string LichSuTenVoucher { get; set; }

        /// <summary>
        /// Mô tả voucher (Lưu lại khi user sử dụng voucher)
        /// </summary>
        [ColumnSnackCase(nameof(LichSuMoTa), TypeName = "VARCHAR2")]
        [MaxLength(500)]
        public string LichSuMoTa { get; set; }

        /// <summary>
        /// Giá trị (Lưu lại khi user sử dụng voucher)
        /// </summary>
        [ColumnSnackCase(nameof(LichSuGiaTri))]
        public double? LichSuGiaTri { get; set; }

        /// <summary>
        /// Trạng thái voucher
        /// <see cref="VoucherDetailStatus"/>
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
