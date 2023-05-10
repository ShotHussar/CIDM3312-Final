using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using final_ShotHussar.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace final_ShotHussar.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly final_ShotHussar.Models.TeamDbContext _context;

        public DetailsModel(final_ShotHussar.Models.TeamDbContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Player Player { get; set; } = default!;
        [BindProperty]
        public int TeamIdToDelete { get; set; }

        [BindProperty]
        [Display(Name = "Team")]
        public int TeamIdToAdd { get; set; }
        public List<Team> AllTeams { get; set; } = default!;
        public SelectList TeamsDropdown { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = await _context.Players.Include(s => s.PlayerTeams!).ThenInclude(ps => ps.Team).FirstOrDefaultAsync(m => m.PlayerID == id);
            AllTeams = await _context.Teams.ToListAsync();
            TeamsDropdown = new SelectList(AllTeams, "TeamID", "TeamName");
            if (player == null)
            {
                return NotFound();
            }
            else
            {
                Player = player;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteTeamAsync(int? id)
        {
            _logger.LogWarning($"OnPost: PlayerID {id}, DROP team {TeamIdToDelete}");
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players.Include(p => p.PlayerTeams!).ThenInclude(pt => pt.Team).FirstOrDefaultAsync(p => p.PlayerID == id);

            if (player == null)
            {
                return NotFound();
            }
            else
            {
                Player = player;
            }

            PlayerTeam teamToDrop = _context.TeamPlayers.Find(TeamIdToDelete, id.Value)!;

            if (teamToDrop != null)
            {
                _context.Remove(teamToDrop);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Player not on team");
            }

            return RedirectToPage(new { id = id });
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogWarning($"OnPost: PlayerId {id}, ADD team {TeamIdToAdd}");
            if (TeamIdToAdd == 0)
            {
                ModelState.AddModelError("TeamIdToAdd", "This field is a required field.");
                return Page();
            }
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players.Include(p => p.PlayerTeams!).ThenInclude(pt => pt.Team).FirstOrDefaultAsync(p => p.PlayerID == id);
            AllTeams = await _context.Teams.ToListAsync();
            TeamsDropdown = new SelectList(AllTeams, "TeamID", "TeamName");

            if (player == null)
            {
                return NotFound();
            }
            else
            {
                Player = player;
            }

            if (!_context.TeamPlayers.Any(tp => tp.TeamID == TeamIdToAdd && tp.PlayerID == id.Value))
            {
                PlayerTeam teamToAdd = new PlayerTeam { PlayerID = id.Value, TeamID = TeamIdToAdd };
                _context.Add(teamToAdd);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Player already on team");
            }

            return RedirectToPage(new { id = id });
        }
    }
}
