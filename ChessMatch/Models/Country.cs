﻿using System.ComponentModel.DataAnnotations;

namespace ChessMatch.Models
{
    public class Country
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

    }
}
