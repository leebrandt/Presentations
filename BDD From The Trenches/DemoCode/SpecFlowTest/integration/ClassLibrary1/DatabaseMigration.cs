using FakeItEasy;
using Machine.Specifications;
using NHibernate.Tool.hbm2ddl;
using SFT.Core.Data.NHibernate;
using SFT.Core.Services.Configuration;

namespace SFT.Integration
{
    [Subject("99 - Persistence")]
    public class DatabaseMigration
    {
        Establish context = () =>
        {
            _configurationService = A.Fake<ConfigurationService>();
            A.CallTo(() => _configurationService.ConnectionString)
                .Returns("data source=.;initial catalog=testdb;user id=db-user;password=db-pass;");
            _dbConfiguration = new AutoMappedConfiguration(_configurationService);
            _repository = new NHibernateRepository(_dbConfiguration.CreateSessionFactory());
        };

        It should_migrate_database_schema = () => new SchemaExport(_dbConfiguration.DbConfiguration).Create(true, true);

        It should_migrate_test_data = () =>
            {

            };

        static ConfigurationService _configurationService;
        static AutoMappedConfiguration _dbConfiguration;
        static NHibernateRepository _repository;
    }
}