using Ninject.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;


namespace BEAssignment.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        { 
            //iis entry point

             //GlobalConfiguration.Configure(WebApiConfig.Register);
              //NinjectHttpContainer.RegisterAssembly();
        }
    }
}
