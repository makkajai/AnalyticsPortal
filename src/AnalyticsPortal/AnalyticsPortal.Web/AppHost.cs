using System.Net;
using AnalyticsPortal.Web.Helpers;
using Funq;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.PostgreSQL;
using ServiceStack.Razor;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;

namespace AnalyticsPortal.Web
{
    public class AppHost : AppHostBase
    {	
        public AppHost() : base("AnalyticsService", typeof(AppHost).Assembly) { }
        private OrmLiteAuthRepository _userRep;

        public override void Configure(Container container)
        {
            //TODO: change this
            LogManager.LogFactory = new ConsoleLogFactory();

            //we are using the authentication, registration features
            Plugins.Add(new AuthFeature(() => new AuthUserSession(), new IAuthProvider[]
                {
                    new CredentialsAuthProvider(), 
                }));

            Plugins.Add(new RegistrationFeature());

            Plugins.Add(new RazorFormat());

            //configure ormlite
            ConfigureOrmLite();

            _userRep = new OrmLiteAuthRepository(new OrmLiteConnectionFactory(DbHelper.GetConnectionString()));
            container.Register<IUserAuthRepository>(_userRep);

            //_userRep.CreateMissingTables();

            SetConfig(new EndpointHostConfig
            {
                DebugMode = true, 
                CustomHttpHandlers = {
            //        { HttpStatusCode.NotFound, new RazorHandler("/notfound") },
                    { HttpStatusCode.Unauthorized, new RazorHandler("~/login") },
                }
            });
        }

        /// <summary>
        /// Configures the database connection string for use with ETL database
        /// </summary>
        public static void ConfigureOrmLite()
        {
            OrmLiteConfig.DialectProvider = PostgreSQLDialectProvider.Instance;
        }
    }
}
