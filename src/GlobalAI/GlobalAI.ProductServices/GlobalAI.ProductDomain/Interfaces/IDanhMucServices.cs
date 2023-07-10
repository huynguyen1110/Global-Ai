using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface IDanhMucServices
    {
        DanhMuc Add(CreateDanhMucDto input);
        void Delete(int id);
        void UpdateDanhMucHomePage(DanhMucHomePageDto input);
        PagingResult<DanhMucDto> FindAll(FilterDanhMucDto input);
        DanhMucDto GetById(int id);
    }
}
