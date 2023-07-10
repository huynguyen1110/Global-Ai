
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
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace GlobalAI.ProductDomain.Implements
{
    public class SanPhamChiTietServices : ISanPhamChiTietServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<SanPhamChiTietServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly SanPhamRepository _sanPhamRepository;
        private readonly SanPhamChiTietRepository _sanPhamChiTietRepository;
        private readonly IMapper _mapper;
        public SanPhamChiTietServices(GlobalAIDbContext dbContext, IHttpContextAccessor httpContext, DatabaseOptions databaseOptions, ILogger<SanPhamChiTietServices> logger, IMapper mapper)
        {
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
            _httpContext = httpContext;

            _sanPhamRepository = new SanPhamRepository(dbContext, logger, mapper);
            _sanPhamChiTietRepository = new SanPhamChiTietRepository(dbContext, logger, mapper);
        }
        public SanPhamChiTietDto GetSanPhamChiTietByIdSanPhamGttt(int idSanPham, List<int> gttt)
        {
            var result = _sanPhamChiTietRepository.GetSanPhamChiTietBySanPhamtt(idSanPham,gttt);
            return result;
        }
        /// <summary>
        /// Thêm sản phẩm chi tiết
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Sản phẩm vừa thêm vào</returns>
        public void AddSanPhamChiTiet(AddListSanPhamChiTietDto dto)
        {
            _logger.LogInformation($"{nameof(AddSanPhamChiTiet)}: dt ={JsonSerializer.Serialize(dto)}");

            string username = CommonUtils.GetCurrentUsername(_httpContext);
            int userId = CommonUtils.GetCurrentUserId(_httpContext);

            using (var tran = _dbContext.Database.BeginTransaction())
            {
                if (dto.ListSanPhamChiTiet != null)
                {
                    var dict = new Dictionary<int, SanPhamChiTiet>();

                    // Thêm chi tiết sp
                    for (int i = 0; i < dto.ListSanPhamChiTiet.Count; i++)
                    {
                        var spChiTiet = dto.ListSanPhamChiTiet[i];
                        spChiTiet.IdSanPham = spChiTiet.IdSanPham;

                        var dbSpChiTiet = _sanPhamChiTietRepository.Add(_mapper.Map<SanPhamChiTiet>(spChiTiet), username);
                        dict.Add(i, dbSpChiTiet);
                    }
                    _dbContext.SaveChanges();

                    // Them thuoc tinh cho sp chi tiet
                    for (int i = 0; i < dto.ListSanPhamChiTiet.Count; i++)
                    {
                        var spChiTiet = dto.ListSanPhamChiTiet[i];

                        _sanPhamChiTietRepository.AddSanPhamChiTietThuocTinh(dict[i].Id, spChiTiet.ListIdThuocTinhGiaTri, username);
                    }

                }

                _dbContext.SaveChanges();
                tran.Commit();
            }
        }

        /// <summary>
        /// Cập nhật sản phẩm chi tiết
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateSanPhamChiTiet(UpdateSanPhamChiTietDto dto)
        {
            _logger.LogInformation($"{nameof(UpdateSanPhamChiTiet)}: dt ={JsonSerializer.Serialize(dto)}");

            string username = CommonUtils.GetCurrentUsername(_httpContext);

            using (var tran = _dbContext.Database.BeginTransaction())
            {
                _sanPhamChiTietRepository.UpdateSanPhamChiTiet(_mapper.Map<SanPhamChiTiet>(dto), username);

                if (dto.ListDeleteIdSanPhamChiTietThuocTinh.Count > 0)
                {
                    _sanPhamChiTietRepository.DeleteSanPhamChiTietThuocTinh(dto.ListDeleteIdSanPhamChiTietThuocTinh, username);
                }

                if (dto.ListAddThuocTinhGiaTri.Count > 0)
                {
                    _sanPhamChiTietRepository.AddSanPhamChiTietThuocTinh(dto.Id, dto.ListAddThuocTinhGiaTri, username);
                }

                _dbContext.SaveChanges();
                tran.Commit();
            }
        }

        /// <summary>
        /// Xóa mềm sp chi tiết
        /// </summary>
        /// <param name="id"></param>
        public void DeleteSanPhamChiTiet(int id)
        {
            _logger.LogInformation($"{nameof(DeleteSanPhamChiTiet)}: id={id}");
            string username = CommonUtils.GetCurrentUsername(_httpContext);
            _sanPhamChiTietRepository.DeleteSanPhamChiTiet(id, username);
            _dbContext.SaveChanges();
        }
        public SanPhamChiTietDto GetSanPhamChiTietByIdSanPham(int idSanPham) {
            var result = _sanPhamChiTietRepository.GetSanPhamChiTietByIdSanPham(idSanPham); return result;
        }

    }
}
