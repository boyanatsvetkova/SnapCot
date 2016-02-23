using System.Web.Mvc;

namespace SnapCot.Web.Areas.SupplyManager
{
    public class SupplyManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SupplyManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SupplyManager_default",
                "SupplyManager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}