using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment_3.Data;
using Assignment_3.Model;

namespace Assignment_3.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly Assignment_3.Data.Assignment_3Context _context;

        public DetailsModel(Assignment_3.Data.Assignment_3Context context)
        {
            _context = context;
        }

        public MovieModel Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
