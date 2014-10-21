namespace AreasWebsite.Areas.FiftyOne.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using AreasWebsite.Areas.FiftyOne.Items;
    using AreasWebsite.Areas.FiftyOne.Mappers;
    using AreasWebsite.Areas.FiftyOne.Models;
    using AreasWebsite.Extensions;

    using Sitecore.Diagnostics;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web.UI.WebControls;

    public class ContentController : Controller
    {
        private readonly IModelMapper<MvcAreasItem, ContentViewModel> modelMapper;

        public ContentController(IModelMapper<MvcAreasItem, ContentViewModel> modelMapper)
        {
            Assert.ArgumentNotNull(modelMapper, "modelMapper");
            this.modelMapper = modelMapper;
        }

        public ActionResult Content()
        {
            var rendering = RenderingContext.Current.Rendering;
            var viewModel = this.modelMapper.Map(rendering.Item, rendering.Parameters);
            return this.View(viewModel);
        }
    }
}