using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectGM.Data;
using ProiectGM.Models;

namespace ProiectGM.Pages.Artworks
{
    public class CreateModel : PageModel
    {
        private readonly ProiectGM.Data.ProiectGMContext _context;

        public CreateModel(ProiectGM.Data.ProiectGMContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "Name");
        ViewData["ExhibitionId"] = new SelectList(_context.Set<Exhibition>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Artwork Artwork { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Artwork == null || Artwork == null)
            {
                return Page();
            }

            _context.Artwork.Add(Artwork);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
