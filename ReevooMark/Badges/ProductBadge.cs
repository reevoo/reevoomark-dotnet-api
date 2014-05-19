using System;
using System.Web.UI;

namespace ReevooMark
{
	public class ProductBadge:AbstractReevooBadgeTag
	{
		public ProductBadge(){
			this.BadgeClass = "reevoomark";
			this.BaseUri = @"//mark.reevoo.com/partner/{0}/{1}";
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

