using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClassMiBlog.Entities;

namespace ClassMiBlog.AdoNet
{
    public static class MapperEngineering
    {
        public static IEnumerable<Engineering> Convert(DataTable datatable)
        {
            return datatable.Rows.Count == 0 ? new List<Engineering>() :
              (from DataRow variable in datatable.Rows
               select new Engineering
               {
                   Id = (long) variable["Id"],
                   Name = (string) variable["Name"]

               } );
        }
    }
}
