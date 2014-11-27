using System;
using System.Web.UI;
using System.ComponentModel;
using System.Web.Configuration;
using System.Collections.Generic;

namespace ReevooMark {

    /// <summary>
    /// Base abstact class <see cref="System.Web.UI.UserControl"/> for showing Reevoomark products.
    /// </summary>
    [ParseChildren (true, "Text")]
    public abstract class AbstractReevooTag : System.Web.UI.UserControl {
        protected string _baseUri;

        protected override void OnInit (EventArgs e) {

            if (String.IsNullOrEmpty (Trkref) && String.IsNullOrEmpty (WebConfigurationManager.AppSettings ["Trkref"])) {
                Trace.Write ("Trkref property is empty; returning nothing");
            } else if (String.IsNullOrEmpty (Trkref)) {
                this.Trkref = WebConfigurationManager.AppSettings ["Trkref"]; 
            }

		}

		protected virtual Parameters BuildParams () {
			return new Parameters () {
				{ "trkref", Trkref },
				{ "sku", Sku },
			};
		}

        public String Sku { get; set; }

        public String Trkref { get; set; }

        [DefaultValue ("")]
        public String Text { get; set; }
        //provide a sensible default for BaseUri, seeing as we know it.
        public String BaseUri {
            get { return _baseUri; }
            set { _baseUri = value; }
        }
    }
}

