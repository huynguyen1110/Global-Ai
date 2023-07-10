using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreEntities.Dto.User
{
    public class ViewUserDto
    {
        public int UserId { get; set; }

        /// <summary>
        /// tên đăng nhập
        /// </summary>
        public string Username { get; set; } = String.Empty;

        /// <summary>
        /// tên hiển thị
        /// </summary>
        public string DisplayName { get; set; } = String.Empty;

        /// <summary>
        /// Tên
        /// </summary>
        public string FirstName { get; set; } = String.Empty;

        /// <summary>
        /// Họ
        /// </summary>
        public string LastName { get; set; } = String.Empty;


        /// <summary>
        /// Trạng thái
        /// </summary>
        public string? Status { get; set; } = String.Empty;

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = String.Empty;

        /// <summary>
        /// Sdt
        /// </summary>
        public string Phone { get; set; } = String.Empty;

        /// <summary>
        /// Loại user
        /// </summary>
        public string UserType { get; set; } = String.Empty;

        /// <summary>
        /// Tg đăng nhập gần nhất
        /// </summary>
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Lần đăng nhập thất bại gần nhất
        /// </summary>
        public DateTime? LastFailedLogin { get; set; }

        /// <summary>
        /// Email đã được xác thực chưa
        /// </summary>
        public bool IsVerifiedEmail { get; set; }

        public string? CreatedBy { get; set; } = String.Empty;

        public DateTime? CreatedDate { get; set; }
    }
}
