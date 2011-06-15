DESCRIPTION
===========

A .Net client for ReevooMark partners wanting to integrate Reevoo content into their websites.

FEATURES
========

   * Simple access to per-product ReevooMark data

SYNOPSIS
========

Code
----

    var client = new ReevooClient(3000);	// set timeout explicitly
    ReevooMarkData reevooData = null;

    try
    {
        reevooData = client.ObtainReevooMarkData(trkref_, sku_, baseUri_);
    }
    catch(ReevooException re)
    {						// *always* catch ReevooException here
						// handle gracefully
    }
    var score = reevooData.OverallScore;

asp.Net
-------

    #Register namespace prefix.
    <%@ Register TagPrefix="reevoo" Namespace="ReevooMark" Assembly="ReevooMark" %>

    #Add stylesheet for retailer branding. Replace TSC for your own retailer code.
    <link rel="stylesheet" type="text/css" href="http://mark.reevoo.com/stylesheets/reevoomark/embeded_reviews.css?trkref=TSC" />

    #Display in-line reviews for the retailer TSC and the SKU 67255143
    <reevoo:Mark SKU="67255143" TkRef="TSC" runat="server" />

REQUIREMENTS
============


VERSIONS
========

Supported: .Net versions 2.0, 3.5, 4
Not supported: .Net versions 1.0, 1.1

LICENSE
=======

This software is released under the MIT license.  Only certified ReevooMark partners
are licensed to display Reevoo content on their sites.  Contact [mailto:sales@reevoo.com] for
more information.

(The MIT License)

Copyright (c) 2008 - 2010:

* {Reevoo}[http://www.reevoo.com]

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
'Software'), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.