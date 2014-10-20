using System.Web.Mvc;

namespace AreasWebsite.Areas.FiftyOne
{
    public class FiftyOneAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FiftyOne";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //context.MapRoute(
            //    "FiftyOne_default",
            //    "FiftyOne/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}