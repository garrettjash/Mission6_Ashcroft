using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_GarrettAshcroft.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        public string Category { get; set; }
    }
}
