using GlobalAI.DataAccess.Models;
using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface IChiTietDonHangServices
    {
        public ChiTietDonHang CreateChiTietDonhang(AddChiTietDonHangDto input);


        public void DeleteChiTietDonhangById(int id);

        public ChiTietDonHang EditChiTietDonhang(int idDonHang, EditChiTietDonHangDto newDonHang);
        List<GetChiTietDonHangDto> getChiTietDonHang();
        GetChiTietDonHangDto getChiTietDonhangById(int id);
    }
}