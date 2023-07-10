using GlobalAI.Utils.ConstantVariables.Core;
using GlobalAI.Utils.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreEntities.Dto.User
{
    /// <summary>
    /// Đăng ký tài khoản
    /// </summary>
    public class AddUserDto
    {
        private string _username;
        private string _password;
        private string _firstname;
        private string _lastname;
        private string _email;
        private string _phone;

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên đăng nhập không được bỏ trống")]
        public string Username { get => _username; set => _username = value?.Trim(); }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string Password { get => _password; set => _password = value?.Trim(); }

        /// <summary>
        /// Tên
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được bỏ trống")]
        public string FirstName { get => _firstname; set => _firstname = value?.Trim(); }

        /// <summary>
        /// Họ
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Họ không được bỏ trống")]
        public string LastName { get => _lastname; set => _lastname = value?.Trim(); }

        /// <summary>
        /// Email
        /// </summary>
        [Email(ErrorMessage = "Email không hợp lệ")]
        public string Email { get => _email; set => _email = value?.Trim(); }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [PhoneVN(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get => _phone; set => _phone = value?.Trim(); }

        /// <summary>
        /// Loại người dùng
        /// <see cref="UserTypes"/>
        /// </summary>
        [StringRange(AllowableValues = new string[] { UserTypes.GSaler, UserTypes.GStore })]
        public string UserType { get; set; }
    }
}
