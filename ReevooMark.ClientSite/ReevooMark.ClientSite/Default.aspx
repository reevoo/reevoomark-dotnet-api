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
                	<h1> Tags that use the default TRKREF from the web.config file </h1>
                	<h2>Product Reviews</h2>
                	<reevoo:ProductReviews SKU="337" runat="server"/>
                    <h2>Customer Experience Reviews</h2>
                    <reevoo:CustomerExperienceReviews runat="server"/>
                    <h2>Conversations</h2>
                    <reevoo:Conversations SKU="337" runat="server"/>
                    <reevoo:JavascriptAssets runat="server"/>
                    <h2>Product Badge Undecorated</h2>
                    <reevoo:ProductBadge SKU="337" VariantName = "undecorated" runat="server">Read reviews</reevoo:ProductBadge> 
                    <h2>Overall Service Rating Badge</h2>
                    <reevoo:OverallServiceRatingBadge runat="server" />
                    <h2>Delivery Rating Badge</h2>
                    <reevoo:DeliveryRatingBadge runat="server" />
                    <h2>Customer Service Rating Badge</h2>
                    <reevoo:CustomerServiceRatingBadge runat="server" />
                    <h2>Conversation Badge</h2>
                    <reevoo:ConversationsBadge SKU="337" runat="server" />                
                    <h2>Product Series Badge</h2>
                    <reevoo:ProductSeriesBadge SKU="i20" runat="server" />
                    <h2>Conversation Series Badge </h2>
                    <reevoo:ConversationSeriesBadge SKU="i20" runat="server" />
                    <h1> Tags that override the default TRKREF from the web.config file. </h1>
                    <h2>Product Reviews</h2>
                    <reevoo:ProductReviews SKU="67255143" TRKREF="TSC" runat="server"/>
                    <h2>Customer Experience Reviews</h2>
                    <reevoo:CustomerExperienceReviews TRKREF="CYS" NumberOfReviews="3" runat="server"/> 
                    <h2>Conversations</h2>
                    <reevoo:Conversations TRKREF="REV" SKU="167823" runat="server"/>
                    <h2>Product Badge Undecorated</h2>
                    <reevoo:ProductBadge SKU="67255143" TRKREF="TSC" VariantName = "undecorated" runat="server">Read reviews</reevoo:ProductBadge>
                    <h2>Product Badge Variant</h2>
                    <reevoo:productBadge TRKREF="EBU" SKU="582929" VariantName="search_page_variant" runat="server"/>
                    <h2>Product Badge</h2>
                    <reevoo:ProductBadge SKU="67255143" TRKREF="TSC" runat="server" />
                    <h2>Overall Service Rating Badge</h2>
                    <reevoo:OverallServiceRatingBadge TRKREF="CYS" runat="server" />
                    <h2>Delivery Rating Badge</h2>
                    <reevoo:DeliveryRatingBadge TRKREF="EBU" runat="server" />
                    <h2>Customer Service Rating Badge</h2>
                    <reevoo:CustomerServiceRatingBadge TRKREF="PIU" runat="server" />
                    <h2>Conversations Badge</h2>
                    <reevoo:ConversationsBadge TRKREF="REV" SKU="167823" VariantName = "undecorated" runat="server">Aham</reevoo:ConversationsBadge>
                    <h2>Product Series Badge</h2>
                    <reevoo:ProductSeriesBadge TRKREF="HYU" SKU="i20" runat="server" />
                    <h2>Conversation Series Badge </h2>
                    <reevoo:ConversationSeriesBadge TRKREF="HYU" SKU="i20" runat="server" />
                    <reevoo:Mark TRKREF="REV" SKU="167823" BaseUri ="http://mark.reevoo.com/reevoomark/en-GB/embeddable_reviews" runat="server" />
                    <h2>Product Reviews with locale</h2>
                	<reevoo:ProductReviews SKU="167823" TRKREF="REV" Locale="fr-FR" NumberOfReviews="5" runat="server"/>
                    <reevoo:JavascriptAssets TRKREF="CYS,REV,EBU,PIU,HYU" runat="server"/>
                </div>
            </div>
         </form>
    </body>
</html>