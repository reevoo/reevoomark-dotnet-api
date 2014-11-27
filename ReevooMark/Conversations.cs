using System;

namespace ReevooMark
{
    public class Conversations : AbstractReevooMarkClientTag
    {
        public Conversations ()
        {
			this.BaseUri = Config.BaseUri() + "reevoomark/embeddable_conversations";
        }

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            if (String.IsNullOrEmpty (Sku)) {
                Trace.Write ("Sku property is empty; returning nothing");
            }
                
        }
    }
}

