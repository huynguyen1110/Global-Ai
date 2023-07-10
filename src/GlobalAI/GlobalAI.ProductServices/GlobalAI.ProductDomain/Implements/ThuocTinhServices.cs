using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMucThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri;
using GlobalAI.ProductRepositories;
using GlobalAI.Utils;
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
    public class ThuocTinhServices : IThuocTinhServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<ThuocTinhServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly DanhMucThuocTinhRepository _danhMucThuocTinhRepository;
        private readonly ThuocTinhRepository _thuocTinhRepository;
        public ThuocTinhServices(GlobalAIDbContext dbContext,
                IHttpContextAccessor httpContext,
                DatabaseOptions databaseOptions,
                ILogger<ThuocTinhServices> logger, IMapper mapper)
        {
            _mapper = mapper;
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;

            _danhMucThuocTinhRepository = new DanhMucThuocTinhRepository(dbContext, logger);
            _thuocTinhRepository = new ThuocTinhRepository(dbContext, logger,mapper);
        }

        /// <summary>
        /// Thêm giá trị thuộc tính
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ThuocTinhGiaTri AddGiaTri(AddThuocTinhGiaTriDto dto)
        {
            _logger.LogInformation($"{nameof(AddGiaTri)}: dto={JsonSerializer.Serialize(dto)}");

            string username = CommonUtils.GetCurrentUsername(_httpContext);
            var gt = _thuocTinhRepository.AddGiaTri(_mapper.Map<ThuocTinhGiaTri>(dto), username);

            _dbContext.SaveChanges();
            return gt;
        }

        /// <summary>
        /// Thêm Thuộc tính
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ThuocTinh AddThuocTinh(AddThuocTinhDto dto)
        {
            string username = CommonUtils.GetCurrentUsername(_httpContext);
            _logger.LogInformation($"{nameof(AddThuocTinh)}: dto={JsonSerializer.Serialize(dto)}");

            using (var tran = _dbContext.Database.BeginTransaction())
            {
                var thuocTinh = _thuocTinhRepository.Add(_mapper.Map<ThuocTinh>(dto), username);
                _dbContext.SaveChanges();

                if (dto.ListThuocTinhGiaTri.Count > 0)
                {
                    foreach (var giaTri in dto.ListThuocTinhGiaTri)
                    {
                        var mapped = _mapper.Map<ThuocTinhGiaTri>(giaTri);
                        mapped.IdThuocTinh = thuocTinh.Id;

                        _thuocTinhRepository.AddGiaTri(mapped, username);
                    }
                }

                _dbContext.SaveChanges();
                tran.Commit();

                return thuocTinh;
            }
        }

        /// <summary>
        /// Xóa giá trị
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGiaTri(int id)
        {
            _logger.LogInformation($"{nameof(DeleteGiaTri)}: id={id}");

            string username = CommonUtils.GetCurrentUsername(_httpContext);
            _thuocTinhRepository.DeleteThuocTinhGiaTri(id, username);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Xóa thuộc tính
        /// </summary>
        /// <param name="id"></param>
        public void DeleteThuocTinh(int id)
        {
            _logger.LogInformation($"{nameof(DeleteThuocTinh)}: id={id}");

            string username = CommonUtils.GetCurrentUsername(_httpContext);
            _thuocTinhRepository.DeleteThuocTinh(id, username);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Tìm giá trị theo id giá trị
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewThuocTinhGiaTriDto FindGiaTriById(int id)
        {
            _logger.LogInformation($"{nameof(FindGiaTriById)}: id={id}");

            var result = _thuocTinhRepository.FindGiaTriById(id);
            return _mapper.Map<ViewThuocTinhGiaTriDto>(result);
        }

        /// <summary>
        /// Tìm danh sách gia trị theo id thuộc tính
        /// </summary>
        /// <param name="idThuocTinh"></param>
        /// <returns></returns>
        public List<ViewThuocTinhGiaTriDto> FindListGiaTriByThuocTinh(int idThuocTinh)
        {
            _logger.LogInformation($"{nameof(FindListGiaTriByThuocTinh)}: idThuocTinh={idThuocTinh}");

            var result = _thuocTinhRepository.FindGiaTriByIdThuocTinh(idThuocTinh);
            return _mapper.Map<List<ViewThuocTinhGiaTriDto>>(result);
        }

        /// <summary>
        /// Tìm danh sách thuộc tính theo id danh mục
        /// </summary>
        /// <param name="idDanhMuc"></param>
        /// <returns></returns>
        public List<ViewThuocTinhDto> FindListThuocTinhByDanhMuc(int idDanhMuc)
        {
            _logger.LogInformation($"{nameof(FindListThuocTinhByDanhMuc)}: idDanhMuc={idDanhMuc}");

            var result = _thuocTinhRepository.FindByIdDanhMucThuocTinh(idDanhMuc);
            return _mapper.Map<List<ViewThuocTinhDto>>(result);
        }

        /// <summary>
        /// Tìm thuộc tính theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewThuocTinhDto FindThuocTinhById(int id)
        {
            _logger.LogInformation($"{nameof(FindThuocTinhById)}: id={id}");

            var result = _thuocTinhRepository.FindById(id);

            var data = _mapper.Map<ViewThuocTinhDto>(result);
            var giaTri = _thuocTinhRepository.FindGiaTriByIdThuocTinh(data.Id);
            data.ListGiaTri = _mapper.Map<List<ViewThuocTinhGiaTriDto>>(giaTri);

            return data;
        }

        /// <summary>
        /// Cập nhật giá trị
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateGiaTri(UpdateThuocTinhGiaTriDto dto)
        {
            _logger.LogInformation($"{nameof(UpdateGiaTri)}: dto={JsonSerializer.Serialize(dto)}");

            string username = CommonUtils.GetCurrentUsername(_httpContext);
            _thuocTinhRepository.UpdateThuocTinhGiaTri(dto, username);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Cập nhật thuộc tính
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateThuocTinh(UpdateThuocTinhDto dto)
        {
            _logger.LogInformation($"{nameof(UpdateThuocTinh)}: dto={JsonSerializer.Serialize(dto)}");

            string username = CommonUtils.GetCurrentUsername(_httpContext);
            _thuocTinhRepository.UpdateThuocTinh(dto, username);
            _dbContext.SaveChanges();
        }
    }
}
