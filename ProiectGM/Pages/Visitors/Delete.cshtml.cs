using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectGM.Data;
using ProiectGM.Models;

namespace ProiectGM.Pages.Visitors
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectGM.Data.ProiectGMContext _context;

        public DeleteModel(ProiectGM.Data.ProiectGMContext context)
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

            var visitor = await _context.Visitor.FirstOrDefaultAsync(m => m.Id == id);

            if (visitor == null)
            {
                return NotFound();
            }
            else 
            {
                Visitor = visitor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Visitor == null)
            {
                return NotFound();
            }
            var visitor = await _context.Visitor.FindAsync(id);

            if (visitor != null)
            {
                Visitor = visitor;
                _context.Visitor.Remove(Visitor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
