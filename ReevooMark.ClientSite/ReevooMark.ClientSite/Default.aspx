<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReevooMark.ClientSite._Default" %>
<%@ Register TagPrefix="reevoo" Namespace="ReevooMark" Assembly="ReevooMark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
    <head id="Head1" runat="server">
        <title></title>   
            <reevoo:CssAssets runat="server"/>
    </head>
    <body>
        <form id="Form1" runat="server">
            <div class="page">
                <div class="main">
                    <h2>Product Reviews without trkref</h2>
                	<reevoo:ProductReviews sku="167823" runat="server">FALLBACK TEXT</reevoo:ProductReviews>
                	<h2>Product Reviews</h2>
                	<reevoo:ProductReviews sku="167823" trkref="REV" runat="server"/>
                    <h2>Customer Experience Reviews</h2>
                    <reevoo:CustomerExperienceReviews trkref="CYS" numberOfReviews="3" runat="server"/> 
                    <h2>Conversations</h2>
                    <reevoo:Conversations trkref="REV" sku="167823" runat="server"/>
                    <h2>Product Badge Undecorated</h2>
                    <reevoo:ProductBadge sku="67255143" trkref="TSC" variantName = "undecorated" runat="server">Read reviews</reevoo:ProductBadge>
                    <h2>Product Badge Variant</h2>
                    <reevoo:productBadge trkref="EBU" sku="582929" variantName="search_page_variant" runat="server"/>
                    <h2>Product Badge</h2>
                    <reevoo:ProductBadge sku="67255143" trkref="TSC" runat="server" />
                    <h2>Overall Service Rating Badge</h2>
                    <reevoo:OverallServiceRatingBadge trkref="CYS" runat="server" />
                    <h2>Delivery Rating Badge</h2>
                    <reevoo:DeliveryRatingBadge trkref="EBU" runat="server" />
                    <h2>Customer Service Rating Badge</h2>
                    <reevoo:CustomerServiceRatingBadge trkref="PIU" runat="server" />
                    <h2>Conversations Badge</h2>
                    <reevoo:ConversationsBadge trkref="REV" sku="167823" variantName = "undecorated" runat="server">Aham</reevoo:ConversationsBadge>
                    <h2>Product Series Badge</h2>
                    <reevoo:ProductSeriesBadge trkref="HYU" sku="i20" runat="server" />
                    <h2>Conversation Series Badge </h2>
                    <reevoo:ConversationSeriesBadge trkref="HYU" sku="i20" runat="server" />
                    <h2>Product Reviews with locale</h2>
                	<reevoo:ProductReviews sku="167823" trkref="REV" locale="fr-FR" numberOfReviews="5" runat="server"/>
 					<reevoo:Mark sku="167823" BaseUri ="http://mark.reevoo.com/reevoomark/en-GB/embeddable_reviews" runat="server"> Hello </reevoo:Mark>
                    <reevoo:JavascriptAssets trkref="CYS,REV,EBU,PIU,HYU,TSC" runat="server"/>
                </div>
            </div>
         </form>
    </body>
</html>