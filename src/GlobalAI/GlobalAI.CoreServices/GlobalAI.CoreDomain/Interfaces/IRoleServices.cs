using GlobalAI.CoreEntities.Dto.Role;
using GlobalAI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreDomain.Interfaces
{
    public interface IRoleServices
    {
        /// <summary>
        /// Thêm role
        /// </summary>
        /// <param name="dto"></param>
        public void AddRole(AddRoleDto dto);

        /// <summary>
        /// Update role
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateRole(UpdateRoleDto dto);

        /// <summary>
        /// Get role paging
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PagingResult<ViewRoleDto> FindRolePaging(FindRolePagingDto dto);
    }
}
