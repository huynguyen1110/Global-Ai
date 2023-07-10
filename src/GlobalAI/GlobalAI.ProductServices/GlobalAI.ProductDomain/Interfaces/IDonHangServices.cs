using GlobalAI.DataAccess.Models;
using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductDomain.Implements;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.DonHang;
using GlobalAI.ProductEntities.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface IDonHangServices
    {
        public PagingResult<DonHangDto> FindAll(FilterDonHangDto input);
        public PagingResult<GetDonHangDto> FindAll(FindDonHangDto input);
        public DonHang CreateDonhang(AddDonHangDto input);
        public DonHang EditDonhang(int id, AddDonHangDto newDonHang);
        public void DeleteDonHangById(int id);

        public DonHangFullDto GetDonHangFull(int maDonHang);
        public List<GetDonHangDto> GetDonHangByIdGstore(int idGstore);
        public void CreateDonHangFull(AddDonHangFullDto donHangFullDto);
        public DonHang UpdateStatusDonHang(UpdateStatusDonHangDto updateDonHangDto);
        DonHang GetDonhangById(int id);
    }
}