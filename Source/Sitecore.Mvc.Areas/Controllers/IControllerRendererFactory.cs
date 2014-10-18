// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The ControllerRendererFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Mvc.Areas.Controllers
{
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// The ControllerRendererFactory interface.
    /// </summary>
    public interface IControllerRendererFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Create the renderer.
        /// </summary>
        /// <param name="controllerInfo">
        /// The controller info.
        /// </param>
        /// <returns>
        /// The <see cref="Renderer"/>.
        /// </returns>
        Renderer CreateRenderer(ControllerInfo controllerInfo);

        #endregion
    }
}