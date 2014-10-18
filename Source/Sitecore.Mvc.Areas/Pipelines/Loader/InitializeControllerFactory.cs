// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The initialize controller factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Mvc.Areas.Pipelines.Loader
{
    using System.Web.Mvc;

    using Sitecore.Mvc.Areas.Controllers;
    using Sitecore.Pipelines;

    /// <summary>
    /// The initialize controller factory.  This should replace the default InitializeControllerFactory processor.
    /// </summary>
    public class InitializeControllerFactory : Sitecore.Mvc.Pipelines.Loader.InitializeControllerFactory
    {
        #region Methods

        /// <summary>
        /// The set controller factory.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        protected override void SetControllerFactory(PipelineArgs args)
        {
            ControllerBuilder.Current.SetControllerFactory(
                new FullyQualifiedSitecoreControllerFactory(ControllerBuilder.Current.GetControllerFactory()));
        }

        #endregion
    }
}