using System;

namespace ReevooMark
{
	/// <summary>
	/// A <see cref="System.Web.UI.UserControl"/> for showing in-line reviews for Reevoo products
	/// </summary>
	public class CustomerExperienceReviews : AbstractReevooTag
	{
		public CustomerExperienceReviews(){
			this.BaseUri = @"http://mark.reevoo.com/reevoomark/embeddable_customer_experience_reviews";
		}

		protected override void OnInit(EventArgs e)
		{

			if (String.IsNullOrEmpty(TkRef))
			{
				Trace.Write("TkRef property is empty; returning nothing");
			}
		}

	}

}
