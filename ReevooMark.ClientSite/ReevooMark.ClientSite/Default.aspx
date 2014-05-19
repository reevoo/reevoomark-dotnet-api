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
                    <div>
                    	<h2>Product Reviews</h2>
                        <reevoo:ProductReviews SKU="67255143" TkRef="TSC" runat="server"/>
                        <h2>Customer Experience Reviews</h2>
                        <reevoo:CustomerExperienceReviews TkRef="CYS" runat="server"/> 
                        <h2>Conversations</h2>
                        <reevoo:Conversations TkRef="REV" SKU="167823" runat="server"/>
                        <h2>Product Badge Undecorated</h2>
                        <reevoo:ProductBadge SKU="67255143" TkRef="TSC" VariantName = "undecorated" runat="server">
                        	Read reviews
                        </reevoo:ProductBadge>
                    	<h2>Product Badge</h2>
                        <reevoo:ProductBadge SKU="67255143" TkRef="TSC" runat="server" />
                        <h2>Overall Service Rating Badge</h2>
                        <reevoo:OverallServiceRatingBadge TkRef="CYS" runat="server" />
                        <h2>Delivery Rating Badge</h2>
                        <reevoo:DeliveryRatingBadge TkRef="EBU" runat="server" />
                        <h2>Customer Service Rating Badge</h2>
                        <reevoo:CustomerServiceRatingBadge TkRef="PIU" runat="server" />
                        <h2>Conversation Badge</h2>
                        <reevoo:ConversationsBadge TkRef="REV" SKU="167823" runat="server" />
                        <h2>Product Series Badge</h2>
                        <reevoo:ProductSeriesBadge TkRef="HYU" SKU="i20" runat="server" />
                        <h2>Conversation Series Badge </h2>
                        <reevoo:ConversationSeriesBadge TkRef="HYU" SKU="i20" runat="server" />
                    </div>
   					<reevoo:JavascriptAssets TkRef="CYS,REV,TSC,EBU,PIU,HYU" runat="server"/>
                </div>
            </div>
        </form>
    </body>
</html>