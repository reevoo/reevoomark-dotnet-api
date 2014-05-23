using System;

namespace ReevooMark
{
    public class ConversationSeriesBadge :AbstractReevooBadgeTag
    {
        public ConversationSeriesBadge ()
        {
            this.BadgeClass = "reevoomark reevoo-conversations";
            this.BaseUri = @"//mark.reevoo.com/partner/{0}/series:{1}";
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

