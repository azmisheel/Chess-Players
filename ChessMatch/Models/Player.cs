using System.ComponentModel.DataAnnotations;

namespace ChessMatch.Models
{
    public class Player
    {

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Player Name")]
        public string Name { get; set; }

        [Required]
        [Range(100, 3000)]
        [Display(Name = "Player Rating")]
        public int Rating { get; set; }

        [Required]
        [Range(10, 100)]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Wins")]
        public int Wins { get; set; } = 0;

        [Required]
        [Display(Name = "Losses")]
        public int Losses { get; set; } = 0;

        [Required]
        [Display(Name = "Draws")]
        public int Draws { get; set; } = 0;

        [Required]
        [Display(Name = "Country")]
        public int CountryID { get; set; }

        [Display(Name = "Country")]
        public Country Country { get; set; }
    }
}
