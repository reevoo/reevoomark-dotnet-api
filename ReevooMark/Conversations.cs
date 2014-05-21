using System;

namespace ReevooMark
{
    public class Conversations : AbstractReevooMarkClientTag
    {
        public Conversations ()
        {
            this.BaseUri = @"http://mark.reevoo.com/reevoomark{0}{1}embeddable_conversations";
        }

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);
            if (String.IsNullOrEmpty (SKU)) {
                Trace.Write ("SKU property is empty; returning nothing");
            }

            if (String.IsNullOrEmpty (Locale) && !String.IsNullOrEmpty (NumberOfReviews)) {
                Trace.Write ("Locale property is empty; returning nothing");
            }
            if (!String.IsNullOrEmpty (Locale) && String.IsNullOrEmpty (NumberOfReviews)) {
                Trace.Write ("NumberOfReviews property is empty; returning nothing");
            }
        }
    }
}

