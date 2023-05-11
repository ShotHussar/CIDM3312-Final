using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace final_ShotHussar.Models
{
    public class Player
    {
        public int PlayerID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;

        [Display(Name = "At Bats")]
        [Required]
        public int AtBat { get; set; }

        [Required]
        public int Runs { get; set; }

        [Required]
        public int RBI { get; set; }

        [Required]
        [Display(Name = "Strike Outs")]
        public int StrikeOuts { get; set; }

        [Required]
        [Display(Name = "Batting Average")]
        [Range(0f, .5f)]
        public float BattingAvg { get; set; }

        [Required]
        public string MLBTeam { get; set; } = string.Empty;

        public List<PlayerTeam>? PlayerTeams { get; set; } = default!;
    }
}