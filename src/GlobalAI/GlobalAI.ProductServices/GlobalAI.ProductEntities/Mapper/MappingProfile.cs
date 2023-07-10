using AutoMapper;
using GlobalAI.ProductEntities.Dto.DonHang;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.ChiTietTraGia;
using GlobalAI.ProductEntities.Dto.GioHang;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.TraGia;
using System.Collections.Generic;
using GlobalAI.ProductEntities.Dto.BaiTin;
using GlobalAI.ProductEntities.Dto.DanhMucBaiTin;
using GlobalAI.ProductEntities.Dto.Voucher;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using GlobalAI.ProductEntities.Dto.VoucherChiTiet;
using GlobalAI.ProductEntities.Dto.DanhMucThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;

namespace GlobalAI.ProductEntities.DataEntities.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Đưa hết các cấu hình bạn muốn map giữa các object vào đây
            // Thuộc tính FullName trong UserViewModel được kết hợp từ FirstName và LastName trong User
            CreateMap<SanPham, AddSanPhamDto>().ReverseMap();
            CreateMap<SanPham, GetSanPhamChiTietDto>().ReverseMap();
            CreateMap<GetSanPhamChiTietDto, SanPham>().ReverseMap();
            CreateMap<SanPham, GetSanPhamDto>().ReverseMap();
            CreateMap<SanPham, ViewAdminSanPhamDto>().ReverseMap();
            CreateMap<SanPhamChiTiet, GetSanPhamChiTietDto>().ReverseMap();
            CreateMap<SanPhamChiTiet, ViewSanPhamChiTietDto>().ReverseMap();
            CreateMap<GetSanPhamDto, SanPham>().ReverseMap();

            CreateMap<DonHang, AddDonHangDto>().ReverseMap();
            CreateMap<DonHang, AddDonHangDto>().ReverseMap();
            CreateMap<SanPhamChiTiet, AddSanPhamChiTietDto>().ReverseMap();
            CreateMap<SanPham, SanPhamChiTietDto>().ReverseMap();
            CreateMap<SanPhamChiTiet, UpdateSanPhamChiTietDto>().ReverseMap();
            CreateMap<SanPhamChiTietDto, SanPhamChiTiet>().ReverseMap();

            CreateMap<ChiTietDonHang, AddChiTietDonHangDto>().ReverseMap();
            CreateMap<ChiTietDonHang, EditChiTietDonHangDto>().ReverseMap();
            CreateMap<GetChiTietDonHangDto, ChiTietDonHang>().ReverseMap();
            CreateMap<GetGioHangDto, GioHang>().ReverseMap();
            CreateMap<ChiTietDonHang, GetChiTietDonHangDto>().ReverseMap();
            CreateMap<ChiTietDonHang, DonHangChiTietDto>().ReverseMap();
            CreateMap<DonHang, DonHangDto>().ReverseMap();
            //Giỏ hàng
            CreateMap<GioHang, EditGioHangDto>().ReverseMap();
            CreateMap<GioHang, AddGioHangDto>().ReverseMap();
            CreateMap<GioHang, GetGioHangDto>().ReverseMap();
            CreateMap<GioHang, AddGioHangChiTietDto>().ReverseMap();
            CreateMap<GioHang, EditGioHangChiTietDto>().ReverseMap();
            CreateMap<GioHang, GioHang>().ReverseMap();

            CreateMap<TraGia, AddTraGiaDto>().ReverseMap();
            CreateMap<TraGia, UpdateTraGiaDto>().ReverseMap();
            CreateMap<TraGia, ApproveTraGiaDto>().ReverseMap();
            CreateMap<GetDonHangDto, DonHang>().ReverseMap();
            CreateMap<ChiTietTraGia, AddTraGiaDto>().ReverseMap();
            CreateMap<ChiTietTraGia, AddChiTietTraGiaDto>().ReverseMap();
            CreateMap<ChiTietTraGia, ChiTietTraGiaDto>().ReverseMap();
            CreateMap<TraGia, TraGiaDto>().ReverseMap();

            CreateMap<BaiTin, CreateBaiTin>().ReverseMap();
            CreateMap<BaiTin, UpdateBaiTinDto>().ReverseMap();
            CreateMap<BaiTin, BaiTinDto>().ReverseMap();
            CreateMap<DanhMucBaiTin, CreateDanhMucBaiTin>().ReverseMap();
            CreateMap<DanhMucBaiTin, UpdateDanhMucBaiTinDto>().ReverseMap();
            CreateMap<DanhMucBaiTin, DanhMucBaiTinDto>().ReverseMap();
            CreateMap<TreesDanhMucBaiTinDto, DanhMucBaiTin>().ReverseMap();

            CreateMap<DanhMuc, CreateDanhMucDto>().ReverseMap();
            CreateMap<DanhMuc, DanhMucDto>().ReverseMap();

            CreateMap<Voucher, CreateVoucherDto>().ReverseMap();
            CreateMap<Voucher, VoucherDto>().ReverseMap();
            CreateMap<Voucher, UpdateVoucherDto>().ReverseMap();
            CreateMap<VoucherChiTiet, CreateVoucherChiTietDto>().ReverseMap();
            CreateMap<VoucherChiTiet, VoucherChiTietDto>().ReverseMap();
            CreateMap<VoucherChiTiet, UpdateVoucherChiTietDto>().ReverseMap();
            CreateMap<VoucherChiTiet, CreateVoucherDto>().ReverseMap();

            CreateMap<DanhMuc, CreateDanhMucDto>().ReverseMap();
            CreateMap<DanhMucThuocTinh, AddDanhMucThuocTinhDto>().ReverseMap();
            CreateMap<DanhMucThuocTinh, ViewDanhMucThuocTinhDto>().ReverseMap();
            CreateMap<DanhMucThuocTinh, UpdateDanhMucThuocTinhDto>().ReverseMap();
            CreateMap<DanhMucThuocTinh, ViewSingleDanhMucThuocTinhDto>().ReverseMap();
            CreateMap<ThuocTinh, AddThuocTinhDto>().ReverseMap();
            CreateMap<ThuocTinh, ViewThuocTinhDto>().ReverseMap();
            CreateMap<ThuocTinh, GetThuocTinhDto>().ReverseMap();
            CreateMap<ThuocTinhGiaTri, AddThuocTinhGiaTriDto>().ReverseMap();
            CreateMap<ThuocTinhGiaTri, ViewThuocTinhGiaTriDto>().ReverseMap();
            CreateMap<ThuocTinhGiaTri, SanPhamChiTietThuocTinh>().ReverseMap();




        }
    }
}
