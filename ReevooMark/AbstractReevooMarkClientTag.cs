using System;
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ReevooMark {

    public abstract class AbstractReevooMarkClientTag:AbstractReevooTag {
        protected String _locale = "";
        protected String _numberOfReviews = "";
		protected String _paginated = "";
        public ReevooClient client = new ReevooClient ();

        protected override void OnInit (EventArgs e) {
            base.OnInit (e);
            this.client = new ReevooClient ();
        }

        protected override void Render (System.Web.UI.HtmlTextWriter writer) {    
            String content = GetContent ();
            if (content == null) {
                writer.Write (Text);
            } else {
                writer.Write (content);
            }
        }

        public String GetContent () {
            String _content;
            try {
				_content = client.ObtainReevooMarkData (BuildParams(), BuildUrl()).Content;
            } catch (ReevooException re_) {
                //We wrap all exceptions with a ReevooException. Log the error & return the empty string.
                Trace.Write (re_.Message);
                _content = String.Empty;
            }
            return _content;
        }

		public override Parameters BuildParams () {
			return new Parameters () {
				{ "locale", Locale },
				{ "reviews", IsPaginated() ? null : NumberOfReviews },
				{ "trkref", Trkref },
				{ "sku", Sku },
				{ "per_page", IsPaginated() ? NumberOfReviews : null },
				{ "page", CurrentPage() },
				{ "sort_by", SortBy() },
				{ "filter", Filter() },
			};
		}

		public string SortBy() {
			if (!IsPaginated())
				return null;

			string reevooSortBy = GetRequestParamValue("reevoo_sort_by");

			if (reevooSortBy != null)
				return reevooSortBy;

			return "seo_boost";
		}

		public string CurrentPage() {
			if (!IsPaginated())
				return null;

			string reevooPage = GetRequestParamValue("reevoo_page");

			if (reevooPage != null)
				return reevooPage;

			return "1";
		}

		public string Filter() {
			if (!IsPaginated())
				return null;

			return GetRequestParamValue("reevoo_filter");
		}

		public string GetRequestParamValue(string key) {
			NameValueCollection paramCollection = HttpUtility.ParseQueryString (Request.Url.Query);
			return paramCollection.Get (key);
		}

		public string BuildUrl ()
        {
            return BaseUri; 
        }

		public string Locale {
            get {  return _locale; }
            set { _locale = value; }
        }

		public string NumberOfReviews {
			get {
				if (!IsPaginated ())
					return _numberOfReviews;

				if (_numberOfReviews == null || _numberOfReviews == "")
					return "default";

				return _numberOfReviews;
			}
            set { _numberOfReviews = value; }
        }

		public string Paginated {
			get { return _paginated; }
			set { _paginated = value; }
		}

		public bool IsPaginated() {
			return Paginated == "true" || Paginated == "yes";
		}
    }
}