using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DemoProduct;
using GlobalAI.EntitiesBase.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface IDemoProductServices
    {
        /// <summary>
        /// Tạo demo product
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AddProductDto Add(AddDemoProductDto dto);

        /// <summary>
        /// Get list demo product phân trang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<AddProductDto> FindAll(FindDemoProductDto input);
    }
}
