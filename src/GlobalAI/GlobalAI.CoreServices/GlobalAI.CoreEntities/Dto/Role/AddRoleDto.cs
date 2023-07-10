using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreEntities.Dto.Role
{
    public class AddRoleDto
    {
        private string _name;
        private string _description;

        /// <summary>
        /// Tên role
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được bỏ trống tên role")]
        public string Name { get => _name; set => _name = value?.Trim(); }

        /// <summary>
        /// Mô tả cho role
        /// </summary>
        public string Description { get => _description; set => _description = value?.Trim(); }

        /// <summary>
        /// List quyền
        /// </summary>
        public List<string> ListPermissions { get; set; }
    }
}
