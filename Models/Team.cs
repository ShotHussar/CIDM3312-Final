using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace final_ShotHussar.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName {get; set;} = string.Empty;

    }

    public class PlayerTeam
    {
        public int TeamID {get; set;}
        public int PlayerID {get; set;}
        public Player Player {get; set;} = default!;
        public Team Team {get; set;} = default!;
    }
}