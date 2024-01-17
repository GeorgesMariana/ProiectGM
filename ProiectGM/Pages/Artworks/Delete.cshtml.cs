using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectGM.Data;
using ProiectGM.Models;

namespace ProiectGM.Pages.Artworks
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectGM.Data.ProiectGMContext _context;

        public DeleteModel(ProiectGM.Data.ProiectGMContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Artwork Artwork { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Artwork == null)
            {
                return NotFound();
            }

            var artwork = await _context.Artwork.FirstOrDefaultAsync(m => m.Id == id);

            if (artwork == null)
            {
                return NotFound();
            }
            else 
            {
                Artwork = artwork;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Artwork == null)
            {
                return NotFound();
            }
            var artwork = await _context.Artwork.FindAsync(id);

            if (artwork != null)
            {
                Artwork = artwork;
                _context.Artwork.Remove(Artwork);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
