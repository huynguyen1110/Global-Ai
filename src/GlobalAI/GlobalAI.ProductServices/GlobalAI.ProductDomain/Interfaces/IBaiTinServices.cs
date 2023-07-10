using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.BaiTin;
using GlobalAI.ProductEntities.Dto.ChiTietTraGia;
using GlobalAI.ProductEntities.Dto.TraGia;
using GlobalAI.ProductEntities.Dto.Voucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    
    public interface IBaiTinServices
    {
        BaiTin Add(CreateBaiTin input);
        void Delete(int id);
        PagingResult<BaiTinDto> FindAll(FilterBaiTinDto input);
        BaiTinDto GetById(int id);
        BaiTinDto GetBySlug(string slug);
        void Update(UpdateBaiTinDto input);
        void Approve(ApproveBaiTinDto input);
    }
}
