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
        
    }
}
