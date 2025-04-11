using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Assignment_3.Data;

using Microsoft.EntityFrameworkCore;
using Assignment_3.Model;
using Assignment_3.Data;
using Microsoft.AspNetCore.Authorization;


[Authorize]
public class DetailsModel : PageModel
{
    private readonly Assignment_3Context _context;

    public DetailsModel(Assignment_3Context context)
    {
        _context = context;
    }

    public MovieModel? Movie { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

        if (Movie == null)
        {
            return NotFound();
        }

        return Page();
    }
}
