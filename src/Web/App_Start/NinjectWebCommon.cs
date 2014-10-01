[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CodeAndCoffeeInfo.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CodeAndCoffeeInfo.Web.App_Start.NinjectWebCommon), "Stop")]

namespace CodeAndCoffeeInfo.Web.App_Start
{
	using System;
	using System.Configuration;
	using System.Web;

	using Microsoft.Web.Infrastructure.DynamicModuleHelper;

	using Common.Logging;
	using Common.Logging.Serilog;

	using Highway.Data;

	using Ninject;
	using Ninject.Web.Common;
	using Ninject.Extensions.Conventions;

	using Serilog;

	using CodeAndCoffeeInfo.Core;
	using CodeAndCoffeeInfo.DataAccess.Mappings;
	using CodeAndCoffeeInfo.Web.Infrastructure;
	using FubuMVC.Core.Runtime;
	using FubuCore;
	using HtmlTags.Conventions;
	using FubuMVC.Core.UI.Security;
	using FubuMVC.Core.UI;
	using FubuCore.Binding.Values;
	using FubuMVC.Core.UI.Elements;
	using FubuMVC.Core.Http.AspNet;

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

				RegisterFubuConventions(kernel);

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

		private static void RegisterFubuConventions(IKernel p_kernel) {

			p_kernel.Bind(x => x.FromAssemblyContaining<IFubuRequest>()
				.SelectAllTypes()
				.BindDefaultInterface());
			p_kernel.Bind(x => x.FromAssemblyContaining<ITypeResolver>()
				.SelectAllTypes()
				.BindDefaultInterface());
			p_kernel.Bind(x => x.FromAssemblyContaining<ITagGeneratorFactory>()
				.SelectAllTypes()
				.BindDefaultInterface());
			p_kernel.Bind(x => x.FromAssemblyContaining<IFieldAccessService>()
				.SelectAllTypes()
				.BindDefaultInterface());
			//p_kernel.Bind(x => {
			//	x.FromAssemblyContaining<IFubuRequest>();
			//	x.FromAssemblyContaining<ITypeResolver>();
			//	x.FromAssemblyContaining<ITagGeneratorFactory>();
			//	x.FromAssemblyContaining<IFieldAccessService>();
				
			//});

			p_kernel.Bind<ISessionState>().To<SimpleSessionState>();

			var htmlConventionLibrary = new HtmlConventionLibrary();
			htmlConventionLibrary.Import(new DefaultHtmlConventions().Library);
			p_kernel.Bind<HtmlConventionLibrary>().ToConstant(htmlConventionLibrary);

			p_kernel.Bind<IValueSource>().To<RequestPropertyValueSource>();

			p_kernel.Bind<ITagRequestActivator>().To<ElementRequestActivator>();
			p_kernel.Bind<ITagRequestActivator>().To<ServiceLocatorTagRequestActivator>();

			p_kernel.Bind<HttpRequestBase>().ToMethod(x => new HttpRequestWrapper(HttpContext.Current.Request));
			p_kernel.Bind<HttpContextBase>().ToMethod(x => new HttpContextWrapper(HttpContext.Current));

			p_kernel.Bind<HttpRequest>().ToMethod(x => HttpContext.Current.Request);
			p_kernel.Bind<HttpContext>().ToMethod(x => HttpContext.Current);

			p_kernel.Bind<ITypeResolverStrategy>().To<TypeResolver.DefaultStrategy>();
			p_kernel.Bind<IElementNamingConvention>().To<DotNotationElementNamingConvention>();
			p_kernel.Bind(typeof(ITagGenerator<>)).To(typeof(TagGenerator<>));
			p_kernel.Bind(typeof(IElementGenerator<>)).To(typeof(ElementGenerator<>));
		}
	}
}
