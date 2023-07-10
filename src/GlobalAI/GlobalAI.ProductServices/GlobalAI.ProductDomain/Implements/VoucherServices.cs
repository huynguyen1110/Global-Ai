using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductRepositories;
using GlobalAI.Utils.ConstantVariables.Product;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalAI.ProductEntities.Dto.Voucher;
using GlobalAI.Utils.DataUtils;
using GlobalAI.ProductEntities.Dto.VoucherChiTiet;

namespace GlobalAI.ProductDomain.Implements
{
    public class VoucherServices : IVoucherServices
    {

        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<VoucherServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly VoucherRepository _voucherRepository;
        private readonly VoucherChiTietRepository _voucherChiTietRepository;
        private readonly IMapper _mapper;
        public VoucherServices(GlobalAIDbContext dbContext,
                IHttpContextAccessor httpContext,
                DatabaseOptions databaseOptions,
                ILogger<VoucherServices> logger, IMapper mapper)
        {
            _mapper = mapper;
            _voucherRepository = new VoucherRepository(dbContext, logger, mapper);
            _voucherChiTietRepository = new VoucherChiTietRepository(dbContext, logger, mapper);
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;

        }

        /// <summary>
        /// random ma voucher
        /// </summary>
        /// <returns></returns>
        public string FuncVerifyCodeGenerate()
        {
            while (true)
            {
                var numberRandom = RandomNumberUtils.RandomNumber(8);
                var checkCodeVoucher = _dbContext.VoucherChiTiets.Where(o => o.MaVoucher == numberRandom);
                if (!checkCodeVoucher.Any())
                {
                    return numberRandom;
                }
            }
        }

        /// <summary>
        /// them chi tiet voucher
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public VoucherChiTiet AddVoucherChiTiet(CreateVoucherChiTietDto input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);

            var inputInsert = _mapper.Map<VoucherChiTiet>(input);

            inputInsert.CreatedBy = username;
            inputInsert.Status = VoucherDetailStatus.KHOI_TAO;
            inputInsert.MaVoucher = FuncVerifyCodeGenerate();

            inputInsert = _voucherChiTietRepository.Add(inputInsert);
            _dbContext.SaveChanges();
            return inputInsert;
        }

        /// <summary>
        /// thêm bản ghi voucher
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Voucher Add(CreateVoucherDto input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            var transaction = _dbContext.Database.BeginTransaction();
            var inputInsert = _mapper.Map<Voucher>(input);

            inputInsert.CreatedBy = username; 
            inputInsert.Status = VoucherStatus.KHOI_TAO;

            //add voucher
            inputInsert = _voucherRepository.Add(inputInsert);
            _dbContext.SaveChanges();
            //Add voucher detail
            foreach (var item in input.VoucherChiTiets)
            {
                var insertDetail = _mapper.Map<VoucherChiTiet>(item);
                insertDetail.VoucherId = inputInsert.Id;
                insertDetail.CreatedBy = username;
                insertDetail.MaVoucher = FuncVerifyCodeGenerate();
                insertDetail.Status = VoucherDetailStatus.KHOI_TAO;
                var detailAdd = _voucherChiTietRepository.Add(insertDetail);
            }
           
            _dbContext.SaveChanges();
            transaction.Commit();
            return inputInsert;
        }

        public void Update(UpdateVoucherDto input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            var inputUpdate = _mapper.Map<Voucher>(input);
            inputUpdate.ModifiedBy = username;
            _voucherRepository.Update(inputUpdate);
            UpdateVoucherDetail(input.VoucherChiTiets, input.Id);
            _dbContext.SaveChanges();
        }

        public void UpdateVoucherDetail(List<CreateVoucherChiTietDto> input, int voucherId)
        {
    
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            var voucher = _voucherRepository.FindById(voucherId);

            var queryDetail = _voucherChiTietRepository.Entity.Where(c => c.VoucherId == voucherId);
            // Xóa detail
            var ids = input.Where(i => i.Id != 0).Select(i => i.Id);
            var removeDetail = queryDetail.Where(d => !ids.Contains(d.Id)).ToList();
            _voucherChiTietRepository.Entity.RemoveRange(removeDetail);

            foreach (var item in input)
            {
                if (item.Id == 0)
                {
                    var insertDetail = _mapper.Map<VoucherChiTiet>(item);
                    _voucherChiTietRepository.Add(insertDetail);
                }
                else
                {
                    var configdetailUpdate = _voucherChiTietRepository.Entity.FirstOrDefault(e => e.Id == item.Id);

                }
            }
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            _voucherRepository.DeleteById(id, username);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Danh sach 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<VoucherDto> FindAll(FilterVoucherDto input)
        {

            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var usertype = CommonUtils.GetCurrentRole(_httpContext);

            var result = new PagingResult<VoucherDto>();
            var query = _voucherRepository.FindAll(input, userId);

            result.Items = _mapper.Map<List<VoucherDto>>(query.Items);
            result.TotalItems = query.TotalItems;
            foreach (var item in result.Items)
            {
                item.VoucherChiTiets = _mapper.Map<List<VoucherChiTietDto>>(_voucherChiTietRepository.GetAllByVoucherId(item.Id));
              
            }
            return result;
        }

        public VoucherDto GetById(int id)
        {
            int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var baiTin = _voucherRepository.FindById(id);
            var result = _mapper.Map<VoucherDto>(baiTin);
            return result;
        }

     
    }
}
