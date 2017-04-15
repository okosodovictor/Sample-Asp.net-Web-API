using BEAssignment.Api.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Ninject.Http;
using Ninject.Web.Common.OwinHost;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(BEAssignment.Api.Startup))]

namespace BEAssignment.Api
{
    partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            //ConfigureNinject
            ConfigureNinject(app);
            // Configure OAUTH
            ConfigureOAuth(app);
            //Configure Web Api
            ConfigureWebApi(app);
            //Configure Welcome Page
           // app.UseWelcomePage();

        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigureNinject(IAppBuilder app)
        {
            //Configure Ninject Middleware
            NinjectHttpContainer.RegisterAssembly();
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {

                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/authtoken"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
