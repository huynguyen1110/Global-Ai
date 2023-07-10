using GlobalAI.CoreDomain.Interfaces;
using GlobalAI.CoreEntities.Dto.Role;
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
    [Route("api/core/role")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleServices _roleServices;

        public RoleController(ILogger<RoleController> logger, IRoleServices roleServices)
        {
            _logger = logger;
            _roleServices = roleServices;
        }

        /// <summary>
        /// Tạo mới role
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public APIResponse Add([FromBody] AddRoleDto input)
        {
            try
            {
                _roleServices.AddRole(input);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Update role
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public APIResponse UpdateRole([FromBody] UpdateRoleDto dto)
        {
            try
            {
                _roleServices.UpdateRole(dto);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Lấy list role phân trang
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(ViewRoleDto), (int)HttpStatusCode.OK)]
        public APIResponse FindUser([FromQuery] FindRolePagingDto dto)
        {
            try
            {
                var data = _roleServices.FindRolePaging(dto);
                return new APIResponse(Utils.StatusCode.Success, data, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

    }
}
