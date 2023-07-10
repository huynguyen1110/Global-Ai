using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.Dto.GioHang;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product/giohang")]
    [ApiController]
    public class GioHangController : BaseController
    {
        private readonly IGioHangServices _gioHangServices;

        public GioHangController(IGioHangServices gioHangServices)
        {
            _gioHangServices = gioHangServices;
        }
        /// <summary>
        /// Lấy mới giỏ hàng
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        //[ProducesResponseType(typeof(APIResponse<List<int>>), (int)HttpStatusCode.OK)]
        public APIResponse GetGioHang()
        {
            try
            {
                var result = _gioHangServices.GetGiohang();
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Tạo mới giỏ hàng
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIResponse<List<AddGioHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse CreateGioHang([FromBody] AddGioHangChiTietDto input)
        {
            try
            {
                _gioHangServices.CreateGiohang(input);
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
        /// <param name="id">Mã GSaler </param>
        /// <param name="maSanPham">Mã sản phẩm</param>
        /// <param name="newGioHang"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(APIResponse<List<EditGioHangDto>>), (int)HttpStatusCode.OK)]
        public APIResponse EditGioHang([FromRoute]int id,[FromBody] EditGioHangChiTietDto newGioHang)
        {
            try
            {
                var gioHang = _gioHangServices.EditGiohang(id, newGioHang);
                if (gioHang == null)
                {
                    return new APIResponse(Utils.StatusCode.Success, null, 404, "Not Found");
                }    
                return new APIResponse(Utils.StatusCode.Success, gioHang, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Xóa giỏ hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIResponse<int>), (int)HttpStatusCode.OK)]
        public APIResponse DeleteGioHang([FromRoute] int id)
        {
            try
            {
                var gioHang = _gioHangServices.DeleteGiohang(id);
                if (gioHang == null)
                {
                    return new APIResponse(Utils.StatusCode.Success, null, 404, "Not Found");
                }
                return new APIResponse(Utils.StatusCode.Success, gioHang, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Lấy ra sản phẩm theo giỏ hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet("sanpham-giohang")]
        [ProducesResponseType(typeof(APIResponse<List<GetSanPhamChiTietDto>>), (int)HttpStatusCode.OK)]
        public APIResponse GetSanPhamGioHang()
        {
            try
            {
                var result = _gioHangServices.getSanPhamTheoNguoiMua();
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Lấy ra sản phẩm theo giỏ hàng 
        /// </summary>
        /// <returns></returns>
        [HttpGet("giohangByIdSanPham/{id}")]
        [ProducesResponseType(typeof(APIResponse<List<GetSanPhamChiTietDto>>), (int)HttpStatusCode.OK)]
        public APIResponse GetGioHangByIdSanPham([FromRoute] int id)
        {
            try
            {
                var result = _gioHangServices.GetGioHangTheoIdSanPham(id);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
