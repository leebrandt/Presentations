using System.Collections.Generic;
using BddDemo.Framework.Domain;

namespace BddDemo.Framework.Presentation.Data
{
    public interface IFloogleRepository
    {
        IList<Floogle> Search(string partNumber);
    }
}