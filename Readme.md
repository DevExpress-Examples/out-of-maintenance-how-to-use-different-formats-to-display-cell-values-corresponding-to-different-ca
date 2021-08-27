<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128577916/10.2.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3200)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Solution.sln](./CS/Solution.sln) (VB: [Solution.sln](./VB/Solution.sln))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to use different formats to display cell values corresponding to different categories
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e3200/)**
<!-- run online end -->


<p>This example demonstrates how to display cell values in different formats (using different culture settings an currency symbol): Dollar, Pound or Euro. To apply the custom format to a specific cell, the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_CustomCellDisplayTexttopic"><u>ASPxPivotGrid.CustomCellDisplayText</u></a> event is used. The information about a cell format is provided by a separate field "Currency". Some cells represent data corresponding to different currencies. In this case, it is necessary to handle the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_CustomSummarytopic"><u>ASPxPivotGrid.CustomSummary </u></a>event to calculate summary values correctly.</p>

<br/>


