using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.BaiTin;
using GlobalAI.Utils.Controllers;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GlobalAI.ProductEntities.Dto.DanhMucBaiTin;
using GlobalAI.ProductDomain.Implements;

namespace GlobalAI.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product/danh-muc-bai-tin")]
    [ApiController]
    public class DanhMucBaiTinController : BaseController
    {
        public readonly IDanhMucBaiTinServices _danhMucBaiTinServices;

        public DanhMucBaiTinController(IDanhMucBaiTinServices danhMucBaiTinServices)
        {
            _danhMucBaiTinServices = danhMucBaiTinServices;
        }

        /// <summary>
        /// cập nhật danh mục bài tin
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        
        [Authorize]
        [HttpPut("")]
        public APIResponse Update([FromBody] UpdateDanhMucBaiTinDto input)
        {
            try
            {
                _danhMucBaiTinServices.Update(input);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// them 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("")]
        public APIResponse Add([FromBody] CreateDanhMucBaiTin input)
        {
            try
            {
                var result = _danhMucBaiTinServices.Add(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// xoa
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("")]
        public void Delete(int id)
        {
            _danhMucBaiTinServices.Delete(id);
        }

        /// <summary>
        /// danh sach dang list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// 
        [AllowAnonymous]
        [HttpGet("find-all")]
        [ProducesResponseType(typeof(APIResponse<List<DanhMucBaiTinDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FilterDanhMucBaiTinDto input)
        {
            try
            {
                var result = _danhMucBaiTinServices.FindAll(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// danh sach dang cay
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("find-all-trees")]
        [ProducesResponseType(typeof(APIResponse<List<TreesDanhMucBaiTinDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAllTress([FromQuery] FilterDanhMucBaiTinDto input)
        {
            try
            {
                var result = _danhMucBaiTinServices.FindAllTrees(input);
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
        /// 
        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIResponse), (int)HttpStatusCode.OK)]
        public APIResponse GetById(int id)
        {
            try
            {
                var result = _danhMucBaiTinServices.GetById(id);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
