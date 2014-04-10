#reevoomark-dotnet-api

##Description

The reevoomark-dotnet-api is a .NET tag library for ReevooMark and Reevoo Essentials customers who want to quickly and easily integrate Reevoo content in to their sites server-side.

##Other Languages
Tag libraries are also available for [Java](https://github.com/reevoo/reevoomark-java-api) and [PHP](https://github.com/reevoo/reevoomark-php-api).

##Features

* Server-side inclusion of Reevoo content.
* Included CSS for display of Reevoo content.
* Server-side caching of content that respects the cache control rules set by Reevoo.

##Support
For ReevooMark and Reevoo Essentials customers, support can be obtained by emailing <operations@reevoo.com>.

There is also a [bug tracker](http://github.com/reevoo/reevoomark-dotnet-api/issues) available.

##Installation

Install [NuGet](http://nuget.org/) if you don't already have it, then run the following command in the package manager console:

```
Install-Package ReevooMark
```

##Implementation

Include the relevant CSS. For product reviews use:

``` html
<link rel="stylesheet" href="http://mark.reevoo.com/stylesheets/reevoomark/embedded_reviews.css" type="text/css" />
```

Include your customer specific Reevoo JavaScript:

If you don't need https you can include the JavaScript like this:

``` html
<script id="reevoomark-loader">
  (function() {
    var script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = 'http://cdn.mark.reevoo.com/assets/reevoo_mark.js';
    var s = document.getElementById('reevoomark-loader');
    s.parentNode.insertBefore(script, s);
  })();
  
  afterReevooMarkLoaded = [];
  afterReevooMarkLoaded.push(function(){
    ReevooApi.load('TRKREF', function(retailer){
      retailer.init_badges();
    });
  });
</script>
```

If you do need to use https you can include the JavaScript like this:

``` html
<script id="reevoomark-loader">
  (function() {
    var trkref = 'TRKREF';
    var myscript = document.createElement('script');
    myscript.type = 'text/javascript';
    myscript.src=('//mark.reevoo.com/reevoomark/'+trkref+'.js?async=true');
    var s = document.getElementById('reevoomark-loader');
    s.parentNode.insertBefore(myscript, s);
  })();
</script>
```

Register the namespace prefix:

``` net
<%@ Register TagPrefix="reevoo" Namespace="ReevooMark" Assembly="ReevooMark" %>
```

Render embedded review content. Make sure to replace `<SKU>` and `<TRKREF>` with the appropriate values:

``` net
<reevoo:Mark SKU="<SKU>" TkRef="<TRKREF>" runat="server" />
```

It is also possible to set the locale by changing `<LOCALE>` to an appropriate value such as `fr-FR`:

``` net
<reevoo:Mark SKU="<SKU>" TkRef="<TRKREF>" BaseUri="http://mark.reevoo.com/reevoomark/<LOCALE>/embeddable_reviews.html" runat="server" />
```

### Rendering Issues

Any changes to the visiblity settings of the 'traffic reviews solution' will require you to call the code below to ensure the correct formatting is applied.

NOTE: This assumes you are using the latest version of the Reevoo JS library.

``` javascript
ReevooMark.auto_scale()
```

## Tracking

If you display the reviews in a tabbed display, or otherwise require visitors to your site to click an element before seeing the embedded reviews, add the following onclick attribute to track the clickthroughs:

``` html
  onclick="ReevooMark.track_click_through(‘<SKU>’)”
```

## Overall rating

The overall rating section at the top of inline reviews contains an overall score, a summary and the score breakdowns. 

##Requirements

.NET v2.0+

##License

This software is released under the MIT license.  Only certified ReevooMark partners
are licensed to display Reevoo content on their sites.  Contact <sales@reevoo.com> for
more information.

(The MIT License)

Copyright (c) 2008 - 2010:

* [Reevoo](http://www.reevoo.com)

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
