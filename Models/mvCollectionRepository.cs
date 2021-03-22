using System;
using System.Linq;

namespace MovieCollection.Models
{
    public interface mvCollectionRepository
    {
        IQueryable<NewData> NewDatas { get; }
    }
}
