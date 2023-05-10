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
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly final_ShotHussar.Models.TeamDbContext _context;

        public EditModel(final_ShotHussar.Models.TeamDbContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Player Player { get; set; } = default!;

        public List<Team> Teams {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player =  await _context.Players.Include(p => p.PlayerTeams!).ThenInclude(pt => pt.Team).FirstOrDefaultAsync(p => p.PlayerID == id);

            Teams = _context.Teams.ToList();
            if (player == null)
            {
                return NotFound();
            }
            Player = player;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var playerToUpdate = await _context.Players.Include(p => p.PlayerTeams!).ThenInclude(pt => pt.Team).FirstOrDefaultAsync(p => p.PlayerID == Player.PlayerID);
            if (playerToUpdate != null)
            {
                playerToUpdate.FirstName = Player.FirstName;
                playerToUpdate.LastName = Player.LastName;
                playerToUpdate.Position = Player.Position;
                playerToUpdate.AtBat = Player.AtBat;
                playerToUpdate.Runs = Player.Runs;
                playerToUpdate.RBI = Player.RBI;
                playerToUpdate.StrikeOuts = Player.StrikeOuts;
                playerToUpdate.BattingAvg = Player.BattingAvg;
                playerToUpdate.MLBTeam = Player.MLBTeam;

                //UpdatePlayerTeams(selectTeams, playerToUpdate);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(Player.PlayerID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlayerExists(int id)
        {
          return (_context.Players?.Any(e => e.PlayerID == id)).GetValueOrDefault();
        }

        /*private void UpdateStudentTeams(int[] selectedTeams, Player playerToUpdate)
        {
            if (selectedTeams == null)
            {
                playerToUpdate.PlayerTeams = new List<PlayerTeam>();
                return;
            }

            List<int> currentTeams = playerToUpdate.PlayerTeams!.Select(t => t.TeamID).ToList();
            List<int> selectedTeamsList = selectedTeams.ToList();

            foreach (var team in _context.Teams)
            {
                if (selectedTeamsList.Contains(team.TeamID))
                {
                    if (!currentTeams.Contains(team.TeamID))
                    {
                        studentToUpdate.StudentCourses!.Add(
                            new StudentCourse { StudentID = studentToUpdate.StudentID, CourseID = course.CourseID }
                        );
                        _logger.LogWarning($"Student {studentToUpdate.FirstName} {studentToUpdate.LastName} ({studentToUpdate.StudentID}) - ADD {course.CourseID} {course.Description}");
                    }
                }
                else
                {
                    if (currentCourses.Contains(course.CourseID))
                    {
                        // Remove course here
                        StudentCourse courseToRemove = studentToUpdate.StudentCourses!.SingleOrDefault(s => s.CourseID == course.CourseID)!;
                        _context.Remove(courseToRemove);
                        _logger.LogWarning($"Student {studentToUpdate.FirstName} {studentToUpdate.LastName} ({studentToUpdate.StudentID}) - DROP {course.CourseID} {course.Description}");
                    }
                }
            }
        }*/
    }
}
