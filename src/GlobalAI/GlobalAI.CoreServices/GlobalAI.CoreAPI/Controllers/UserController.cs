using GlobalAI.CoreDomain.Interfaces;
using GlobalAI.CoreEntities.Dto.User;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.CoreAPI.Controllers
{
    [Authorize]
    [Route("api/core/user")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserServices _userServices;

        public UserController(ILogger<UserController> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        /// <summary>
        /// Đăng ký người dùng
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// 
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public APIResponse Add([FromBody] AddUserDto input)
        {
            try
            {
                _userServices.CreateUser(input);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Cập nhật list role
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("role")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public APIResponse UpdateRole([FromBody] UpdateUserRoleDto dto)
        {
            try
            {
                _userServices.UpdateListRole(dto);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Lấy list role theo user id truyền vào
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}/roles")]
        [ProducesResponseType(typeof(ViewUserRoleDto), (int)HttpStatusCode.OK)]
        public APIResponse GetRoleByUserId(int userId)
        {
            try
            {
                var data = _userServices.FindUserRoleByUserId(userId);
                return new APIResponse(Utils.StatusCode.Success, data, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Lấy list user phân trang
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(ViewUserDto), (int)HttpStatusCode.OK)]
        public APIResponse FindUser([FromQuery] FindUserDto dto)
        {
            try
            {
                var data = _userServices.FindUserPaging(dto);
                return new APIResponse(Utils.StatusCode.Success, data, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

    }
}
