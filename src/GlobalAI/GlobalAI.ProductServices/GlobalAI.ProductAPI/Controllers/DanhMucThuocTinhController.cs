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

namespace GlobalAI.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product/danh-muc-thuoc-tinh")]
    [ApiController]
    public class DanhMucThuocTinhController : BaseController
    {
        public readonly IDanhMucThuocTinhServices _danhMucThuocTinhServices;

        public DanhMucThuocTinhController(IDanhMucThuocTinhServices danhMucThuocTinhServices)
        {
            _danhMucThuocTinhServices = danhMucThuocTinhServices;
        }

        /// <summary>
        /// Thêm danh mục thuộc tính
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("")]
        public APIResponse Add([FromBody] AddDanhMucThuocTinhDto dto)
        {
            try
            {
                var result = _danhMucThuocTinhServices.Add(dto);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Cập nhật danh mục thuộc tính
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("")]
        public APIResponse Update([FromBody] UpdateDanhMucThuocTinhDto dto)
        {
            try
            {
                _danhMucThuocTinhServices.Update(dto);
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
        public APIResponse Delete(int id)
        {
            try
            {
                _danhMucThuocTinhServices.Delete(id);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Tìm kiếm danh mục thuộc tính phân trang
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(APIResponse<List<ViewDanhMucThuocTinhDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FindDanhMucThuocTinhDto dto)
        {
            try
            {
                var result = _danhMucThuocTinhServices.FindDanhMucThuocTinh(dto);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Lấy danh mục thuộc tính theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIResponse<ViewSingleDanhMucThuocTinhDto>), (int)HttpStatusCode.OK)]
        public APIResponse GetById(int id)
        {
            try
            {
                var result = _danhMucThuocTinhServices.FindById(id);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
