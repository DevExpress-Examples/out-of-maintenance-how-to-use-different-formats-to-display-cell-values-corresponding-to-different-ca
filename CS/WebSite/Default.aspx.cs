using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Data.PivotGrid;
using System.Globalization;
using DevExpress.XtraPivotGrid;

public partial class _Default : System.Web.UI.Page
{
    DataTable data;
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxPivotGrid1.DataSource = CreateTable();
    }

    private DataTable CreateTable()
    {
        data = new DataTable();
        data.Columns.Add("Name", typeof(string));
        data.Columns.Add("Currency", typeof(string));
        data.Columns.Add("Date", typeof(object));
        data.Columns.Add("Value", typeof(int));

        data.Rows.Add(new object[] { "Aaa", "Dollar", DateTime.Today, 7 });
        data.Rows.Add(new object[] { "Aaa", "Dollar", DateTime.Today.AddDays(1), 4 });
        data.Rows.Add(new object[] { "Bbb", "Euro", DateTime.Today, 12 });
        data.Rows.Add(new object[] { "Bbb", "Dollar", DateTime.Today.AddDays(1), 14 });
        data.Rows.Add(new object[] { "Ccc", "Euro", DateTime.Today, 11 });
        data.Rows.Add(new object[] { "Ccc", "Pound", DateTime.Today.AddDays(1), 10 });

        data.Rows.Add(new object[] { "Aaa", "Pound", DateTime.Today.AddYears(1), 4 });
        data.Rows.Add(new object[] { "Aaa", "Pound", DateTime.Today.AddYears(1).AddDays(1), 2 });
        data.Rows.Add(new object[] { "Bbb", "Euro", DateTime.Today.AddYears(1), 3 });
        data.Rows.Add(new object[] { "Bbb", "Dollar", DateTime.Today.AddDays(1).AddYears(1), 1 });
        data.Rows.Add(new object[] { "Ccc", "Euro", DateTime.Today.AddYears(1), 8 });
        data.Rows.Add(new object[] { "Ccc", "Pound", DateTime.Today.AddDays(1).AddYears(1), 22 });

        return data;
    }
    protected void ASPxPivotGrid1_CustomCellDisplayText(object sender, DevExpress.Web.ASPxPivotGrid.PivotCellDisplayTextEventArgs e)
    {
        if (e.Value != null )
            e.DisplayText = Convert.ToDecimal(e.Value).ToString("C0", GetCultureInfo(e.GetFieldValue(fieldCurrency)));
    }

    private CultureInfo GetCultureInfo(object format)
    {
        if (format == null)
            return GetCultureInfo(ASPxComboBox1.SelectedItem.Value);
        string formatStr = Convert.ToString(format);
        if (formatStr == "Dollar")
            return new CultureInfo("en-US");
        else if (formatStr == "Pound")
            return new CultureInfo("en-GB");
        else if (formatStr == "Euro")
            return new CultureInfo("de-DE");
        else
            return new CultureInfo("");
    }

    protected void ASPxPivotGrid1_CustomSummary(object sender, DevExpress.Web.ASPxPivotGrid.PivotGridCustomSummaryEventArgs e)
    {
        PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
        if (DataProvidesSameValues(ds, fieldCurrency))
        {
            e.CustomValue = e.SummaryValue.Summary;
        }
        else
        {
            decimal customValue = 0;
            for (int i = 0; i < ds.RowCount ; i++)
            {
                if (Equals(ds[i][fieldCurrency], ASPxComboBox1.SelectedItem.Value))
                    customValue += Convert.ToDecimal(ds[i][e.DataField]);

            }
            e.CustomValue = customValue;
        }
    }

    private bool DataProvidesSameValues(PivotDrillDownDataSource ds, DevExpress.Web.ASPxPivotGrid.PivotGridField fieldCurrency)
    {
            
        object firstValue = ds[0][fieldCurrency];
        for (int i = 1; i < ds.RowCount; i++)
        {
            if (!object.Equals(firstValue, ds[i][fieldCurrency]))
            {
                return false;
            }
        }
        return true;
    }
}
