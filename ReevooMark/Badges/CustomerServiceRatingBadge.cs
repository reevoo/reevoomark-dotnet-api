using System;

namespace ReevooMark
{
	public class CustomerServiceRatingBadge:AbstractReevooBadgeTag
	{	
		public CustomerServiceRatingBadge(){
			this.BadgeClass = "reevoo_reputation customer_service";
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

