using System;

namespace ReevooMark
{
    public class Mark : AbstractReevooTag
    {
        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);
            if (String.IsNullOrEmpty (SKU)) {
                Trace.Write ("SKU property is empty; returning nothing");
            }

            if (String.IsNullOrEmpty (BaseUri)) {
                Trace.Write ("BaseUri property is empty; returning nothing");
            }
        }
    }
}