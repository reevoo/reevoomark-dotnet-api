using System;

namespace ReevooMark
{
	public abstract class AbstractReevooMarkClientTag:AbstractReevooTag
	{
		protected String _locale="";

		protected String _numberOfReviews="/";

		public String Locale
		{
			get 
			{ 
				if (!String.IsNullOrEmpty(_locale))
					return "/" +_locale;
				return _locale;
			}
			set { _locale = value; }
		}

		public String NumberOfReviews
		{
			get 
			{ 
				if (!String.IsNullOrEmpty(_numberOfReviews))
					return "/" +_locale;
				return _locale;
			}
			set { _locale = value; }
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if (String.IsNullOrEmpty(Locale) && !String.IsNullOrEmpty(NumberOfReviews))
			{
				Trace.Write("Locale property is empty; returning nothing");
			}
			if (!String.IsNullOrEmpty(Locale) && String.IsNullOrEmpty(NumberOfReviews))
			{
				Trace.Write("NumberOfReviews property is empty; returning nothing");
			}
		}


	}
}

