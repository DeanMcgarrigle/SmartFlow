using System;
using System.Linq;
using FileLogging4Net;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Security;
using Nancy.TinyIoc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SmartFlow.DataAccess;
using SmartFlow.Entity;
using SmartFlow.Properties;

namespace SmartFlow
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("images"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("fonts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("build"));
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            StaticConfiguration.DisableErrorTraces = false;
            var context = container.Resolve<SmartFlowContext>();
            var user = context.Users.FirstOrDefault(x => x.UserName == "vs4000");

            if (user == null)
            {
                var hashPassword = MachSecure.BusinessObjects.Encryption.EncryptPassword("vs4000");

                context.Users.Add(new User
                {
                    UserName = "vs4000",
                    Password = hashPassword
                });
            }

            context.SaveChanges();

            //var response = PurpleWifiRequest<VenuesResponse>.GetData("/venues");

            base.ApplicationStartup(container, pipelines);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var logger = new TextFileLogger(Settings.Default.FilePath, "Request", null, 30, "SmartFlow", "1")
            {
                MaximumLogSize = 15
            };

            container.Register(logger);
            container.Register<JsonSerializer, SmartFlowJsonSerializer>();

            logger.Write("Logging Configured", Enums.LogLevel.Information);
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            var formsAuthConfig = new FormsAuthenticationConfiguration
            {
                RedirectUrl = "~/login",
                UserMapper = container.Resolve<IUserMapper>()
            };

            FormsAuthentication.Enable(pipelines, formsAuthConfig);

            pipelines.AfterRequest += ctx =>
            {
                var dbContext = container.Resolve<SmartFlowContext>();
                dbContext.SaveChanges();
            };

            pipelines.OnError += (ctx, ex) =>
            {
                var logger = container.Resolve<TextFileLogger>();
                logger.Write("Error", Enums.LogLevel.ApplicationError, ex);
                return ErrorResponse.FromException(ex);
            };

            base.RequestStartup(container, pipelines, context);
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            var ctx = new SmartFlowContext();
            container.Register(ctx);
            container.Register<IUserMapper, SmartFlowAuthService>();
        }
    }

    public class SmartFlowAuthService : IUserMapper
    {
        private readonly SmartFlowContext _context;

        public SmartFlowAuthService(SmartFlowContext context)
        {
            _context = context;
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            return _context.Users.FirstOrDefault(x => x.RecordId == identifier);
        }
    }

    public sealed class SmartFlowJsonSerializer : JsonSerializer
    {
        public SmartFlowJsonSerializer()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver();
            Formatting = Formatting.Indented;
        }
    }
}