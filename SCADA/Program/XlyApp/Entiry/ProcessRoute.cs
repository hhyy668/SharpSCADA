


using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "ProcessRoute")] 
	public class ProcessRoute
	{    
      	/// <summary>
		/// 工艺路线主键
        /// </summary>		
        [Id(Name = "ProcessRouteID", Strategy = GenerationType.INDENTITY)]
        public int ProcessRouteID { get; set;}       
		/// <summary>
		/// 物料类型主键
        /// </summary>		
		[Column(Name = "MaterielID")]
        public string MaterielID { get; set;}       
		/// <summary>
		/// 步骤序号
        /// </summary>		
		[Column(Name = "StepNumber")]
        public int StepNumber { get; set;}       
		/// <summary>
		/// 步骤名称
        /// </summary>		
		[Column(Name = "StepName")]
        public string StepName { get; set;}       
		/// <summary>
		/// 应停留时长
        /// </summary>		
		[Column(Name = "LengthOfStay")]
        public int LengthOfStay { get; set;}       
		/// <summary>
		/// 应处理池类型
        /// </summary>		
		[Column(Name = "ProcessingPoolType")]
        public string ProcessingPoolType { get; set;}       
		
   
	}
}