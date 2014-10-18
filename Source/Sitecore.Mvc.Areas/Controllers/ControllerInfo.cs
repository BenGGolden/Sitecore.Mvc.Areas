// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="ControllerInfo.cs">
//   
// </copyright>
// <summary>
//   The controller info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Sitecore.Mvc.Areas.Controllers
{
    using Sitecore.Diagnostics;

    /// <summary>
    /// The controller info.
    /// </summary>
    public class ControllerInfo
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerInfo"/> class.
        /// </summary>
        /// <param name="controllerName">
        /// The controller name.
        /// </param>
        /// <param name="actionName">
        /// The action name.
        /// </param>
        /// <param name="areaName">
        /// The area name.
        /// </param>
        public ControllerInfo(string controllerName, string actionName, string areaName)
        {
            Assert.ArgumentNotNullOrEmpty(controllerName, "controllerName");
            Assert.ArgumentNotNullOrEmpty(actionName, "actionName");

            this.ControllerName = controllerName;
            this.ActionName = actionName;
            this.AreaName = areaName;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the action name.
        /// </summary>
        public string ActionName { get; private set; }

        /// <summary>
        /// Gets the area name.
        /// </summary>
        public string AreaName { get; private set; }

        /// <summary>
        /// Gets the controller name.
        /// </summary>
        public string ControllerName { get; private set; }

        #endregion
    }
}