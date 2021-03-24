using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCollection.Models;

namespace MovieCollection.Views.V2
{
    public class CreateModel : PageModel
    {
        private readonly MovieCollection.Models.mvCollectionDbContext _context;

        public CreateModel(MovieCollection.Models.mvCollectionDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NewData NewData { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NewDatas.Add(NewData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
