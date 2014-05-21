using System;

namespace ReevooMark
{
	public class Conversations : AbstractReevooMarkClientTag
	{   
		public Conversations(){
			this.BaseUri = String.Format(@"http://mark.reevoo.com/reevoomark{0}{1}embeddable_conversations", Locale, NumberOfReviews);
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

