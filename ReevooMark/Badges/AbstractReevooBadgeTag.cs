using System;
using System.Web.UI;

namespace ReevooMark
{
	public abstract class AbstractReevooBadgeTag: AbstractReevooTag
	{
		protected String variantName;

		protected String badgeClass;

		public String VariantName
		{
			get { return variantName; }
			set { variantName = value; }
		}

		public String BadgeClass {
			get {
				if (String.IsNullOrEmpty (VariantName)) {
					return badgeClass;
				} else {
					return badgeClass + VariantName;
				} 
			}
			set {badgeClass = value; }
		}
			

		protected override void Render(HtmlTextWriter writer)
		{	
			try{
				string hrefValue = String.Format(BaseUri, TkRef, SKU);

				writer.AddAttribute (HtmlTextWriterAttribute.Class, BadgeClass);
				writer.AddAttribute (HtmlTextWriterAttribute.Href, hrefValue);

				writer.RenderBeginTag (HtmlTextWriterTag.A);
				writer.Write(this.Text);
				writer.RenderEndTag();
			}
			catch (Exception e_)
			{
				throw new ReevooException(e_);
			}
		}	

	}	
}

