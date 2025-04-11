using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Assignment_3.Data;
using Assignment_3.Model;
using Assignment_3.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Assignment_3.Pages.Movie
{
    public class CreateModel : PageModel
    {
        private readonly Assignment_3Context _context;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(Assignment_3Context context, IWebHostEnvironment env, ILogger<CreateModel> logger)
        {
            _context = context;
            _env = env;
            _logger = logger;
        }

        [BindProperty]
        public MovieModel Movie { get; set; }

        [BindProperty]
        public IFormFile UploadImage { get; set; } // ✅ Handles file input

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Validation Failed! Errors:");
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var errors = ModelState[modelStateKey].Errors;
                    foreach (var error in errors)
                    {
                        _logger.LogError($"Validation Error in {modelStateKey}: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            _logger.LogInformation($"Saving Movie: {Movie.Title}, {Movie.ReleaseDate}, {Movie.Genre}, {Movie.Price}, {Movie.Rating}");

            // ✅ Save the uploaded image and store its path in the database
            if (UploadImage != null)
            {
                Movie.Image = PictureHelper.UploadNewImage(_env, UploadImage);
                _logger.LogInformation($"Image uploaded: {Movie.Image}");
            }
            else
            {
                Movie.Image = "/images/Movies/mov.jpg"; // ✅ Provide a default image if none is uploaded
                _logger.LogInformation("No image uploaded, using default.");
            }

            try
            {
                _context.Movie.Add(Movie);
                int changes = await _context.SaveChangesAsync();
                _logger.LogInformation($"Database Save Result: {changes} rows affected.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Database Save Failed: {ex.Message}");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
