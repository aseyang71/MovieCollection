using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieCollection.Models;

namespace MovieCollection.Views.V2
{
    public class DetailsModel : PageModel
    {
        private readonly MovieCollection.Models.mvCollectionDbContext _context;

        public DetailsModel(MovieCollection.Models.mvCollectionDbContext context)
        {
            _context = context;
        }

        public NewData NewData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewData = await _context.NewDatas.FirstOrDefaultAsync(m => m.MovieId == id);

            if (NewData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
