using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.BaiTin;
using GlobalAI.ProductEntities.Dto.DanhMucBaiTin;
using GlobalAI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductRepositories
{
    public class DanhMucBaiTinRepository : BaseEFRepository<DanhMucBaiTin>
    {
        private readonly IMapper _mapper;
        public DanhMucBaiTinRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }

        public DanhMucBaiTin Add(DanhMucBaiTin input)
        {
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

        public DanhMucBaiTin FindById(int id)
        {
            return _dbSet.FirstOrDefault(d => d.Id == id && d.Deleted == DeletedBool.NO);
        }

        public PagingResult<DanhMucBaiTin> FindAll(FilterDanhMucBaiTinDto input, int? userId = null)
        {
            PagingResult<DanhMucBaiTin> result = new();

            var baiTinQuery = (from baiTin in _dbSet
                               where baiTin.Deleted == DeletedBool.NO
                                && (input.ParentId == null || input.ParentId == baiTin.ParentId)
                                     && (input.Status == null || input.Status == baiTin.Status)
                               select baiTin);
            if (input.IsParent == true)
            {
                baiTinQuery = baiTinQuery.Where(baiTin => baiTin.ParentId == null);
            }
            result.TotalItems = baiTinQuery.Count();
            baiTinQuery = baiTinQuery.OrderByDescending(d => d.Id);
            if (input.PageSize != -1)
            {
                baiTinQuery = baiTinQuery.Skip(input.Skip).Take(input.PageSize);
            }
            result.Items = baiTinQuery;
            return result;
        }

        public void Update(DanhMucBaiTin input)
        {
            var query = _dbSet.FirstOrDefault(d => d.Id == input.Id && d.Deleted == DeletedBool.NO);
            query.ModifiedDate = DateTime.Now;
            query.ModifiedBy = input.ModifiedBy;
            query.MaDanhMuc = input.MaDanhMuc;
            query.TenDanhMuc = input.TenDanhMuc;
            query.Thumbnail = input.Thumbnail;
        }

    }
}
