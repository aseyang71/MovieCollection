using System;
using System.Linq;

namespace MovieCollection.Models
{
    public interface mvCollectionRepository 
    {
        IQueryable<NewData> NewDatas { get;}


        // Listing 10-12
        //IQueryable<NewData> newDatas { get; }

        void SaveMovieData(NewData newData);
        void CreateMovieData(NewData newData);
        void DeleteMovieData(NewData newData);
    }
}
