using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Reporting.WinForms;
public class DynamicReport:IDynamicReport
{
    #region 空白文档

    /// <summary>
    /// 空白文档的xml文件
    /// </summary>
    protected string _docTemplate =
        "<?xml version=\"1.0\" encoding=\"utf-8\"?><Report xmlns:rd=\"http://schemas.microsoft.com/SQLServer/reporting/reportdesigner\" xmlns=\"http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition\">" +
        "<DataSources>" +
        "   <DataSource Name=\"DummyDataSource\">" +
        "       <ConnectionProperties>" +
        "           <DataProvider>SQL</DataProvider>" +
        "           <ConnectString />" +
        "       </ConnectionProperties>" +
        "       <rd:DataSourceID>3eecdab9-6b4b-4836-ad62-95e4aee65ea8</rd:DataSourceID>" +
        "   </DataSource>" +
        "</DataSources>" +
        "<DataSets>@DataSets</DataSets>" +
        "<Body>" +
        "<ReportItems>@Title@Tablix" +
        "</ReportItems>" +
        "<Style />" +
        "<Height>8cm</Height>" +
        "</Body>" +
        "<Width>17cm</Width>" +
        "<Page>" +
        "<PageHeight>29.7cm</PageHeight>" +
        "<PageWidth>21cm</PageWidth>" +
        "<LeftMargin>1.8cm</LeftMargin>" +
        "<RightMargin>1.8cm</RightMargin>" +
        "<TopMargin>1.8cm</TopMargin>" +
        "<BottomMargin>1.8cm</BottomMargin>" +
        "<ColumnSpacing>0.13cm</ColumnSpacing>" +
        "<Style />" +
        "</Page>" +
        "<rd:ReportID>809f16cf-ea78-4469-bf43-965c4afe69d0</rd:ReportID>" +
        "<rd:ReportUnitType>Cm</rd:ReportUnitType>" +
        "</Report>";

    protected string TitlePattern =
        " <Textbox Name=\"Textbo@TextboxName\"> "
        + @"<CanGrow>true</CanGrow>
        <KeepTogether>true</KeepTogether>
        <Paragraphs>
          <Paragraph>
            <TextRuns>
              <TextRun>
                <Value>@Title</Value>
                <Style>@FontStyle</Style>
              </TextRun>
            </TextRuns>
            <Style>@Style</Style>
          </Paragraph>
        </Paragraphs>
        <rd:DefaultName>Textbo@TextboxName</rd:DefaultName>
        <Top>@TopPositioncm</Top>
        <Left>1cm</Left>
        <Height>0.83813cm</Height>
        <Width>14.35207cm</Width>
        <ZIndex>1</ZIndex>
        <Style>
          <Border>
            <Style>None</Style>
          </Border>
          <PaddingLeft>2pt</PaddingLeft>
          <PaddingRight>2pt</PaddingRight>
          <PaddingTop>2pt</PaddingTop>
          <PaddingBottom>2pt</PaddingBottom>
        </Style>
      </Textbox>";

    #endregion

    private ReportViewer _report;
    private List<ReportColoumStyle> _coloumStyle = new List<ReportColoumStyle>();
    private List<ReportItemPattern> _reportItemPatterns = new List<ReportItemPattern>();
    private List<string> _reportTitlePatterns = new List<string>();
    private List<ReportItemPattern> _reportHeadPatterns = new List<ReportItemPattern>();
    internal const float ColoumWidth = 1.6F; //行宽
    public ReportType ReportType { get; set; }

    public DynamicReport()
    {

    }
    public void SetReport(ReportViewer reportViewer)
    {
        this._report = reportViewer;
    }
    /// <summary>
    /// 从现有报表中加载报表并进行修改
    /// </summary>
    /// <param name="url"></param>
    public void LoadReport(string url)
    {
        try
        {
            _docTemplate = File.ReadAllText(url);
        }
        catch (Exception ex)
        {

        }
    }

