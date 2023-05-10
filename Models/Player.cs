using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace final_ShotHussar.Models
{
    public class Player
    {
        public int PlayerID {get; set;}
        
        [Display(Name = "First Name")]
        [Required]
        public string FirstName {get; set;} = string.Empty;
        [Display(Name = "Last Name")]
        [Required]
        public string LastName {get; set;} = string.Empty;
        //public string Position {get; set;} = string.Empty;
        //public int AtBat {get; set;}
        //public int Runs {get; set;}
        //public int RBI {get; set;}
        //public int StrikeOuts {get; set;}
        //public float BattingAvg {get; set;}
        //public string MLBTeam {get; set;} = string.Empty;
        public List<PlayerTeam>? PlayerTeams {get; set;} = default!;
    }
}