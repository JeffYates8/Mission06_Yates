using System.ComponentModel.DataAnnotations;

namespace Mission06_Yates.Models
{
    public class MovieForm
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
