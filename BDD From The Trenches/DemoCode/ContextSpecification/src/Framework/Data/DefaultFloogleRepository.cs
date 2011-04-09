using System.Collections.Generic;
using BddDemo.Framework.Domain;
using BddDemo.Framework.Presentation.Data;

namespace BddDemo.Framework.Data
{
    public class DefaultFloogleRepository : IFloogleRepository
    {
        public IList<Floogle> Search(string partNumber)
        {
            return new List<Floogle>
                       {
                           new Floogle {PartNumber = "A12345"},
                           new Floogle{PartNumber="B12345"}
                       };
        }
    }
}