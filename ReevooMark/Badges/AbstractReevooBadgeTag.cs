using System;
using System.Web.UI;

namespace ReevooMark
{
    public abstract class AbstractReevooBadgeTag: AbstractReevooTag
    {
        protected String variantName;
        protected String badgeClass;

        public String VariantName {
            get { return variantName; }
            set { 
                if (!String.IsNullOrEmpty (value)) {
                    if (!value.EndsWith ("_variant") && !value.Equals ("undecorated")) {
                        this.variantName = value + "_variant";
                    } else {
                        this.variantName = value;
                    }
                }
            } 
        }

        public String BadgeClass {
            get {
                if (String.IsNullOrEmpty (VariantName)) {
                    return badgeClass;
                } else {
                    return badgeClass + " " + VariantName;
                }
            }
        
            set { badgeClass = value; }
        }

        protected override void Render (HtmlTextWriter writer)
        {    
            try {
                string hrefValue = String.Format (BaseUri, TRKREF, SKU);

                writer.AddAttribute (HtmlTextWriterAttribute.Class, BadgeClass);
                writer.AddAttribute (HtmlTextWriterAttribute.Href, hrefValue);

                writer.RenderBeginTag (HtmlTextWriterTag.A);
                writer.Write (this.Text);
                writer.RenderEndTag ();
            } catch (Exception e_) {
                throw new ReevooException (e_);
            }
        }
    }
}

