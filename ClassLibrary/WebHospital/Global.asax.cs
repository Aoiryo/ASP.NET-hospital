using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ClassLibrary;

namespace WebHospital
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private Model1 db = new Model1();

        protected void Application_Start()
        {
            int? maxRegistration = (from t in db.registrationSession
                        select (int?)t.registrationSessionID).Max();
            maxRegistration = (maxRegistration != null) ? maxRegistration : -1;
            Application["registration"] = maxRegistration + 1;
            int? maxOrder = (from t in db.order
                                    select (int?)t.orderNumber).Max();
            maxOrder = (maxOrder != null) ? maxOrder : -1;
            Application["order"] = maxOrder + 1;
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
