
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;

using AutoMapper;

using GlobalAI.DemoEntities.Dto.Product;

using GlobalAI.DemoRepositories;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalAI.Utils;
using GlobalAI.Utils.ConstantVariables.Product;
using GlobalAI.Utils.ConstantVariables.Core;
using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using GlobalAI.ProductEntities.Dto.ChiTietTraGia;
using GlobalAI.ProductEntities.Dto.TraGia;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;
using GlobalAI.ProductEntities.Dto.ThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri;
using AutoMapper.Internal;

namespace GlobalAI.ProductDomain.Implements
{
    public class SanPhamServices : ISanPhamServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<SanPhamServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly SanPhamRepository _sanPhamRepository;
        private readonly SanPhamChiTietRepository _sanPhamChiTietRepository;
        private readonly ThuocTinhRepository _thuocTinhRepository;
        private readonly IMapper _mapper;
        public SanPhamServices(GlobalAIDbContext dbContext, IHttpContextAccessor httpContext, DatabaseOptions databaseOptions, ILogger<SanPhamServices> logger, IMapper mapper)
        {
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
            _httpContext = httpContext;
            _thuocTinhRepository = new ThuocTinhRepository(dbContext, logger, mapper);
            _sanPhamRepository = new SanPhamRepository(dbContext, logger, mapper);
            _sanPhamChiTietRepository = new SanPhamChiTietRepository(dbContext, logger, mapper);
        }

        /// <summary>
        /// danh sach san pham cho home page
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<SanPhamChiTietDto> FindAllHomePage(FilterSanPhamChiTietDto input)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            string usertype = CommonUtils.GetCurrentRole(_httpContext);

            var result = new PagingResult<SanPhamChiTietDto>();
            var query = _sanPhamChiTietRepository.FindAllProduct(input);

