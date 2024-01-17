using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectGM.Data;
using ProiectGM.Models;

namespace ProiectGM.Pages.Visitors
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
            return Page();
        }

        [BindProperty]
        public Visitor Visitor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Visitor == null || Visitor == null)
            {
                return Page();
            }

            _context.Visitor.Add(Visitor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
