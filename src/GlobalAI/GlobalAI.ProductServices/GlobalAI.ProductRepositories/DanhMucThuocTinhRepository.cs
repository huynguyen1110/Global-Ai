using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMucThuocTinh;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlobalAI.ProductRepositories
{
    public class DanhMucThuocTinhRepository : BaseEFRepository<DanhMucThuocTinh>
    {
        public DanhMucThuocTinhRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {

        }

        /// <summary>
        /// Thêm danh mục thuộc tính
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public DanhMucThuocTinh Add(DanhMucThuocTinh entity, string username)
        {
            _logger.LogInformation($"{nameof(Add)}: entity = {JsonSerializer.Serialize(entity)}; username={username}");

            entity.CreatedBy = username;
            entity.CreatedDate = DateTime.Now;

            _dbSet.Add(entity);

            return entity;
        }

        /// <summary>
        /// Lấy danh sách phân trang danh mục thuộc tính
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PagingResult<ViewDanhMucThuocTinhDto> FindDanhMucThuocTinh(FindDanhMucThuocTinhDto dto)
        {
            _logger.LogInformation($"{nameof(FindDanhMucThuocTinh)} -> {nameof(PagingResult<ViewDanhMucThuocTinhDto>)}: dto = {JsonSerializer.Serialize(dto)}");

            var query = from danhMuc in _dbSet.AsNoTracking()
                        where !danhMuc.Deleted && (dto.Keyword == null || danhMuc.Ma.ToLower().Contains(dto.Keyword.ToLower()) || danhMuc.Ten.ToLower().Contains(dto.Keyword.ToLower()))
                        orderby danhMuc.Ten
                        select new ViewDanhMucThuocTinhDto
                        {
                            Id = danhMuc.Id,
                            Ma = danhMuc.Ma,
                            Ten = danhMuc.Ten
                        };

            var result = new PagingResult<ViewDanhMucThuocTinhDto>
            {
                TotalItems = query.Count(),
                Items = query.Skip(dto.Skip).Take(dto.PageSize).ToList()
            };
            return result;
        }

        /// <summary>
        /// Tìm danh mục thuộc tính theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DanhMucThuocTinh FindById(int id) 
        {
            _logger.LogInformation($"{nameof(FindById)} -> {nameof(DanhMucThuocTinh)}: id={id}");

            var result = _dbSet.FirstOrDefault(x => x.Id == id && !x.Deleted);
            return result;
        }

        /// <summary>
        /// Cập nhật danh mục thuộc tính
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="username"></param>
        public void UpdateDanhMucThuocTinh(UpdateDanhMucThuocTinhDto dto, string username)
        {
            _logger.LogInformation($"{nameof(UpdateDanhMucThuocTinh)}: dto={JsonSerializer.Serialize(dto)}");
            var entity = FindById(dto.Id).ThrowIfNull(_globalAIDbContext, Utils.ErrorCode.ProductDanhMucThuocTinhNotFound);

            checkInUsed(entity.Id);

            entity.ModifiedBy = username;
            entity.ModifiedDate = DateTime.Now;
            entity.Ma = dto.Ma;
            entity.Ten = dto.Ten;            
        }

        /// <summary>
        /// Xóa mềm danh mục thuộc tính
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        public void DeleteDanhMucThuocTinh(int id, string username)
        {
            _logger.LogInformation($"{nameof(DeleteDanhMucThuocTinh)}: id={id}");
            var entity = FindById(id).ThrowIfNull(_globalAIDbContext, Utils.ErrorCode.ProductDanhMucThuocTinhNotFound);

            checkInUsed(entity.Id);

            entity.DeletedBy = username;
            entity.DeletedDate = DateTime.Now;
            entity.Deleted = true;
        }

        /// <summary>
        /// Check danh mục thuộc tính đã sử dụng lần nào chưa
        /// </summary>
        /// <param name="id"></param>
        private void checkInUsed(int id)
        {
            var inUsedThuocTinh = _globalAIDbContext.ThuocTinhs.AsNoTracking().Any(x => !x.Deleted && x.IdDanhMucThuocTinh == id);
            var inUsedSanPham = _globalAIDbContext.SanPhams.AsNoTracking().Any(x => !x.Deleted && x.IdDanhMucThuocTinh == id);

            if (inUsedSanPham || inUsedThuocTinh)
            {
                ThrowException(Utils.ErrorCode.ProductDanhMucThuocTinhInUsed);
            }
        }
    }
}
