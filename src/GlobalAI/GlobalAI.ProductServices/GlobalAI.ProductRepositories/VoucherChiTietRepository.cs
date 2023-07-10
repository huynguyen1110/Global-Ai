using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.VoucherChiTiet;
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
    public class VoucherChiTietRepository : BaseEFRepository<VoucherChiTiet>
    {
        private readonly IMapper _mapper;
        public VoucherChiTietRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }

        public VoucherChiTiet Add(VoucherChiTiet input)
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

        public VoucherChiTiet FindById(int id)
        {
            return _dbSet.FirstOrDefault(d => d.Id == id && d.Deleted == DeletedBool.NO);
        }

        public PagingResult<VoucherChiTiet> FindAll(FilterVoucherChiTietDto input, int? userId = null)
        {
            PagingResult<VoucherChiTiet> result = new();

            var query = (from voucher in _dbSet
                         where voucher.Deleted == DeletedBool.NO

                               && (input.Status == null || input.Status == voucher.Status)
                         select voucher);

            result.TotalItems = query.Count();
            query = query.OrderByDescending(d => d.Id);
            if (input.PageSize != -1)
            {
                query = query.Skip(input.Skip).Take(input.PageSize);
            }
            result.Items = query;
            return result;
        }

        public List<VoucherChiTiet> GetAllByVoucherId(int voucherId)
        {
            var result = _dbSet.Where(e => e.VoucherId == voucherId);
            return result.ToList();
        }

        public void Update(VoucherChiTiet input)
        {
            var bargainQuery = _dbSet.FirstOrDefault(d => d.Id == input.Id && d.Deleted == DeletedBool.NO);
            bargainQuery.ModifiedDate = DateTime.Now;
            //bargainQuery.Name = input.Name;
            //bargainQuery.ModifiedBy = input.ModifiedBy;
            //bargainQuery.Avatar = input.Avatar;
            //bargainQuery.GiaTri = input.GiaTri;
            //bargainQuery.SoLuong = input.SoLuong;
            //bargainQuery.NgayHetHan = input.NgayHetHan;
            //bargainQuery.Status = input.Status;
        }

    }
}
