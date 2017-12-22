using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Eval;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;

namespace zxw.Excel
{
    public class ExportExcel
    {
        /// <summary> 
        /// 将一组对象导出成EXCEL 
        /// </summary> 
        /// <typeparam name="T">要导出对象的类型</typeparam> 
        /// <param name="objList">一组对象</param> 
        /// <param name="FileName">导出后的文件名</param> 
        /// <param name="columnInfo">列名信息</param> 
        public void ExExcel<T>(List<T> objList, string FileName, Dictionary<string, string> columnInfo)
        {
            if (columnInfo.Count == 0) { return; }
            if (objList.Count == 0) { return; }
            //生成EXCEL的HTML 
            string excelStr = "";
            Type myType = objList[0].GetType();
            //根据反射从传递进来的属性名信息得到要显示的属性 
            List<System.Reflection.PropertyInfo> myPro = new List<System.Reflection.PropertyInfo>();
            foreach (string cName in columnInfo.Keys)
            {
                System.Reflection.PropertyInfo p = myType.GetProperty(cName);
                if (p != null)
                {
                    myPro.Add(p);
                    excelStr += columnInfo[cName] + "\t";
                }
            }
            //如果没有找到可用的属性则结束 
            if (myPro.Count == 0) { return; }
            excelStr += "\n";
            foreach (T obj in objList)
            {
                foreach (System.Reflection.PropertyInfo p in myPro)
                {
                    excelStr += p.GetValue(obj, null) + "\t";
                }
                excelStr += "\n";
            }
            //输出EXCEL 
            HttpResponse rs = System.Web.HttpContext.Current.Response;
            rs.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            rs.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
            rs.ContentType = "application/ms-excel";
            rs.Write(excelStr);
            rs.End();
        }

        public DataTable GetExcelData(string excelFilePath)
        {
            using (FileStream fs = File.OpenRead(excelFilePath))   //打开myxls.xls文件
            {
                IWorkbook workbook = WorkbookFactory.Create(fs);
                ISheet sheet = workbook.GetSheetAt(0);
                //HSSFSheet sheet = workbook.GetSheetAt(0);
                DataTable table = new DataTable();
                IRow headerRow = sheet.GetRow(0);
                //HSSFRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;
                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }
                int rowCount = sheet.LastRowNum;
                for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    //HSSFRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = row.GetCell(j).ToString();
                    }
                    table.Rows.Add(dataRow);
                }
                workbook = null;
                sheet = null;
                return table;

            }
        }
        public DataTable GetExcelDataByStream(Stream stream)
        {
            IWorkbook workbook = WorkbookFactory.Create(stream);
            ISheet sheet = workbook.GetSheetAt(0);
            //HSSFSheet sheet = workbook.GetSheetAt(0);
            DataTable table = new DataTable();
            IRow headerRow = sheet.GetRow(0);
            //HSSFRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            int rowCount = sheet.LastRowNum;
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                //HSSFRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }
                table.Rows.Add(dataRow);
            }
            workbook = null;
            sheet = null;
            return table;
        }

        public Stream RenderDataTableToExcel(Dictionary<string, string> columnInfo, DataTable SourceTable)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);
            // handling header.       
            //foreach (DataColumn column in SourceTable.Columns)
            //{
            //    string colname = "";
            //    if (columnInfo.TryGetValue(column.ColumnName,out colname))
            //    {
            //        headerRow.CreateCell(column.Ordinal).SetCellValue(colname);
            //    }
            //}
            int i=0;
            foreach (var item in columnInfo)
            {
                headerRow.CreateCell(i++).SetCellValue(item.Value);
            }
            int rowIndex = 1;
            foreach (DataRow row in SourceTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                i=0;
                foreach (var item in columnInfo)
                {
                    dataRow.CreateCell(i++).SetCellValue(row[item.Key].ToString());
                }
                rowIndex++;
            }
 
            //int rowIndex = 1;
            //foreach (DataRow row in SourceTable.Rows)
            //{
            //    IRow dataRow = sheet.CreateRow(rowIndex);
            //    foreach (DataColumn column in SourceTable.Columns)
            //    {
            //        string colname = "";
            //        if (columnInfo.TryGetValue(column.ColumnName, out colname))
            //        {
            //            dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
            //        }
            //    }
            //    rowIndex++;
            //}
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            sheet = null;
            headerRow = null;
            workbook = null;
            return ms;
        }
        public void RenderDataTableToExcel(Dictionary<string, string> columnInfo,DataTable SourceTable, string FileName)
        {
            MemoryStream ms = RenderDataTableToExcel(columnInfo, SourceTable) as MemoryStream;
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            byte[] data = ms.ToArray();
            fs.Write(data, 0, data.Length);
            fs.Flush(); fs.Close();
            data = null; ms = null; fs = null;
        }
        public void RenderDataTableToBrowser( Dictionary<string, string> columnInfo,DataTable SourceTable, HttpContext context, string fileName)
        {
            if (context.Request.Browser.Browser == "IE")
                fileName = HttpUtility.UrlEncode(fileName);
            Stream ms = RenderDataTableToExcel(columnInfo,SourceTable);
            int len = Convert.ToInt32(ms.Length);
            byte[] FileObj = new byte[len];
            ms.Read(FileObj, 0, len);
            context.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName, System.Text.Encoding.UTF8));
            context.Response.AddHeader("Content-Length", len.ToString());
            context.Response.ContentType = "application/octet-stream";
            context.Response.Charset = "UTF-8";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.BinaryWrite(FileObj);
            ms.Close();
        }
        public DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex)
        {
            //HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            IWorkbook workbook = WorkbookFactory.Create(ExcelFileStream);
            ISheet sheet = workbook.GetSheet(SheetName);
            DataTable table = new DataTable();
            IRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            int rowCount = sheet.LastRowNum;
            for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                    dataRow[j] = row.GetCell(j).ToString();
            }
            ExcelFileStream.Close(); workbook = null; sheet = null; return table;
        }
        public DataTable RenderDataTableFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex)
        {
            IWorkbook workbook = WorkbookFactory.Create(ExcelFileStream);
            //HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            ISheet sheet = workbook.GetSheetAt(SheetIndex);
            DataTable table = new DataTable();
            IRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            int rowCount = sheet.LastRowNum;
            for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }
                table.Rows.Add(dataRow);
            }
            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        public bool InsertByDataTable(DataTable dt, string DBTableName, string ConnectionString, Dictionary<string,string> Field, out string msg)
        {
            try
            {
                DateTime startTime = DateTime.Now;
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                {
                    bulkCopy.DestinationTableName = DBTableName;
                    foreach (KeyValuePair<string,string> item in Field)
                    {
                        bulkCopy.ColumnMappings.Add(item.Value, item.Key);
                    }
                    bulkCopy.WriteToServer(dt);
                }
                TimeSpan ts = DateTime.Now.Subtract(startTime);
                msg="一共插入" + dt.Rows.Count + "条数据,用时：" + ts.ToString();
                return true;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return false;
            }
        }
    }
}
