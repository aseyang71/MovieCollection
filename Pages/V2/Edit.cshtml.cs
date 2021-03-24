using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieCollection.Models;

namespace MovieCollection.Views.V2
{
    public class EditModel : PageModel
    {
        private readonly MovieCollection.Models.mvCollectionDbContext _context;

        public EditModel(MovieCollection.Models.mvCollectionDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NewData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewDataExists(NewData.MovieId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NewDataExists(int id)
        {
            return _context.NewDatas.Any(e => e.MovieId == id);
        }
    }
}