    public void SetColoumStyle(List<ReportColoumStyle> coloumStyle)
    {
        this._coloumStyle = coloumStyle;
    }

    public void AddText(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            var pos = CaculatePlacePostion();
            var titlePattern = TitlePattern
                .Replace("@Title", text)
                .Replace("@TopPosition", pos.ToString())
                .Replace("@TextboxName", _reportTitlePatterns.Count.ToString())
                .Replace("@FontStyle", "<FontFamily>微软雅黑</FontFamily><FontSize>12pt</FontSize>")
                .Replace("@Style", "<TextAlign>Center</TextAlign>");
            _reportTitlePatterns.Add(titlePattern);
        }
    }

    public void AddText(string text, int chapterGrade)
    {
        if (!string.IsNullOrEmpty(text))
        {
            var pos = CaculatePlacePostion();
            var titlePattern = TitlePattern
                .Replace("@Title", text)
                .Replace("@TopPosition", pos.ToString())
                .Replace("@TextboxName", _reportTitlePatterns.Count.ToString());
            switch (chapterGrade)
            {
                case 1:
                    titlePattern = titlePattern.Replace("@FontStyle",
                                                        "<FontFamily>宋体</FontFamily><FontSize>18pt</FontSize><Color>#000000</Color>")
                                               .Replace("@Style", "<TextAlign>Center</TextAlign>");
                    break;
                case 2:
                    titlePattern = titlePattern.Replace("@FontStyle",
                                                        "<FontFamily>黑体</FontFamily><FontSize>14pt</FontSize><Color>#000000</Color>")
                                               .Replace("@Style", "<TextAlign>Left</TextAlign>");
                    break;
                case 3:
                    titlePattern = titlePattern.Replace("@FontStyle",
                                                        "<FontFamily>宋体</FontFamily><FontSize>12pt</FontSize><FontWeight>Bold</FontWeight>")
                                               .Replace("@Style", "<TextAlign>Left</TextAlign>");
                    break;
                default:
                case 10:
                    titlePattern = titlePattern.Replace("@FontStyle",
                                                        "<FontFamily>宋体</FontFamily><FontSize>12pt</FontSize>")
                                               .Replace("@Style", "<LineHeight>22pt</LineHeight>");
                    break;
            }
            _reportTitlePatterns.Add(titlePattern);
        }
    }

    public void AddData<T>(IEnumerable<T> data)
    {
        if (data.Count() != 0)
        {
            var properites = typeof(T).GetProperties(); //得到实体类属性的集合
            AddReportItemPattern(properites.Select(p => p.Name).ToArray(), data);
        }
    }

    public void AddData(DataTable dataTable)
    {
        if (dataTable != null)
        {
            var coloumNames = new List<string>();
            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                var protertyName = dataColumn.ColumnName;
                coloumNames.Add(protertyName);
            }
            AddReportItemPattern(coloumNames.ToArray(), dataTable);
        }
    }

    /// <summary>
    /// 计算开始摆放的位置
    /// </summary>
    /// <returns></returns>
    protected float CaculatePlacePostion()
    {
        //每个标题的高度
        float titleCount = _reportTitlePatterns.Count * 1f;
        //每个数据表的高度
        float itemCount = _reportItemPatterns.Count * 2f;
        // 每个空表头的高度
        float emptyItemCount = _reportHeadPatterns.Count * 0.5f;
        switch (ReportType)
        {
            case ReportType.Tables:
                return titleCount + itemCount + emptyItemCount + 0.5f;
            case ReportType.Chart:
            case ReportType.Finally:
                return titleCount + itemCount + emptyItemCount + 25.7f;
        }
        return 0f;
    }

    /// <summary>
    /// 增加一个报表
    /// </summary>
    /// <param name="coloumNames"></param>
    /// <param name="data"></param>
    /// <param name="dataType"></param>
    protected void AddReportItemPattern(string[] coloumNames, dynamic data)
    {
        var fields = new StringBuilder();
        var coloums = new StringBuilder();
        var tablixHearders = new StringBuilder();
        var tablixCells = new StringBuilder();
        var tablixMembers = new StringBuilder();
        var currentNamePrefix = _reportItemPatterns.Count + _reportHeadPatterns.Count + 1;
        var tableWidth = 0F;
        var dataRows = GetDataRowsCount(data); //数据行数

        foreach (var coloumName in coloumNames)
        {
            var coloumWidth = ColoumWidth;
            var textAlign = TextAlign.Right;
            var reportColoumStyle = _coloumStyle.FirstOrDefault(r => r.ColoumName == coloumName);
            if (reportColoumStyle != null)
            {
                textAlign = reportColoumStyle.TextAlign;
                coloumWidth = reportColoumStyle.ColoumWidth;
            }
            tableWidth += coloumWidth;

            var bottomBorder = string.Empty; //每个单元格底部border
            if (dataRows == 0)
            {
                bottomBorder = "<BottomBorder><Style>None</Style></BottomBorder>";
            }
            var coloumValue = coloumName;
            //例外,如果coloumName包含Coloum之类的字段,则将value设成空
            if (coloumName.IndexOf("Column", System.StringComparison.Ordinal) > -1)
            {
                coloumValue = "　";
            }

            fields.AppendFormat(
                "<Field Name=\"{0}\"><DataField>{0}</DataField><rd:TypeName>System.String</rd:TypeName></Field>",
                coloumName);
            coloums.AppendFormat("<TablixColumn><Width>{0}cm</Width></TablixColumn>", coloumWidth);
            tablixHearders.AppendFormat("<TablixCell><CellContents>" +
                                        "<Textbox Name=\"Textbox{0}{1}\"><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph>" +
                                        "<TextRuns><TextRun><Value>{2}</Value><Style /></TextRun></TextRuns><Style><TextAlign>Center</TextAlign></Style></Paragraph></Paragraphs>" +
                                        "<rd:DefaultName>Textbox{0}{1}</rd:DefaultName><Style><Border><Color>LightGrey</Color><Style>Solid</Style></Border>{3}" +
                                        "<PaddingLeft>2pt</PaddingLeft><PaddingRight>2pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox></CellContents></TablixCell>",
                                        coloumName, currentNamePrefix, coloumValue, bottomBorder);
            tablixCells.AppendFormat(
                "<TablixCell><CellContents><Textbox Name=\"{0}{1}1\"><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether>" +
                "<Paragraphs><Paragraph><TextRuns><TextRun><Value>=Fields!{0}.Value</Value><Style /></TextRun></TextRuns><Style><TextAlign>{2}</TextAlign></Style></Paragraph></Paragraphs>" +
                "<rd:DefaultName>{0}{1}1</rd:DefaultName><Style><Border><Color>LightGrey</Color><Style>Solid</Style></Border>" +
                "<PaddingLeft>2pt</PaddingLeft><PaddingRight>2pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox></CellContents></TablixCell>",
                coloumName, currentNamePrefix, textAlign);

            tablixMembers.AppendFormat("<TablixMember />");
        }

        //计算表格应该离左边多少距离
        var leftPosition = 0F;
        if (tableWidth < 17)
        {
            leftPosition = (17F - tableWidth) / 2;
        }

        var dataSetName = string.Format("Data{0}", _reportItemPatterns.Count + _reportHeadPatterns.Count + 1);
        var reportItemPattern = new ReportItemPattern();
        reportItemPattern.Data = DynamicReportExtension.RemoveZeroData(data);
        reportItemPattern.DataSetName = dataSetName;
        reportItemPattern.DataSetString =
            reportItemPattern.DataSetPattern
                             .Replace("@DataSetName", dataSetName)
                             .Replace("@Fields", fields.ToString());
        reportItemPattern.TablixString =
            reportItemPattern.TablixPattern
                             .Replace("@DataSetName", dataSetName)
                             .Replace("@TablixColumns", coloums.ToString())
                             .Replace("@TablixHeader", tablixHearders.ToString())
                             .Replace("@TablixCells", tablixCells.ToString())
                             .Replace("@TablixMember", tablixMembers.ToString())
                             .Replace("@TopPosition", CaculatePlacePostion().ToString())
                             .Replace("@LeftPostion", leftPosition.ToString());

        //读取行数,如果是空行就加到新的
        if (dataRows == 0)
        {
            _reportHeadPatterns.Add(reportItemPattern);
        }
        else
        {
            _reportItemPatterns.Add(reportItemPattern);
        }
    }

    /// <summary>
    /// 得到某种类型数据的数量
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private int GetDataRowsCount(dynamic data)
    {
        if (data is DataTable)
        {
            return ((DataTable)data).Rows.Count;
        }
        else if (data is IEnumerable)
        {
            return Enumerable.Count(data);
        }
        else return 0;
    }

    /// <summary>
    /// 最终显示报表
    /// </summary>
    public void ShowReport()
    {
        //将每一个patter转换
        if (_reportItemPatterns.Count > 0 || _reportTitlePatterns.Count > 0)
        {
            var dataSetsString = new StringBuilder();
            var tablixString = new StringBuilder();

            foreach (var reportItemPattern in _reportItemPatterns)
            {
                dataSetsString.Append(reportItemPattern.DataSetString);
                tablixString.Append(reportItemPattern.TablixString);
            }
            foreach (var reportItemPattern in _reportHeadPatterns)
            {
                dataSetsString.Append(reportItemPattern.DataSetString);
                tablixString.Append(reportItemPattern.TablixString);
            }

            var reportTitleString = new StringBuilder();
            foreach (var reportTitlePattern in _reportTitlePatterns)
            {
                reportTitleString.Append(reportTitlePattern);
            }

            //把文档中的文字替换掉
            switch (ReportType)
            {
                case ReportType.Tables:
                    _docTemplate = _docTemplate.Replace("@DataSets", dataSetsString.ToString())
                                               .Replace("@Tablix", tablixString.ToString())
                                               .Replace("@Title", reportTitleString.ToString());
                    break;
                case ReportType.Chart:
                    break;
                case ReportType.Finally:
                    //替换datasetstring
                    var pos = _docTemplate.IndexOf("<Body>", StringComparison.Ordinal);
                    _docTemplate = _docTemplate.Insert(pos,
                                                       string.Format(
                                                           "<DataSources><DataSource Name=\"DummyDataSource\"><ConnectionProperties><DataProvider>SQL</DataProvider><ConnectString /></ConnectionProperties><rd:DataSourceID>3eecdab9-6b4b-4836-ad62-95e4aee65ea8</rd:DataSourceID></DataSource></DataSources><DataSets>{0}</DataSets>",
                                                           dataSetsString));
                    //替换Tablix
                    pos = _docTemplate.IndexOf("<ReportItems>", StringComparison.Ordinal);
                    _docTemplate = _docTemplate.Insert(pos + 13, tablixString.ToString());
                    //替换title
                    _docTemplate = _docTemplate.Insert(pos + 13, reportTitleString.ToString());
                    break;
            }

            var doc = new XmlDocument();
            doc.LoadXml(_docTemplate);
            Stream stream = GetRdlcStream(doc);

            //加载报表定义
            _report.LocalReport.LoadReportDefinition(stream);
            _report.LocalReport.DataSources.Clear();
            foreach (var reportItemPattern in _reportItemPatterns)
            {
                _report.LocalReport.DataSources
                       .Add(new ReportDataSource(reportItemPattern.DataSetName + "Data",
                                                 reportItemPattern.Data));
            }
            foreach (var reportItemPattern in _reportHeadPatterns)
            {
                _report.LocalReport.DataSources
                       .Add(new ReportDataSource(reportItemPattern.DataSetName + "Data",
                                                 reportItemPattern.Data));
            }

            //_report.LocalReport.Refresh();
            _report.RefreshReport();
        }
    }
    public void ShowReport(string a)
    {
        //将每一个patter转换
        if (_reportItemPatterns.Count > 0 || _reportTitlePatterns.Count > 0)
        {
            var dataSetsString = new StringBuilder();
            var tablixString = new StringBuilder();

            foreach (var reportItemPattern in _reportItemPatterns)
            {
                dataSetsString.Append(reportItemPattern.DataSetString);
                tablixString.Append(reportItemPattern.TablixString);
            }
            foreach (var reportItemPattern in _reportHeadPatterns)
            {
                dataSetsString.Append(reportItemPattern.DataSetString);
                tablixString.Append(reportItemPattern.TablixString);
            }

            var reportTitleString = new StringBuilder();
            foreach (var reportTitlePattern in _reportTitlePatterns)
            {
                reportTitleString.Append(reportTitlePattern);
            }

            //把文档中的文字替换掉
            //switch (ReportType)
            //{
            //    case ReportType.Tables:
            //        _docTemplate = _docTemplate.Replace("@DataSets", dataSetsString.ToString())
            //                                   .Replace("@Tablix", tablixString.ToString())
            //                                   .Replace("@Title", reportTitleString.ToString());
            //        break;
            //    case ReportType.Chart:
            //        break;
            //    case ReportType.Finally:
            //        //替换datasetstring
            //        var pos = _docTemplate.IndexOf("<Body>", StringComparison.Ordinal);
            //        _docTemplate = _docTemplate.Insert(pos,
            //                                           string.Format(
            //                                               "<DataSources><DataSource Name=\"DummyDataSource\"><ConnectionProperties><DataProvider>SQL</DataProvider><ConnectString /></ConnectionProperties><rd:DataSourceID>3eecdab9-6b4b-4836-ad62-95e4aee65ea8</rd:DataSourceID></DataSource></DataSources><DataSets>{0}</DataSets>",
            //                                               dataSetsString));
            //        //替换Tablix
            //        pos = _docTemplate.IndexOf("<ReportItems>", StringComparison.Ordinal);
            //        _docTemplate = _docTemplate.Insert(pos + 13, tablixString.ToString());
            //        //替换title
            //        _docTemplate = _docTemplate.Insert(pos + 13, reportTitleString.ToString());
            //        break;
            //}

            var doc = new XmlDocument();
            doc.LoadXml(_docTemplate);
            Stream stream = GetRdlcStream(doc);

            //加载报表定义
            _report.LocalReport.LoadReportDefinition(stream);
            _report.LocalReport.DataSources.Clear();
            foreach (var reportItemPattern in _reportItemPatterns)
            {
                _report.LocalReport.DataSources
                       .Add(new ReportDataSource(reportItemPattern.DataSetName + "Data",
                                                 reportItemPattern.Data));
            }
            foreach (var reportItemPattern in _reportHeadPatterns)
            {
                _report.LocalReport.DataSources
                       .Add(new ReportDataSource(reportItemPattern.DataSetName + "Data",
                                                 reportItemPattern.Data));
            }

            //_report.LocalReport.Refresh();
            _report.RefreshReport();
        }
    }

    /// <summary>
    /// 序列化到内存流
    /// </summary>
    /// <returns></returns>
    protected Stream GetRdlcStream(XmlDocument xmlDoc)
    {
        Stream ms = new MemoryStream();
        XmlSerializer serializer = new XmlSerializer(typeof(XmlDocument));
        serializer.Serialize(ms, xmlDoc);

        ms.Position = 0;
        return ms;
    }
}