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

namespace ProiectGM.Pages.Exhibitions
{
    public class EditModel : PageModel
    {
        private readonly ProiectGM.Data.ProiectGMContext _context;

        public EditModel(ProiectGM.Data.ProiectGMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exhibition Exhibition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Exhibition == null)
            {
                return NotFound();
            }

            var exhibition =  await _context.Exhibition.FirstOrDefaultAsync(m => m.Id == id);
            if (exhibition == null)
            {
                return NotFound();
            }
            Exhibition = exhibition;
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

            _context.Attach(Exhibition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExhibitionExists(Exhibition.Id))
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

        private bool ExhibitionExists(int id)
        {
          return (_context.Exhibition?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
