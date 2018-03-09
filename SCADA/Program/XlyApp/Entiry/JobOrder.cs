using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "JobOrder")] 
	public class JobOrder
	{
        public JobOrder()
        {
            Status = 1;
            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;
            StartTime = "1900-01-01 00:00:00".ToDateTime();
            EndTime = "1900-01-01 00:00:00".ToDateTime();
        }
        /// <summary>
        /// 任务单主键
        /// </summary>		
        [Id(Name = "JobOrderID", Strategy = GenerationType.FILL)]
        public string JobOrderID { get; set;}       
        /// <summary>
		/// 挂具编号
        /// </summary>		
		[Column(Name = "RacksID")]
        public string RacksID { get; set; }
        
        /// <summary>
        /// 生产单主键
        /// </summary>		
        [Column(Name = "ProductionOderID")]
        public int ProductionOderID { get; set;}
        /// <summary>
        /// 进料单主键
        /// </summary>		
        [Column(Name = "ReciveRecordID")]
        public string ReciveRecordID { get; set; }
        
        /// <summary>
        /// 状态 （1-未开始，2-执行中，3-已完成）
        /// </summary>		
        [Column(Name = "Status")]
        public int Status { get; set;}       
		/// <summary>
		/// 开始时间
        /// </summary>		
		[Column(Name = "StartTime")]
        public DateTime? StartTime { get; set;}       
		/// <summary>
		/// 结束时间
        /// </summary>		
		[Column(Name = "EndTime")]
        public DateTime? EndTime { get; set;}       
		/// <summary>
		/// 数量
        /// </summary>		
		[Column(Name = "Number")]
        public decimal Number { get; set;}       
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