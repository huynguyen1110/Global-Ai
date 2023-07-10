using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.CoreEntities.Dto.User;
using GlobalAI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreDomain.Interfaces
{
    public interface IUserServices
    {
        /// <summary>
        /// Tạo user mới
        /// </summary>
        /// <param name="dto"></param>
        public void CreateUser(AddUserDto dto);
        /// <summary>
        /// Check username vs password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User ValidateUser(string username, string password);
        /// <summary>
        /// Lấy user theo username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User FindByUsername(string username);

        /// <summary>
        /// Cập nhật role cho user
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateListRole(UpdateUserRoleDto dto);

        /// <summary>
        /// Lấy list role theo user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ViewUserRoleDto> FindUserRoleByUserId(int userId);

        /// <summary>
        /// Lấy list user phân trang
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PagingResult<ViewUserDto> FindUserPaging(FindUserDto dto);
    }
}
