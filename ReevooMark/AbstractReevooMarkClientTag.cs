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
				_content = client.ObtainReevooMarkData (BuildParams(), BaseUri).Content;
            } catch (ReevooException re_) {
                //We wrap all exceptions with a ReevooException. Log the error & return the empty string.
                Trace.Write (re_.Message);
                _content = String.Empty;
            }
            return _content;
        }

		protected override Parameters BuildParams () {
			return new Parameters () {
				{ "locale", Locale },
				{ "reviews", IsPaginated() ? null : NumberOfReviews }, // we are using 'reviews' when not paginated
				{ "trkref", Trkref },
				{ "sku", Sku },
				{ "per_page", IsPaginated() ? NumberOfReviews : null }, // we are using 'per_page' when paginated
				{ "page", GetReevooParam("page", "1") },
				{ "sort_by", GetReevooParam("sort_by") },
				{ "filter", GetReevooParam("filter") },
			};
		}
		protected string GetReevooParam(string paramName) {
			return GetReevooParam (paramName, null);
		}

		protected string GetReevooParam(string paramName, string defaultValue) {
			if (!IsPaginated())
				return null;

			string paramValue = GetRequestParamValue("reevoo_" + paramName);

			if (paramValue != null)
				return paramValue;

			return defaultValue;
		}

		protected string GetRequestParamValue(string key) {
			return ParamCollection().Get(key);
		}

		public virtual NameValueCollection ParamCollection() {
			return HttpUtility.ParseQueryString(Request.Url.Query);
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