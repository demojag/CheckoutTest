using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using CheckoutTest.BasketLogic;

namespace CheckoutTest.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            BasketInMemorySorage.InitializeBasketInMemorySorage();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
         
    }
}
