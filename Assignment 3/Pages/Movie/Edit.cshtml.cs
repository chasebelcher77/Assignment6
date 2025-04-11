using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment_3.Data;
using Assignment_3.Model;
using Assignment_3.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Assignment_3.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly Assignment_3Context _context;
        private readonly IWebHostEnvironment _env; 

        public EditModel(Assignment_3Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [BindProperty]
        public MovieModel Movie { get; set; }

        [BindProperty]
        public IFormFile UploadImage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var movieToUpdate = await _context.Movie.FindAsync(Movie.Id);

            if (movieToUpdate == null)
            {
                return NotFound();
            }

    
            if (UploadImage != null)
            {
                movieToUpdate.Image = PictureHelper.UploadNewImage(_env, UploadImage);
            }

            
            movieToUpdate.Title = Movie.Title;
            movieToUpdate.ReleaseDate = Movie.ReleaseDate;
            movieToUpdate.Genre = Movie.Genre;
            movieToUpdate.Price = Movie.Price;
            movieToUpdate.Rating = Movie.Rating;

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}

