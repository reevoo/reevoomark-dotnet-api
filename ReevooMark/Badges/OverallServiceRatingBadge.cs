using System;

namespace ReevooMark
{
	public class OverallServiceRatingBadge:AbstractReevooBadgeTag
	{
		public OverallServiceRatingBadge(){
			this.BadgeClass = "reevoo_reputation";
			this.BaseUri = @"//mark.reevoo.com/retailer/{0}";
		}

		protected override void OnInit(EventArgs e)
		{
			if (String.IsNullOrEmpty(TkRef))
			{
				Trace.Write("TRKREF property is empty; returning nothing");
			}
		}
	}
}

