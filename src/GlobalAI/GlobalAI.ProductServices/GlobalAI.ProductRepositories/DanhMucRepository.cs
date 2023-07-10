using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using GlobalAI.Utils;
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
    public class DanhMucRepository : BaseEFRepository<DanhMuc>
    {
        private readonly IMapper _mapper;
        public DanhMucRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }

        public DanhMuc Add(DanhMuc input)
        {
            _logger.LogInformation($"{nameof(Add)}: entity = {JsonSerializer.Serialize(input)}");
            input.CreatedDate = DateTime.Now;
            input.ModifiedDate = DateTime.Now;
            input.Deleted = DeletedBool.NO;
            return _dbSet.Add(input).Entity;
        }

        public void DeleteById(int id, string username)
        {
            if (_dbSet.Any(e => e.Id == id))
            {
                _dbSet.Where(e => e.Id == id)
                    .ToList()
                    .ForEach(e =>
                    {
                        e.DeletedBy = username;
                        e.DeletedDate = DateTime.Now;
                        e.Deleted = true;
                    });
            }
        }

        public DanhMuc FindById(int id)
        {
            return _dbSet.FirstOrDefault(d => d.Id == id && d.Deleted == DeletedBool.NO);
        }

        public PagingResult<DanhMuc> FindAll(FilterDanhMucDto input, int? userId = null)
        {
            PagingResult<DanhMuc> result = new();

            var query = (from danhMuc in _dbSet
                               where danhMuc.Deleted == DeletedBool.NO
                              && (input.IsDisplayOnHomePage == null || input.IsDisplayOnHomePage == danhMuc.IsDisplayOnHomePage)
                         select danhMuc);

            result.TotalItems = query.Count();
            query = query.OrderByDescending(d => d.Id);
            if (input.PageSize != -1)
            {
                query = query.Skip(input.Skip).Take(input.PageSize);
            }
            result.Items = query;
            return result;
        }

    }
}
