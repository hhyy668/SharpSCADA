


using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "ReciveRecord")] 
	public class ReciveRecord
	{
        /// <summary>
        /// 进料单号
        /// </summary>		
        [Id(Name = "ReciveRecordID", Strategy = GenerationType.FILL)]
        public string ReciveRecordID { get; set;}       
		/// <summary>
		/// 订单号
        /// </summary>		
		[Column(Name = "ProductionOderID")]
        public int ProductionOderID { get; set;}
        /// <summary>
        /// 锈蚀程度
        /// </summary>		
        [Column(Name = "CorrosionDegree")]
        public string CorrosionDegree { get; set; }
        /// <summary>
        /// 描述
        /// </summary>		
        [Column(Name = "CorrosionMsg")]
        public string CorrosionMsg { get; set; }
        /// <summary>
        /// 特殊工艺时长
        /// </summary>		
        [Column(Name = "SpecialProcessLengthOfStay")]
        public int SpecialProcessLengthOfStay { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>		
        [Column(Name = "VehicleID")]
        public string VehicleID { get; set;}       
		/// <summary>
		/// 司机
        /// </summary>		
		[Column(Name = "Driver")]
        public string Driver { get; set;}       
		/// <summary>
		/// 司机电话
        /// </summary>		
		[Column(Name = "DriverPhone")]
        public string DriverPhone { get; set;}       
		/// <summary>
		/// 毛重
        /// </summary>		
		[Column(Name = "RoughWeight")]
        public decimal RoughWeight { get; set;}       
		/// <summary>
		/// 皮重
        /// </summary>		
		[Column(Name = "TareWeight")]
        public decimal TareWeight { get; set;}       
		/// <summary>
		/// 接受重量
        /// </summary>		
		[Column(Name = "AcceptWeight")]
        public decimal AcceptWeight { get; set;}       
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