using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AniDB.Application.Infrastructure;
using AniDB.Persistence.Repositories.InMemory;
using AniDB.Persistence.Repositories.MySql;
using Autofac;
using FluentValidation;
using MediatR;

namespace AniDB.WpfUI
{
    public static class Startup
    {
        public static IContainer ConfigureAutofac()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder
                .RegisterAssemblyTypes(typeof(RequestValidationBehavior<,>).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterGeneric(typeof(RequestValidationBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));


            builder
                .RegisterType<InMemoryRepository>()
                .As<IRepository>()
                .SingleInstance();

            return builder.Build();
        }
    }
}
