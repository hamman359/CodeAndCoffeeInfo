[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CodeAndCoffeeInfo.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CodeAndCoffeeInfo.Web.App_Start.NinjectWebCommon), "Stop")]

namespace CodeAndCoffeeInfo.Web.App_Start
{
	using System;
	using System.Configuration;
	using System.Web;

	using Microsoft.Web.Infrastructure.DynamicModuleHelper;

	using CodeAndCoffeeInfo.DataAccess.Mappings;

	using Common.Logging;
	using Common.Logging.Serilog;

	using Highway.Data;

	using Ninject;
	using Ninject.Web.Common;

	using Serilog;
	using CodeAndCoffeeInfo.Core;
	using CodeAndCoffeeInfo.Web.Infrastructure;

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

				RegisterHighwayFramework(kernel);

				RegisterLogger(kernel);

				RegisterConfigs(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

		private static void RegisterHighwayFramework(IKernel p_kernel) {

			//This is Highway.Data's Context
			p_kernel.Bind<IDataContext>().To<DataContext>()
				.InRequestScope()
				.WithConstructorArgument(
					"connectionString",
					ConfigurationManager.ConnectionStrings["CCIConnection"].ConnectionString); //TODO: Need to Create a Configuration object and move this there.

			//This is Highway.Data's Repository
			p_kernel.Bind<IRepository>().To<Repository>().InRequestScope();

			//This is Highway.Data's relational mappings Interface, but YOUR implementation
			p_kernel.Bind<IMappingConfiguration>().To<CCIMappingConfiguration>();

			////This is Highway.Data's context configuration, by default use the default :-)
			p_kernel.Bind<IContextConfiguration>().To<DefaultContextConfiguration>();
		}

		private static void RegisterLogger(IKernel p_kernel) {
			
			//This is Common.Loggings log interface, feel free to supply anything that uses it *cough* log4net
			p_kernel.Bind<ILogger>()
				.ToMethod(ctx => new LoggerConfiguration()
					.ReadAppSettings()
					.Enrich.WithProperty("Server", "Local")
					.Enrich.WithMachineName()
					.CreateLogger())
				.InSingletonScope();

			p_kernel.Bind<ILog>().To<SerilogCommonLogger>().InSingletonScope();
		}

		private static void RegisterConfigs(IKernel p_kernel) {

			p_kernel.Bind<ICoreConfig>()
				.ToMethod(ctx => new CoreConfig(ConfigurationManager.AppSettings))
				.InRequestScope();

			p_kernel.Bind<IWebConfig>()
				.ToMethod(ctx => new WebConfig(ConfigurationManager.AppSettings))
				.InRequestScope();
		}


	}
}
