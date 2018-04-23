Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Data.PivotGrid
Imports System.Globalization
Imports DevExpress.XtraPivotGrid

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private data As DataTable
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		ASPxPivotGrid1.DataSource = CreateTable()
	End Sub

	Private Function CreateTable() As DataTable
		data = New DataTable()
		data.Columns.Add("Name", GetType(String))
		data.Columns.Add("Currency", GetType(String))
		data.Columns.Add("Date", GetType(Object))
		data.Columns.Add("Value", GetType(Integer))

		data.Rows.Add(New Object() { "Aaa", "Dollar", DateTime.Today, 7 })
		data.Rows.Add(New Object() { "Aaa", "Dollar", DateTime.Today.AddDays(1), 4 })
		data.Rows.Add(New Object() { "Bbb", "Euro", DateTime.Today, 12 })
		data.Rows.Add(New Object() { "Bbb", "Dollar", DateTime.Today.AddDays(1), 14 })
		data.Rows.Add(New Object() { "Ccc", "Euro", DateTime.Today, 11 })
		data.Rows.Add(New Object() { "Ccc", "Pound", DateTime.Today.AddDays(1), 10 })

		data.Rows.Add(New Object() { "Aaa", "Pound", DateTime.Today.AddYears(1), 4 })
		data.Rows.Add(New Object() { "Aaa", "Pound", DateTime.Today.AddYears(1).AddDays(1), 2 })
		data.Rows.Add(New Object() { "Bbb", "Euro", DateTime.Today.AddYears(1), 3 })
		data.Rows.Add(New Object() { "Bbb", "Dollar", DateTime.Today.AddDays(1).AddYears(1), 1 })
		data.Rows.Add(New Object() { "Ccc", "Euro", DateTime.Today.AddYears(1), 8 })
		data.Rows.Add(New Object() { "Ccc", "Pound", DateTime.Today.AddDays(1).AddYears(1), 22 })

		Return data
	End Function
	Protected Sub ASPxPivotGrid1_CustomCellDisplayText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxPivotGrid.PivotCellDisplayTextEventArgs)
		If e.Value IsNot Nothing Then
			e.DisplayText = Convert.ToDecimal(e.Value).ToString("C0", GetCultureInfo(e.GetFieldValue(fieldCurrency)))
		End If
	End Sub

	Private Function GetCultureInfo(ByVal format As Object) As CultureInfo
		If format Is Nothing Then
			Return GetCultureInfo(ASPxComboBox1.SelectedItem.Value)
		End If
		Dim formatStr As String = Convert.ToString(format)
		If formatStr = "Dollar" Then
			Return New CultureInfo("en-US")
		ElseIf formatStr = "Pound" Then
			Return New CultureInfo("en-GB")
		ElseIf formatStr = "Euro" Then
			Return New CultureInfo("de-DE")
		Else
			Return New CultureInfo("")
		End If
	End Function

	Protected Sub ASPxPivotGrid1_CustomSummary(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxPivotGrid.PivotGridCustomSummaryEventArgs)
		Dim ds As PivotDrillDownDataSource = e.CreateDrillDownDataSource()
		If DataProvidesSameValues(ds, fieldCurrency) Then
			e.CustomValue = e.SummaryValue.Summary
		Else
			Dim customValue As Decimal = 0
			For i As Integer = 0 To ds.RowCount - 1
				If Equals(ds(i)(fieldCurrency), ASPxComboBox1.SelectedItem.Value) Then
					customValue += Convert.ToDecimal(ds(i)(e.DataField))
				End If

			Next i
			e.CustomValue = customValue
		End If
	End Sub

	Private Function DataProvidesSameValues(ByVal ds As PivotDrillDownDataSource, ByVal fieldCurrency As DevExpress.Web.ASPxPivotGrid.PivotGridField) As Boolean

		Dim firstValue As Object = ds(0)(fieldCurrency)
		For i As Integer = 1 To ds.RowCount - 1
			If (Not Object.Equals(firstValue, ds(i)(fieldCurrency))) Then
				Return False
			End If
		Next i
		Return True
	End Function
End Class
