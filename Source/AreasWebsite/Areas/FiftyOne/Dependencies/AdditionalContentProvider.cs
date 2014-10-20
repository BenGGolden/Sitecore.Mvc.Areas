using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AreasWebsite.Areas.FiftyOne.Dependencies
{
    public class AdditionalContentProvider : IAdditionalContentProvider
    {
        public string GetAdditionalContent()
        {
            return "<p>This content was provided by an injected dependency.<p>";
        }
    }
}