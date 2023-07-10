using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductDomain.Implements;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using GlobalAI.ProductEntities.Dto.DanhMucBaiTin;
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
    [Route("api/product/sanpham")]
    [ApiController]
    public class SanPhamController : BaseController
    {
        private readonly ISanPhamServices _sanPhamServices;
        private readonly IDanhMucServices _danhMucServices;
        public SanPhamController(ISanPhamServices sanPhamServices, IDanhMucServices danhMucServices ) 
        {
            _sanPhamServices = sanPhamServices;
            _danhMucServices = danhMucServices;
        }

        /// <summary>
        /// danh sach chi tiet san pham cho home page
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("home-page")]
        [ProducesResponseType(typeof(APIResponse<List<SanPhamChiTietDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAllHomePage([FromQuery] FilterSanPhamChiTietDto input)
        {
            try
            {
                var result = _sanPhamServices.FindAllHomePage(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// them danh muc cua san pham ( luc them san pham dang dung IdDanhMuc )
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("danh-muc")]
        public APIResponse Add([FromBody] CreateDanhMucDto input)
        {
            try
            {
                var result = _danhMucServices.Add(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        [HttpPut("danh-muc-home-page")]
        public APIResponse DanhMucHomePage([FromBody] DanhMucHomePageDto input)
        {
            try
            {
                _danhMucServices.UpdateDanhMucHomePage(input);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Get SanPham Chi tiet
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("san-pham-ct/{id}")]
        public APIResponse GetSanPhamChiTiet(int id)
        {
            try
            {
                var result = _sanPhamServices.GetSanPhamChiTiet(id);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// get danh sach danh muc
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("danh-muc")]
        [ProducesResponseType(typeof(APIResponse<List<DanhMucDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll([FromQuery] FilterDanhMucDto input)
        {
            try
            {
                var result = _danhMucServices.FindAll(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// xoa danh muc
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("danh-muc")]
        public void DeleteDanhMuc(int id)
        {
            _danhMucServices.Delete(id);
        }


        [HttpGet("sanPham-full")]
        [ProducesResponseType(typeof(APIResponse<GetSanPhamDto>), (int)HttpStatusCode.OK)]
        public APIResponse Add()
        {
            try
            {
                var result = _sanPhamServices.GetFullSanPham();
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Thêm sản phẩm
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIResponse<AddSanPhamDto>), (int)HttpStatusCode.OK)]
        public APIResponse Add([FromBody] AddSanPhamDto input)
        {
            try
            {
                var result = _sanPhamServices.AddSanPham(input);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Sửa sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(APIResponse<AddSanPhamDto>), (int)HttpStatusCode.OK)]
        public APIResponse Put(int id, [FromBody] AddSanPhamDto input)
        {
            try
            {
                var result = _sanPhamServices.EditSanPham(id, input);
                if (result == null)
                {
                    return new APIResponse(Utils.StatusCode.Error, result, 404, "NotFound");
                }
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIResponse<AddSanPhamDto>), (int)HttpStatusCode.OK)]
        public APIResponse Delete(int id)
        {
            try
            {
                _sanPhamServices.DeleteSanPham(id);
                return new APIResponse(Utils.StatusCode.Success, null, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// lấy danh sách sản phẩm có phân trang
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(APIResponse<List<FindSanPhamDto>>), (int)HttpStatusCode.OK)]
        public APIResponse FindAll1([FromQuery] FindSanPhamDto input)
        {
            try
            {
                var result = _sanPhamServices.FindAll(input);

                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// lấy sản phẩm theo id
        /// </summary>s
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIResponse<List<GetSanPhamDto>>), (int)HttpStatusCode.OK)]
        public APIResponse GetById(int id)
        {
            try
            {
                var result = _sanPhamServices.GetById(id);
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// lấy sản phẩm theo danh mục
        /// </summary>
        [HttpGet("danh-muc/{id}")]
        [ProducesResponseType(typeof(APIResponse<List<SanPham>>), (int)HttpStatusCode.OK)]
        public APIResponse GetByCategory(string id, [FromQuery] FindSanPhamByCatetoryDto input)
        {
            try
            {
                var result = _sanPhamServices.GetByCategory(id, input);

                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Duyệt sản phẩm theo id
        /// </summary>
        [HttpPut("duyet-sp/{id}")]
        public APIResponse AppproveSanPham(int id)
        {
            try
            {
                var result = _sanPhamServices.GetDanhMucById(id);

                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        /// <summary>
        /// Get Danh muc theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("danhmuc-id/{id}")]
        public APIResponse GetDanhMucSanPhamTheoId( int id)
        {
            try
            {
                 var result = _sanPhamServices.GetDanhMucById(id);

                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
        [HttpPut("edit-danhmuc/{id}")]
        [ProducesResponseType(typeof(APIResponse<AddSanPhamDto>), (int)HttpStatusCode.OK)]
        public APIResponse PutDanhMuc(int id, [FromBody] CreateDanhMucDto input)
        {
            try
            {
                var result = _sanPhamServices.EditDanhMuc(id, input);
                if (result == null)
                {
                    return new APIResponse(Utils.StatusCode.Error, result, 404, "NotFound");
                }
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Lấy sản phẩm theo id Gstore
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-sanpham-gstore")]
        [ProducesResponseType(typeof(APIResponse<List<GetSanPhamDto>>), (int)HttpStatusCode.OK)]
        public APIResponse GetSanPhamByIdGstore([FromQuery] GetSanPhamIdGstoreDto input)
        {
            try
            {
                var result = _sanPhamServices.GetSanPhamByIdGstore(input);
                
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }

        /// <summary>
        /// Lấy sp cho gstore/admin theo id sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("admin/{id}")]
        [ProducesResponseType(typeof(APIResponse<ViewAdminSanPhamDto>), (int)HttpStatusCode.OK)]
        public APIResponse GetSanPhamByIdGstore(int id)
        {
            try
            {
                var result = _sanPhamServices.GetAdminSanPhamById(id);

                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
