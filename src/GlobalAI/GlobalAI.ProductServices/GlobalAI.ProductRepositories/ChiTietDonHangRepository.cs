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
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.DemoEntities.Dto.ChiTietDonHang;
using Microsoft.AspNetCore.Mvc;

using System.Net.Mail;

namespace GlobalAI.ProductRepositories
{
    public class ChiTietDonHangRepository : BaseEFRepository<ChiTietDonHang>
    {
        private readonly IMapper _mapper;
        public ChiTietDonHangRepository(DbContext dbContext, ILogger logger, IMapper mapper, string seqName = null) : base(dbContext, logger, seqName)
        {
            _mapper = mapper;
        }

        public List<ChiTietDonHang> GetAllByDonHangId(int idDonHang)
        {
            var result = _dbSet.Where(e => e.IdDonHang == idDonHang);
            return result.ToList();
        }
        /// <summary>
        /// Get Chi tiết đơn hàng
        /// </summary>
        /// <returns></returns>
        public List<ChiTietDonHang> GetChiTietDonHang()
        {
            var result = _dbSet.AsNoTracking().Where(s => !s.Deleted).ToList();
            return result;
        }
        /// <summary>
        /// Get chi tiết đơn hàng theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ChiTietDonHang GetChiTietDonHangById(int id)
        {
            var result = _dbSet.FirstOrDefault(s => s.Id == id);
            return result;
        }

        /// <summary>
        /// Tạo chi tiết đơn hàng
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ChiTietDonHang CreateChiTietDonHang(ChiTietDonHang input)
        {
            _dbSet.Add(input);
            return input;
        }
        /// <summary>
        /// Tìm sản phẩm cần sửa, xóa
        /// </summary>
        public ChiTietDonHang FindChiTietDonHang(int maDonHang)
        {
            var donHang = _dbSet.FirstOrDefault(sp => sp.Id == maDonHang);
            if (donHang != null && donHang.Deleted == true)
            {
                return null;
            }
            return donHang;

        }
        public ChiTietDonHang EditChiTietDonHang(ChiTietDonHang oldDonHang, EditChiTietDonHangDto newDonHang)
        {
            _mapper.Map(newDonHang, oldDonHang);
            return oldDonHang;
        }
        public List<ChiTietDonHang> GetListChiTietDonHang(int maDonHang)
        {
            return _dbSet.Where(dh => dh.IdDonHang == maDonHang).ToList();
        }
        public void DeleteChiTietDonHangById(int id)
        {
            var Result = _dbSet.FirstOrDefault((Order) => Order.Id == id);
            if (Result != null)
            {
                Result.Deleted = true;
                _dbContext.SaveChanges();
            }
        }

    }
}