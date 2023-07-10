
﻿using GlobalAI.DataAccess.Models;
using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;
using GlobalAI.ProductEntities.Dto.ThuocTinh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface ISanPhamServices
    {
        public PagingResult<SanPhamChiTietDto> FindAllHomePage(FilterSanPhamChiTietDto input);
        public List<GetSanPhamDto> GetFullSanPham();
        public PagingResult<GetSanPhamDto> FindAll(FindSanPhamDto input);
        public SanPham GetById(int input);
        public PagingResult<GetSanPhamDto> GetByCategory(string idDanhMuc, FindSanPhamByCatetoryDto input);
        public SanPham AddSanPham(AddSanPhamDto newSanPham);
        public SanPham EditSanPham(int id, AddSanPhamDto newSanPham);
        void DeleteSanPham(int id);

        public void ApproveSanPham(int id);
        public PagingResult<GetSanPhamDto> GetSanPhamByIdGstore(GetSanPhamIdGstoreDto input);
        DanhMuc GetDanhMucById(int idDanhMuc);
        DanhMuc EditDanhMuc(int id, CreateDanhMucDto newDanhMuc);
        GetSanPhamChiTietDto GetSanPhamChiTiet(int idSanPham);
        /// <summary>
        /// Get sp cho admin/gstore theo sp id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewAdminSanPhamDto GetAdminSanPhamById(int id);
    }
}
