using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment_3.Data;
using Assignment_3.Model;

namespace Assignment_3.Pages.Movie
{
    public class IndexModel : PageModel
    {
        private readonly Assignment_3.Data.Assignment_3Context _context;

        public IndexModel(Assignment_3.Data.Assignment_3Context context)
        {
            _context = context;
        }

        public IList<MovieModel> Movie { get;set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            var movies = from m in _context.Movie 
                         select m;
           

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            Movie = await movies.ToListAsync();
        }
    }
}
