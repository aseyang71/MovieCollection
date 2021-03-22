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

        // Listing 10-13

        public IQueryable<NewData> newDatas => throw new NotImplementedException();

        public void CreateNewData(NewData newData)
        {
            _context.Add(newData);
            _context.SaveChanges();
        }

        public void DeleteNewData(NewData newData)
        {
            _context.Remove(newData);
            _context.SaveChanges();
        }

        public void SaveNewData(NewData newData)
        {
            _context.SaveChanges();
        }
    }
}
