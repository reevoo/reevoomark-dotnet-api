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

##Configuration
In your ```web.config``` file add the value of the TRKREF provided to you by Reevoo in the following way:

```net
<appSettings>
   <add key="TRKREF" value="PIU"/>
</appSettings>
```
This will be used throughout your web server wherever you use a Reevoo asset without specifying an alternative TRKREF.

For example,

```net
<reevoo:JavascriptAssets runat="server"/>
```
will initialize our Reevoo javascript assets with the default TRKREF provided in the web.config file, in this case trkref="PIU". You can override this default value by providing the TRKREF in the following way:

```net
<reevoo:JavascriptAssets  trkref="REV" runat="server"/>
```

##Implementation

Register the namespace prefix:

```net
<%@ Register TagPrefix="reevoo" Namespace="ReevooMark" Assembly="ReevooMark" %>
```

You should include the Reevoo specific CSS in your header:

```net
<reevoo:CssAssets runat="server"/>
```

You should include the Reevoo specific JavaScript at the bottom of your body:

```net
<reevoo:JavascriptAssets runat="server"/>
```

As before you may set an explicit TRKREF if you wish.


```net
<reevvoo:JavascriptAssets  trkref="REV" runat="server"/>
```
It also has support for multiple TRKREF'S.


```net
<reevvoo:JavascriptAssets  trkref="REV, CYS, HYU" runat="server"/>
```



### Standard Badges

#### Product Badge

To render "product badges" you can use any of the below.
The ```SKU``` is compulsory but ```TRKREF``` and ```VariantName``` are optional.

Make sure to replace `<SKU>`,`<TRKREF>` and `<VARIANT_NAME>` with the appropriate values.

```net
  <reevoo:ProductBadge sku="<SKU>" runat="server"/>
  <reevoo:ProductBadge sku="<SKU>" trkref="<TRKREF>" runat="server"/>
  <reevoo:ProductBadge sku="<SKU>" variantName="undecorated" runat="server"/>
  <reevoo:ProductBadge sku="<SKU>" trkref="<TRKREF>" variantName="stars_only" runat="server"/>
```

#### Conversations Badge

To render "conversations badges" you can use any of the below.
The ```SKU``` is compulsory but ```TRKREF``` and ```VariantName``` are optional.

Make sure to replace `<SKU>`,`<TRKREF>` and `<VARIANT_NAME>` with the appropriate values.

```net
  <reevoo:ConversationsBadge sku="<SKU>" runat="server"/>
  <reevoo:ConversationsBadge sku="<SKU>" trkref="<TRKREF>" runat="server"/>
  <reevoo:ConversationsBadge sku="<SKU>" variantName="undecorated" runat="server"/>
  <reevoo:ConversationsBadge sku="<SKU>" trkref="<TRKREF>" variantName="<VARIANT_NAME>" runat="server"/>
```

### Series Badges

#### Product Badges

To render "product series badges" you can use any of the below.
The ```SKU``` is compulsory and should be set to the series id. The ```TRKREF``` and ```VariantName``` are optional.

Make sure to replace `<SKU>`,`<TRKREF>` and `<VARIANT_NAME>` with the appropriate values.

```net
  <reevoo:ProductSeriesBadge sku="<SKU>" runat="server" />
  <reevoo:ProductSeriesBadge sku="<SKU>" trkref="<TRKREF>" runat="server"/>
  <reevoo:ProductSeriesBadge sku="<SKU>" variantName="undecorated" runat="server"/>
  <reevoo:ProductSeriesBadge sku="<SKU>" trkref="<TRKREF>" variantName="<VARIANT_NAME>" runat="server"/>
```

#### Conversations Badges

To render "conversation series badges" you can use any of the below.
The ```SKU``` is compulsory and should be set to the series id. The ```TRKREF``` and ```VariantName``` are optional.

Make sure to replace `<SKU>`,`<TRKREF>` and `<VARIANT_NAME>` with the appropriate values.

```net
  <reevoo:ConversationSeriesBadge sku="<SKU>" runat="server"/>
  <reevoo:ConversationSeriesBadge sku="<SKU>" trkref="<TRKREF>" runat="server"/>
  <reevoo:ConversationSeriesBadge sku="<SKU>" variantName="undecorated" runat="server"/>
  <reevoo:ConversationSeriesBadge sku="<SKU>" trkref="<TRKREF>" variantName="<VARIANT_NAME>" runat="server"/>
```

### Overall Service Rating Badges

To render "Overall Service Rating badges" you can use any of the below.
The ```TRKREF``` and ```VariantName``` are optional.

Make sure to replace `<TRKREF>` and `<VARIANT_NAME>` with the appropriate values.

```net
  <reevoo:OverallServiceRatingBadge runat="server"/>
  <reevoo:OverallServiceRatingBadge trkref="<TRKREF>" runat="server"/>
  <reevoo:OverallServiceRatingBadge variantName="undecorated" runat="server"/>
  <reevoo:OverallServiceRatingBadge trkref="<TRKREF>" variantName="<VARIANT_NAME>" runat="server"/>
```

### Customer Service Rating Badges

To render "Customer Service Rating badges" you can use any of the below.
The ```TRKREF``` and ```VariantName``` are optional.

Make sure to replace `<TRKREF>` and `<VARIANT_NAME>` with the appropriate values.

