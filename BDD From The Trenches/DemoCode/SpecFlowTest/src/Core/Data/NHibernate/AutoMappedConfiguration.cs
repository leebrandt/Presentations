using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using SFT.Core.Domain;
using SFT.Core.Services.Configuration;

namespace SFT.Core.Data.NHibernate
{
    public class AutoMappedConfiguration
    {
        readonly ConfigurationService _configurationService;

        public AutoMappedConfiguration(ConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(_configurationService.ConnectionString)
                    .AdoNetBatchSize(20)
                    .ShowSql())
                .Mappings(m => m.
                    AutoMappings.Add(
                        AutoMap.AssemblyOf<PersistentObject>()
                        .Where(type => type.IsSubclassOf(typeof(PersistentObject)))
                        .Conventions.Add(
                            Table.Is(x => Inflector.Net.Inflector.Pluralize(x.EntityType.Name)),
                            PrimaryKey.Name.Is(x => "ID"),
                            ForeignKey.EndsWith("ID"),
                            ConventionBuilder.Class.Always(x => x.
                                Schema(x.EntityType.Namespace == null || x.EntityType.Namespace.EndsWith("Domain")
                                    ? "dbo" : x.EntityType.Namespace.Substring(x.EntityType.Namespace.LastIndexOf(".")))),
                            DefaultCascade.All()
                        )))
                .ExposeConfiguration(x => DbConfiguration = x)
                .BuildSessionFactory();
        }

        public Configuration DbConfiguration { get; set; }
    }
}