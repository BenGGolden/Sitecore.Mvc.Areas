using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Sitecore.Mvc.Areas.Unity.App_Start
{
    using AreasWebsite.Areas.FiftyOne.AdditionalContent;
    using AreasWebsite.Areas.FiftyOne.Items;
    using AreasWebsite.Areas.FiftyOne.Mappers;
    using AreasWebsite.Areas.FiftyOne.Models;

    using Sitecore.Mvc.Areas.Controllers;
    using Sitecore.Mvc.Areas.Unity.Controllers;
    using Sitecore.Mvc.Controllers;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            container.RegisterType<IControllerRendererFactory, UnityAreaControllerRendererFactory>();
            container.RegisterType<Renderer, AreaControllerRenderer>(
                UnityAreaControllerRendererFactory.RegistrationName,
                new InjectionConstructor(
                    new ResolvedParameter<ControllerInfo>(),
                    new ResolvedParameter<ControllerRunner>(UnityAreaControllerRendererFactory.RegistrationName)));
            container.RegisterType<ControllerRunner, AreaControllerRunner>(
                UnityAreaControllerRendererFactory.RegistrationName);
            container.RegisterType<IModelMapper<MvcAreasItem, ContentViewModel>, ContentMapper>();
            container.RegisterType<IAdditionalContentProvider, AdditionalContentProvider>();
        }
    }
}
