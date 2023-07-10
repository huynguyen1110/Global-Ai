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
    [Route("api/core/permission")]
    [ApiController]
    public class PermissionController : BaseController
    {
        private readonly IPermissionServices _permissionServices;

        public PermissionController(ILogger<PermissionController> logger, IPermissionServices permissionServices)
        {
            _logger = logger;
            _permissionServices = permissionServices;
        }

        /// <summary>
        /// Update role
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public APIResponse UpdateRole()
        {
            try
            {
                var data = _permissionServices.FindPermissionsByCurrentUser();
                return new APIResponse(Utils.StatusCode.Success, data, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Lấy toàn bộ permission trong hệ thống
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public APIResponse FindUser()
        {
            try
            {
                var data = _permissionServices.GetAllPermissions();
                return new APIResponse(Utils.StatusCode.Success, data, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

    }
}
