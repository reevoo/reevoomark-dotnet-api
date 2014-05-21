using System;
using System.Web.Configuration;

namespace ReevooMark
{
	public class ProductReviews :AbstractReevooMarkClientTag
    {   
		public ProductReviews(){
			this.BaseUri = String.Format(@"http://mark.reevoo.com/reevoomark/{0}{1}embeddable_reviews",Locale,NumberOfReviews);
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			if (String.IsNullOrEmpty(SKU))
			{
				Trace.Write("SKU property is empty; returning nothing");
			}

		}
    }
}
