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
                    <h2><a href="/ClassicReviews.aspx">Classic Reviews</a></h2>
                    <h2><a href="/PaginatedProductReviews.aspx">Paginated Product Reviews</a></h2>
                    <h2><a href="/PaginatedCXReviews.aspx">Paginated Customer Experience Reviews</a></h2>
                </div>
            </div>
         </form>
    </body>
</html>