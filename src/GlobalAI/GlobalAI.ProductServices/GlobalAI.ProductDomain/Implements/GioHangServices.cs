using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DonHang;
using GlobalAI.ProductEntities.Dto.GioHang;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;
using GlobalAI.ProductEntities.Dto.ThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri;
using GlobalAI.ProductRepositories;
using GlobalAI.Utils;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Implements
{
    public class GioHangServices : IGioHangServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<SanPhamServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly GioHangRepository _repositoryGioHang;
        private readonly ThuocTinhRepository _thuocTinhRepository;
        private readonly SanPhamRepository _sanPhamRepository;
        private readonly SanPhamChiTietRepository _sanPhamChiTietRepository;
        private readonly ISanPhamServices _sanPhamServices;
        private readonly IMapper _mapper;
        public GioHangServices(GlobalAIDbContext dbContext, IHttpContextAccessor httpContext, DatabaseOptions databaseOptions, ILogger<SanPhamServices> logger, IMapper mapper, ISanPhamServices sanPhamServices) 
        {
            _repositoryGioHang = new GioHangRepository(dbContext, logger, mapper);
            _thuocTinhRepository = new ThuocTinhRepository(dbContext, logger, mapper);
            _sanPhamRepository = new SanPhamRepository(dbContext, logger, mapper);
            _sanPhamChiTietRepository = new SanPhamChiTietRepository(dbContext, logger, mapper);
            _sanPhamServices = sanPhamServices;
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;
            _mapper = mapper;
        }
        public GetFullGioHangDto GetGiohang()
        {
            var IdNguoiMua = CommonUtils.GetCurrentUserId(_httpContext);
            var UserName = CommonUtils.GetCurrentUsername(_httpContext);
            var gioHang = _repositoryGioHang.GetGioHang(IdNguoiMua);
            var getFullDonHangDto = new GetFullGioHangDto
            {
                GioHang = gioHang,
            };
            return getFullDonHangDto;
        }
        public GioHang CreateGiohang(AddGioHangChiTietDto input)
        {
            var idNguoiMua = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            var gioHang = _repositoryGioHang.AddGioHang(input, idNguoiMua, username);
            _dbContext.SaveChanges();
            return gioHang;
        }


        public GioHang DeleteGiohang(int idGioHang)
        {
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            var result = _repositoryGioHang.DeleteGioHang(idGioHang, username);
            _dbContext.SaveChanges();
            return result;
        }

        public GioHang EditGiohang(int idGiohang, EditGioHangChiTietDto newGioHang)
        {
            var gioHang = _repositoryGioHang.FindGioHang(idGiohang);
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            if (gioHang != null)
            {
                _repositoryGioHang.EditGioHang(gioHang, newGioHang, username);
                _dbContext.SaveChanges();
            }
            return gioHang;
        }

      
        /// <summary>
        /// Lấy ra danh sách sản phẩm trong giỏ hàng của người dùng
        /// </summary>
        /// <returns></returns>
        public List<GetSanPhamChiTietGioHangDto> getSanPhamTheoNguoiMua()
        {
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var gioHangs = _repositoryGioHang.GetSanPhamByNguoiMua(userId);

            //Xử lý từng sản phẩm trong giỏ hàng
            var sanPhams = new List<GetSanPhamChiTietGioHangDto>();
            foreach (var giohang in gioHangs)
            {
                var sanPham = _sanPhamRepository.GetById(giohang.IdSanPham);
                var sanPhamChiTiet = _sanPhamChiTietRepository.GetSanPhamChiTietById(giohang.IdSanPhamChiTiet);
                var sanPhamChiTietGioHang = new GetSanPhamChiTietGioHangDto()
                {
                    IdSanPham = giohang.IdSanPham,
                    IdSanPhamChiTiet = giohang.IdSanPhamChiTiet,
                    TenSanPham = sanPham.TenSanPham,
                    GiaBan = sanPhamChiTiet.GiaBan,
                    MoTa = sanPhamChiTiet.MoTa,
                    GiaChietKhau = sanPhamChiTiet.GiaChietKhau,
                    GiaToiThieu = sanPhamChiTiet.GiaToiThieu,
                    Thumbnail = sanPham.Thumbnail, 
                    SoLuong = giohang.SoLuong,
                    IdGStore = sanPham.IdGStore
                };
                // Xử lý lấy ra thuộc tính của sản phẩm 
                var dict = new Dictionary<String, AddThuocTinhGiaTriDto>();
                var listDanhMucThuocTinhs = _thuocTinhRepository.FindByIdDanhMucThuocTinh(sanPham.IdDanhMucThuocTinh);
                var listIdThuocTinhGiaTris = giohang.IdThuocTinhs.ToList();
                if(listIdThuocTinhGiaTris.Count() != 0)
                {
                    for (int i = 0; i < listDanhMucThuocTinhs.Count; i++)
                    {
                        var giatritt = _thuocTinhRepository.FindGiaTriById(listIdThuocTinhGiaTris[i]);
                        dict.Add(listDanhMucThuocTinhs[i].TenThuocTinh, _mapper.Map<AddThuocTinhGiaTriDto>(giatritt));

                    }
                }
                
                sanPhamChiTietGioHang.ThuocTinhs = dict;
                sanPhams.Add(sanPhamChiTietGioHang);
            }
            return sanPhams;
        }
        public GetGioHangDto GetGioHangTheoIdSanPham(int idSanPham)
        {
            
            var sanPhams = _repositoryGioHang.GetGioHangByIdSanPhamChiTiet(idSanPham);
            if(sanPhams == null)
            {
                throw new Exception("Không tìm thấy giỏ hàng");
            }    
            return sanPhams;
        }
    }
}
