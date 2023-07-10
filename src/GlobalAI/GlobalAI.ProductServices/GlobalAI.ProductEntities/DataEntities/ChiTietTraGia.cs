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
    [Table("P_ChiTietTraGia")]
    [Comment("Chi tiết trả giá")]
    public class ChiTietTraGia
    {
        /// <summary>
        /// Id chi tiết trả giá
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(Id))]
        public int Id { get; set; }

        /// <summary>
        /// Id trả giá
        /// </summary>
        [ColumnSnackCase(nameof(IdTraGia))]
        public int IdTraGia { get; set; }

        /// <summary>
        /// Giá tiền mặc cả
        /// </summary>
        [ColumnSnackCase(nameof(GiaTien))]
        public decimal? GiaTien { get; set; }

        /// <summary>
        /// Loại user (GStore hay GSaler)
        /// <see cref="TraGiaUsertypes"/>
        /// </summary>
        [MaxLength(20)]
        [ColumnSnackCase(nameof(Usertype), TypeName = "VARCHAR2")]
        public string Usertype { get; set; }

        /// <summary>
        /// 1: Người mua đề xuất giá; 2: Người bán đề xuất giá
        /// <see cref="LoaiTraGias"/>
        /// </summary>
        [ColumnSnackCase(nameof(LoaiTraGia))]
        public int LoaiTraGia { get; set; }

        /// <summary>
        /// Trạng thái của đợt trả giá
        /// <see cref="TrangThaiChiTietTraGia"/>
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
