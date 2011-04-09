using BddDemo.Framework.Data;
using BddDemo.Framework.Presentation.Data;
using StructureMap.Configuration.DSL;

namespace BddDemo.Framework.Dependencies
{
    public class RepositoryRegistry : Registry
    {
        protected override void configure()
        {
            ForRequestedType<IFloogleRepository>().TheDefaultIsConcreteType<FloogleRepository>();
        }
    }
}