// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The area controller renderer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Sitecore.Mvc.Areas.Controllers
{
    using System.IO;

    using Sitecore.Mvc.Controllers;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// The area controller renderer.
    /// </summary>
    public class AreaControllerRenderer : Renderer
    {
        #region Fields
        
        /// <summary>
        /// The controller info.
        /// </summary>
        private readonly ControllerInfo controllerInfo;

        /// <summary>
        /// The controller runner factory.
        /// </summary>
        private readonly ControllerRunner controllerRunner;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaControllerRenderer"/> class.
        /// </summary>
        /// <param name="controllerInfo">
        /// The controller info.
        /// </param>
        /// <param name="controllerRunner">
        /// The controller runner
        /// </param>
        public AreaControllerRenderer(
            ControllerInfo controllerInfo, 
            ControllerRunner controllerRunner)
        {
            this.controllerInfo = controllerInfo;
            this.controllerRunner = controllerRunner;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the cache key.
        /// </summary>
        public override string CacheKey
        {
            get
            {
                return "Accelcor.Common.Mvc.Areas.AreaControllerRenderer::" + this.controllerInfo.ControllerName + "#"
                       + this.controllerInfo.ActionName + "#" + this.controllerInfo.AreaName;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Writes the controller output to the provided text writer.
        /// </summary>
        /// <param name="writer">
        /// The text writer.
        /// </param>
        public override void Render(TextWriter writer)
        {
            var output = this.controllerRunner.Execute();
            if (string.IsNullOrEmpty(output))
            {
                return;
            }

            writer.Write(output);
        }

        /// <summary>
        /// Returns a string describing the controller.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format(
                "Controller: {0}. Action: {1}. Area {2}", 
                this.controllerInfo.ControllerName, 
                this.controllerInfo.ActionName, 
                this.controllerInfo.AreaName);
        }

        #endregion
    }
}