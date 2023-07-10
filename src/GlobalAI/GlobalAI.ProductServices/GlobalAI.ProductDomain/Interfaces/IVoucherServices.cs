using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.Voucher;
using GlobalAI.ProductEntities.Dto.VoucherChiTiet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface IVoucherServices
    {

        VoucherChiTiet AddVoucherChiTiet(CreateVoucherChiTietDto input);

        Voucher Add(CreateVoucherDto input);
        void Delete(int id);
        PagingResult<VoucherDto> FindAll(FilterVoucherDto input);
        VoucherDto GetById(int id);
        void Update(UpdateVoucherDto input);
    }
}
