using GlobalAI.Utils.Attributes;
using GlobalAI.Utils.DataUtils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;

namespace GlobalAI.ProductEntities.DataEntities
{
    [Table("DEMO_PRODUCT")]
    [Comment("Demo bảng sản phẩm")]
    public class AddProductDto
    {
        //public static string SEQ { get; } = $"SEQ_{nameof(DemoProduct).ToSnakeUpperCase()}";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ColumnSnackCase(nameof(ProductRecordId))]
        public int ProductRecordId { get; set; }

        [StringLength(100)]
        [ColumnSnackCase(nameof(ProductId))]
        public string ProductId { get; set; } = String.Empty;

        [StringLength(400)]
        [ColumnSnackCase(nameof(ProductName))]
        public string ProductName { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(Manufacturer))]
        [StringLength(200)]
        public string Manufacturer { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(Description))]
        [StringLength(1000)]
        public string Description { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(Price))]
        public int Price { get; set; }
    }
}
