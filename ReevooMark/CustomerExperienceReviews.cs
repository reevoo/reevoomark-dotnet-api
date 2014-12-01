using System;

namespace ReevooMark {

    /// <summary>
    /// A <see cref="System.Web.UI.UserControl"/> for showing in-line reviews for Reevoo products
    /// </summary>
    public class CustomerExperienceReviews :AbstractReevooMarkClientTag {
        public CustomerExperienceReviews () {
            this.BaseUri = Config.BaseUri() + "reevoomark/embeddable_customer_experience_reviews";
        }
    }
}
