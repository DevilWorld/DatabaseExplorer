using Autofac;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Services;
using PocoGenerator.Domain.Services.Templates;
//using PocoGenerator.DatabaseConnection;
using PocoGenerator.Domain;
//using PocoGenerator.TypeMapping;
using PocoGenerator.Infrastructure.Data.Repositories;
using PocoGenerator.Infrastructure;
using PocoGenerator.Domain.DotLiquidDrops;
using PocoGenerator.Domain.Models.BaseObjects;
using PocoGenerator.Domain.Services.BlankSpace;
using PocoGenerator.Domain.Services.Output;
using DatabaseExplorer.Services;

namespace DatabaseExplorer.StartUp
{
    internal static class AutofacConfiguration
    {
        internal static void Configure()
        {
            //Create a container
            var builder = new ContainerBuilder();

            //Register Domain services
            builder.RegisterType<SQLServerDBConnectService>().As<IDbConnectService>();
            builder.RegisterType<ConnectionStringService>().AsImplementedInterfaces();
            builder.RegisterType<SqlDataTypeService>().AsImplementedInterfaces();
            builder.RegisterType<RetrieveDbObjectsService>().AsImplementedInterfaces();
            builder.RegisterType<GenerateTemplateService>().AsImplementedInterfaces();


            //Register Domian Models
            builder.RegisterType<SysObjects>();
            builder.RegisterType<SysColumns>();

            builder.RegisterType<SysColumnsDrop>();

            builder.RegisterType<PropertiesTemplateSevice>().AsImplementedInterfaces();
            builder.RegisterType<ClassTemplateService>().AsImplementedInterfaces();
            builder.RegisterType<NamespaceTemplateService>().AsImplementedInterfaces();

            //Blank Space Configuration
            builder.RegisterType<ClassBlankSpaceService>().AsImplementedInterfaces();
            builder.RegisterType<PropertiesBlankSpaceService>().AsImplementedInterfaces();

            //Output configuration
            builder.RegisterType<RenderOutputUsingTablesWithColumnsService>().AsImplementedInterfaces();
            builder.RegisterType<RenderOutputUsingTablesWithColumnsListService>().AsImplementedInterfaces();

            //Register Repositories
            builder.RegisterType<RetrieveSqlDbObjectsRepository>().AsImplementedInterfaces();

            //Register types
            //builder.RegisterType<PocoGenerator>();
            //builder.Register(f => new PocoGenerator(f.Resolve<IRetrieveDbObjectsService>())).As<PocoGenerator>();
            //builder.RegisterType<PocoGenerator>().UsingConstructor(typeof(IRetrieveDbObjectsService));
            //builder.RegisterType<ConnectToDatabase>().AsSelf();
            //builder.RegisterType<TypeMapper>().AsSelf();
            builder.RegisterType<PocoContext>().AsSelf();

            //builder.Register(f => new ConnectToDatabase(f.Resolve<IDbConnect>())).As<ConnectToDatabase>();

            //Register services in client application
            builder.RegisterType<LoadDatabaseService>().AsImplementedInterfaces();

            //Build the container
            Global.Container = builder.Build();
        }
    }
}
