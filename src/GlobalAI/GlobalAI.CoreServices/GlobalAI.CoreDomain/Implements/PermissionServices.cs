using AutoMapper;
using GlobalAI.CoreDomain.Interfaces;
using GlobalAI.CoreRepositories;
using GlobalAI.DataAccess.Base;
using GlobalAI.Entites;
using GlobalAI.Utils;
using GlobalAI.Utils.RolePermissions;
using GlobalAI.Utils.RolePermissions.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreDomain.Implements
{
    public class PermissionServices : IPermissionServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<PermissionServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;

        public PermissionServices(GlobalAIDbContext dbContext, IMapper mapper, ILogger<PermissionServices> logger, DatabaseOptions databaseOptions, IHttpContextAccessor httpContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _connectionString = databaseOptions.ConnectionString;
            _httpContext = httpContext;
            _userRepository = new UserRepository(dbContext, logger);
            _roleRepository = new RoleRepository(dbContext, logger);
        }

        /// <summary>
        /// Lấy list permission theo userid hiện tại
        /// </summary>
        /// <returns></returns>
        public List<string> FindPermissionsByCurrentUser()
        {
            var userId = CommonUtils.GetCurrentUserId(_httpContext);

            var data = _roleRepository.FindListPermissionByUserId(userId);
            return data;
        }

        /// <summary>
        /// Lấy toàn bộ permissions
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllPermissions()
        {
            return PermissionConfig.Configs.Keys.ToList();
        }
    }
}
