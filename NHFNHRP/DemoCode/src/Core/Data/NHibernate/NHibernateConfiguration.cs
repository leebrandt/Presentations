using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;

namespace Core.Data.NHibernate
{
    public class NHibernateConfiguration
    {
        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(cnx=>cnx.FromConnectionStringWithKey("Default"))
                    .AdoNetBatchSize(20)
                    .ShowSql())
                .Mappings(m =>
                    m.AutoMappings.Add(
                    AutoMap.AssemblyOf<NHibernateRepository>(new MyAutoConfig())
                    .UseOverridesFromAssemblyOf<NHibernateRepository>()
                    .Conventions.Add(
                        Table.Is(x => Inflector.Net.Inflector.Pluralize(x.EntityType.Name)),
                        PrimaryKey.Name.Is(x => "ID"),
                        ForeignKey.EndsWith("ID"))))
                .BuildSessionFactory();
        }

        public class MyAutoConfig : DefaultAutomappingConfiguration
        {
            public override bool IsId(FluentNHibernate.Member member)
            {
                return member.Name == "ID";
            }

            public override bool ShouldMap(System.Type type)
            {
                return type.Namespace.Contains("Domain");
            }
        }
    }
}