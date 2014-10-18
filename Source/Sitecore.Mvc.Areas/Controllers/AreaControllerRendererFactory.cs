using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Mvc.Areas.Controllers
{
    using Sitecore.Mvc.Presentation;

    public class AreaControllerRendererFactory : IControllerRendererFactory
    {
        public virtual Renderer CreateRenderer(ControllerInfo controllerInfo)
        {
            return new AreaControllerRenderer(controllerInfo, new AreaControllerRunner(controllerInfo));
        }
    }
}
