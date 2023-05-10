using Microsoft.EntityFrameworkCore;

namespace final_ShotHussar.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TeamDbContext(serviceProvider.GetRequiredService<DbContextOptions<TeamDbContext>>()))
            {

                if (context == null || context.Players == null || context.Teams == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                if (context.Players.Any() || context.Teams.Any())
                {
                    return;
                }

                List<Player> Players = new List<Player> {
                    new Player {FirstName = "Justin", LastName = "Verlander", Position = "Pitcher", AtBat = 15, Runs = 4, RBI = 6, StrikeOuts = 2, BattingAvg = 0.365f, MLBTeam = "Test"},
                    new Player {FirstName = "Luis", LastName = "Arraez", Position = "Pitcher", AtBat = 15, Runs = 4, RBI = 6, StrikeOuts = 2, BattingAvg = 0.365f, MLBTeam = "Test"},
                    new Player {FirstName = "Max", LastName = "Scherzer", Position = "Pitcher", AtBat = 15, Runs = 4, RBI = 6, StrikeOuts = 2, BattingAvg = 0.365f, MLBTeam = "Test"}
                };
                context.AddRange(Players);

                List<Team> Teams = new List<Team> {
                    new Team {TeamName = "Team 1"},
                    new Team {TeamName = "Team 2"}
                };
                context.AddRange(Teams);
                context.SaveChanges();

                List<PlayerTeam> Fantasy = new List<PlayerTeam> {
                    new PlayerTeam {TeamID = 1, PlayerID = 2},
                    new PlayerTeam {TeamID = 1, PlayerID = 1},
                    new PlayerTeam {TeamID = 2, PlayerID = 1},
                    new PlayerTeam {TeamID = 2, PlayerID = 3}
                };
                context.AddRange(Fantasy);

                context.SaveChanges();
            }
        }
    }
}