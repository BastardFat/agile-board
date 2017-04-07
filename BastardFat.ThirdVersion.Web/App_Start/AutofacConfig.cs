using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using BastardFat.ThirdVersion.BusinessLogic.Services.Implementation;
using BastardFat.ThirdVersion.DatabaseInteraction.Repository.Implementation;

namespace BastardFat.ThirdVersion.Web
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;


            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            var asseblies = new[]
            {
                typeof(PeopleServiceImpl).Assembly,
                typeof(PeoplesRepositoryImpl).Assembly
            };


            builder.RegisterAssemblyTypes(asseblies)
                    .Where(t => t.Name.EndsWith("Impl"))
                    .AsImplementedInterfaces()
                    .InstancePerRequest();

            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}