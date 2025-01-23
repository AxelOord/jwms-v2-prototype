using Application.Generics.Delete;
using Application.Generics.GetAll;
using Application.Generics.GetById;
using Application.Warehouse.Articles.Commands.CreateArticle;
using Application.Warehouse.Suppliers;
using Autofac;
using Infrastructure;
using Infrastructure.Persistence.Articles;
using Infrastructure.Persistence.Generics.Commands;
using Infrastructure.Persistence.Generics.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence.Persistence.Suppliers;
using System.Reflection;

namespace Persistence
{
  public static class AutofacServiceRegistration
    {
        public static void ConfigureAutofacContainer(this ContainerBuilder containerBuilder)
        {
            // Register MediatR with Autofac
            containerBuilder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();

            // Register all application-specific request handlers
            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();

            containerBuilder.RegisterGeneric(typeof(GetByIdService<>))
                .As(typeof(IGetByIdService<>))
                .InstancePerDependency();

            containerBuilder.RegisterGeneric(typeof(GetAllService<>))
                .As(typeof(IGetAllService<>))
                .InstancePerDependency();

            containerBuilder.RegisterGeneric(typeof(DeleteService<>))
                .As(typeof(IDeleteService<>))
                .InstancePerDependency();

            containerBuilder.RegisterType<CreateArticleService>()
                .As<ICreateArticleService>()
                .InstancePerDependency();

      containerBuilder.RegisterType<ServiceFactory>()
                .As<IServiceFactory>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<SupplierRepository>()
               .As<ISupplierRepository>()
               .InstancePerLifetimeScope();

      //containerBuilder.RegisterGeneric(typeof(DeleteCommandHandler<>))
      //    .As(typeof(IRequestHandler<,>))
      //    .InstancePerDependency();

      // Register additional pipeline behaviors if 
      //containerBuilder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    }
    }
}
