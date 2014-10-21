// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The content mapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AreasWebsite.Areas.FiftyOne.Mappers
{
    using System.Web;

    using AreasWebsite.Areas.FiftyOne.AdditionalContent;
    using AreasWebsite.Areas.FiftyOne.Items;
    using AreasWebsite.Areas.FiftyOne.Models;
    using AreasWebsite.Extensions;

    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// The content mapper.
    /// </summary>
    public class ContentMapper : IModelMapper<MvcAreasItem, ContentViewModel>
    {
        #region Fields

        /// <summary>
        /// The additional content provider.
        /// </summary>
        private readonly IAdditionalContentProvider additionalContentProvider;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentMapper"/> class.
        /// </summary>
        /// <param name="additionalContentProvider">
        /// The additional content provider.
        /// </param>
        public ContentMapper(IAdditionalContentProvider additionalContentProvider)
        {
            this.additionalContentProvider = additionalContentProvider;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Initialize the view model
        /// </summary>
        /// <param name="sourceItem">
        /// The source item.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="ContentViewModel"/>.
        /// </returns>
        public ContentViewModel Map(MvcAreasItem sourceItem, RenderingParameters parameters)
        {
            var viewModel = new ContentViewModel
                                {
                                    Title = sourceItem.Title.Render(), 
                                    Text = sourceItem.Text.Render(), 
                                    AdditionalContent =
                                        new HtmlString(
                                        this.additionalContentProvider.GetAdditionalContent())
                                };
            return viewModel;
        }

        #endregion
    }
}