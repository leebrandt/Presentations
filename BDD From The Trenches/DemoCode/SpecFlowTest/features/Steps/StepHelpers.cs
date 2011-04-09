using FakeItEasy;
using NHibernate.Tool.hbm2ddl;
using SFT.Core.Data.NHibernate;
using SFT.Core.Dependencies;
using SFT.Core.Services.Configuration;
using TechTalk.SpecFlow;

namespace SFT.Features.Steps
{
    [Binding]
    public class StepHelpers
    {
        [BeforeScenario("data")]
        public void InitializeDataScenario()
        {
            DependencyRegistrar.RegisterDependencies();
        }

        //[AfterScenario("data")]
        public void ResetDatabase()
        {
            var cfgService = A.Fake<ConfigurationService>();
            A.CallTo(() => cfgService.ConnectionString).Returns("data source=.;initial catalog=testdb;user id=db-user;password=db-pass;");
            var cfg = new AutoMappedConfiguration(cfgService);
            cfg.CreateSessionFactory();
            new SchemaExport(cfg.DbConfiguration).Create(true, true);
        }

    }
}