// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The get area controller renderer.
//   Based on MvcAreas by Kevin Buckley:
//   http://webcmd.wordpress.com/2013/01/24/sitecore-mvc-area-controller-rendering-type/.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Mvc.Areas.Pipelines.Response.GetRenderer
{
    using System.Web.Mvc;

    using Sitecore.Data;
    using Sitecore.Mvc.Areas.Controllers;
    using Sitecore.Mvc.Pipelines.Response.GetRenderer;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// The get area controller renderer.
    /// </summary>
    public class GetAreaControllerRenderer : GetRendererProcessor
    {
        #region Static Fields

        /// <summary>
        /// The area controller rendering template id.
        /// </summary>
        private static readonly ID AreaControllerRenderingTemplateId = new ID("{EAEC25B0-3110-40D4-B3F9-9D70211022CF}");

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The process.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public override void Process(GetRendererArgs args)
        {
            if (args.Result != null)
            {
                return;
            }

            if (args.RenderingTemplate == null
                || !args.RenderingTemplate.DescendsFromOrEquals(AreaControllerRenderingTemplateId))
            {
                return;
            }

            args.Result = this.GetRenderer(args.Rendering, args);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get renderer.
        /// </summary>
        /// <param name="rendering">
        /// The rendering.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="Renderer"/>.
        /// </returns>
        protected virtual Renderer GetRenderer(Rendering rendering, GetRendererArgs args)
        {
            var rendererFactory = this.GetControllerRendererFactory();
            if (rendererFactory == null)
            {
                return null;
            }

            var controllerInfo = new ControllerInfo(
                rendering.RenderingItem.InnerItem["controller"],
                rendering.RenderingItem.InnerItem["controller action"],
                rendering.RenderingItem.InnerItem["area"]);

            return rendererFactory.CreateRenderer(controllerInfo);
        }

        protected virtual IControllerRendererFactory GetControllerRendererFactory()
        {
            return DependencyResolver.Current.GetService<IControllerRendererFactory>() ?? new AreaControllerRendererFactory();
        }

        #endregion
    }
}