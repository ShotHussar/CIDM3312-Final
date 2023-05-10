using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Players != null)
            {
                Player = await _context.Players.ToListAsync();
            }
        }
    }
}
