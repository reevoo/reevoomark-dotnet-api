using System;

namespace ReevooMark
{
	public class DeliveryRatingBadge: AbstractReevooBadgeTag
	{
		public DeliveryRatingBadge(){
			this.BadgeClass = "reevoo_reputation delivery";
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

