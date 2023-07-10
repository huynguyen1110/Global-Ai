using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreEntities.Dto.User
{
    public class ViewUserRoleDto
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        /// <summary>
        /// Mã role
        /// </summary>
        public string Code { get; set; } = String.Empty;

        /// <summary>
        /// Tên role
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Mô tả cho role
        /// </summary>
        public string Description { get; set; } = String.Empty;
    }
}
