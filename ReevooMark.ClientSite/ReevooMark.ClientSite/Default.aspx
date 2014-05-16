<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReevooMark.ClientSite._Default" %>
<%@ Register TagPrefix="reevoo" Namespace="ReevooMark" Assembly="ReevooMark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
    <head id="Head1" runat="server">
        <title></title>
        <link rel="stylesheet" type="text/css" 
            href="http://mark.reevoo.com/stylesheets/reevoomark/embeded_reviews.css" />
    </head>
    <body>
        <form id="Form1" runat="server">
            <div class="page">
                <div class="main">
                    <div>
                        <reevoo:Mark SKU="67255143" TkRef="TSC" runat="server"/>
                        <reevoo:ReevooCustomerExperienceReviews  TkRef="CYS" runat="server"/>
                    </div>
                    <script src="http://mark.reevoo.com/reevoomark/TSC.js"></script>

                    <script>
                        ReevooMark.init_badges();
                    </script>
                </div>
            </div>
        </form>
    </body>
</html>