            result.Items = _mapper.Map<List<SanPhamChiTietDto>>(query.Items);
            result.TotalItems = query.TotalItems;
            foreach (var item in result.Items)
            {;
  
                item.IdSanPham = item.Id;
                item.MaSanPham = item.MaSanPham;
                item.TenSanPham = item.TenSanPham;
                item.MoTaSanPham = item.MoTa;
                item.IdDanhMuc = item.IdDanhMuc;
                item.ThumbnailSanPham = item.Thumbnail;
            }
            return result;
        }

        public List<GetSanPhamDto> GetFullSanPham()
        {
            return _sanPhamRepository.GetFullSanPham();
        }
      
        /// <summary>
        /// Thêm sản phẩm
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Sản phẩm vừa thêm vào</returns>
        public SanPham AddSanPham(AddSanPhamDto dto)
        {
            string username = CommonUtils.GetCurrentUsername(_httpContext);
            int userId = CommonUtils.GetCurrentUserId(_httpContext);

            using (var tran = _dbContext.Database.BeginTransaction())
            {
                // Them sp
                var newSanPham = _mapper.Map<SanPham>(dto);

                newSanPham.IdGStore = userId;
                newSanPham.CreatedBy = username;

                _sanPhamRepository.Add(newSanPham);
                _dbContext.SaveChanges();

                if (dto.ListChiTiet != null)
                {
                    // Them sp chi tiet
                    var dict = new Dictionary<int, SanPhamChiTiet>();
                    for (int i = 0; i < dto.ListChiTiet.Count; i++)
                    {
                        var spChiTiet = dto.ListChiTiet[i];
                        spChiTiet.IdSanPham = newSanPham.Id;

                        var dbSpChiTiet = _sanPhamChiTietRepository.Add(_mapper.Map<SanPhamChiTiet>(spChiTiet), username);
                        dict.Add(i, dbSpChiTiet);
                    }
                    _dbContext.SaveChanges();

                    // Them thuoc tinh cho sp chi tiet
                    for (int i = 0; i < dto.ListChiTiet.Count; i++)
                    {
                        var spChiTiet = dto.ListChiTiet[i];

                        _sanPhamChiTietRepository.AddSanPhamChiTietThuocTinh(dict[i].Id, spChiTiet.ListIdThuocTinhGiaTri, username);
                    }
                }

                _dbContext.SaveChanges();
                tran.Commit();

                return newSanPham;
            }
        }
        /// <summary>
        /// Lấy ra chi tiết sản phẩm có thuocj tính
        /// </summary>
        /// <param name="idSanPham"></param>
        /// <returns></returns>
        public GetSanPhamChiTietDto GetSanPhamChiTiet(int idSanPham)
        {
            var sanPham = _sanPhamRepository.FindByIdSanPham(idSanPham);
            var GetSanPhamChiTiet = new GetSanPhamChiTietDto
            {
                IdSanPham = sanPham.Id,
                MoTa = sanPham.MoTa,
                GiaBan = sanPham.GiaBan,
                GiaChietKhau = sanPham.GiaChietKhau,
                GiaToiThieu = sanPham.GiaToiThieu,
                IdDanhMucThuocTinh = sanPham.IdDanhMucThuocTinh,
                Thumbnail = sanPham.Thumbnail,
            };
            var dict = new Dictionary<String, List<ViewThuocTinhGiaTriDto>>();
            var sanPhamCt = _dbContext.SanPhamChiTiets.Where(spct => spct.IdSanPham == sanPham.Id).ToList();
            //Check xem có id san phảm chi tiết chưa 
            var listSanPhamCt = new List<int>();
            for (int i = 0; i < sanPhamCt.Count; i++)
            {   
                var thuocTinhGtSanPham = _dbContext.SanPhamChiTietThuocTinhs.Where(spctt => spctt.IdSanPhamChiTiet == sanPhamCt[i].Id).Select(s => s.IdThuocTinhGiaTri).ToList();
                listSanPhamCt = listSanPhamCt.Concat(thuocTinhGtSanPham).ToList();
            }
            
            var listDanhMucThuocTinhs = _thuocTinhRepository.FindByIdDanhMucThuocTinh(sanPham.IdDanhMucThuocTinh);
            
            for (int i = 0; i < listDanhMucThuocTinhs.Count; i++)
            {
                
                var giatritt = _thuocTinhRepository.FindGiaTriByIdThuocTinh(listDanhMucThuocTinhs[i].Id);
                //chỉ lấy ra những thuộc tính giá trị có spct 
                var giatriTT = giatritt.Where(s => listSanPhamCt.Contains(s.Id));
                dict.Add(_mapper.Map<GetThuocTinhDto>(listDanhMucThuocTinhs[i]).TenThuocTinh, _mapper.Map<List<ViewThuocTinhGiaTriDto>>(giatriTT));
            }
            GetSanPhamChiTiet.ThuocTinhs = dict;
            return GetSanPhamChiTiet;
        }
        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Trả về sản phẩm vừa xóa(Trường deleted = true)</returns>
        public void DeleteSanPham(int idSanPham)
        {
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            var query = _sanPhamRepository.Entity.FirstOrDefault(x => x.Id == idSanPham);
            query.Deleted = DeletedBool.YES;
            query.DeletedBy = username;
            query.DeletedDate = DateTime.Now;
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// Sửa sản phẩm
        /// </summary>
        /// <param name="id">Mã sản phầm cần sửa</param>
        /// <param name="newSanPham"></param>
        /// <returns>Trả về sản phẩm đã được sửa</returns>
        public SanPham EditSanPham(int id, AddSanPhamDto newSanPham)
        {
            var findSanPham = _sanPhamRepository.FindByIdSanPham(id);
            if (findSanPham != null)
            {
                _sanPhamRepository.EditSanPham(newSanPham, findSanPham);
            }
            _dbContext.SaveChanges();
            return findSanPham;
        }

        public DanhMuc EditDanhMuc(int id, CreateDanhMucDto newDanhMuc)
        {
            var findDanhMuc = _sanPhamRepository.FindByIdDanhMuc(id);
            if (findDanhMuc != null)
            {
                _sanPhamRepository.EditDanhMuc(newDanhMuc, findDanhMuc);
            }
            _dbContext.SaveChanges();
            return findDanhMuc;
        }
        /// <summary>
        /// Get list demo product phân trang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<GetSanPhamDto> FindAll(FindSanPhamDto input)
        {
            //_logger.LogInformation($"{nameof(FindAll)}: input = {JsonSerializer.Serialize(input)}");

            return _sanPhamRepository.FindAll(input);
        }

        /// <summary>
        /// Lấy sản phẩm theo id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public SanPham GetById(int idSanPham)
        {
            //_logger.LogInformation($"{nameof(FindAll)}: input = {JsonSerializer.Serialize(input)}");

            return _sanPhamRepository.GetById(idSanPham);
        }

        public DanhMuc GetDanhMucById(int idDanhMuc)
        {
            var result = _sanPhamRepository.FindByIdDanhMuc(idDanhMuc);
            return result;
        }

        /// <summary>
        /// Lấy sản phẩm theo danh mục
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PagingResult<GetSanPhamDto> GetByCategory(string idDanhMuc, FindSanPhamByCatetoryDto input)
        {
            //_logger.LogInformation($"{nameof(FindAll)}: input = {JsonSerializer.Serialize(id)}");

            return _sanPhamRepository.GetByCategory(idDanhMuc, input);
        }

        /// <summary>
        /// Duyệt sản phẩm theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void ApproveSanPham(int id)
        {
            var Result = _sanPhamRepository.FindByIdSanPham(id);
            if (Result != null)
            {
                Result.NgayDuyet = DateTime.Now;
                Result.Status = TrangThaiSanPham.DA_DUYET;
                _dbContext.SaveChanges();
            }
        }

        public PagingResult<GetSanPhamDto> GetSanPhamByIdGstore(GetSanPhamIdGstoreDto input)
        {
            string userRole = CommonUtils.GetCurrentRole(_httpContext);
            if (userRole == Roles.Admin)
            {
                return _sanPhamRepository.GetSanPhamByIdGstore(null, input);
            }
            if (userRole == Roles.GStore)
            {
                int userId = CommonUtils.GetCurrentUserId(_httpContext);
                return _sanPhamRepository.GetSanPhamByIdGstore(userId, input);
            }
            return null;
        }

        /// <summary>
        /// Get sp cho admin/gstore theo sp id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewAdminSanPhamDto GetAdminSanPhamById(int id)
        {
            _logger.LogInformation($"{nameof(GetAdminSanPhamById)}: id={id}");

            var sp = _sanPhamRepository.FindByIdSanPham(id);
            var result = _mapper.Map<ViewAdminSanPhamDto>(sp);

            var queryListSpChiTiet = _sanPhamChiTietRepository.GetListByIdSanPham(id);
            var listSpChiTiet = _mapper.Map<List<ViewSanPhamChiTietDto>>(queryListSpChiTiet);

            if (listSpChiTiet.Count > 0)
            {
                foreach (var spChiTiet in listSpChiTiet)
                {
                    spChiTiet.ListThuocTinh = _sanPhamChiTietRepository.GetListThuocTinhByIdSanPhamChiTiet(spChiTiet.Id);
                }
            }
            result.ListSanPhamChiTiet = listSpChiTiet;
            return result;
        }
    }
}
