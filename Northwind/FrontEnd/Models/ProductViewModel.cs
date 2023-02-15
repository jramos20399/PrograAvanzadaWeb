
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ProductViewModel
    {

        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;

        [Display(Name ="Proveedor")]
        public int? SupplierId { get; set; }
        public IEnumerable<SupplierViewModel> Suppliers { get; set; }




        public int? CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

        public string? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
