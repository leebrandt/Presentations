using System.Collections.Generic;
using System.Linq;
using BddDemo.Framework.Domain;
using BddDemo.Framework.Presentation.Data;

namespace BddDemo.Framework.Data
{
    public class FloogleRepository : IFloogleRepository
    {
        public IList<Floogle> Search(string partNumber)
        {
            return All().Where(x => x.PartNumber.ToLowerInvariant().Contains(partNumber.ToLowerInvariant())).ToList();
        }

        public IQueryable<Floogle> All()
        {
            return new List<Floogle>
                       {
                           new Floogle {PartNumber = "A00001"},
                           new Floogle {PartNumber = "A00002"},
                           new Floogle {PartNumber = "B00001"},
                           new Floogle {PartNumber = "B00002"},
                           new Floogle {PartNumber = "B00010"},
                           new Floogle {PartNumber = "C00011"},
                           new Floogle {PartNumber = "A00100"},
                           new Floogle {PartNumber = "C00010"}
                       }.AsQueryable();
        }
    }
}