﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly ProiectGM.Data.ProiectGMContext _context;

        public IndexModel(ProiectGM.Data.ProiectGMContext context)
        {
            _context = context;
        }

        public IList<Artwork> Artwork { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Artwork != null)
            {
                Artwork = await _context.Artwork
                .Include(a => a.Author)
                .Include(a => a.Exhibition).ToListAsync();
            }
        }
    }
}
