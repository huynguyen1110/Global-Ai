using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreEntities.Dto.User
{
    public class UpdateUserRoleDto
    {
        public int UserId { get; set; }
        public List<int> ListRoleId { get; set; }
    }
}
