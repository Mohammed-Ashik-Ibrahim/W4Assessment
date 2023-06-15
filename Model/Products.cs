using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace W4Assessment.Model
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(100)]
        [NotNull]
        public string Name { get; set; }
        [StringLength(100)]
        public string Category { get; set; }
        [StringLength(20)]
        public string Color { get; set; }
        [NotNull]
        public decimal UnitPrice { get; set; }
        [NotNull]
        public int AvailableQuantity { get; set; }
    }
}
