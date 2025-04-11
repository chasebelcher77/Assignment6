using Assignment_3.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.EntityFrameworkCore;
using Assignment_3.Model;

namespace Assignment_3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Assignment_3Context _context;
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<MovieModel> Movies { get; set; } = new List<MovieModel>();

        public IndexModel(ILogger<IndexModel> logger, Assignment_3Context context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Movies = await _context.Movie.ToListAsync();
        }
    }
}
