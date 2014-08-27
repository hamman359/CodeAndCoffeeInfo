[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App_Start.NinjectWebCommon), "Stop")]

namespace Web.App_Start
{
	using System;
	using System.Configuration;
	using System.Web;
	using CodeAndCoffeeInfo.DataAccess.Mappings;
	using Common.Logging;
	using Common.Logging.Serilog;
	using Highway.Data;
	using Microsoft.Web.Infrastructure.DynamicModuleHelper;
	using Ninject;
	using Ninject.Web.Common;
	using Serilog;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>source
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				//TODO: Need to break this up into helper methods. One for Highway and one for Serilog

				RegisterHighwayFramework(kernel);

				RegisterLogger(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

		private static void RegisterHighwayFramework(IKernel kernel) {

			//This is Highway.Data's Context
			kernel.Bind<IDataContext>().To<DataContext>()
				.InRequestScope()
				.WithConstructorArgument(
					"connectionString",
					ConfigurationManager.ConnectionStrings["MvcTestConnection"].ConnectionString); //TODO: Need to Create a Configuration object and move this there.

			//This is Highway.Data's Repository
			kernel.Bind<IRepository>().To<Repository>().InRequestScope();

			//This is Highway.Data's relational mappings Interface, but YOUR implementation
			kernel.Bind<IMappingConfiguration>().To<CCIMappingConfiguration>();

			////This is Highway.Data's context configuration, by default use the default :-)
			kernel.Bind<IContextConfiguration>().To<DefaultContextConfiguration>();
		}

		private static void RegisterLogger(IKernel kernel) {
			
			//This is Common.Loggings log interface, feel free to supply anything that uses it *cough* log4net
			kernel.Bind<ILogger>()
				.ToMethod(ctx => new LoggerConfiguration()
					.ReadAppSettings()
					.Enrich.WithProperty("Server", "Local")
					.Enrich.WithMachineName()
					.CreateLogger())
				.InSingletonScope();

			kernel.Bind<ILog>().To<SerilogCommonLogger>().InSingletonScope();
		}
	}
}
