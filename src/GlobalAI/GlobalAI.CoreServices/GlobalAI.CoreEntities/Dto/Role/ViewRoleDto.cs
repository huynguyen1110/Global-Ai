using GlobalAI.Utils.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreEntities.Dto.Role
{
    public class ViewRoleDto
    {
        public int Id { get; set; }

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
