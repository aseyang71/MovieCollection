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
    public class IndexModel : PageModel
    {
        private readonly MovieCollection.Models.mvCollectionDbContext _context;

        public IndexModel(MovieCollection.Models.mvCollectionDbContext context)
        {
            _context = context;
        }

        public IList<NewData> NewData { get;set; }

        public async Task OnGetAsync()
        {
            NewData = await _context.NewDatas.ToListAsync();
        }
    }
}
