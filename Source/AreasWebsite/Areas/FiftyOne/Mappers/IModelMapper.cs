// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The ModelMapper interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AreasWebsite.Areas.FiftyOne.Mappers
{
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// The ModelMapper interface.
    /// </summary>
    /// <typeparam name="TItem">
    /// </typeparam>
    /// <typeparam name="TViewModel">
    /// </typeparam>
    public interface IModelMapper<TItem, TViewModel>
        where TItem : CustomItem where TViewModel : class, new()
    {
        #region Public Methods and Operators

        /// <summary>
        /// Initialize the view model.
        /// </summary>
        /// <param name="sourceItem">
        /// The source item.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="TViewModel"/>.
        /// </returns>
        TViewModel Map(TItem sourceItem, RenderingParameters parameters);

        #endregion
    }
}