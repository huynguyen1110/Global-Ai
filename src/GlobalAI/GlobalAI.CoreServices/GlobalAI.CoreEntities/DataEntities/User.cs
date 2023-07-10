using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreEntities.DataEntities
{
    [Table("USER")]
    [Comment("User")]
    public class User
    {
        [Key]
        [ColumnSnackCase(nameof(UserId))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// tên đăng nhập
        /// </summary>
        [MaxLength(100)]
        [ColumnSnackCase(nameof(Username), TypeName = "VARCHAR2")]
        public string Username { get; set; } = String.Empty;

        /// <summary>
        /// tên hiển thị
        /// </summary>
        [MaxLength(500)]
        [ColumnSnackCase(nameof(DisplayName), TypeName = "VARCHAR2")]
        public string? DisplayName { get; set; } = String.Empty;

        /// <summary>
        /// Tên
        /// </summary>
        [MaxLength(250)]
        [ColumnSnackCase(nameof(FirstName), TypeName = "VARCHAR2")]
        public string FirstName { get; set; } = String.Empty;

        /// <summary>
        /// Họ
        /// </summary>
        [MaxLength(250)]
        [ColumnSnackCase(nameof(LastName), TypeName = "VARCHAR2")]
        public string LastName { get; set; } = String.Empty;

        /// <summary>
        /// Mật khẩu
        /// </summary>
        [MaxLength(500)]
        [ColumnSnackCase(nameof(Password), TypeName = "VARCHAR2")]
        public string Password { get; set; } = String.Empty;

        /// <summary>
        /// Trạng thái
        /// </summary>
        [MaxLength(3)]
        [ColumnSnackCase(nameof(Status), TypeName = "CHAR")]
        public string? Status { get; set; } = String.Empty;

        /// <summary>
        /// Bị xóa chưa
        /// </summary>
        [ColumnSnackCase(nameof(Deleted))]
        public bool Deleted { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [MaxLength(500)]
        [ColumnSnackCase(nameof(Email), TypeName = "VARCHAR2")]
        public string Email { get; set; } = String.Empty;

        /// <summary>
        /// Sdt
        /// </summary>
        [MaxLength(20)]
        [ColumnSnackCase(nameof(Phone), TypeName = "VARCHAR2")]
        public string Phone { get; set; } = String.Empty;

        /// <summary>
        /// Loại user
        /// </summary>
        [MaxLength(20)]
        [ColumnSnackCase(nameof(UserType), TypeName = "VARCHAR2")]
        public string UserType { get; set; } = String.Empty;

        /// <summary>
        /// Tg đăng nhập gần nhất
        /// </summary>

        [ColumnSnackCase(nameof(LastLogin), TypeName = "DATE")]
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Lần đăng nhập thất bại gần nhất
        /// </summary>

        [ColumnSnackCase(nameof(LastFailedLogin), TypeName = "DATE")]
        public DateTime? LastFailedLogin { get; set; }

        /// <summary>
        /// Số lần đăng nhập thất bại
        /// </summary>

        [ColumnSnackCase(nameof(FailAttemp))]
        public decimal? FailAttemp { get; set; }

        /// <summary>
        /// Có phải lần đầu đăng nhập ko
        /// </summary>

        [ColumnSnackCase(nameof(IsFirstTime))]
        public bool IsFirstTime { get; set; }

        /// <summary>
        /// Mật khẩu tạm
        /// </summary>

        [ColumnSnackCase(nameof(IsTempPassword))]
        public bool IsTempPassword { get; set; }

        /// <summary>
        /// Token để reset password
        /// </summary>
        [MaxLength(500)]
        [ColumnSnackCase(nameof(ResetPasswordToken), TypeName = "VARCHAR2")]
        public string? ResetPasswordToken { get; set; } = String.Empty;

        /// <summary>
        /// Tg hết hạn token reset pass
        /// </summary>

        [ColumnSnackCase(nameof(ResetPasswordTokenExp), TypeName = "DATE")]
        public DateTime? ResetPasswordTokenExp { get; set; }

        /// <summary>
        /// Email đã được xác thực chưa
        /// </summary>

        [ColumnSnackCase(nameof(IsVerifiedEmail))]
        public bool IsVerifiedEmail { get; set; }

        /// <summary>
        /// Mã xác thực email
        /// </summary>

        [ColumnSnackCase(nameof(VerifyEmailCode), TypeName = "VARCHAR2")]
        [MaxLength(100)]
        public string? VerifyEmailCode { get; set; } = String.Empty;

        /// <summary>
        /// Ảnh đại diện 
        /// </summary>
        [ColumnSnackCase(nameof(Avatar), TypeName = "VARCHAR2")]
        [MaxLength(500)]
        public string Avatar { get; set; }

        /// <summary>
        /// Điều khoản
        /// </summary>
        [ColumnSnackCase(nameof(Policy), TypeName = "CLOB")]
        public string Policy { get; set; }

        /// <summary>
        /// Gpoint
        /// </summary>
        [ColumnSnackCase(nameof(GPoint))]
        public decimal? GPoint { get; set; }

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
