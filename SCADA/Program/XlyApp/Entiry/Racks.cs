


using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "Racks")] 
	public class Racks
	{    
      	/// <summary>
		/// 挂具主键
        /// </summary>		
        [Id(Name = "RacksID", Strategy = GenerationType.INDENTITY)]
        public int RacksID { get; set;}       
		/// <summary>
		/// 挂具名称
        /// </summary>		
		[Column(Name = "RacksName")]
        public string RacksName { get; set;}       
		/// <summary>
		/// 挂具类型
        /// </summary>		
		[Column(Name = "RacksType")]
        public int RacksType { get; set;}       
		/// <summary>
		/// 挂具状态
        /// </summary>		
		[Column(Name = "RacksStatus")]
        public int RacksStatus { get; set;}       
		/// <summary>
		/// 所属任务编号
        /// </summary>		
		[Column(Name = "JobOrderID")]
        public int JobOrderID { get; set;}       
		/// <summary>
		/// 使用时间
        /// </summary>		
		[Column(Name = "UseTime")]
        public DateTime UseTime { get; set;}       
		/// <summary>
		/// 创建时间
        /// </summary>		
		[Column(Name = "CreateTime")]
        public DateTime CreateTime { get; set;}       
		/// <summary>
		/// 创建人
        /// </summary>		
		[Column(Name = "CteateUser")]
        public string CteateUser { get; set;}       
		/// <summary>
		/// 修改时间
        /// </summary>		
		[Column(Name = "ModifyTime")]
        public DateTime ModifyTime { get; set;}       
		/// <summary>
		/// 修改人
        /// </summary>		
		[Column(Name = "ModifyUser")]
        public string ModifyUser { get; set;}       
		
   
	}
}