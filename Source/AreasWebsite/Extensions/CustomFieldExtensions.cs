// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The custom field extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AreasWebsite.Extensions
{
    using System.Web;

    using Sitecore.Data.Fields;
    using Sitecore.Web.UI.WebControls;

    /// <summary>
    /// The custom field extensions.
    /// </summary>
    public static class CustomFieldExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the raw, unencoded value of the field.
        /// </summary>
        /// <param name="field">
        /// The field.
        /// </param>
        /// <returns>
        /// The <see cref="HtmlString"/>.
        /// </returns>
        public static HtmlString Raw(this CustomField field)
        {
            return new HtmlString(field.Value);
        }

        /// <summary>
        /// The render.
        /// </summary>
        /// <param name="field">
        /// The field.
        /// </param>
        /// <param name="disableWebEdit">
        /// The disable Web Edit.
        /// </param>
        /// <returns>
        /// The <see cref="HtmlString"/>.
        /// </returns>
        public static HtmlString Render(this CustomField field, bool disableWebEdit = false)
        {
            return field.Render(string.Empty, string.Empty, string.Empty, string.Empty, disableWebEdit);
        }

        /// <summary>
        /// The render.
        /// </summary>
        /// <param name="field">
        /// The field.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <param name="disableWebEdit">
        /// The disable web edit.
        /// </param>
        /// <returns>
        /// The <see cref="HtmlString"/>.
        /// </returns>
        public static HtmlString Render(this CustomField field, string parameters, bool disableWebEdit = false)
        {
            return field.Render(parameters, string.Empty, string.Empty, string.Empty, disableWebEdit);
        }

        /// <summary>
        /// The render.
        /// </summary>
        /// <param name="field">
        /// The field.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <param name="enclosingTag">
        /// The enclosing tag.
        /// </param>
        /// <param name="disableWebEdit">
        /// The disable web edit.
        /// </param>
        /// <returns>
        /// The <see cref="HtmlString"/>.
        /// </returns>
        public static HtmlString Render(
            this CustomField field, 
            string parameters, 
            string enclosingTag, 
            bool disableWebEdit = false)
        {
            return field.Render(parameters, enclosingTag, string.Empty, string.Empty, disableWebEdit);
        }

        /// <summary>
        /// The render.
        /// </summary>
        /// <param name="field">
        /// The field.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <param name="enclosingTag">
        /// The enclosing tag.
        /// </param>
        /// <param name="before">
        /// The before.
        /// </param>
        /// <param name="after">
        /// The after.
        /// </param>
        /// <param name="disableWebEdit">
        /// The disable web edit.
        /// </param>
        /// <returns>
        /// The <see cref="HtmlString"/>.
        /// </returns>
        public static HtmlString Render(
            this CustomField field, 
            string parameters, 
            string enclosingTag, 
            string before, 
            string after, 
            bool disableWebEdit = false)
        {
            if (field == null || field.InnerField == null || field.InnerField.Item == null)
            {
                return new HtmlString(string.Empty);
            }

            var renderer = new FieldRenderer()
                               {
                                   Item = field.InnerField.Item, 
                                   FieldName = field.InnerField.Name, 
                                   Parameters = parameters, 
                                   EnclosingTag = enclosingTag, 
                                   Before = before, 
                                   After = after, 
                                   DisableWebEditing = disableWebEdit
                               };

            return new HtmlString(renderer.Render());
        }

        #endregion
    }
}