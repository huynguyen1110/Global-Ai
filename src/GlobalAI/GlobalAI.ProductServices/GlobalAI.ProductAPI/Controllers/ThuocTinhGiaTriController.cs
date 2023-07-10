using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.BaiTin;
using GlobalAI.Utils.Controllers;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GlobalAI.ProductEntities.Dto.DanhMucBaiTin;
using GlobalAI.ProductDomain.Implements;
using GlobalAI.ProductEntities.Dto.DanhMucThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri;

namespace GlobalAI.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product/thuoc-tinh-gia-tri")]
    [ApiController]
    public class ThuocTinhGiaTriController : BaseController
    {
        public readonly IThuocTinhServices _thuocTinhServices;

        public ThuocTinhGiaTriController(IThuocTinhServices thuocTinhServices)
        {
            _thuocTinhServices = thuocTinhServices;
        }

        #region giá trị
        /// <summary>
        /// Thêm giá trị
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("")]
        public APIResponse AddGiaTri([FromBody] AddThuocTinhGiaTriDto dto)
        {
            try
            {
                var result = _thuocTinhServices.AddGiaTri(dto);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Cập nhật giá trị
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("")]
        public APIResponse UpdateGiaTri([FromBody] UpdateThuocTinhGiaTriDto dto)
        {
            try
            {
                _thuocTinhServices.UpdateGiaTri(dto);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Xóa mềm giá trị
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public APIResponse DeleteGiaTri(int id)
        {
            try
            {
                _thuocTinhServices.DeleteGiaTri(id);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Lấy list giá trị theo thuộc tính
        /// </summary>
        /// <param name="idThuocTinh"></param>
        /// <returns></returns>
        [HttpGet("thuoc-tinh/{idThuocTinh}")]
        [ProducesResponseType(typeof(APIResponse<List<ViewThuocTinhGiaTriDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindGiaTriByThuocTinh(int idThuocTinh)
        {
            try
            {
                var result = _thuocTinhServices.FindListGiaTriByThuocTinh(idThuocTinh);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Lấy giá trị theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIResponse<ViewThuocTinhGiaTriDto>), (int)HttpStatusCode.OK)]
        public APIResponse GetGiaTriById(int id)
        {
            try
            {
                var result = _thuocTinhServices.FindGiaTriById(id);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        #endregion
    }
}
