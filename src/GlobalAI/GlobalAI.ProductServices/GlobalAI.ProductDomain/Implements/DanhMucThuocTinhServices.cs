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
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Implements
{
    public class DanhMucThuocTinhServices : IDanhMucThuocTinhServices
    {
        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<DanhMucThuocTinhServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly DanhMucThuocTinhRepository _danhMucThuocTinhRepository;
        private readonly ThuocTinhRepository _thuocTinhRepository;
        public DanhMucThuocTinhServices(GlobalAIDbContext dbContext,
                IHttpContextAccessor httpContext,
                DatabaseOptions databaseOptions,
                ILogger<DanhMucThuocTinhServices> logger, IMapper mapper)
        {
            _mapper = mapper;
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;

            _danhMucThuocTinhRepository = new DanhMucThuocTinhRepository(dbContext, logger);
            _thuocTinhRepository = new ThuocTinhRepository(dbContext, logger, mapper);
        }

        /// <summary>
        /// Thêm danh mục thuộc tính
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public DanhMucThuocTinh Add(AddDanhMucThuocTinhDto dto)
        {
            _logger.LogInformation($"{nameof(Add)}: dto={JsonSerializer.Serialize(dto)}");
            string username = CommonUtils.GetCurrentUsername(_httpContext);

            using (var tran = _dbContext.Database.BeginTransaction())
            {
                var danhMuc = _danhMucThuocTinhRepository.Add(_mapper.Map<DanhMucThuocTinh>(dto), username);
                _dbContext.SaveChanges();

                if (dto.ListThuocTinh.Count > 0)
                {
                    var dict = new Dictionary<int, ThuocTinh>();

                    for (int i = 0; i < dto.ListThuocTinh.Count; i++)
                    {
                        var tmpThuocTinh = dto.ListThuocTinh[i];

                        var mapped = _mapper.Map<ThuocTinh>(tmpThuocTinh);
                        mapped.IdDanhMucThuocTinh = danhMuc.Id;

                        var thuocTinh = _thuocTinhRepository.Add(mapped, username);
                        dict.Add(i, thuocTinh);
                    }
                    _dbContext.SaveChanges();


                    for (int i = 0; i < dto.ListThuocTinh.Count; i++)
                    {
                        var tmpThuocTinh = dto.ListThuocTinh[i];

                        if (tmpThuocTinh.ListThuocTinhGiaTri.Count > 0)
                        {
                            foreach (var tmpGiaTri in tmpThuocTinh.ListThuocTinhGiaTri)
                            {
                                var mapped = _mapper.Map<ThuocTinhGiaTri>(tmpGiaTri);
                                mapped.IdThuocTinh = dict[i].Id;
                                mapped.TenThuocTinh = dict[i].TenThuocTinh;

                                _thuocTinhRepository.AddGiaTri(mapped, username);
                            }
                        }
                    }
                }

                _dbContext.SaveChanges();
                tran.Commit();

                return danhMuc;
            }
        }

        /// <summary>
        /// List danh mục thuộc tính phân trang
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PagingResult<ViewDanhMucThuocTinhDto> FindDanhMucThuocTinh(FindDanhMucThuocTinhDto dto)
        {
            _logger.LogInformation($"{nameof(FindDanhMucThuocTinh)} -> {nameof(PagingResult<DanhMucThuocTinh>)}: dto={JsonSerializer.Serialize(dto)}");

            var result = _danhMucThuocTinhRepository.FindDanhMucThuocTinh(dto);
            return result;
        }

        /// <summary>
        /// Find danh mục thuộc tính theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewSingleDanhMucThuocTinhDto FindById(int id)
        {
            _logger.LogInformation($"{nameof(FindById)} -> {nameof(ViewSingleDanhMucThuocTinhDto)}: id ={id}");

            var danhMuc = _danhMucThuocTinhRepository.FindById(id);
            var result = _mapper.Map<ViewSingleDanhMucThuocTinhDto>(danhMuc);

            var thuocTinh = _thuocTinhRepository.FindByIdDanhMucThuocTinh(danhMuc.Id);
            if (thuocTinh != null)
            {
                result.ListThuocTinh = _mapper.Map<List<ViewThuocTinhDto>>(thuocTinh);
                foreach (var item in result.ListThuocTinh)
                {
                    var giaTri = _thuocTinhRepository.FindGiaTriByIdThuocTinh(item.Id);
                    if (giaTri != null)
                    {
                        item.ListGiaTri = _mapper.Map<List<ViewThuocTinhGiaTriDto>>(giaTri);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Cập nhật danh mục bài viết
        /// </summary>
        /// <param name="dto"></param>
        public void Update(UpdateDanhMucThuocTinhDto dto)
        {
            _logger.LogInformation($"{nameof(Update)}: dto={JsonSerializer.Serialize(dto)}");

            string username = CommonUtils.GetCurrentUsername(_httpContext);
            _danhMucThuocTinhRepository.UpdateDanhMucThuocTinh(dto, username);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Xoá danh mục bài viết
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            _logger.LogInformation($"{nameof(Delete)}: id={id}");

            string username = CommonUtils.GetCurrentUsername(_httpContext);
            _danhMucThuocTinhRepository.DeleteDanhMucThuocTinh(id, username);
            _dbContext.SaveChanges();
        }
    }
}
