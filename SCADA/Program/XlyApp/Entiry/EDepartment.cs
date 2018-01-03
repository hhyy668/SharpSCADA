using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "XC_Department")] 
	public class EDepartment
	{    
        public EDepartment()
        {
            Status = 1;
            CreateTime = DateTime.Now;
            LastChange = DateTime.Now;
        }
      	/// <summary>
		/// DepartmentID
        /// </summary>		
        [Id(Name = "DepartmentID", Strategy = GenerationType.INDENTITY)]
        public int DepartmentID { get; set;}       
		/// <summary>
		/// PID
        /// </summary>		
		[Column(Name = "PID")]
        public int PID { get; set;}       
		/// <summary>
		/// DepartmentName
        /// </summary>		
		[Column(Name = "DepartmentName")]
        public string DepartmentName { get; set;}       
		/// <summary>
		/// Description
        /// </summary>		
		[Column(Name = "Description")]
        public string Description { get; set;}       
		/// <summary>
		/// CreateTime
        /// </summary>		
		[Column(Name = "CreateTime")]
        public DateTime CreateTime { get; set;}       
		/// <summary>
		/// Status
        /// </summary>		
		[Column(Name = "Status")]
        public int Status { get; set;}       
		/// <summary>
		/// LastChange
        /// </summary>		
		[Column(Name = "LastChange")]
        public DateTime LastChange { get; set;}       
		   
	}
}