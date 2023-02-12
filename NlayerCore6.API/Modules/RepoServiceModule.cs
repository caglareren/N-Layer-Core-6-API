using Autofac;
using NLayerCore6.Caching;
using NLayerCore6.Core;
using NLayerCore6.Core.Repositories;
using NLayerCore6.Core.Services;
using NLayerCore6.Core.UnitOfWorks;
using NLayerCore6.Repository;
using NLayerCore6.Repository.Repositories;
using NLayerCore6.Repository.UnitOfWorks;
using NLayerCore6.Service.Mapping;
using NLayerCore6.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace NLayerCore6.API.Modules
{
    public class RepoServiceModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();



            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterType<AddressInfoServiceWithCaching>().As<IService<AddressInfo>>();

        }
    }
}
