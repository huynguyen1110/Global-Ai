using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.DemoProduct
{
    public class AddDemoProductDto
    {
        private string _productName {get;set;}
        private string _manufacturer {get;set;}
        private string _description {get;set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên sản phẩm không được bỏ trống")]
        public string ProductName { get => _productName; set => _productName = value?.Trim(); }
        
        public string Manufacturer { get => _manufacturer; set => _manufacturer = value?.Trim(); }

        public string Description { get => _description; set => _description = value?.Trim(); }

        public int Price { get; set; }
    }
}
