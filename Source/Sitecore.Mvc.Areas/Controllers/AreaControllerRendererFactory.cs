// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The area controller renderer factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Mvc.Areas.Controllers
{
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// The area controller renderer factory.
    /// </summary>
    public class AreaControllerRendererFactory : IControllerRendererFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// The create renderer.
        /// </summary>
        /// <param name="controllerInfo">
        /// The controller info.
        /// </param>
        /// <returns>
        /// The <see cref="Renderer"/>.
        /// </returns>
        public virtual Renderer CreateRenderer(ControllerInfo controllerInfo)
        {
            return new AreaControllerRenderer(controllerInfo, new AreaControllerRunner(controllerInfo));
        }

        #endregion
    }
}