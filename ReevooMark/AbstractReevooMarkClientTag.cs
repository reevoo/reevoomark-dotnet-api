using System;
using System.Collections.Generic;

namespace ReevooMark
{
    public abstract class AbstractReevooMarkClientTag:AbstractReevooTag
    {
        protected String _locale = "";
        protected String _numberOfReviews = "";
		protected String _paginated = "";
        public ReevooClient client = new ReevooClient ();

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);
            this.client = new ReevooClient ();
        }

        protected override void Render (System.Web.UI.HtmlTextWriter writer)
        {    
            String content = GetContent ();
            if (content == null) {
                writer.Write (Text);
            } else {
                writer.Write (content);
            }
        }

        public String GetContent ()
        {
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

		public override Parameters BuildParams ()
		{
			return new Parameters () {
				{ "trkref", Trkref },
				{ "sku", Sku },
				{ "per_page", IsPaginated() ? NumberOfReviews : null },
				{ "page", IsPaginated() ? "1" : null },
			};
		}

        public String BuildUrl ()
        {
            return String.Format (BaseUri, Locale, NumberOfReviews); 
        }

        public String Locale {
            get { 
                if (!String.IsNullOrEmpty (_locale))
                    return "/" + _locale;
                return _locale;
            }
            set { _locale = value; }
        }

        public String NumberOfReviews {
            get { 
                if (!String.IsNullOrEmpty (_numberOfReviews))
                    return "/" + _numberOfReviews + "/";
                return "/";
            }
            set { 
                _numberOfReviews = value;
            }
        }

		public String Paginated {
			get {
				return _paginated;
			}
			set {
				_paginated = value;
			}
		}

		public bool IsPaginated() {
			return Paginated == "true" || Paginated == "yes";
		}
    }
}

