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
    [Route("api/product/thuoc-tinh")]
    [ApiController]
    public class ThuocTinhController : BaseController
    {
        public readonly IThuocTinhServices _thuocTinhServices;

        public ThuocTinhController(IThuocTinhServices thuocTinhServices)
        {
            _thuocTinhServices = thuocTinhServices;
        }

        #region thuộc tính
        /// <summary>
        /// Thêm thuộc tính
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("")]
        public APIResponse AddThuocTinh([FromBody] AddThuocTinhDto dto)
        {
            try
            {
                var result = _thuocTinhServices.AddThuocTinh(dto);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Cập nhật thuộc tính
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("")]
        public APIResponse UpdateThuocTinh([FromBody] UpdateThuocTinhDto dto)
        {
            try
            {
                _thuocTinhServices.UpdateThuocTinh(dto);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Xóa mềm danh mục thuộc tính
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public APIResponse DeleteThuocTinh(int id)
        {
            try
            {
                _thuocTinhServices.DeleteThuocTinh(id);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Lấy list thuộc tính theo danh mục
        /// </summary>
        /// <param name="idDanhMucThuocTinh"></param>
        /// <returns></returns>
        [HttpGet("danh-muc/{idDanhMucThuocTinh}")]
        [ProducesResponseType(typeof(APIResponse<List<ViewThuocTinhDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAllThuocTinh(int idDanhMucThuocTinh)
        {
            try
            {
                var result = _thuocTinhServices.FindListThuocTinhByDanhMuc(idDanhMucThuocTinh);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Lấy thuộc tính theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIResponse<ViewThuocTinhDto>), (int)HttpStatusCode.OK)]
        public APIResponse GetThuocTinhById(int id)
        {
            try
            {
                var result = _thuocTinhServices.FindThuocTinhById(id);
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
