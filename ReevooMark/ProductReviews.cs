using System;
using System.Web.Configuration;

namespace ReevooMark {

    public class ProductReviews :AbstractReevooMarkClientTag  {
        public ProductReviews () {
			this.BaseUri = Config.BaseUri() + "reevoomark/embeddable_reviews";
        }

        protected override void OnInit (EventArgs e) {
            base.OnInit (e);
            if (String.IsNullOrEmpty (Sku)) {
                Trace.Write ("Sku property is empty; returning nothing");
            }
               
            if (!String.IsNullOrEmpty (Locale) && String.IsNullOrEmpty (NumberOfReviews)) {
                Trace.Write ("NumberOfReviews property is empty; returning nothing");
            }
        }
    }

}
