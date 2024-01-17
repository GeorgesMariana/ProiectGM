using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectGM.Data;
using ProiectGM.Models;

namespace ProiectGM.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectGM.Data.ProiectGMContext _context;

        public DetailsModel(ProiectGM.Data.ProiectGMContext context)
        {
            _context = context;
        }

      public Department Department { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = await _context.Department.FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            else 
            {
                Department = department;
            }
            return Page();
        }
    }
}
