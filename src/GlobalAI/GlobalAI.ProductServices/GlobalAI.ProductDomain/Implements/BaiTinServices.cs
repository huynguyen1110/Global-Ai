using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.Utils.ConstantVariables.Product;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalAI.ProductEntities.Dto.BaiTin;
using GlobalAI.ProductEntities.Dto.Voucher;
using GlobalAI.ProductRepositories;

namespace GlobalAI.ProductDomain.Implements
{

    public class BaiTinServices : IBaiTinServices
    {

        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<BaiTinServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly TinBaiRepository _baiTinRepository;
        private readonly DanhMucBaiTinRepository _danhMucBaiTinRepository;
        private readonly IMapper _mapper;
        public BaiTinServices(GlobalAIDbContext dbContext, 
                IHttpContextAccessor httpContext, 
                DatabaseOptions databaseOptions, 
                ILogger<BaiTinServices> logger, IMapper mapper)
        {
            _mapper = mapper;
            _baiTinRepository = new TinBaiRepository(dbContext, logger, mapper);
            _danhMucBaiTinRepository = new DanhMucBaiTinRepository(dbContext, logger, mapper);
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;

        }

        /// <summary>
        /// thêm bản ghi 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public BaiTin Add(CreateBaiTin input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);
        
            var inputInsert = _mapper.Map<BaiTin>(input);

            inputInsert.CreatedBy = username;

            inputInsert.Status = TrangThaiBaiTin.KHOI_TAO;
            inputInsert = _baiTinRepository.Add(inputInsert);
            _dbContext.SaveChanges();
            return inputInsert;
        }



        public void Delete(int id)
        {
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            _baiTinRepository.DeleteBaiTinById(id, username);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Danh sach 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<BaiTinDto> FindAll(FilterBaiTinDto input)
        {
            //int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            //var usertype = CommonUtils.GetCurrentRole(_httpContext);

            var result = new PagingResult<BaiTinDto>();
            var baiTinQuery = _baiTinRepository.FindAll(input);

            result.Items = _mapper.Map<List<BaiTinDto>>(baiTinQuery.Items);
            result.TotalItems = baiTinQuery.TotalItems;
            foreach (var item in result.Items)
            {
                item.TenDanhMuc = (item.IdDanhMuc != 0) ? _danhMucBaiTinRepository.FindById(item.IdDanhMuc).TenDanhMuc : item.TenDanhMuc;
            }

            return result;
        }

        public BaiTinDto GetById(int id)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var baiTin = _baiTinRepository.FindById(id);
            var result = _mapper.Map<BaiTinDto>(baiTin);
            result.TenDanhMuc = _danhMucBaiTinRepository.FindById(result.IdDanhMuc).TenDanhMuc;
            return result;
        }

        public BaiTinDto GetBySlug(string slug)
        {
            var baiTin = _baiTinRepository.FindBySlug(slug);
            var result = _mapper.Map<BaiTinDto>(baiTin);
            return result;
        }

        public void Update(UpdateBaiTinDto input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            var inputUpdate = _mapper.Map<BaiTin>(input);
            inputUpdate.ModifiedBy = username;
            _baiTinRepository.Update(inputUpdate);
            _dbContext.SaveChanges();
        }

        public void Approve(ApproveBaiTinDto input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            var query = _baiTinRepository.FindById(input.Id);
            query.ModifiedBy = username;
            query.Status = input.Status;
            _dbContext.SaveChanges();
        }
    }
}
