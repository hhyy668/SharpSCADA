


using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "Pool")] 
	public class Pool
	{    
      	/// <summary>
		/// 池主键
        /// </summary>		
        [Id(Name = "PoolID", Strategy = GenerationType.INDENTITY)]
        public int PoolID { get; set;}       
		/// <summary>
		/// 池编号
        /// </summary>		
		[Column(Name = "PoolCode")]
        public string PoolCode { get; set;}       
		/// <summary>
		/// 池类型
        /// </summary>		
		[Column(Name = "PoolType")]
        public string PoolType { get; set;}       
		
   
	}
}