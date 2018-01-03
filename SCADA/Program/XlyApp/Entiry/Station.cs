


using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "Station")] 
	public class Station
	{    
      	/// <summary>
		/// 工位主键
        /// </summary>		
        [Id(Name = "StationID", Strategy = GenerationType.INDENTITY)]
        public int StationID { get; set;}       
		/// <summary>
		/// 池主键
        /// </summary>		
		[Column(Name = "PoolID")]
        public int PoolID { get; set;}       
		/// <summary>
		/// 工位类型
        /// </summary>		
		[Column(Name = "StationType")]
        public string StationType { get; set;}       
		/// <summary>
		/// 工位状态（1-空闲，2-使用中）
        /// </summary>		
		[Column(Name = "StationStatus")]
        public int StationStatus { get; set;}       
		
   
	}
}