using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.Entities
{
    [Table(name:"Categories")]
    public class Category
    {
        [Key]
        [Column(name:"CategoryID")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Category Name is required")]
        [MaxLength(15, ErrorMessage ="Max Lenght is 15 characters")]
        public string CategoryName { get; set; } = null!;
        [Column(TypeName = "ntext")] //only use column if it isnt the same name as in the database
        public string? Description { get; set; }
        [Column(TypeName ="varbinary")]
        public byte[]? Picture { get; set; }
        public string? PictureMimeType { get; set; }

    }
}
