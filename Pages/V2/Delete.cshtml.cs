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
    public class DeleteModel : PageModel
    {
        private readonly MovieCollection.Models.mvCollectionDbContext _context;

        public DeleteModel(MovieCollection.Models.mvCollectionDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewData = await _context.NewDatas.FindAsync(id);

            if (NewData != null)
            {
                _context.NewDatas.Remove(NewData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
