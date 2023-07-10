using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DemoProduct;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.DemoAPI.Controllers
{
    [Authorize]
    [Route("api/demo/product")]
    [ApiController]
    public class DemoProductController : BaseController
    {
        private readonly IDemoProductServices _demoProductServices;

        public DemoProductController(ILogger<DemoProductController> logger, IDemoProductServices demoProductServices)
        {
            _logger = logger;
            _demoProductServices = demoProductServices;
        }

        /// <summary>
        /// Thêm demo product
        /// </summary>
        [HttpPost("add")]
        [ProducesResponseType(typeof(APIResponse<AddProductDto>), (int)HttpStatusCode.OK)]
        public APIResponse Add([FromBody] AddDemoProductDto input)
        {
            try
            {
                var result = _demoProductServices.Add(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// lấy danh sách demo product
        /// </summary>
        [HttpGet("find-all")]
        [ProducesResponseType(typeof(APIResponse<List<AddProductDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FindDemoProductDto input)
        {
            try
            {
                var result = _demoProductServices.FindAll(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
