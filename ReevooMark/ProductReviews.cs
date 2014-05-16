using System;

namespace ReevooMark
{
    /// <summary>
    /// A <see cref="System.Web.UI.UserControl"/> for showing in-line reviews for Reevoo products
    /// </summary>
	public class ProductReviews : AbstractReevooTag
    {   
		public ProductReviews(){
			this.BaseUri = @"http://mark.reevoo.com/reevoomark/en-GB/embeddable_reviews";
		}

		protected override void OnInit(EventArgs e)
		{
			if (String.IsNullOrEmpty(SKU))
			{
				Trace.Write("SKU property is empty; returning nothing");
			}

			if (String.IsNullOrEmpty(TkRef))
			{
				Trace.Write("SKU property is empty; returning nothing");
			}
		}
    }
}
