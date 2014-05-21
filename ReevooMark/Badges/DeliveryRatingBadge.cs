using System;

namespace ReevooMark
{
	public class DeliveryRatingBadge: AbstractReevooBadgeTag
	{
		public DeliveryRatingBadge(){
			this.BadgeClass = "reevoo_reputation delivery";
			this.BaseUri = @"//mark.reevoo.com/retailer/{0}";
		}
			
	}
}

