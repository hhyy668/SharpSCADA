using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "ProcessSteps")] 
	public class ProcessSteps
	{
        public ProcessSteps()
        {
            Statue = 1;
            StartTime = "1900-01-01 00:00:00".ToDateTime();
            EntTime = "1900-01-01 00:00:00".ToDateTime();
        }
        /// <summary>
        /// 工艺步骤主键
        /// </summary>		
        [Id(Name = "ProcessStepsID", Strategy = GenerationType.INDENTITY)]
        public int ProcessStepsID { get; set;}       
		/// <summary>
		/// 任务单主键
        /// </summary>		
		[Column(Name = "JobOrderID")]
        public int JobOrderID { get; set;}       
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
		/// <summary>
		/// 开始时间
        /// </summary>		
		[Column(Name = "StartTime")]
        public DateTime StartTime { get; set;}       
		/// <summary>
		/// 结束时间
        /// </summary>		
		[Column(Name = "EntTime")]
        public DateTime EntTime { get; set;}       
		/// <summary>
		/// 状态（1-开始时间，2-执行中，已完成）
        /// </summary>		
		[Column(Name = "Statue")]
        public int Statue { get; set;}       
		/// <summary>
		/// 工位主键
        /// </summary>		
		[Column(Name = "StationID")]
        public int StationID { get; set;}       
		
   
	}
}