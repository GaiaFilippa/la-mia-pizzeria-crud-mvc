using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [MaxLength(300)]
        public string Image { get; set; }

        public float Price { get; set; }

        public Pizza(string name, string description, string image, float price)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }
    }
}