```net
  <reevoo:CustomerServiceRatingBadge runat="server"/>
  <reevoo:CustomerServiceRatingBadge trkref="<TRKREF>" runat="server"/>
  <reevoo:CustomerServiceRatingBadge variantName="undecorated" runat="server"/>
  <reevoo:CustomerServiceRatingBadge trkref="<TRKREF>" variantName="<VARIANT_NAME>" runat="server"/>
```

### Delivery Rating Badges

To render "Delivery Rating badges" you can use any of the below.
The ```TRKREF``` and ```VariantName``` are optional.

Make sure to replace `<TRKREF>` and `<VARIANT_NAME>` with the appropriate values.

```net
  <reevoo:DeliveryRatingBadge runat="server"/>
  <reevoo:DeliveryRatingBadge trkref="<TRKREF>" runat="server"/>
  <reevoo:DeliveryRatingBadge variantName="undecorated" runat="server"/>
  <reevoo:DeliveryRatingBadge trkref="<TRKREF>" variantName="<VARIANT_NAME>" runat="server"/>
```

### Embedded Review Content

To render "embedded review content" you can use any of the below.
The ```SKU``` attribute is compulsory but ```TRKREF```, ```Locale``` and ```NumberOfReviews``` are optional.

If you wish to use ```NumberOfReviews``` you must include the ```Locale```.

Make sure to replace `<SKU>` and `<TRKREF>`, `<LOCALE>` and `<NUMBEROFREVIEWS>` with the appropriate values.

```net
  <reevoo:ProductReviews sku="<SKU>" runat="server" />
  <reevoo:ProductReviews sku="<SKU>" trkref="<TRKREF>" runat="server"/>
  <reevoo:ProductReviews sku="<SKU>" trkref="<TRKREF>" locale="<LOCALE>" runat="server"/>
  <reevoo:ProductReviews sku="<SKU>" trkref="<TRKREF>" locale="<LOCALE>" numberOfReviews="<NUMBEROFREVIEWS>" runat="server"/>
  <reevoo:ProductReviews sku="<SKU>" trkref="<TRKREF>" locale="<LOCALE>" numberOfReviews="<NUMBEROFREVIEWS>" paginated="true" runat="server"/>
```

#### Overall rating

The overall rating section at the top of inline reviews contains an overall score, a summary and the score breakdowns.

#### Fallback

If you would like to fall back to some content when Reevoo content is not available, just specify it within the tag:

```net
  <reevoo:ProductReviews sku="<SKU>" runat="server">
    <p>Sorry we don't have any reviews available right now</p>
  </reevoo:ProductReviews>
```

### Embedded Conversation Content

To render "embedded conversations content" you can use any of the below.
The ```SKU``` attribute is compulsory but ```TRKREF``` is optional.

Make sure to replace `<SKU>` and `<TRKREF>` with the appropriate values.

```net
  <reevoo:Conversations sku="<SKU>" runat="server" />
  <reevoo:Conversations sku="<SKU>" trkref="<TRKREF>" runat="server"/>
```

#### Fallback

If you would like to fall back to some content when Reevoo content is not available, just specify it within the tag:

```net
  <reevoo:Conversations sku="<SKU>" runat="server">
    <p>Sorry we don't have any conversations available right now</p>
  </reevoo:Conversations>
```

### Embedded Customer Experience Review Content

To render "embedded customer experience review content" you can use any of the below.
The ```TRKREF``` and ```NumberOfReviews``` are optional.

Make sure to replace `<TRKREF>` and `<NUMBEROFREVIEWS>` with the appropriate values.

```net
  <reevoo:CustomerExperienceReviews runat="server"/>
  <reevoo:CustomerExperienceReviews trkref="<TRKREF>" runat="server"/>
  <reevoo:CustomerExperienceReviews numberOfReviews="<NUMBEROFREVIEWS>" runat="server"/>
  <reevoo:CustomerExperienceReviews trkref="<TRKREF>" numberOfReviews="<NUMBEROFREVIEWS>" runat="server"/>
  <reevoo:CustomerExperienceReviews trkref="<TRKREF>" numberOfReviews="<NUMBEROFREVIEWS>" paginated="true" runat="server"/>
```

#### Fallback

If you would like to fall back to some content when Reevoo content is not available, just specify it within the tag:

```net
  <reevoo:CustomerExperienceReviews sku="<SKU>" runat="server">
    <p>Sorry we don't have any customer experience reviews available right now</p>
  </reevoo:CustomerExperienceReviews>
```


### Generic Mark Embeddable Content Tag

There is a generic tag that allows to specify the base url to call on the Reevoo server for generic embeddable content that is
not provided by any of the previous tags. The tag name is "mark" and you can use it in the following way:

Make sure to replace `<SKU>` and `<TRKREF>` with the appropriate values:

```net
  <reevoo:Mark sku="<SKU>" trkref="<TRKREF>" BaseUri="http://mark.reevoo.com/reevoomark/embeddable_reviews.html" runat="server"/>
```

It is also possible to specify locale and the number of reviews you'd like in the baseURI:

```net
  <reevoo:Mark sku="<SKU>" trkref="<TRKREF>" baseURI="http://mark.reevoo.com/reevoomark/fr-FR/10/embeddable_reviews.html" runat="server" />
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


