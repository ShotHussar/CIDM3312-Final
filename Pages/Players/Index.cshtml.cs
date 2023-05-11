using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using final_ShotHussar.Models;

namespace final_ShotHussar.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly final_ShotHussar.Models.TeamDbContext _context;

        public IndexModel(final_ShotHussar.Models.TeamDbContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNum { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public int totalPlayers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CurrentSort { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? PlayerName { get; set; }


        public async Task OnGetAsync()
        {
            if (_context.Players != null)
            {
                var query = _context.Players.Select(p => p);

                totalPlayers = _context.Players.Count();

                if (!string.IsNullOrEmpty(SearchString))
                {
                    query = query.Where(p => p.FirstName.Contains(SearchString));
                }

                switch (CurrentSort)
                {
                    case "first_asc":
                        query = query.OrderBy(p => p.FirstName);
                        break;
                    case "first_desc":
                        query = query.OrderByDescending(p => p.FirstName);
                        break;
                    case "last_asc":
                        query = query.OrderBy(p => p.LastName);
                        break;
                    case "last_desc":
                        query = query.OrderByDescending(p => p.LastName);
                        break;
                    case "pos_asc":
                        query = query.OrderBy(p => p.Position);
                        break;
                    case "pos_desc":
                        query = query.OrderByDescending(p => p.Position);
                        break;
                    case "avg_asc":
                        query = query.OrderBy(p => p.BattingAvg);
                        break;
                    case "avg_desc":
                        query = query.OrderByDescending(p => p.BattingAvg);
                        break;
                    case "team_asc":
                        query = query.OrderBy(p => p.MLBTeam);
                        break;
                    case "team_desc":
                        query = query.OrderByDescending(p => p.MLBTeam);
                        break;
                }


                Player = await query.Skip((PageNum - 1) * PageSize).Take(PageSize).Include(p => p.PlayerTeams!).ThenInclude(pt => pt.Team).ToListAsync();
            }
        }
    }
}
