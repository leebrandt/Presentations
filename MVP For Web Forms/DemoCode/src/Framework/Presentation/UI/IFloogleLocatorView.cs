using System.Collections.Generic;
using BddDemo.Framework.Domain;

namespace BddDemo.Framework.Presentation.UI
{
    public interface IFloogleLocatorView
    {
        string PartNumber { get; set; }
        IList<Floogle> Floogles { set; }
    }
}