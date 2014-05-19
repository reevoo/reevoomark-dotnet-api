using System;

namespace ReevooMark
{
	public class Conversations : AbstractReevooTag
	{   
		public Conversations(){
			this.BaseUri = @"http://mark.reevoo.com/reevoomark/embeddable_customer_experience_reviews";
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

