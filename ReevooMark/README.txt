DESCRIPTION
===========
 A .Net client for ReevooMark partners wanting to integrate Reevoo content into their websites.

LICENSE
=======
 Code is released under an MIT license; though use of Reevoo content requires users to be a certified ReevooMark client.

FEATURES
========

 * Simple access to per-product ReevooMark data

SYNOPSIS
========

Code:
	using System;
	using ReevooMark;

	var client = new ReevooClient(3000);	// set timeout explicitly
	ReevooMarkData reevooData = null;
	try {
	  reevooData = client.ObtainReevooMarkData(trkref_, sku_, baseUri_);
	}
	catch(ReevooException re) {				// *always* catch ReevooException here
											// handle gracefully
	}
	var score = reevooData.OverallScore;

asp.Net:
	#Register namespace prefix.
	<%@ Register TagPrefix="reevoo" Namespace="ReevooMark" Assembly="ReevooMark" %>

	#Add stylesheet for retailer branding. Replace TSC for your own retailer code.
	<link rel="stylesheet" type="text/css" href="http://mark.reevoo.com/stylesheets/reevoomark/embeded_reviews.css?trkref=TSC" />

	#Display in-line reviews for the retailer TSC and the SKU 67255143
	<reevoo:Mark SKU="67255143" TkRef="TSC" runat="server" />

VERSIONS
========
Supported: .Net versions 2.0, 3.5, 4
Not supported: .Net versions 1.0, 1.1