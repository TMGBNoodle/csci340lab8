using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages_Weapons
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public DeleteModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Weapon Weapon { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Weapon == null)
            {
                return NotFound();
            }

            var weapon = await _context.Weapon.FirstOrDefaultAsync(m => m.ID == id);

            if (weapon == null)
            {
                return NotFound();
            }
            else 
            {
                Weapon = weapon;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Weapon == null)
            {
                return NotFound();
            }
            var weapon = await _context.Weapon.FindAsync(id);

            if (weapon != null)
            {
                Weapon = weapon;
                _context.Weapon.Remove(Weapon);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
