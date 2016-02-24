namespace SnapCot.Web
{
    using SnapCot.Web.App_Start;
    using Infrastructure.Mapping;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Reflection;
    using Data.Models;
    using Services.Contracts;

    public class MvcApplication : System.Web.HttpApplication
    {
        //private IProductService products;

        //public MvcApplication(IProductService products)
        //{
        //    this.products = products;
        //}

        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var autoMapperConfig = new AutoMapperConfig();
            // May cause problem???
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }

        //protected void Session_OnEnd()
        //{
        //    var shoppingCart = (ShoppingCart)Session["Cart"];
        //    if (shoppingCart.ProductCartItems.Count != 0)
        //    {
        //        foreach (var item in shoppingCart.ProductCartItems)
        //        {
        //            var product = item.Product;
        //            var quantity = item.Quantity;
        //            this.products.UpdateProductQuantity(product, quantity);
        //        }
        //    }
        //}
    }
}
