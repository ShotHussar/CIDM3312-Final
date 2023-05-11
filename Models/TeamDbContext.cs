using Microsoft.EntityFrameworkCore;

namespace final_ShotHussar.Models
{
    public class TeamDbContext : DbContext
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerTeam>().HasKey(p => new {p.TeamID, p.PlayerID});
        }

        public DbSet<Team> Teams {get; set;} = default!;
        public DbSet<Player> Players {get; set;} = default!;
        public DbSet<PlayerTeam> TeamPlayers {get; set;} = default!;

    }
}