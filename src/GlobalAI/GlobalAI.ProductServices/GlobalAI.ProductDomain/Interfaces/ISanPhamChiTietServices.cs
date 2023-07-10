
﻿using GlobalAI.DataAccess.Models;
using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMuc;
using GlobalAI.ProductEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.SanPhamChiTiet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface ISanPhamChiTietServices
    {
        /// <summary>
        /// Thêm sản phẩm chi tiết
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Sản phẩm vừa thêm vào</returns>
        public void AddSanPhamChiTiet(AddListSanPhamChiTietDto dto);

        /// <summary>
        /// Cập nhật sản phẩm chi tiết
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateSanPhamChiTiet(UpdateSanPhamChiTietDto dto);

        /// <summary>
        /// Xóa mềm sp chi tiết
        /// </summary>
        /// <param name="id"></param>
        public void DeleteSanPhamChiTiet(int id);
        SanPhamChiTietDto GetSanPhamChiTietByIdSanPhamGttt(int idSanPham, List<int> gttt);
        SanPhamChiTietDto GetSanPhamChiTietByIdSanPham(int idSanPham);
    }
}
