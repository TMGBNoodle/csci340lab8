using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages_Weapons
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Weapon> Weapon { get;set; } = default!;
        
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Weapon != null)
            {
                Weapon = await _context.Weapon.ToListAsync();
            }
                // Use LINQ to get list of genres.

        var weapons = from m in _context.Weapon
                    select m;

        if (!string.IsNullOrEmpty(SearchString))
        {
            weapons = weapons.Where(s => s.Name.Contains(SearchString));
        }

        Weapon = await weapons.ToListAsync();
        }
    }
}
