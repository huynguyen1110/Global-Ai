using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.TraGia;
using GlobalAI.Utils;
using GlobalAI.Utils.ConstantVariables.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductRepositories
{
    public class ChiTietTraGiaRepository : BaseEFRepository<ChiTietTraGia>
    {
        private readonly IMapper _mapper;
        public ChiTietTraGiaRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }

        public ChiTietTraGia Add(ChiTietTraGia input)
        {
            input.CreatedDate = DateTime.Now;
            input.ModifiedDate = DateTime.Now;
            input.Deleted = DeletedBool.NO;
            return _dbSet.Add(input).Entity;
        }

        public void DeleteByTraGiaId(int id, string username)
        {
            if (_dbSet.Any(e => e.IdTraGia == id))
            {
                _dbSet.Where(e => e.IdTraGia == id)
                    .ToList()
                    .ForEach(e => {
                        e.DeletedBy = username;
                        e.DeletedDate = DateTime.Now;
                        e.Deleted = true;
                    });
            }
        }
        
        public ChiTietTraGia FindById(int id, int? IdGSaler = null, int? IdGStore = null)
        {
            return _dbSet.FirstOrDefault(d => d.Id == id && d.Deleted == DeletedBool.NO);
        }

        //public void Update(TraGia input)
        //{
        //    var bargainQuery = _dbSet.FirstOrDefault(d => d.Id == input.Id && d.Deleted == DeletedBool.NO);
        //    bargainQuery.GiaTien = input.GiaTien;
        //    bargainQuery.ModifiedDate = DateTime.Now;
        //    bargainQuery.ModifiedBy = input.ModifiedBy;
        //}

        //public PagingResult<TraGia> FindAll(FilterTraGiaDto input, int? IdGSaler = null, int? IdGStore = null)
        //{
        //    PagingResult<TraGia> result = new();

        //    var traGiaQuery = (from traGia in _dbSet
        //                       where traGia.Deleted == DeletedBool.NO
        //                       && (input.IdSanPham == null || input.IdSanPham == traGia.IdSanPham)
        //                       && (input.Status == null || input.Status == traGia.Status)
        //                       select traGia);

        //    result.TotalItems = traGiaQuery.Count();
        //    traGiaQuery = traGiaQuery.OrderByDescending(d => d.Id);
        //    if (input.PageSize != -1)
        //    {
        //        traGiaQuery = traGiaQuery.Skip(input.Skip).Take(input.PageSize);
        //    }

        //    result.Items = traGiaQuery;
        //    return result;
        //}
        public IQueryable<ChiTietTraGia> GetAll(int idTraGia)
        {
            return _dbSet.Where(b => b.IdTraGia == idTraGia && b.Deleted == DeletedBool.NO);
        }
    }
}
