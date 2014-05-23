using System;
using System.Web.UI;

namespace ReevooMark
{
    public class ProductBadge:AbstractReevooBadgeTag
    {
        public ProductBadge ()
        {
            this.BadgeClass = "reevoomark";
            this.BaseUri = @"//mark.reevoo.com/partner/{0}/{1}";
        }

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);
            if (String.IsNullOrEmpty (Sku)) {
                Trace.Write ("Sku property is empty; returning nothing");
            }
        }
    }
}

