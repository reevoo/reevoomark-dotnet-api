﻿using System;

namespace ReevooMark
{
	/// <summary>
	/// A <see cref="System.Web.UI.UserControl"/> for showing in-line reviews for Reevoo products
	/// </summary>
	public class CustomerExperienceReviews :AbstractReevooMarkClientTag
	{
		public CustomerExperienceReviews(){
			this.BaseUri = String.Format(@"http://mark.reevoo.com/reevoomark{0}embeddable_customer_experience_reviews", NumberOfReviews);
		}

	}

}
