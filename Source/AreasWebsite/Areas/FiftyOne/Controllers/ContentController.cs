namespace AreasWebsite.Areas.FiftyOne.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using AreasWebsite.Areas.FiftyOne.Dependencies;
    using AreasWebsite.Areas.FiftyOne.Items;
    using AreasWebsite.Areas.FiftyOne.Models;
    using AreasWebsite.Extensions;

    using Sitecore.Mvc.Presentation;
    using Sitecore.Web.UI.WebControls;

    public class ContentController : Controller
    {
        private readonly IAdditionalContentProvider additionalContentProvider;

        public ContentController(IAdditionalContentProvider additionalContentProvider)
        {
            this.additionalContentProvider = additionalContentProvider;
        }

        public ActionResult Content()
        {
            MvcAreasItem item = PageContext.Current.Item;
            var viewModel = new ContentViewModel
                                {
                                    Title = item.Title.Render(),
                                    Text = new HtmlString(item.Text.Render() + this.additionalContentProvider.GetAdditionalContent())
                                };
            return this.View(viewModel);
        }
    }
}