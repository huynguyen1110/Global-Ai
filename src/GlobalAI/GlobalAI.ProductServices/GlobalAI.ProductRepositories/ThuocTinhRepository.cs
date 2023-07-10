using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMucThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri;
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
    public class ThuocTinhRepository : BaseEFRepository<ThuocTinh>
    {
        private readonly IMapper _mapper;

        public ThuocTinhRepository(DbContext dbContext, ILogger logger,IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {

        }

        /// <summary>
        /// Thêm thuộc tính
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public ThuocTinh Add(ThuocTinh entity, string username)
        {
            _logger.LogInformation($"{nameof(Add)}: entity = {JsonSerializer.Serialize(entity)}; username={username}");

            entity.CreatedBy = username;
            entity.CreatedDate = DateTime.Now;

            _dbSet.Add(entity);

            return entity;
        }

        /// <summary>
        /// Thêm thuộc tính giá trị
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public ThuocTinhGiaTri AddGiaTri(ThuocTinhGiaTri entity, string username)
        {
            _logger.LogInformation($"{nameof(AddGiaTri)}: entity = {JsonSerializer.Serialize(entity)}; username={username}");

            entity.CreatedBy = username;
            entity.CreatedDate = DateTime.Now;

            _globalAIDbContext.ThuocTinhGiaTris.Add(entity);
            return entity;
        }

        /// <summary>
        /// Tìm thuộc tính theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ThuocTinh FindById(int id)
        {
            _logger.LogInformation($"{nameof(FindById)} -> {nameof(ThuocTinh)}: id={id}");

            var result = _dbSet.FirstOrDefault(x => x.Id == id && !x.Deleted);
            return result;
        }

        /// <summary>
        /// Tìm giá trị theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ThuocTinhGiaTri FindGiaTriById(int id)
        {
            _logger.LogInformation($"{nameof(FindById)} -> {nameof(ThuocTinh)}: id={id}");

            var result = _globalAIDbContext.ThuocTinhGiaTris.FirstOrDefault(x => x.Id == id && !x.Deleted);
            return result;
        }

        /// <summary>
        /// Lấy list thuộc tính theo id danh mục thuộc tính
        /// </summary>
        /// <param name="idDanhMucThuoctinh"></param>
        /// <returns></returns>
        public List<ThuocTinh> FindByIdDanhMucThuocTinh(int? idDanhMucThuoctinh)
        {
            _logger.LogInformation($"{nameof(FindByIdDanhMucThuocTinh)} -> {nameof(List<ThuocTinh>)}: idDanhMucThuoctinh={idDanhMucThuoctinh}");

            var query = from danhMuc in _globalAIDbContext.danhMucThuocTinhs.AsNoTracking()
                        join thuocTinh in _globalAIDbContext.ThuocTinhs.AsNoTracking() on danhMuc.Id equals thuocTinh.IdDanhMucThuocTinh
                        where !danhMuc.Deleted && !thuocTinh.Deleted && danhMuc.Id == idDanhMucThuoctinh
                        orderby thuocTinh.TenThuocTinh
                        select thuocTinh;
            return query.ToList();
        }

        /// <summary>
        /// Lấy list giá trị theo id thuộc tính
        /// </summary>
        /// <param name="idThuocTinh"></param>
        /// <returns></returns>
        public List<ThuocTinhGiaTri> FindGiaTriByIdThuocTinh(int idThuocTinh)
        {
            _logger.LogInformation($"{nameof(FindGiaTriByIdThuocTinh)} -> {nameof(List<ThuocTinhGiaTri>)}: idThuocTinh={idThuocTinh}");

            var query = from thuocTinh in _globalAIDbContext.ThuocTinhs.AsNoTracking()
                        join giaTri in _globalAIDbContext.ThuocTinhGiaTris.AsNoTracking() on thuocTinh.Id equals giaTri.IdThuocTinh
                        where !thuocTinh.Deleted && !giaTri.Deleted && thuocTinh.Id == idThuocTinh
                        orderby giaTri.GiaTri
                        select giaTri;
            return query.ToList();
        }

        /// <summary>
        /// Cập nhật thuộc tính
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="username"></param>
        public void UpdateThuocTinh(UpdateThuocTinhDto dto, string username)
        {
            _logger.LogInformation($"{nameof(UpdateThuocTinh)}: dto={JsonSerializer.Serialize(dto)}, username={username}");

            var thuocTinh = FindById(dto.Id).ThrowIfNull(_globalAIDbContext, Utils.ErrorCode.ProductThuocTinhNotFound);

            CheckThuocTinhInUsed(thuocTinh.Id);

            thuocTinh.IdDanhMucThuocTinh = dto.IdDanhMucThuocTinh;
            thuocTinh.TenThuocTinh = dto.TenThuocTinh;
            thuocTinh.ModifiedBy = username;
            thuocTinh.ModifiedDate = DateTime.Now;
        }

        /// <summary>
        /// Cập nhật thuộc tính giá trị
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="username"></param>
        public void UpdateThuocTinhGiaTri(UpdateThuocTinhGiaTriDto dto, string username)
        {
            _logger.LogInformation($"{nameof(UpdateThuocTinhGiaTri)}: dto={JsonSerializer.Serialize(dto)}, username={username}");

            var thuocTinh = FindGiaTriById(dto.Id).ThrowIfNull(_globalAIDbContext, Utils.ErrorCode.ProductThuocTinhGiaTriNotFound);

            CheckGiaTriInUsed(thuocTinh.Id);

            thuocTinh.IdThuocTinh = dto.IdThuocTinh;
            thuocTinh.GiaTri = dto.GiaTri;
            thuocTinh.ModifiedBy = username;
            thuocTinh.ModifiedDate = DateTime.Now;
        }

        /// <summary>
        /// Xóa mềm thuộc tính
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        public void DeleteThuocTinh(int id, string username)
        {
            _logger.LogInformation($"{nameof(DeleteThuocTinh)}: id={id}, username={username}");

            var thuocTinh = FindById(id).ThrowIfNull(_globalAIDbContext, Utils.ErrorCode.ProductThuocTinhNotFound);

            CheckThuocTinhInUsed(id);

            thuocTinh.Deleted = true;
            thuocTinh.DeletedBy = username;
            thuocTinh.DeletedDate = DateTime.Now;
        }

        /// <summary>
        /// Xóa mềm thuộc tính giá trị
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        public void DeleteThuocTinhGiaTri(int id, string username)
        {
            _logger.LogInformation($"{nameof(DeleteThuocTinhGiaTri)}: id={id}, username={username}");

            var giaTri = FindGiaTriById(id).ThrowIfNull(_globalAIDbContext, Utils.ErrorCode.ProductThuocTinhGiaTriNotFound);

            CheckGiaTriInUsed(giaTri.Id);

            giaTri.Deleted = true;
            giaTri.DeletedBy = username;
            giaTri.DeletedDate = DateTime.Now;

        }

        /// <summary>
        /// Check thuộc tính đã được sử dụng chưa
        /// </summary>
        /// <param name="id"></param>
        private void CheckThuocTinhInUsed(int id)
        {
            var inUsedThuocTinhGiaTri = _globalAIDbContext.ThuocTinhGiaTris.AsNoTracking().Any(x => !x.Deleted && x.IdThuocTinh == id);
            if (inUsedThuocTinhGiaTri)
            {
                ThrowException(Utils.ErrorCode.ProductThuocTinhInUsed);
            }
        }

        /// <summary>
        /// Check thuộc tính giá trị đã gán vào sản phẩm chi tiết chưa
        /// </summary>
        /// <param name="id"></param>
        private void CheckGiaTriInUsed(int id)
        {
            var inUsed = _globalAIDbContext.SanPhamChiTietThuocTinhs.AsNoTracking().Any(x => !x.Deleted && x.IdThuocTinhGiaTri == id);
            if (inUsed)
            {
                ThrowException(Utils.ErrorCode.ProductThuocTinhGiaTriInUsed);
            }
        }
       
    }
}
