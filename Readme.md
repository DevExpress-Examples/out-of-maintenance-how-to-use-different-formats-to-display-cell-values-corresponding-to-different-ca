<!-- default file list -->
*Files to look at*:

* [Solution.sln](./CS/Solution.sln) (VB: [Solution.sln](./VB/Solution.sln))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
<!-- default file list end -->
# How to use different formats to display cell values corresponding to different categories


<p>This example demonstrates how to display cell values in different formats (using different culture settings an currency symbol): Dollar, Pound or Euro. To apply the custom format to a specific cell, the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_CustomCellDisplayTexttopic"><u>ASPxPivotGrid.CustomCellDisplayText</u></a> event is used. The information about a cell format is provided by a separate field "Currency". Some cells represent data corresponding to different currencies. In this case, it is necessary to handle the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_CustomSummarytopic"><u>ASPxPivotGrid.CustomSummary </u></a>event to calculate summary values correctly.</p>

<br/>


