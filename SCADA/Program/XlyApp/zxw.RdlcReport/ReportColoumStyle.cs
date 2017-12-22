using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
public class ReportColoumStyle
{
    public string ColoumName { get; set; }
    public float ColoumWidth { get; set; }
    public TextAlign TextAlign { get; set; }

    public ReportColoumStyle()
    {
        ColoumWidth = DynamicReport.ColoumWidth;
    }
}

public enum TextAlign
{
    Left,
    Center,
    Right
}

public enum ReportType
{
    Tables,
    Chart,
    Finally
}

internal enum DataType
{
    DataTable,
    Enumerable
}

internal class ReportItemPattern
{
    public string DataSetName { get; set; }
    public string DataSetString { get; set; }
    public string TablixString { get; set; }
    public dynamic Data { get; set; }

    public string DataSetPattern
    {
        get
        {
            return "    <DataSet Name=\"@DataSetNameData\">" +
                   "       <Fields>@Fields</Fields>" +
                   "       <Query>" +
                   "           <DataSourceName>DummyDataSource</DataSourceName>" +
                   "           <CommandText />" +
                   "       </Query>" +
                   "    </DataSet>";
        }
    }

    public string TablixPattern
    {
        get
        {
            return " <Tablix Name=\"Tablix@DataSetName\">" +
                   "   <TablixBody>" +
                   "       <TablixColumns>@TablixColumns</TablixColumns>" +
                   "       <TablixRows>" +
                   "           <TablixRow>" +
                   "               <Height>0.23622in</Height>" +
                   "               <TablixCells>@TablixHeader</TablixCells>" +
                   "           </TablixRow>" +
                   "           <TablixRow>" +
                   "               <Height>0.23622in</Height>" +
                   "               <TablixCells>@TablixCells</TablixCells>" +
                   "           </TablixRow>" +
                   "       </TablixRows>" +
                   "   </TablixBody>" +
                   "   <TablixColumnHierarchy>" +
                   "       <TablixMembers>@TablixMember</TablixMembers>" +
                   "   </TablixColumnHierarchy>" +
                   "   <TablixRowHierarchy>" +
                   "       <TablixMembers>" +
                   "           <TablixMember>" +
                   "               <KeepWithGroup>After</KeepWithGroup>" +
                   "           </TablixMember>" +
                   "           <TablixMember>" +
                   "               <Group Name=\"详细信息@DataSetName\" />" +
                   "           </TablixMember>" +
                   "       </TablixMembers>" +
                   "   </TablixRowHierarchy>" +
                   "   <DataSetName>@DataSetNameData</DataSetName>" +
                   "   <Top>@TopPositioncm</Top>" +
                   "   <Left>@LeftPostioncm</Left>" +
                   "   <Height>1.2cm</Height>" +
                   "   <Width>14.35207cm</Width>" +
                   "   <Style>" +
                   "       <Border>" +
                   "           <Style>None</Style>" +
                   "       </Border>" +
                   "   </Style>" +
                   "</Tablix>";
        }
    }
}

internal static class DynamicReportExtension
{
    public static dynamic RemoveZeroData(this object data)
    {
        if (data is DataTable)
        {
            return ((DataTable)data).ChangeEachColumnTypeToString();
        }
        else if (data is IEnumerable)
        {
            var _data = ((IEnumerable)data).Cast<object>();
            return _data.CopyToDataTable().RemoveZeroData();
        }
        return data;
    }

    public static DataTable ChangeEachColumnTypeToString(this DataTable dt)
    {
        DataTable tempdt = new DataTable();
        foreach (DataColumn dc in dt.Columns)
        {
            DataColumn tempdc = new DataColumn();

            tempdc.ColumnName = dc.ColumnName;
            tempdc.DataType = typeof(String);
            tempdt.Columns.Add(tempdc);
        }
        int coloumCount = dt.Columns.Count;
        foreach (DataRow dr in dt.Rows)
        {
            var newrow = tempdt.NewRow();

            for (int i = 0; i < coloumCount; i++)
            {
                var value = dr[i].ToString();
                switch (value)
                {
                    case "0":
                    case "0.00%":
                        newrow[i] = "-";
                        break;
                    default:
                        newrow[i] = value;
                        break;
                }

            }
            tempdt.Rows.Add(newrow);
        }
        return tempdt;
    }
}

