using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using BastardFat.AgileBoard.YetAnother.Database.Repo.Impl;
using BastardFat.AgileBoard.YetAnother.Database.Repo;
using BastardFat.AgileBoard.YetAnother.Database;

namespace BastardFat.AgileBoard.YetAnother
{
    public static class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;


            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder
                .RegisterType<MainRepository>()
                .As<IRepository>()
                .WithParameter("db", new MainDBContext());


            builder.RegisterWebApiFilterProvider(config);


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}