using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Data;
using Microsoft.Reporting.WinForms;

public interface IDynamicReport
{
    void AddData<T>(IEnumerable<T> data);
    void AddData(DataTable dataTable);
    void ShowReport();
    void LoadReport(string reportPath);
    void SetColoumStyle(List<ReportColoumStyle> coloumStyle);
    void AddText(string title);
    void SetReport(ReportViewer reportViewer);
}