using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.TraGia;
using GlobalAI.Utils;
using GlobalAI.Utils.ConstantVariables.Core;
using GlobalAI.Utils.ConstantVariables.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductRepositories
{
    public class TraGiaRepository : BaseEFRepository<TraGia>
    {
        private readonly IMapper _mapper;
        public TraGiaRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }

        public TraGia Add(TraGia input)
        {
            input.CreatedDate = DateTime.Now;
            input.ModifiedDate = DateTime.Now;
            input.Deleted = DeletedBool.NO;
            return _dbSet.Add(input).Entity;
        }

        public void Update(TraGia input)
        {
            var bargainQuery = _dbSet.FirstOrDefault(d => d.Id == input.Id && d.Deleted == DeletedBool.NO);
            bargainQuery.GiaCuoi = input.GiaCuoi;
            bargainQuery.ModifiedDate = DateTime.Now;
            bargainQuery.ModifiedBy = input.ModifiedBy;
        }

        /// <summary>
        /// Danh sach tra gia cua nguoi mua
        /// </summary>
        /// <param name="input"></param>
        /// <param name="idGSaler"></param>
        /// <param name="idGStore"></param>
        /// <returns></returns>
        public PagingResult<TraGia> FindAll(FilterTraGiaDto input, string usertype, int? userId = null )
        {
            PagingResult<TraGia> result = new();

            var traGiaQuery = (from traGia in _dbSet
                           where traGia.Deleted == DeletedBool.NO
                           && (input.IdSanPham == null || input.IdSanPham == traGia.IdSanPham)
                           && (usertype == Roles.Admin || (traGia.IdNguoiBan == userId || traGia.IdNguoiMua == userId))
                           && (input.Status == null || input.Status == traGia.Status)
                           select traGia);

            result.TotalItems = traGiaQuery.Count();
            traGiaQuery = traGiaQuery.OrderByDescending(d => d.Id);
            if (input.PageSize != -1)
            {
                traGiaQuery = traGiaQuery.Skip(input.Skip).Take(input.PageSize);
            }
            result.Items = traGiaQuery;
            return result;
        }

        public void DeleteTraGiaById(int id, string username)
        {
            var result = _dbSet.FirstOrDefault( e => e.Id == id );
            if (result != null)
            {
                result.DeletedBy = username;
                result.DeletedDate = DateTime.Now;
                result.Deleted = DeletedBool.YES;
                _dbContext.SaveChanges();
            }
        }
        public TraGia FindById(int id, int? userId = null)
        {
            return _dbSet.FirstOrDefault(d => d.Id == id && d.Deleted == DeletedBool.NO);
        }
        public TraGiaDto FindTraGiaBySanPham(int idSanPham, int? idNguoiMua , int idNguoiban) {
            var traGia = _dbSet.FirstOrDefault(tg => tg.IdSanPham == idSanPham && tg.IdNguoiBan == idNguoiban && tg.IdNguoiMua == idNguoiMua);
            return _mapper.Map<TraGiaDto>(traGia);
        }
    }
}
