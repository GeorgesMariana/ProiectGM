using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectGM.Data;
using ProiectGM.Models;

namespace ProiectGM.Pages.Exhibitions
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
        public Exhibition Exhibition { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Exhibition == null || Exhibition == null)
            {
                return Page();
            }

            _context.Exhibition.Add(Exhibition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
