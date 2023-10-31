using HendrixCollege.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HendrixCollege.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly HendrixCollege.Data.SchoolContext _context;

        public IndexModel(HendrixCollege.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get; set; }

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}