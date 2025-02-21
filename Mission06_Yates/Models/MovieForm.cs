using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Yates.Models
{
    public class MovieForm
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; } // Foreign Key
        public Category? Category { get; set; } // Navigation Property

        [Required(ErrorMessage = "Sorry, you need to enter a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Sorry, you need to enter a year between 1888 and 2025")]
        [Range(1888,2025)]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "Sorry, you need to choose if it's been edited'")]
        public int Edited { get; set; }
        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Sorry, you need to choose if it is copied to Plex")]
        public int CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
