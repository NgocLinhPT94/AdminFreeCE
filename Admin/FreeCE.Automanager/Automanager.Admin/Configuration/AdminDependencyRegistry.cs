using Autofac;
using Autofac.Integration.Mvc;
using Automanager.Data.Database;
using Automanager.Libraries.RepoImpl;
using Automanager.Libraries.RepoImpl.DependencyManagement;
using Automanager.RepoImpl.DBContext;
using Automanager.RepoImpl.Repository;
using Automanager.RepoInterface.Repository;
using System.Web;

namespace Automanager.Admin.Configuration
{
    public class AdminDependencyRegistry : IDependencyRegistrar
    {
        public int Order => 0;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            #region register base

            // MVC - Register your MVC controllers.
            // MVC - OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            // MVC - OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();
            // MVC - OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());
            // MVC - OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            #endregion

            //http context
            builder.RegisterInstance(new HttpContextWrapper(HttpContext.Current));

            #region Register DataRepository

            // TODO: Refactor code to change the dbcontext of report module to FreeCEContext
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>();

            #endregion

            #region Register report services

            // Register application dependencies.

            #endregion

            RegisterRepository(builder, typeFinder, config);
        }

        public void RegisterRepository(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<FreeCEContext>().As<IDbContext>()
                .WithParameter("connectionString", "FreeCE_ConnectString")
                .InstancePerLifetimeScope();
            builder.RegisterType<DbRepository>().As<IDbRepository>();


            #region Register repository

            builder.RegisterType<LoginRepository>().As<ILoginRepository>();

            #endregion
        }
    }
}