using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectGM.Data;
using ProiectGM.Models;

namespace ProiectGM.Pages.Exhibitions
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectGM.Data.ProiectGMContext _context;

        public DetailsModel(ProiectGM.Data.ProiectGMContext context)
        {
            _context = context;
        }

      public Exhibition Exhibition { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Exhibition == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibition.FirstOrDefaultAsync(m => m.Id == id);
            if (exhibition == null)
            {
                return NotFound();
            }
            else 
            {
                Exhibition = exhibition;
            }
            return Page();
        }
    }
}
