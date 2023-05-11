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
                    new Player {FirstName = "Justin", LastName = "Verlander", Position = "Pitcher", AtBat = 15, Runs = 4, RBI = 6, StrikeOuts = 2, BattingAvg = 0.365f, MLBTeam = "White Sox"},
                    new Player {FirstName = "Luis", LastName = "Arraez", Position = "Pitcher", AtBat = 15, Runs = 4, RBI = 6, StrikeOuts = 2, BattingAvg = 0.365f, MLBTeam = "Texas Rangers"},
                    new Player {FirstName = "Max", LastName = "Scherzer", Position = "Pitcher", AtBat = 15, Runs = 4, RBI = 6, StrikeOuts = 2, BattingAvg = 0.365f, MLBTeam = "Chicago Cubs"},
                    new Player {FirstName = "Drugi", LastName = "Tyson", Position = "1st Basemen", AtBat = 2, Runs = 1, RBI = 1, StrikeOuts = 1, BattingAvg = .411f, MLBTeam ="Houston Astros"},
                    new Player {FirstName = "Matschke", LastName = "Croll", Position = "2nd Basemen", AtBat = 5, Runs = 6, RBI = 2, StrikeOuts = 5, BattingAvg = .376f, MLBTeam ="Kansas City Royals"},
                    new Player {FirstName = "Jeremiah", LastName = "Koppen", Position = "Short Stop", AtBat = 8, Runs = 2, RBI = 4, StrikeOuts = 2, BattingAvg = .156f, MLBTeam ="Pittsburgh Pirates"},
                    new Player {FirstName = "Florence", LastName = "McCartney", Position = "Outfielder", AtBat = 6, Runs = 9, RBI = 7, StrikeOuts = 2, BattingAvg = .350f, MLBTeam ="White Sox"},
                    new Player {FirstName = "Hyman", LastName = "Mallen", Position = "Outfielder", AtBat = 20, Runs = 2, RBI = 3, StrikeOuts = 7, BattingAvg = .500f, MLBTeam ="Chicago Cubs"},
                    new Player {FirstName = "Clare", LastName = "Barnett", Position = "Pitcher", AtBat = 13, Runs = 15, RBI = 9, StrikeOuts = 1, BattingAvg = .315f, MLBTeam ="Houston Astros"},
                    new Player {FirstName = "Innis", LastName = "Fitzsymon", Position = "Catcher", AtBat = 10, Runs = 16, RBI = 3, StrikeOuts = 5, BattingAvg = .255f, MLBTeam ="Texas Rangers"},
                    new Player {FirstName = "Kalindi", LastName = "Marzele", Position = "1st Basemen", AtBat = 12, Runs = 9, RBI = 7, StrikeOuts = 6, BattingAvg = .156f, MLBTeam ="Chicago Cubs"},
                    new Player {FirstName = "Maisey", LastName = "Joncic", Position = "2nd Basemen", AtBat = 16, Runs = 8, RBI = 7, StrikeOuts = 7, BattingAvg = .190f, MLBTeam ="Houston Astros"},
                    new Player {FirstName = "Isa", LastName = "Heading", Position = "Short Stop", AtBat = 8, Runs = 8, RBI = 1, StrikeOuts = 9, BattingAvg = .250f, MLBTeam ="Kansas City Royals"},
                    new Player {FirstName = "Rosalynd", LastName = "Vinten", Position = "Outfielder", AtBat = 5, Runs = 1, RBI = 3, StrikeOuts = 2, BattingAvg = .500f, MLBTeam ="White Sox"},
                    new Player {FirstName = "Pincas", LastName = "Torricina", Position = "Outfielder", AtBat = 8, Runs = 7, RBI = 9, StrikeOuts = 0, BattingAvg = .150f, MLBTeam ="Pittsburgh Pirates"},
                    new Player {FirstName = "Sayers", LastName = "Reder", Position = "Catcher", AtBat = 2, Runs = 3, RBI = 7, StrikeOuts = 1, BattingAvg = .311f, MLBTeam ="New York Yankees"},
                    new Player {FirstName = "Sydney", LastName = "Ick", Position = "3rd Basemen", AtBat = 16, Runs = 1, RBI = 8, StrikeOuts = 5, BattingAvg = .333f, MLBTeam ="Texas Rangers"},
                    new Player {FirstName = "Lauren", LastName = "Alves", Position = "1st Basemen", AtBat = 8, Runs = 7, RBI = 3, StrikeOuts = 1, BattingAvg = .100f, MLBTeam ="Houston Astros"},
                    new Player {FirstName = "Audie", LastName = "Pateman", Position = "2nd Basemen", AtBat = 20, Runs = 15, RBI = 1, StrikeOuts = 7, BattingAvg = .140f, MLBTeam ="Pittsburgh Pirates"},
                    new Player {FirstName = "Josee", LastName = "Richie", Position = "Short Stop", AtBat = 19, Runs = 12, RBI = 7, StrikeOuts = 4, BattingAvg = .156f, MLBTeam ="White Sox"},
                    new Player {FirstName = "Lalonde", LastName = "Sunny", Position = "Outfielder", AtBat = 3, Runs = 8, RBI = 8, StrikeOuts = 9, BattingAvg = .123f, MLBTeam ="Chicago Cubs"},
                    new Player {FirstName = "Tate", LastName = "Mariette", Position = "Outfielder", AtBat = 6, Runs = 14, RBI = 6, StrikeOuts = 1, BattingAvg = .234f, MLBTeam ="New York Yankees"},
                    new Player {FirstName = "Camille", LastName = "Haryngton", Position = "3rd Basemen", AtBat = 9, Runs = 10, RBI = 1, StrikeOuts = 7, BattingAvg = .345f, MLBTeam ="New York Yankees"},
                    new Player {FirstName = "Wash", LastName = "McCroary", Position = "2nd Basemen", AtBat = 14, Runs = 4, RBI = 7, StrikeOuts = 3, BattingAvg = .238f, MLBTeam ="Texas Rangers"},
                    new Player {FirstName = "Rois", LastName = "Olligan", Position = "3rd Basemen", AtBat = 6, Runs = 2, RBI = 3, StrikeOuts = 2, BattingAvg = .214f, MLBTeam ="Kansas City Royals"},
                    new Player {FirstName = "Dylan", LastName = "Morgan", Position = "1st Basemen", AtBat = 8, Runs = 6, RBI = 1, StrikeOuts = 1, BattingAvg = .128f, MLBTeam ="Pittsburgh Pirates"}
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