using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class mvCollectionDbContext : DbContext
    {
        public mvCollectionDbContext (DbContextOptions<mvCollectionDbContext> options) : base (options)
        {

        }

        public DbSet<NewData> NewDatas { get; set; }
        //public IQueryable<NewData> Newdatas { get; internal set; }
    }
}
