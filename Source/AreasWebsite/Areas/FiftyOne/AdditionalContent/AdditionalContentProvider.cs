namespace AreasWebsite.Areas.FiftyOne.AdditionalContent
{
    public class AdditionalContentProvider : IAdditionalContentProvider
    {
        public string GetAdditionalContent()
        {
            return "This content was provided by an injected dependency.";
        }
    }
}