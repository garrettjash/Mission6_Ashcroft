using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Mission6_GarrettAshcroft.Models
{
    public class AddMovie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }


        [ForeignKey("CategoryId")]
        [Required(ErrorMessage = "Please select a category.")]
        public int? CategoryId { get; set; }

        public Categories? Category { get; set; }

        [Required(ErrorMessage = "A movie title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, int.MaxValue, ErrorMessage ="Year must be 1888 or later.")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Edited is required")]
        public int? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Copied To Plex is required")]
        public int? CopiedToPlex { get; set; }

        public string? Notes { get; set; }


    }
}
