using System;
using System.Data.Common;
using AnyNHibernate.Domains;
using AnyNHibernate.Domains.Workflow;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Engine;
using NHibernate.Tool.hbm2ddl;

namespace AnyNHibernate.test
{
    public class FactBase : IDisposable
    {
        readonly DbConnection dbConnection;
        ISessionFactory sessionFactory;
        Configuration inMemDbConfiguration;

        public FactBase()
        {
            sessionFactory = BuildSessionFactory();
            dbConnection = ((ISessionFactoryImplementor) sessionFactory)
                .ConnectionProvider
                .GetConnection();
            ImportTables(dbConnection, inMemDbConfiguration);
        }

        protected ISession ResolveSession()
        {
            return sessionFactory
                .WithOptions()
                .Connection(dbConnection)
                .FlushMode(FlushMode.Commit)
                .OpenSession();
        }

        ISessionFactory BuildSessionFactory()
        {
            return sessionFactory ?? (sessionFactory = Fluently.Configure()
                       .Database(SQLiteConfiguration.Standard.InMemory)
                       .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Workflow>())
                       .CurrentSessionContext<ThreadStaticSessionContext>()
                       .ExposeConfiguration(cfg => inMemDbConfiguration = cfg)
                       .BuildSessionFactory());
        }

        static void ImportTables(DbConnection dbConnection, Configuration inMemDbConfiguration)
        {
            var schemaExport = new SchemaExport(inMemDbConfiguration);
            schemaExport.Execute(false, true, false, dbConnection, null);
        }

        public void Dispose()
        {
        }
    }
}