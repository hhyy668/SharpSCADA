using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "BridgeCrane")] 
	public class BridgeCrane
	{    
      	/// <summary>
		/// 行车主键
        /// </summary>		
        [Id(Name = "BridgeCraneID", Strategy = GenerationType.INDENTITY)]
        public int BridgeCraneID { get; set;}       
		/// <summary>
		/// 行车名称
        /// </summary>		
		[Column(Name = "BridgeCraneName")]
        public string BridgeCraneName { get; set;}       
		/// <summary>
		/// 行车状态（1-空闲，2-使用中）
        /// </summary>		
		[Column(Name = "BridgeCraneStatus")]
        public int BridgeCraneStatus { get; set;}       
		/// <summary>
		/// 空闲时所处工位主键
        /// </summary>		
		[Column(Name = "StationID")]
        public int StationID { get; set;}       
		
   
	}
}