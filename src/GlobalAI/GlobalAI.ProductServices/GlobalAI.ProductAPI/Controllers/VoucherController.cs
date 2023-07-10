using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.Voucher;
using GlobalAI.Utils.Controllers;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product/voucher")]
    [ApiController]
    public class VoucherController : BaseController
    {
        public readonly IVoucherServices _voucherServices;

        public VoucherController(IVoucherServices voucherServices)
        {
            _voucherServices = voucherServices;
        }
        /// <summary>
        /// them 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("")]
        public APIResponse Add([FromBody] CreateVoucherDto input)
        {
            try
            {
                var result = _voucherServices.Add(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        [HttpPut("update")]
        public APIResponse Update([FromBody] UpdateVoucherDto input)
        {
            try
            {
                _voucherServices.Update(input);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        [HttpDelete("")]
        public void Delete(int id)
        {
            _voucherServices.Delete(id);
        }

        /// <summary>
        /// danh sach 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("find-all")]
        [ProducesResponseType(typeof(APIResponse<List<VoucherDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FilterVoucherDto input)
        {
            try
            {
                var result = _voucherServices.FindAll(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// chi tiet 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIResponse), (int)HttpStatusCode.OK)]
        public APIResponse GetById(int id)
        {
            try
            {
                var result = _voucherServices.GetById(id);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
