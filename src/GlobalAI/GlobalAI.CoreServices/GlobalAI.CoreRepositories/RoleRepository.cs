using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.CoreEntities.Dto.Role;
using GlobalAI.CoreEntities.Dto.User;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlobalAI.CoreRepositories
{
    public class RoleRepository : BaseEFRepository<CoreRole>
    {
        public RoleRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {
        }

        /// <summary>
        /// Thêm mới role
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="username"></param>
        public CoreRole AddRole(CoreRole entity, string username)
        {
            _logger.LogInformation($"{nameof(AddRole)}: entity = {JsonSerializer.Serialize(entity)},  username={username}");

            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = username;

            _globalAIDbContext.CoreRoles.Add(entity);

            return entity;
        }

        /// <summary>
        /// Add nhiều role permissions
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permissions"></param>
        /// <param name="username"></param>
        public void AddListRolePermissions(List<CoreRolePermisison> listRolePer)
        {
            _globalAIDbContext.CoreRolePermisisons.AddRange(listRolePer);
        }

        /// <summary>
        /// Xoá 1 role
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="username"></param>
        public void DeleteRole(int roleId, string username)
        {
            _logger.LogInformation($"{nameof(DeleteRole)}: roleId={roleId}, username={username}");

            var role = _globalAIDbContext.CoreRoles.FirstOrDefault(x => x.Id == roleId && !x.Deleted).ThrowIfNull(_globalAIDbContext, ErrorCode.UserRoleNotFound);
            role.Deleted = true;
            role.DeletedDate = DateTime.Now;
            role.DeletedBy = username;
        }

        /// <summary>
        /// Lấy role theo id role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public CoreRole FindRoleById(int roleId)
        {
            _logger.LogInformation($"{nameof(FindRoleById)}: roleId={roleId}");

            var role = _globalAIDbContext.CoreRoles.FirstOrDefault(x => x.Id == roleId && !x.Deleted);
            return role;
        }

        /// <summary>
        /// Lấy list role phân trang
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PagingResult<CoreRole> FindRolePaging(FindRolePagingDto dto)
        {
            _logger.LogInformation($"{nameof(FindRolePaging)}: dto = {JsonSerializer.Serialize(dto)}");

            var query = _globalAIDbContext.CoreRoles.AsNoTracking()
                            .Where(x => (dto.Keyword == null || x.Name.ToLower().Contains(dto.Keyword.Trim().ToLower()) || x.Description.ToLower().Contains(dto.Keyword.Trim().ToLower())) && !x.Deleted)
                            .OrderByDescending(x => x.Id)
                            ;

            var result = new PagingResult<CoreRole>
            {
                TotalItems = query.Count(),
                Items = query.Skip(dto.Skip).Take(dto.PageSize)
            };

            return result;
        }

        /// <summary>
        /// Lấy list permission theo role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<CoreRolePermisison> FindPermissionsByRole(int roleId)
        {
            _logger.LogInformation($"{nameof(FindPermissionsByRole)}: roleId={roleId}");

            var query = from role in _globalAIDbContext.CoreRoles
                        join rolePer in _globalAIDbContext.CoreRolePermisisons on role.Id equals rolePer.RoleId
                        where !role.Deleted && !rolePer.Deleted && rolePer.RoleId == roleId
                        select rolePer;

            return query.ToList();
        }

        /// <summary>
        /// Xoá 1 dòng role permissions
        /// </summary>
        /// <param name="rolePermissionId"></param>
        /// <param name="username"></param>
        public void DeleteRolePermissionById(int rolePermissionId, string username)
        {
            _logger.LogInformation($"{nameof(DeleteRolePermissionById)}: rolePermissionId={rolePermissionId}");

            var rolePer = _globalAIDbContext.CoreRolePermisisons.FirstOrDefault(x => x.Id == rolePermissionId && !x.Deleted);
            if (rolePer != null)
            {
                rolePer.Deleted = true;
                rolePer.DeletedDate = DateTime.Now;
                rolePer.DeletedBy = username;
            }
        }

        /// <summary>
        /// Xoá 1 dòng user role theo id
        /// </summary>
        /// <param name="userRoleId"></param>
        public void DeleteUserRoleById(int userRoleId,string username )
        {
            _logger.LogInformation($"{nameof(DeleteUserRoleById)}: userRoleId={userRoleId}");

            var userRole = _globalAIDbContext.CoreUserRoles.FirstOrDefault(x => x.Id == userRoleId && !x.Deleted);
            if (userRole != null)
            {
                userRole.Deleted = true;
                userRole.DeletedDate = DateTime.Now;
                userRole.DeletedBy = username;
            }
        }

        /// <summary>
        /// Tạo mới 1 role permission
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public CoreRolePermisison AddRolePermission(CoreRolePermisison entity, string username)
        {
            _logger.LogInformation($"{nameof(AddRolePermission)}: entity={JsonSerializer.Serialize(entity)}, username={username}");

            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = username;

            _globalAIDbContext.Add(entity);
            return entity;
        }

        /// <summary>
        /// Lấy list permission theo userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> FindListPermissionByUserId(int userId)
        {
            _logger.LogInformation($"{nameof(FindListPermissionByUserId)}: userId={userId}");

            var query = (from user in _globalAIDbContext.Users.AsNoTracking()
                        join userRole in _globalAIDbContext.CoreUserRoles.AsNoTracking() on user.UserId equals userRole.UserId
                        join role in _globalAIDbContext.CoreRoles.AsNoTracking() on userRole.RoleId equals role.Id
                        join rolePer in _globalAIDbContext.CoreRolePermisisons.AsNoTracking() on role.Id equals rolePer.RoleId
                       where !user.Deleted && !userRole.Deleted && !role.Deleted && !rolePer.Deleted && user.UserId == userId
                       select rolePer.PermissionKey
                       ).Distinct();

            return query.ToList();
        }

        /// <summary>
        /// Lấy list role theo user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ViewUserRoleDto> FindListRoleByUserId(int userId)
        {
            _logger.LogInformation($"{nameof(FindListRoleByUserId)}: userId={userId}");

            var query = from user in _globalAIDbContext.Users.AsNoTracking()
                         join userRole in _globalAIDbContext.CoreUserRoles.AsNoTracking() on user.UserId equals userRole.UserId
                         join role in _globalAIDbContext.CoreRoles.AsNoTracking() on userRole.RoleId equals role.Id
                         where !user.Deleted && !userRole.Deleted && !role.Deleted && user.UserId == userId 
                         select new ViewUserRoleDto
                         {
                             RoleId = role.Id,
                             Code = role.Code,
                             Description = role.Description,
                             Name = role.Name,
                             UserRoleId = userRole.Id,
                         };

            return query.ToList();
        }

        /// <summary>
        /// Thêm 1 dòng userrole
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public CoreUserRole AddUserRole(CoreUserRole entity, string username)
        {
            _logger.LogInformation($"{nameof(AddUserRole)}: entity={JsonSerializer.Serialize(entity)}; username={username}");

            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = username;

            _globalAIDbContext.CoreUserRoles.Add(entity);
            return entity;
        }
    }
}
