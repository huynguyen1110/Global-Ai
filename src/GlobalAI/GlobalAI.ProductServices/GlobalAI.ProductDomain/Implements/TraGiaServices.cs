using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.ChiTietTraGia;
using GlobalAI.ProductEntities.Dto.TraGia;
using GlobalAI.ProductRepositories;
using GlobalAI.Utils;
using GlobalAI.Utils.ConstantVariables.Core;
using GlobalAI.Utils.ConstantVariables.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace GlobalAI.ProductDomain.Implements
{
    public class TraGiaServices : ITraGiaServices
    {

        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<TraGiaServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly TraGiaRepository _traGiaRepository;
        private readonly ChiTietTraGiaRepository _chiTietTraGiaRepository;
        private readonly SanPhamRepository _sanPhamRepository;
        private readonly IMapper _mapper;
        private readonly GlobalAIDbContext _globalAIDbContext;
        public TraGiaServices(GlobalAIDbContext dbContext, IHttpContextAccessor httpContext, DatabaseOptions databaseOptions, ILogger<TraGiaServices> logger, IMapper mapper, GlobalAIDbContext globalAIDbContext)
        {
            _mapper = mapper;
            _traGiaRepository = new TraGiaRepository(dbContext, logger, mapper);
            _chiTietTraGiaRepository = new ChiTietTraGiaRepository(dbContext, logger, mapper);
            _sanPhamRepository = new SanPhamRepository(dbContext, logger, mapper);
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _globalAIDbContext = globalAIDbContext;
            _httpContext = httpContext;

        }
        
        /// <summary>
        /// thêm bản ghi trả giá
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public TraGia Add(AddTraGiaDto input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            var transaction = _dbContext.Database.BeginTransaction();
            var inputInsert = _mapper.Map<TraGia>(input);

            var inputDetailInsert = _mapper.Map<ChiTietTraGia>(input);
            //Lay id cua nguoi ban san pham nhung chua dung duoc api cua san pham
            //var productFind = _sanPhamRepository.GetById(input.IdSanPham).ThrowIfNull(_dbContext, 400);
            //inputInsert.IdNguoiBan = productFind.IdGsaler;

            inputInsert.IdNguoiMua = userId;
            inputInsert.CreatedBy = username;
           
            inputInsert.Status = TrangThaiTraGia.DANG_TRA_GIA;
            inputInsert = _traGiaRepository.Add(inputInsert);
            _dbContext.SaveChanges();

            inputDetailInsert.IdTraGia = inputInsert.Id;
            inputDetailInsert.GiaTien = inputDetailInsert.GiaTien;
            inputDetailInsert.CreatedBy = username;
            inputDetailInsert.Status = TrangThaiChiTietTraGia.NGUOI_MUA_DE_NGHI;
            inputDetailInsert.Usertype = userType;
            inputDetailInsert.LoaiTraGia = LoaiTraGias.NGUOI_MUA_DE_XUAT;
            _chiTietTraGiaRepository.Add(inputDetailInsert);
            _dbContext.SaveChanges();
            transaction.Commit();
            return inputInsert;
        }

        public ChiTietTraGia AddDetail(AddChiTietTraGiaDto input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);

            var inputDetailInsert = _mapper.Map<ChiTietTraGia>(input);

            _dbContext.SaveChanges();

            inputDetailInsert.IdTraGia = input.IdTraGia;
            inputDetailInsert.GiaTien = input.GiaTien;
            inputDetailInsert.CreatedBy = username;
            inputDetailInsert.Status = TrangThaiChiTietTraGia.NGUOI_MUA_DE_NGHI;
            inputDetailInsert.Usertype = userType;
            inputDetailInsert.LoaiTraGia = input.LoaiTraGia;
            _chiTietTraGiaRepository.Add(inputDetailInsert);
            _dbContext.SaveChanges();

            return inputDetailInsert;
        }

        public void DeleteTraGia(int id)
        {
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            _traGiaRepository.DeleteTraGiaById(id, username);
            _chiTietTraGiaRepository.DeleteByTraGiaId(id, username);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// cập nhật trả giá
        /// </summary>
        /// <param name="input"></param>
        //public void Update(UpdateTraGiaDto input)
        //{
        //    var userType = CommonUtils.GetCurrentRole(_httpContext);
        //    var userId = CommonUtils.GetCurrentUserId(_httpContext);
        //    var username = CommonUtils.GetCurrentUsername(_httpContext);
        //    //var productFind = _sanPhamRepository.GetById(input.IdSanPham).ThrowIfNull(_dbContext, 400);
        //    var inputUpdate = _mapper.Map<TraGia>(input);
        //    if (userType == UserTypes.GSaler)
        //    {
        //        inputUpdate.Usertype = userType;
        //    }
        //    if (userType == UserTypes.GStore)
        //    {
        //        inputUpdate.Usertype = userType;
        //    }
        //    inputUpdate.IdNguoiMua = userId;
        //    inputUpdate.ModifiedBy = username;
        //    _traGiaRepository.Update(inputUpdate);
        //    _dbContext.SaveChanges();
        //}

        ///// <summary>
        ///// Xác nhận trả giá thành công
        ///// </summary>
        ///// <param name="input"></param>
        public void Approve(ApproveTraGiaDto input)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            var username = CommonUtils.GetCurrentUsername(_httpContext);
   
            var traGia = _traGiaRepository.FindById(input.Id);
            traGia.ModifiedBy = username;
            traGia.Status = input.Status;
            _dbContext.SaveChanges();

            var chiTietTraGia = _chiTietTraGiaRepository.FindById(input.IdChiTietTraGia);
            chiTietTraGia.ModifiedBy = username;
   
            chiTietTraGia.Status = traGia.Status == TrangThaiTraGia.DA_TRA_GIA ? TrangThaiChiTietTraGia.NGUOI_BAN_DONG_Y : TrangThaiChiTietTraGia.NGUOI_MUA_DE_NGHI;

            _dbContext.SaveChanges();
            transaction.Commit();
        }

        /// <summary>
        /// Danh sach tra gia cua nguoi mua
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<TraGiaDto> FindAll(FilterTraGiaDto input)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            string usertype = CommonUtils.GetCurrentRole(_httpContext);
            
            var result = new PagingResult<TraGiaDto>();
            var traGiaQuery = _traGiaRepository.FindAll(input, usertype, userId );

            result.Items = _mapper.Map<List<TraGiaDto>>(traGiaQuery.Items);
            result.TotalItems = traGiaQuery.TotalItems;
            foreach (var item in result.Items)
            {
                item.ChiTietTraGias = _mapper.Map<List<ChiTietTraGiaDto>>(_chiTietTraGiaRepository.GetAll(item.Id));
                item.Type = item.IdNguoiMua == userId ? TypeLoginTraGia.NGUOI_MUA : item.IdNguoiBan == userId ? TypeLoginTraGia.NGUOI_BAN : 0;
            }
            return result;
        }

        public TraGiaDto GetById(int id)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);

            var traGia = _traGiaRepository.FindById(id);
            var result = _mapper.Map<TraGiaDto>(traGia);
            result.Type = result.IdNguoiMua == userId ? TypeLoginTraGia.NGUOI_MUA : result.IdNguoiBan == userId ? TypeLoginTraGia.NGUOI_BAN : 0;
            result.ChiTietTraGias = _mapper.Map<List<ChiTietTraGiaDto>>(_chiTietTraGiaRepository.GetAll(traGia.Id));
            return result;
        }
        public TraGiaDto FindTraGiaBySanPham(int idSanPham)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var traGiaNew = _dbContext.TraGias.FirstOrDefault(tg => tg.IdSanPham == idSanPham);

            var sanPham = _dbContext.SanPhams.FirstOrDefault(sp => sp.Id == idSanPham);

            var traGia = _traGiaRepository.FindTraGiaBySanPham(idSanPham, traGiaNew.IdNguoiMua, sanPham.IdGStore);

            var result = _mapper.Map<TraGiaDto>(traGia);
            result.Type = result.IdNguoiMua == userId ? TypeLoginTraGia.NGUOI_MUA : result.IdNguoiBan == userId ? TypeLoginTraGia.NGUOI_BAN : 0;
            result.ChiTietTraGias = _mapper.Map<List<ChiTietTraGiaDto>>(_chiTietTraGiaRepository.GetAll(traGia.Id));
            return result;
        }

    }
}
