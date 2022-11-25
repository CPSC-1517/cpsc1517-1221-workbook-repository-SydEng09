using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestWindSystem.Entities
{
    [Table("Products")]

    public class Product
    {
        [Column("ProductID")]
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        [Column(TypeName ="money")]
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public bool Discontinued { get; set; }
        public int UnitsOnOrder { get; set; }
        public string QuantityPerUnit { get; set; } = null!;
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;
        
    }
}
