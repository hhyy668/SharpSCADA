using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
    //XC_Report
    [Table(Name = "XC_Report")]
    public class EReport
    {
        /// <summary>
        /// ID
        /// </summary>		
        //[DisplayName("ID")]
        [Id(Name = "ID", Strategy = GenerationType.INDENTITY)]
        public int ID { get; set; }
        /// <summary>
        /// ReportName
        /// </summary>		
        //[DisplayName("ReportName")]
        [Column(Name = "ReportName")]
        public string ReportName { get; set; }
        /// <summary>
        /// Type
        /// </summary>		
        //[DisplayName("Type")]
        [Column(Name = "Type")]
        public int Type { get; set; }
        /// <summary>
        /// Description
        /// </summary>		
        //[DisplayName("Description")]
        [Column(Name = "Description")]
        public string Description { get; set; }
        /// <summary>
        /// Sql
        /// </summary>		
        //[DisplayName("Sql")]
        [Column(Name = "Sql")]
        public string Sql { get; set; }
        /// <summary>
        /// StoredProcedure
        /// </summary>		
        //[DisplayName("StoredProcedure")]
        [Column(Name = "StoredProcedure")]
        public string StoredProcedure { get; set; }
        /// <summary>
        /// ParaName1
        /// </summary>		
        //[DisplayName("ParaName1")]
        [Column(Name = "ParaName1")]
        public string ParaName1 { get; set; }
        /// <summary>
        /// ParaValue1
        /// </summary>		
        //[DisplayName("ParaValue1")]
        [Column(Name = "ParaValue1")]
        public string ParaValue1 { get; set; }
        /// <summary>
        /// ParaName2
        /// </summary>		
        //[DisplayName("ParaName2")]
        [Column(Name = "ParaName2")]
        public string ParaName2 { get; set; }
        /// <summary>
        /// ParaValue2
        /// </summary>		
        //[DisplayName("ParaValue2")]
        [Column(Name = "ParaValue2")]
        public string ParaValue2 { get; set; }
        /// <summary>
        /// ParaName3
        /// </summary>		
        //[DisplayName("ParaName3")]
        [Column(Name = "ParaName3")]
        public string ParaName3 { get; set; }
        /// <summary>
        /// ParaValue3
        /// </summary>		
        //[DisplayName("ParaValue3")]
        [Column(Name = "ParaValue3")]
        public string ParaValue3 { get; set; }
        /// <summary>
        /// ParaName4
        /// </summary>		
        //[DisplayName("ParaName4")]
        [Column(Name = "ParaName4")]
        public string ParaName4 { get; set; }
        /// <summary>
        /// ParaValue4
        /// </summary>		
        //[DisplayName("ParaValue4")]
        [Column(Name = "ParaValue4")]
        public string ParaValue4 { get; set; }
        /// <summary>
        /// ParaName5
        /// </summary>		
        //[DisplayName("ParaName5")]
        [Column(Name = "ParaName5")]
        public string ParaName5 { get; set; }
        /// <summary>
        /// ParaValue5
        /// </summary>		
        //[DisplayName("ParaValue5")]
        [Column(Name = "ParaValue5")]
        public string ParaValue5 { get; set; }
        /// <summary>
        /// ParaName6
        /// </summary>		
        //[DisplayName("ParaName6")]
        [Column(Name = "ParaName6")]
        public string ParaName6 { get; set; }
        /// <summary>
        /// ParaValue6
        /// </summary>		
        //[DisplayName("ParaValue6")]
        [Column(Name = "ParaValue6")]
        public string ParaValue6 { get; set; }
        /// <summary>
        /// ParaName7
        /// </summary>		
        //[DisplayName("ParaName7")]
        [Column(Name = "ParaName7")]
        public string ParaName7 { get; set; }
        /// <summary>
        /// ParaValue7
        /// </summary>		
        //[DisplayName("ParaValue7")]
        [Column(Name = "ParaValue7")]
        public string ParaValue7 { get; set; }
        /// <summary>
        /// ParaName8
        /// </summary>		
        //[DisplayName("ParaName8")]
        [Column(Name = "ParaName8")]
        public string ParaName8 { get; set; }
        /// <summary>
        /// ParaValue8
        /// </summary>		
        //[DisplayName("ParaValue8")]
        [Column(Name = "ParaValue8")]
        public string ParaValue8 { get; set; }
        /// <summary>
        /// ParaName9
        /// </summary>		
        //[DisplayName("ParaName9")]
        [Column(Name = "ParaName9")]
        public string ParaName9 { get; set; }
        /// <summary>
        /// ParaValue9
        /// </summary>		
        //[DisplayName("ParaValue9")]
        [Column(Name = "ParaValue9")]
        public string ParaValue9 { get; set; }
        /// <summary>
        /// ParaName10
        /// </summary>		
        //[DisplayName("ParaName10")]
        [Column(Name = "ParaName10")]
        public string ParaName10 { get; set; }
        /// <summary>
        /// ParaValue10
        /// </summary>		
        //[DisplayName("ParaValue10")]
        [Column(Name = "ParaValue10")]
        public string ParaValue10 { get; set; }
        /// <summary>
        /// ParaName11
        /// </summary>		
        //[DisplayName("ParaName11")]
        [Column(Name = "ParaName11")]
        public string ParaName11 { get; set; }
        /// <summary>
        /// ParaValue11
        /// </summary>		
        //[DisplayName("ParaValue11")]
        [Column(Name = "ParaValue11")]
        public string ParaValue11 { get; set; }
        /// <summary>
        /// ParaName12
        /// </summary>		
        //[DisplayName("ParaName12")]
        [Column(Name = "ParaName12")]
        public string ParaName12 { get; set; }
        /// <summary>
        /// ParaValue12
        /// </summary>		
        //[DisplayName("ParaValue12")]
        [Column(Name = "ParaValue12")]
        public string ParaValue12 { get; set; }
        /// <summary>
        /// ParaName13
        /// </summary>		
        //[DisplayName("ParaName13")]
        [Column(Name = "ParaName13")]
        public string ParaName13 { get; set; }
        /// <summary>
        /// ParaValue13
        /// </summary>		
        //[DisplayName("ParaValue13")]
        [Column(Name = "ParaValue13")]
        public string ParaValue13 { get; set; }
        /// <summary>
        /// ParaName14
        /// </summary>		
        //[DisplayName("ParaName14")]
        [Column(Name = "ParaName14")]
        public string ParaName14 { get; set; }
        /// <summary>
        /// ParaValue14
        /// </summary>		
        //[DisplayName("ParaValue14")]
        [Column(Name = "ParaValue14")]
        public string ParaValue14 { get; set; }

    }
}