using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DanhMucThuocTinh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface IDanhMucThuocTinhServices
    {
        /// <summary>
        /// Thêm danh mục thuộc tính
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public DanhMucThuocTinh Add(AddDanhMucThuocTinhDto dto);

        /// <summary>
        /// List danh mục thuộc tính phân trang
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PagingResult<ViewDanhMucThuocTinhDto> FindDanhMucThuocTinh(FindDanhMucThuocTinhDto dto);

        /// <summary>
        /// Find danh mục thuộc tính theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewSingleDanhMucThuocTinhDto FindById(int id);

        /// <summary>
        /// Xoá danh mục bài viết
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id);

        /// <summary>
        /// Cập nhật danh mục bài viết
        /// </summary>
        /// <param name="dto"></param>
        public void Update(UpdateDanhMucThuocTinhDto dto);
    }
}
