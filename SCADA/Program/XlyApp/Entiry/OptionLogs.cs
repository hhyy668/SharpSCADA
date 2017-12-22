using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "OptionLogs")] 
	public class OptionLogs
	{    
      	/// <summary>
		/// 操作内容
        /// </summary>		
		[Column(Name = "OptionID")]
        public long OptionID { get; set;}       
		/// <summary>
		/// 操作时间
        /// </summary>		
		[Column(Name = "OptionTime")]
        public DateTime OptionTime { get; set;}       
		/// <summary>
		/// 操作人
        /// </summary>		
		[Column(Name = "OptionPerson")]
        public string OptionPerson { get; set;}       
		/// <summary>
		/// Description
        /// </summary>		
		[Column(Name = "Description")]
        public string Description { get; set;}       
		/// <summary>
		/// 状态
        /// </summary>		
		[Column(Name = "State")]
        public int State { get; set;}       
		
   
	}
}