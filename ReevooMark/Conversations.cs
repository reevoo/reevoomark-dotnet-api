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
            if (String.IsNullOrEmpty (Sku)) {
                Trace.Write ("Sku property is empty; returning nothing");
            }
                
        }
    }
}

