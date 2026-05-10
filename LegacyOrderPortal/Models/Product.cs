using System.ComponentModel.DataAnnotations;

namespace LegacyOrderPortal.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [StringLength(300)]
        public string Description { get; set; }
    }
}
