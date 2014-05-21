using System;

namespace ReevooMark
{
	public class OverallServiceRatingBadge:AbstractReevooBadgeTag
	{
		public OverallServiceRatingBadge(){
			this.BadgeClass = "reevoo_reputation";
			this.BaseUri = @"//mark.reevoo.com/retailer/{0}";
		}
			
	}
}

