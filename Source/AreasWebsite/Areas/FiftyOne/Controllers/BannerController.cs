namespace AreasWebsite.Areas.FiftyOne.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using AreasWebsite.Areas.FiftyOne.Items;
    using AreasWebsite.Areas.FiftyOne.Models;
    using AreasWebsite.Extensions;

    using Sitecore.Mvc.Presentation;
    using Sitecore.Web.UI.WebControls;

    public class BannerController : Controller
    {
        public ActionResult Banner()
        {
            MvcAreasItem item = PageContext.Current.Item;
            var viewModel = new BannerViewModel { BannerLogoImage = item.Logo.Render() };
            return this.View(viewModel);
        }
    }
}