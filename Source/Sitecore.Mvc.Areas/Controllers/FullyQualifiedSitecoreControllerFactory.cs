// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FullyQualifiedSitecoreControllerFactory.cs" company="">
//   
// </copyright>
// <summary>
//   The fully qualified sitecore controller factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Mvc.Areas.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Sitecore.Mvc.Controllers;
    using Sitecore.Mvc.Extensions;
    using Sitecore.Mvc.Helpers;

    /// <summary>
    /// The fully qualified sitecore controller factory.
    /// </summary>
    public class FullyQualifiedSitecoreControllerFactory : SitecoreControllerFactory
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FullyQualifiedSitecoreControllerFactory"/> class.
        /// </summary>
        /// <param name="innerFactory">
        /// The inner factory.
        /// </param>
        public FullyQualifiedSitecoreControllerFactory(IControllerFactory innerFactory)
            : base(innerFactory)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// The create controller instance.
        /// </summary>
        /// <param name="requestContext">
        /// The request context.
        /// </param>
        /// <param name="controllerName">
        /// The controller name.
        /// </param>
        /// <returns>
        /// The <see cref="IController"/>.
        /// </returns>
        protected override IController CreateControllerInstance(RequestContext requestContext, string controllerName)
        {
            if (controllerName.EqualsText(this.SitecoreControllerName))
            {
                return this.CreateSitecoreController(requestContext, controllerName);
            }

            if (TypeHelper.LooksLikeTypeName(controllerName))
            {
                Type type = TypeHelper.GetType(controllerName);
                if (type != null)
                {
                    return (IController)DependencyResolver.Current.GetService(type)
                           ?? TypeHelper.CreateObject<IController>(type);
                }
            }

            return this.InnerFactory.CreateController(requestContext, controllerName);
        }

        #endregion
    }
}