internal static class DataSetLinqOperators
{
    public static DataTable CopyToDataTable<T>(this IEnumerable<T> source)
    {
        return new ObjectShredder<T>().Shred(source, null, null);
    }

    public static DataTable CopyToDataTable<T>(this IEnumerable<T> source,
                                               DataTable table, LoadOption? options)
    {
        return new ObjectShredder<T>().Shred(source, table, options);
    }

}

internal class ObjectShredder<T>
{
    private FieldInfo[] _fi;
    private PropertyInfo[] _pi;
    private Dictionary<string, int> _ordinalMap;
    private Type _type;

    public ObjectShredder()
    {
        _type = typeof(T);
        _fi = _type.GetFields();
        _pi = _type.GetProperties();
        _ordinalMap = new Dictionary<string, int>();
    }

    public DataTable Shred(IEnumerable<T> source, DataTable table, LoadOption? options)
    {
        if (typeof(T).IsPrimitive)
        {
            return ShredPrimitive(source, table, options);
        }


        if (table == null)
        {
            table = new DataTable(typeof(T).Name);
        }

        // now see if need to extend datatable base on the type T + build ordinal map
        table = ExtendTable(table, typeof(T));

        table.BeginLoadData();
        using (IEnumerator<T> e = source.GetEnumerator())
        {
            while (e.MoveNext())
            {
                if (options != null)
                {
                    table.LoadDataRow(ShredObject(table, e.Current), (LoadOption)options);
                }
                else
                {
                    table.LoadDataRow(ShredObject(table, e.Current), true);
                }
            }
        }
        table.EndLoadData();
        return table;
    }

    public DataTable ShredPrimitive(IEnumerable<T> source, DataTable table, LoadOption? options)
    {
        if (table == null)
        {
            table = new DataTable(typeof(T).Name);
        }

        if (!table.Columns.Contains("Value"))
        {
            table.Columns.Add("Value", typeof(T));
        }

        table.BeginLoadData();
        using (IEnumerator<T> e = source.GetEnumerator())
        {
            Object[] values = new object[table.Columns.Count];
            while (e.MoveNext())
            {
                values[table.Columns["Value"].Ordinal] = e.Current;

                if (options != null)
                {
                    table.LoadDataRow(values, (LoadOption)options);
                }
                else
                {
                    table.LoadDataRow(values, true);
                }
            }
        }
        table.EndLoadData();
        return table;
    }

    public DataTable ExtendTable(DataTable table, Type type)
    {
        // value is type derived  T, may need to extend table.
        foreach (FieldInfo f in type.GetFields())
        {
            if (!_ordinalMap.ContainsKey(f.Name))
            {
                DataColumn dc = table.Columns.Contains(f.Name) ?
                table.Columns[f.Name]
                :
                table.Columns.Add(f.Name, f.FieldType);
                _ordinalMap.Add(f.Name, dc.Ordinal);
            }
        }
        foreach (PropertyInfo p in type.GetProperties())
        {
            if (!_ordinalMap.ContainsKey(p.Name))
            {
                DataColumn dc = table.Columns.Contains(p.Name) ?
                table.Columns[p.Name]
                :
                table.Columns.Add(p.Name, p.PropertyType);
                _ordinalMap.Add(p.Name, dc.Ordinal);
            }
        }
        return table;
    }

    public object[] ShredObject(DataTable table, T instance)
    {

        FieldInfo[] fi = _fi;
        PropertyInfo[] pi = _pi;

        if (instance.GetType() != typeof(T))
        {
            ExtendTable(table, instance.GetType());
            fi = instance.GetType().GetFields();
            pi = instance.GetType().GetProperties();
        }

        Object[] values = new object[table.Columns.Count];
        foreach (FieldInfo f in fi)
        {
            values[_ordinalMap[f.Name]] = f.GetValue(instance);
        }

        foreach (PropertyInfo p in pi)
        {
            values[_ordinalMap[p.Name]] = p.GetValue(instance, null);
        }
        return values;
    }
}