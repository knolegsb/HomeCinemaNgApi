using Autofac;
using Autofac.Integration.WebApi;
using HomeCinemaNgApi.Data;
using HomeCinemaNgApi.Data.Infrastructure;
using HomeCinemaNgApi.Data.Repositories;
using HomeCinemaNgApi.Services;
using HomeCinemaNgApi.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using HomeCinemaNgApi.Web.Infrastructure.Core;

namespace HomeCinemaNgApi.Web.App_Start
{
    public class AutofacWebApiConfig
    {
        public static IContainer container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        private static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            containerBuilder.RegisterType<HomeCinemaNgApiDbContext>()
                            .As<DbContext>()
                            .InstancePerRequest();

            containerBuilder.RegisterType<DbFactory>()
                            .As<IDbFactory>()
                            .InstancePerRequest();

            containerBuilder.RegisterGeneric(typeof(EntityBaseRepository<>))
                            .As(typeof(IEntityBaseRepository<>))
                            .InstancePerRequest();

            containerBuilder.RegisterType<EncryptionService>()
                            .As<IEncryptionService>()
                            .InstancePerRequest();

            containerBuilder.RegisterType<MembershipService>()
                            .As<IMembershipService>()
                            .InstancePerRequest();

            containerBuilder.RegisterType<DataRepositoryFactory>()
                            .As<IDataRepositoryFactory>().InstancePerRequest();

            container = containerBuilder.Build();

            return container;
        }
    }
}