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

namespace ProiectGM.Pages.Visitors
{
    public class EditModel : PageModel
    {
        private readonly ProiectGM.Data.ProiectGMContext _context;

        public EditModel(ProiectGM.Data.ProiectGMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Visitor Visitor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Visitor == null)
            {
                return NotFound();
            }

            var visitor =  await _context.Visitor.FirstOrDefaultAsync(m => m.Id == id);
            if (visitor == null)
            {
                return NotFound();
            }
            Visitor = visitor;
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

            _context.Attach(Visitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorExists(Visitor.Id))
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

        private bool VisitorExists(int id)
        {
          return (_context.Visitor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
