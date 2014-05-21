using System;

namespace ReevooMark
{
    public class CustomerServiceRatingBadge:AbstractReevooBadgeTag
    {
        public CustomerServiceRatingBadge ()
        {
            this.BadgeClass = "reevoo_reputation customer_service";
            this.BaseUri = @"//mark.reevoo.com/retailer/{0}";
        }
    }
}

