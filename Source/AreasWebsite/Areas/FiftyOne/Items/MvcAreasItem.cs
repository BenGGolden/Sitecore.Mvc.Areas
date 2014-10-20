using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AreasWebsite.Areas.FiftyOne.Items
{
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;

    public class MvcAreasItem : CustomItem
    {
        public MvcAreasItem(Item innerItem)
            : base(innerItem)
        {
        }

        public static implicit operator MvcAreasItem(Item innerItem)
        {
            return innerItem != null ? new MvcAreasItem(innerItem) : null;
        }

        public static implicit operator Item(MvcAreasItem customItem)
        {
            return customItem != null ? customItem.InnerItem : null;
        }

        public static readonly ID TemplateId = new ID("{F29CCAA9-2CB5-41AF-A454-73947FBE7784}");

        public static class FieldIds
        {
            public static readonly ID Logo = new ID("{7BA087CA-3441-4268-978A-992C4D655FE6}");
            public static readonly ID Title = new ID("{4923F8DC-E90A-4780-BA03-95EE34264382}");
            public static readonly ID Text = new ID("{0FBB9034-6C78-43FA-988D-48C8A0886BE5}");
        }

        private ImageField logo;
        public ImageField Logo
        {
            get
            {
                return this.logo ?? (this.logo = this.InnerItem.Fields[FieldIds.Logo]);
            }
        }

        private TextField title;
        public TextField Title
        {
            get
            {
                return this.title ?? (this.title = this.InnerItem.Fields[FieldIds.Title]);
            }
        }

        private TextField text;
        public TextField Text
        {
            get
            {
                return this.text ?? (this.text = this.InnerItem.Fields[FieldIds.Text]);
            }
        }
    }
}