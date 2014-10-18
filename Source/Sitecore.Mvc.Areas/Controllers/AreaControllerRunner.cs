// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The area controller runner.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Sitecore.Mvc.Areas.Controllers
{
    using System.Web.Mvc;

    using Sitecore.Diagnostics;
    using Sitecore.Mvc.Controllers;
    using Sitecore.Mvc.Presentation;

    using ControllerBuilder = System.Web.Mvc.ControllerBuilder;

    /// <summary>
    /// The area controller runner.
    /// </summary>
    public class AreaControllerRunner : ControllerRunner
    {
        #region Fields

        /// <summary>
        /// The controller factory.
        /// </summary>
        private readonly IControllerFactory controllerFactory;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaControllerRunner"/> class.
        /// </summary>
        /// <param name="controllerInfo">
        /// The controller Info.
        /// </param>
        /// <param name="controllerFactory">
        /// The controller Factory.
        /// </param>
        public AreaControllerRunner(ControllerInfo controllerInfo)
            : base(controllerInfo.ControllerName, controllerInfo.ActionName)
        {
            Assert.ArgumentNotNull(controllerInfo, "controllerInfo");

            this.Area = controllerInfo.AreaName;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        public string Area { get; protected set; }

        #endregion

        #region Methods

        /// <summary>
        /// The create controller.
        /// </summary>
        /// <returns>
        /// The <see cref="IController"/>.
        /// </returns>
        protected override IController CreateController()
        {
            return ControllerBuilder.Current.GetControllerFactory()
                .CreateController(PageContext.Current.RequestContext, this.ControllerName);
        }

        /// <summary>
        /// The execute controller.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        protected override void ExecuteController(Controller controller)
        {
            var requestContext = PageContext.Current.RequestContext;
            var area = requestContext.RouteData.DataTokens["area"];
            var controllerName = requestContext.RouteData.Values["controller"];
            var action = requestContext.RouteData.Values["action"];

            try
            {
                requestContext.RouteData.Values["controller"] = this.ActualControllerName;
                requestContext.RouteData.Values["action"] = this.ActionName;
                requestContext.RouteData.DataTokens["area"] = this.Area;

                ((IController)controller).Execute(PageContext.Current.RequestContext);
            }
            finally
            {
                requestContext.RouteData.DataTokens["area"] = area;
                requestContext.RouteData.Values["controller"] = controllerName;
                requestContext.RouteData.Values["action"] = action;
            }
        }

        /// <summary>
        /// Release the controller.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        protected override void ReleaseController(Controller controller)
        {
            ControllerBuilder.Current.GetControllerFactory().ReleaseController(controller);
        }

        #endregion
    }
}