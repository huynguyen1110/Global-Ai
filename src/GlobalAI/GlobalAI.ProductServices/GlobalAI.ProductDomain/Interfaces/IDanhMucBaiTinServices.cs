using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.BaiTin;
using GlobalAI.ProductEntities.Dto.DanhMucBaiTin;
using GlobalAI.ProductEntities.Dto.Voucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface IDanhMucBaiTinServices
    {
        DanhMucBaiTin Add(CreateDanhMucBaiTin input);
        void Delete(int id);
        PagingResult<DanhMucBaiTinDto> FindAll(FilterDanhMucBaiTinDto input);
        List<TreesDanhMucBaiTinDto> FindAllTrees(FilterDanhMucBaiTinDto input);
        DanhMucBaiTinDto GetById(int id);
        void Update(UpdateDanhMucBaiTinDto input);
    }
}
