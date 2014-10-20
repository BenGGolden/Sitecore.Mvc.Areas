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
    public class InitializeControllerFactory
    {
        #region Methods

        public virtual void Process(PipelineArgs args)
        {
            ControllerBuilder.Current.SetControllerFactory(
                new FullyQualifiedSitecoreControllerFactory(ControllerBuilder.Current.GetControllerFactory()));
        }

        #endregion
    }
}