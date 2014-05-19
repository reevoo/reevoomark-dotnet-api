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

		protected override void OnInit(EventArgs e)
		{
			if (String.IsNullOrEmpty(SKU))
			{
				Trace.Write("SKU property is empty; returning nothing");
			}

			if (String.IsNullOrEmpty(TkRef))
			{
				Trace.Write("TRKREF property is empty; returning nothing");
			}
		}
	}
}

