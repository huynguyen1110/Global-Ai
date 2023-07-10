using AutoMapper;
using GlobalAI.CoreDomain.Interfaces;
using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.CoreEntities.Dto.Role;
using GlobalAI.CoreRepositories;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlobalAI.CoreDomain.Implements
{
    public class RoleServices : IRoleServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RoleServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;

        public RoleServices(
            GlobalAIDbContext dbContext, ILogger<RoleServices> logger, DatabaseOptions databaseOptions, IHttpContextAccessor httpContext,
            IMapper mapper
        )
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
            _connectionString = databaseOptions.ConnectionString;
            _httpContext = httpContext;
            _userRepository = new UserRepository(dbContext, logger);
            _roleRepository = new RoleRepository(dbContext, logger);
        }

        /// <summary>
        /// Thêm role
        /// </summary>
        /// <param name="dto"></param>
        public void AddRole(AddRoleDto dto)
        {
            string username = CommonUtils.GetCurrentUsername(_httpContext);
            _logger.LogInformation($"{nameof(AddRole)}: dto = {JsonSerializer.Serialize(dto)},  username={username}");

            using (var tran = _dbContext.Database.BeginTransaction())
            {
                var role = _roleRepository.AddRole(_mapper.Map<CoreRole>(dto), username);
                _dbContext.SaveChanges();

                if (dto.ListPermissions.Count > 0)
                {
                    var listPer = new List<CoreRolePermisison>();
                    foreach (var per in dto.ListPermissions)
                    {
                        listPer.Add(new CoreRolePermisison
                        {
                            PermissionKey = per,
                            RoleId = role.Id,
                            CreatedBy = username,
                            CreatedDate = DateTime.Now,
                        });
                    }
                    _roleRepository.AddListRolePermissions(listPer);
                }

                _dbContext.SaveChanges();
                tran.Commit();
            }
        }

        /// <summary>
        /// Cập nhật role
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateRole(UpdateRoleDto dto)
        {
            string username = CommonUtils.GetCurrentUsername(_httpContext);
            _logger.LogInformation($"{nameof(UpdateRole)}: dto = {JsonSerializer.Serialize(dto)},  username={username}");

            var dbListPermissions = _roleRepository.FindPermissionsByRole(dto.Id);

            foreach (var item in dbListPermissions)
            {
                bool exist = dto.ListPermissions.Any(x => x == item.PermissionKey);

                if (!exist)
                {
                    _roleRepository.DeleteRolePermissionById(item.Id, username);
                }
            }

            foreach (var item in dto.ListPermissions)
            {
                bool exist = dbListPermissions.Any(x => x.PermissionKey == item);
                if (!exist)
                {
                    _roleRepository.AddRolePermission(new CoreRolePermisison
                    {
                        RoleId = dto.Id,
                        PermissionKey = item,
                    }, username);
                }
            }

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Get role paging
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PagingResult<ViewRoleDto> FindRolePaging(FindRolePagingDto dto)
        {
            _logger.LogInformation($"{nameof(FindRolePaging)}: dto = {JsonSerializer.Serialize(dto)}");

            var data = _roleRepository.FindRolePaging(dto);
            var result = new PagingResult<ViewRoleDto>
            {
                TotalItems = data.TotalItems,
                Items = _mapper.Map<List<ViewRoleDto>>(data.Items)
            };

            return result;
        }

    }
}
