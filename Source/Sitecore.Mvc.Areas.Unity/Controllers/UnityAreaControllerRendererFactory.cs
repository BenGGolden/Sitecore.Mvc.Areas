// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The unity area controller renderer factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Mvc.Areas.Unity.Controllers
{
    using Microsoft.Practices.Unity;

    using Sitecore.Mvc.Areas.Controllers;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// The unity area controller renderer factory.
    /// </summary>
    public class UnityAreaControllerRendererFactory : IControllerRendererFactory
    {
        #region Constants

        /// <summary>
        /// The renderer registration name.
        /// </summary>
        public const string RegistrationName = "AreaControllerRenderer";

        #endregion

        #region Fields

        /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityAreaControllerRendererFactory"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public UnityAreaControllerRendererFactory(IUnityContainer container)
        {
            this.container = container;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Use the Unity container to resolve a Renderer.  Presumably, this would return an AreaControllerRenderer.
        /// </summary>
        /// <param name="controllerInfo">
        /// The controller info.
        /// </param>
        /// <returns>
        /// The <see cref="Renderer"/>.
        /// </returns>
        public Renderer CreateRenderer(ControllerInfo controllerInfo)
        {
            return this.container.Resolve<Renderer>(
                RegistrationName, 
                new ParameterOverride("controllerInfo", controllerInfo));
        }

        #endregion
    }
}