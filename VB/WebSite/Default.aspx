<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>

<%@ Register assembly="DevExpress.XtraCharts.v13.1.Web, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxComboBox ID="ASPxComboBox1" runat="server" AutoPostBack="true" SelectedIndex="0" 
			ValueType="System.String">
			<Items>
				<dx:ListEditItem Selected="True" Text="Dollar" Value="Dollar" />
				<dx:ListEditItem Text="Pound" Value="Pound" />
				<dx:ListEditItem Text="Euro" Value="Euro" />
			</Items>
		</dx:ASPxComboBox>
		<dxwpg:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" 
			oncustomcelldisplaytext="ASPxPivotGrid1_CustomCellDisplayText" 
			oncustomsummary="ASPxPivotGrid1_CustomSummary">
			<Fields>
				<dxwpg:PivotGridField ID="fieldName" Area="ColumnArea" AreaIndex="0" FieldName="Name">
				</dxwpg:PivotGridField>
				<dxwpg:PivotGridField ID="fieldCurrency" Area="RowArea" AreaIndex="0" FieldName="Currency">
				</dxwpg:PivotGridField>
				<dxwpg:PivotGridField ID="fieldYear" Area="FilterArea" AreaIndex="0" 
					FieldName="Date" Caption="Year" GroupInterval="DateYear" 
					UnboundFieldName="fieldYear">
				</dxwpg:PivotGridField>
				<dxwpg:PivotGridField ID="fieldDate" Area="FilterArea" AreaIndex="1" 
					FieldName="Date" Caption="Date" GroupInterval="Date" 
					UnboundFieldName="fieldDate">
				</dxwpg:PivotGridField>
				<dxwpg:PivotGridField ID="fieldValue" Area="DataArea" AreaIndex="0" FieldName="Value" SummaryType="Custom" >
				</dxwpg:PivotGridField>
			</Fields>
		</dxwpg:ASPxPivotGrid>

	</div>
	</form>
</body>
</html>