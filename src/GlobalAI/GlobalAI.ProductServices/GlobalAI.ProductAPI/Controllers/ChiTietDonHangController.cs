using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductDomain.Implements;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product/ct-donhang")]
    [ApiController]
    public class ChiTietDonHangController : BaseController
    {
        private readonly IChiTietDonHangServices _chiTietDonHangServices;

        public ChiTietDonHangController(IChiTietDonHangServices chiTietDonHang)
        {
            _chiTietDonHangServices = chiTietDonHang;
        }


        [HttpGet]
        [ProducesResponseType(typeof(APIResponse<List<GetChiTietDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse GetChiTietDonHang()
        {
            try
            {
                var result = _chiTietDonHangServices.getChiTietDonHang();
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIResponse<List<GetChiTietDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse GetChiTietDonHangById(int id)
        {
            try
            {
                var result = _chiTietDonHangServices.getChiTietDonhangById(id);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Tạo chi tiết đơn hàng
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIResponse<List<AddChiTietDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse CreateChiTietDonHang([FromBody] AddChiTietDonHangDto input)
        {
            try
            {
                _chiTietDonHangServices.CreateChiTietDonhang(input);
                return new APIResponse(Utils.StatusCode.Success, input, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Sửa đơn hàng
        /// </summary>
        /// <param name="maDonHang"></param>
        /// <param name="maSanPham"></param>
        /// <param name="newDonHang"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(APIResponse<List<AddChiTietDonHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse EditChiTietDonHang([FromRoute]int id ,EditChiTietDonHangDto newDonHang)
        {
            try
            {
                var donHang = _chiTietDonHangServices.EditChiTietDonhang(id, newDonHang);
                if (donHang == null)
                {
                    return new APIResponse(Utils.StatusCode.Success, null, 404, "Not Found");
                }    
                return new APIResponse(Utils.StatusCode.Success, donHang, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Xóa chi tiết đơn hàng
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeleteChiTietDonHangById(int id)
        {
            _chiTietDonHangServices.DeleteChiTietDonhangById(id);
        }
    }
}
