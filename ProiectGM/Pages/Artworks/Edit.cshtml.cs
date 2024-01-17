using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectGM.Data;
using ProiectGM.Models;

namespace ProiectGM.Pages.Artworks
{
    public class EditModel : PageModel
    {
        private readonly ProiectGM.Data.ProiectGMContext _context;

        public EditModel(ProiectGM.Data.ProiectGMContext context)
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

            var artwork =  await _context.Artwork.FirstOrDefaultAsync(m => m.Id == id);
            if (artwork == null)
            {
                return NotFound();
            }
            Artwork = artwork;
           ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "Name");
           ViewData["ExhibitionId"] = new SelectList(_context.Set<Exhibition>(), "Id", "Name");
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

            _context.Attach(Artwork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtworkExists(Artwork.Id))
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

        private bool ArtworkExists(int id)
        {
          return (_context.Artwork?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
