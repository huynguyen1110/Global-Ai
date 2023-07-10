using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreEntities.Dto.Role
{
    public class UpdateRoleDto : AddRoleDto
    {
        /// <summary>
        /// Role id
        /// </summary>
        public int Id { get; set; }
    }
}
