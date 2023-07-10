using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductDomain.Implements;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using GlobalAI.ProductEntities.Dto.DanhMucBaiTin;
using GlobalAI.ProductEntities.Dto.DanhMucThuocTinh;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalAI.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/product/san-pham-chi-tiet")]
    [ApiController]
    public class SanPhamChiTietController : BaseController
    {
        private readonly ISanPhamChiTietServices _sanPhamChiTiet;
        public SanPhamChiTietController(ISanPhamChiTietServices sanPhamChiTiet) 
        {
            _sanPhamChiTiet = sanPhamChiTiet;
        }

        /// <summary>
        /// get sp chi tiết theo id sản phẩm và thuộc tính giá trị
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("ct-ttgt")]
        public APIResponse GetByIdSanPham([FromQuery] FindSanPhamChiTietDto dto)
        {
            try
            {
                if(dto.Gttt == null)
                {

                    var result = _sanPhamChiTiet.GetSanPhamChiTietByIdSanPham(dto.IdSanPham);
                    return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");

                }
                else
                {
                  

                    List<int> intList = dto.Gttt.Split(',').Select(int.Parse).ToList();
                    var result = _sanPhamChiTiet.GetSanPhamChiTietByIdSanPhamGttt(dto.IdSanPham, intList);
                    return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
                }
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Thêm sp chi tiết vào sp
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("")]
        public APIResponse Add([FromBody] AddListSanPhamChiTietDto dto)
        {
            try
            {
                _sanPhamChiTiet.AddSanPhamChiTiet(dto);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Cập nhật sp chi tiết
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("")]
        public APIResponse Update([FromBody] UpdateSanPhamChiTietDto dto)
        {
            try
            {
                _sanPhamChiTiet.UpdateSanPhamChiTiet(dto);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Xóa mềm sản phẩm chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public APIResponse Delete(int id)
        {
            try
            {
                _sanPhamChiTiet.DeleteSanPhamChiTiet(id);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

    }
}
