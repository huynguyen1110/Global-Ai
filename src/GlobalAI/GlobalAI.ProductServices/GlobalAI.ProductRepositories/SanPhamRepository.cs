using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.Product;
using AutoMapper;
using Microsoft.AspNetCore.Http.Internal;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using GlobalAI.Utils.ConstantVariables.Product;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using GlobalAI.Utils;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;
using GlobalAI.ProductEntities.Dto.Voucher;
using System.Linq;

namespace GlobalAI.ProductRepositories
{
    public class SanPhamRepository : BaseEFRepository<SanPham>
    {
        private readonly IMapper _mapper;
        public SanPhamRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }
        public List<GetSanPhamDto> GetFullSanPham() {
            var result = _dbSet.AsNoTracking().Where(p => p.Deleted == false).ToList();
            return _mapper.Map<List<GetSanPhamDto>>(result);
        }

        /// <summary>
        /// Tạo mới product
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public void Add(SanPham sanPham)
        {
            sanPham.NgayDangKi = DateTime.Now;
            sanPham.Deleted = false;
            sanPham.CreatedDate = DateTime.Now;

            _dbSet.Add(sanPham);
        }

        public void EditSanPham(AddSanPhamDto newSanPham, SanPham oldSanPham)
        {
            _mapper.Map(newSanPham, oldSanPham);
        }
        public void EditDanhMuc(CreateDanhMucDto newDanhMuc, DanhMuc oldDanhmuc)
        {
            _mapper.Map(newDanhMuc, oldDanhmuc);
        }
        public void Delete(SanPham sanPham)
        {
            sanPham.Deleted = true;
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// Lấy demo product phân trang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<GetSanPhamDto> FindAll(FindSanPhamDto input)
        {
            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(FindAll)}: input = {JsonSerializer.Serialize(input)}");
            PagingResult<GetSanPhamDto> result = new();
            var projectQuery = _dbSet.AsNoTracking().OrderByDescending(p => p.Id).Where(p => p.Deleted == false)
                .Where(r => (input.Keyword == null || r.TenSanPham.Contains(input.Keyword)));
            if (input.PageSize != -1)
            {
                projectQuery = projectQuery.Skip(input.Skip).Take(input.PageSize);
            }
            result.TotalItems = projectQuery.Count();
            var sanphams = projectQuery;
            var sanphamDtos = new List<GetSanPhamDto>();
            foreach ( var item in sanphams ) {
                var getSpDto = _mapper.Map<GetSanPhamDto>(item);
               
                sanphamDtos.Add(getSpDto);
            }
            result.Items = sanphamDtos;
            return result;
        }

        

        /// <summary>
        /// Lấy demo product phân trang
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SanPham GetById(int idSanPham)
        {
            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(FindAll)}: input = {JsonSerializer.Serialize(idSanPham)}");
            var sanpham = _dbSet.AsNoTracking().Where(sp => sp.Deleted == false).FirstOrDefault(sp => sp.Id == idSanPham);
            if (sanpham == null)
            {
                throw new Exception("San pham khong ton tai");
            }
            return sanpham;
        }
        /// <summary>
        /// Lấy sản phẩm theo danh mục
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<GetSanPhamDto> GetByCategory(string idDanhMuc, FindSanPhamByCatetoryDto input)
        {

            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(GetByCategory)}: input = {JsonSerializer.Serialize(idDanhMuc)}");
            PagingResult<GetSanPhamDto> result = new();
            
            var projectQuery = _dbSet.AsNoTracking().Where(p => p.Deleted == false && p.IdDanhMuc == idDanhMuc);
                
            if (input.PageSize != -1)
            {
                projectQuery = projectQuery.Skip(input.Skip).Take(input.PageSize);
            }
            if (projectQuery.Count() <= 0)
            {
                throw new Exception("San pham khong ton tai");
            }
            result.TotalItems = projectQuery.Count();
            var sanphams = projectQuery;
            var sanphamDtos = new List<GetSanPhamDto>();
            foreach (var item in sanphams)
            {
                var getSpDto = _mapper.Map<GetSanPhamDto>(item);
                sanphamDtos.Add(getSpDto);
            }
            result.Items = sanphamDtos;
            return result;
        }
        /// <summary>
        /// Tìm sản phầm cần sửa, xóa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SanPham FindByIdSanPham(int idSanPham)
        {

            var result = _dbSet.SingleOrDefault(sp => sp.Id == idSanPham);
            if(result == null)
            {
                throw new Exception("San pham khong ton tai");
            }
            else if(result.Deleted == true)
            {
                throw new Exception("San pham khong ton tai");
            }
            return result;
        }
        public DanhMuc FindByIdDanhMuc(int idDanhMuc)
        {

            var result = _globalAIDbContext.DanhMucs.FirstOrDefault(d => d.Id == idDanhMuc);
            if (result == null)
            {
                throw new Exception("Danh muc khong ton tai");
            }
            else if (result.Deleted == true)
            {
                throw new Exception("Danh muc khong ton tai");
            }
            return result;
        }
        public List<SanPham> GetSanPhamFull()
        {
            var result = _dbSet.ToList();
            
            return result;
        }
        public PagingResult<GetSanPhamDto> GetSanPhamByIdGstore(int? idGstore,GetSanPhamIdGstoreDto input)
        {
            _logger.LogInformation($"{nameof(SanPhamRepository)}->{nameof(FindAll)}: input = {JsonSerializer.Serialize(input)}");

            PagingResult<GetSanPhamDto> result = new();
            var projectQuery = _dbSet.AsNoTracking().OrderByDescending(p => p.Id).Where(p => !p.Deleted && (idGstore == null || p.IdGStore == idGstore) && (input.Keyword == null || p.TenSanPham.Contains(input.Keyword)));

            result.TotalItems = projectQuery.Count();
            if (input.PageSize != -1)
            {
                projectQuery = projectQuery.Skip(input.Skip).Take(input.PageSize);
            }

            var sanphams = projectQuery;
            var sanphamDtos = new List<GetSanPhamDto>();

            foreach (var item in sanphams)
            {
                var getSpDto = _mapper.Map<GetSanPhamDto>(item);

                sanphamDtos.Add(getSpDto);
            }
            result.Items = sanphamDtos;

            return result;
        }

    }
}