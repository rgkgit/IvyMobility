using IvyMobility.App.App_Start;
using ShoppingCart.Helper.AutoMapper;
using System.Web.Mvc;
using System.Web.Routing;

namespace IvyMobility.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            AutoMapperConfig.Configure();
        }
    }
}
