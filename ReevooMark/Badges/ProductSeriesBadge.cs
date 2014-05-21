﻿using System;

namespace ReevooMark
{
    public class ProductSeriesBadge: AbstractReevooBadgeTag
    {
        public ProductSeriesBadge ()
        {
            this.BadgeClass = "reevoomark";
            this.BaseUri = @"//mark.reevoo.com/partner/{0}/series:{1}";
        }

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);
            if (String.IsNullOrEmpty (SKU)) {
                Trace.Write ("SKU property is empty; returning nothing");
            }
        }
    }
}

