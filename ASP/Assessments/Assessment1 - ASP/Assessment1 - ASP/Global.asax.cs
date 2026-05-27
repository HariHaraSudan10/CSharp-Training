using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Assessment1___ASP
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["TotalVisitors"] = 0;
            Application["ActiveUsers"] = 0;
        }

        void Session_Start(object sender, EventArgs e)
        {
            

            Application["TotalVisitors"] = Convert.ToInt32(Application["TotalVisitors"]) + 1;

            Application["ActiveUsers"] = Convert.ToInt32(Application["ActiveUsers"]) + 1;

            
        }

        void Session_End(object sender, EventArgs e)
        {           

            Application["ActiveUsers"] = Convert.ToInt32(Application["ActiveUsers"]) - 1;

        }
    }
}