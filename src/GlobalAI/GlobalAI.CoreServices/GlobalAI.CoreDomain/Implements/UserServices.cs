using GlobalAI.CoreDomain.Interfaces;
using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.CoreEntities.Dto.User;
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
    public class UserServices : IUserServices
    {
        private readonly GlobalAIDbContext _dbContext;
        //private readonly IMapper _mapper;
        private readonly ILogger<UserServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;

        public UserServices(GlobalAIDbContext dbContext, ILogger<UserServices> logger, DatabaseOptions databaseOptions, IHttpContextAccessor httpContext)
        {
            _dbContext = dbContext;
            _logger = logger;
            _connectionString = databaseOptions.ConnectionString;
            _httpContext = httpContext;
            _userRepository = new UserRepository(dbContext, logger);
            _roleRepository = new RoleRepository(dbContext, logger);
        }

        /// <summary>
        /// Tạo mới user
        /// </summary>
        /// <param name="dto"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void CreateUser(AddUserDto dto)
        {
            _logger.LogInformation($"{nameof(CreateUser)}: dto = {JsonSerializer.Serialize(dto)}");

            // Check username
            var user = _userRepository.FindByUsername(dto.Username);
            if (user != null)
            {
                _userRepository.ThrowException(Utils.ErrorCode.UserUsernameDuplicated);
            }

            // Check email
            user = _userRepository.FindByEmail(dto.Email);
            if (user != null)
            {
                _userRepository.ThrowException(Utils.ErrorCode.UserEmailDuplicated);
            }

            // Check phone
            user = _userRepository.FindByPhone(dto.Phone);
            if (user != null)
            {
                _userRepository.ThrowException(Utils.ErrorCode.UserPhoneDuplicated);
            }

            // Tạo user
            _userRepository.AddUser(new User
            {
                Password = dto.Password,
                Username = dto.Username,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CreatedBy = dto.Username,
                Email = dto.Email,
                Phone = dto.Phone,
                UserType = dto.UserType
            });

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Check logiin user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User ValidateUser(string username, string password)
        {
            _logger.LogInformation($"{nameof(ValidateUser)} -> {nameof(User)}: username={username}, password={password}");

            return _userRepository.ValidateUser(username, password);
        }

        /// <summary>
        /// Lấy user theo username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User FindByUsername(string username)
        {
            _logger.LogInformation($"{nameof(FindByUsername)}: username={username}");

            return _userRepository.FindByUsername(username);
        }

        /// <summary>
        /// Cập nhật role cho user
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateListRole(UpdateUserRoleDto dto)
        {
            string username = CommonUtils.GetCurrentUsername(_httpContext);
            _logger.LogInformation($"{nameof(UpdateListRole)}: dto={JsonSerializer.Serialize(dto)}, username={username}");

            var dbUserRole = _roleRepository.FindListRoleByUserId(dto.UserId);
            foreach (var item in dbUserRole)
            {
                bool exist = dto.ListRoleId.Contains(item.RoleId);
                if (!exist)
                {
                    _roleRepository.DeleteUserRoleById(item.UserRoleId, username);
                }
            }

            foreach (var item in dto.ListRoleId)
            {
                bool exist = dbUserRole.Any(x => x.RoleId == item);
                if (!exist)
                {
                    _roleRepository.AddUserRole(new CoreUserRole
                    {
                        RoleId = item,
                        UserId = dto.UserId
                    }, username);
                }
            }

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Lấy list role theo user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ViewUserRoleDto> FindUserRoleByUserId(int userId)
        {
            _logger.LogInformation($"{nameof(FindUserRoleByUserId)}: userId={userId}");

            var data = _roleRepository.FindListRoleByUserId(userId);
            return data;
        }

        /// <summary>
        /// Lấy list user phân trang
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PagingResult<ViewUserDto> FindUserPaging(FindUserDto dto)
        {
            return _userRepository.FindUser(dto);
        }
    }
}
