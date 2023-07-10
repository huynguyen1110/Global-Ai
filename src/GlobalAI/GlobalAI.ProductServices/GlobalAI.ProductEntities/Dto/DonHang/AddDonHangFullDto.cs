using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.DonHang
{
    public class AddDonHangFullDto
    {
        public AddDonHangDto donHang { get; set; }

        public List<AddChiTietDonHangDto> ChiTietDonHangFullDtos { get; set; }

    }
}
