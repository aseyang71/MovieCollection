using System;
using System.Linq;

namespace MovieCollection.Models
{
    public interface mvCollectionRepository 
    {
        IQueryable<NewData> NewDatas { get;}


        // Listing 10-12
        IQueryable<NewData> newDatas { get; }

        void SaveNewData(NewData newData);
        void CreateNewData(NewData newData);
        void DeleteNewData(NewData newData);
    }
}
