using GlobalAI.ProductDomain.Implements;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.DonHang;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.Voucher;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product/donhang")]
    [ApiController]
    public class DonHangController : BaseController
    {
        private readonly IDonHangServices _donHangServices;

        public DonHangController(IDonHangServices donHangServices)
        {
            _donHangServices = donHangServices;
        }

        /// <summary>
        /// danh sach don hang theo nguoi dung
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("purchase")]
        [ProducesResponseType(typeof(APIResponse<List<DonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FilterDonHangDto input)
        {
            try
            {
                var result = _donHangServices.FindAll(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Lấy ra tất cả đơn hàng có phân trang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIResponse<List<FindDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FindDonHangDto input)
        {
            try
            {
                var result = _donHangServices.FindAll(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);  
            }
        }
        /// <summary>
        /// Tạo mới một đơn hàng
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIResponse<List<AddDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse CreateDonHang([FromQuery] AddDonHangDto input)
        {
            try
            {
                _donHangServices.CreateDonhang(input);
                return new APIResponse(Utils.StatusCode.Success, input, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Sửa đơn hàng theo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newDonHang"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(APIResponse<List<AddDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse EditDonHang([FromRoute]int id, AddDonHangDto newDonHang )
        {
            try
            {
                var donHang = _donHangServices.EditDonhang(id, newDonHang);
                if ( donHang != null ) 
                {
                    return new APIResponse(Utils.StatusCode.Success, donHang, 200, "Ok");
                }
                else
                {
                    return new APIResponse(Utils.StatusCode.Error, donHang, 200, "Not Found");
                }
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Xóa đơn hàng
        /// </summary>
        /// <param name="maDonHang"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIResponse<int>), (int)HttpStatusCode.OK)]
        public APIResponse DeleteDonHangFull(int id)
        {
            try
            {
                _donHangServices.DeleteDonHangById(id);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Lấy đơn hàng và chi tiết đơn hàng
        /// </summary>
        /// <param name="maDonHang"></param>
        /// <returns></returns>
        [HttpGet("full")]
        [ProducesResponseType(typeof(APIResponse<int>), (int)HttpStatusCode.OK)]
        public APIResponse GetDonHangFull( [FromQuery] int maDonHang)
        {
            try
            {
                var input = _donHangServices.GetDonHangFull(maDonHang);
                return new APIResponse(Utils.StatusCode.Success, input, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIResponse<int>), (int)HttpStatusCode.OK)]
        public APIResponse GetDonHangById(int id)
        {
            try
            {
                var input = _donHangServices.GetDonhangById(id);
                return new APIResponse(Utils.StatusCode.Success, input, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Lấy đơn hàng và chi tiết đơn hàng
        /// </summary>
        /// <param name="maDonHang"></param>
        /// <returns></returns>
        [HttpGet("full-gstore/{id}")]
        [ProducesResponseType(typeof(APIResponse<int>), (int)HttpStatusCode.OK)]
        public APIResponse GetDonHangByIdGstore(int id)
        {
            try
            {
                var input = _donHangServices.GetDonHangByIdGstore(id);
                return new APIResponse(Utils.StatusCode.Success, input, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Tạo đơn hàng và chi tiết đơn hàng
        /// </summary>
        /// <param name="addDonHangFullDto"></param>
        /// <returns></returns>
        [HttpPost("full")]
        public APIResponse CreateDonHangFull([FromBody] AddDonHangFullDto addDonHangFullDto)
        {
            try
            {
                _donHangServices.CreateDonHangFull(addDonHangFullDto);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        [HttpPut("update-status")]
        public APIResponse UpdateStatusDonHang([FromBody] UpdateStatusDonHangDto updateDonHangDto)
        {
            try
            {
                var result = _donHangServices.UpdateStatusDonHang(updateDonHangDto);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

    }
}
