using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.Product;

namespace GlobalAI.ProductEntities.Dto.DonHang
{
    public class DonHangFullDto
    {
        public List<GetChiTietDonHangDto> ChiTietDonHangFullDtos { get; set; }
        public GetDonHangDto donHang { get; set; }
    }

}
