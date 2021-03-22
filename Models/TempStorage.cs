using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public static class TempStorage
    {
        private static List<NewData> applications = new List<NewData>();

        public static IEnumerable<NewData> Applications => applications;

        public static void AddApplication (NewData application)
        {
            applications.Add(application);
            
        }
    }
}
