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
    public class DetailsModel : PageModel
    {
        private readonly ProiectGM.Data.ProiectGMContext _context;

        public DetailsModel(ProiectGM.Data.ProiectGMContext context)
        {
            _context = context;
        }

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
    }
}
