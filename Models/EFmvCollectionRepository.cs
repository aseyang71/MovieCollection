using System;
using System.Linq;

namespace MovieCollection.Models
{
    public class EFmvCollectionRepository : mvCollectionRepository
    {
        private mvCollectionDbContext _context;

        // Constructor
        public EFmvCollectionRepository (mvCollectionDbContext context)
        {
            _context = context;  
        }

        public IQueryable<NewData> NewDatas => _context.Newdatas;
    }
}
