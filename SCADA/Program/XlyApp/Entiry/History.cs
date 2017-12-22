using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "History")] 
	public class History
	{    
      	/// <summary>
		/// ID
        /// </summary>		
		[Column(Name = "ID")]
        public long ID { get; set;}       
		/// <summary>
		/// 批次
        /// </summary>		
		[Column(Name = "Batch")]
        public int Batch { get; set;}       
		/// <summary>
		/// 生产时间
        /// </summary>		
		[Column(Name = "ProductTime")]
        public DateTime ProductTime { get; set;}       
		/// <summary>
		/// 定单号
        /// </summary>		
		[Column(Name = "OrderNO")]
        public int OrderNO { get; set;}       
		/// <summary>
		/// 骨1重量
        /// </summary>		
		[Column(Name = "AGG1Weigh")]
        public decimal AGG1Weigh { get; set;}       
		/// <summary>
		/// 骨2重量d
        /// </summary>		
		[Column(Name = "AGG2Weigh")]
        public decimal AGG2Weigh { get; set;}       
		/// <summary>
		/// 骨3重量
        /// </summary>		
		[Column(Name = "AGG3Weigh")]
        public decimal AGG3Weigh { get; set;}       
		/// <summary>
		/// 骨4重量
        /// </summary>		
		[Column(Name = "AGG4Weigh")]
        public decimal AGG4Weigh { get; set;}       
		/// <summary>
		/// 骨5重量
        /// </summary>		
		[Column(Name = "AGG5Weigh")]
        public decimal AGG5Weigh { get; set;}       
		/// <summary>
		/// 骨6重量
        /// </summary>		
		[Column(Name = "AGG6Weigh")]
        public decimal AGG6Weigh { get; set;}       
		/// <summary>
		/// 粉1重量
        /// </summary>		
		[Column(Name = "FIL1Weigh")]
        public decimal FIL1Weigh { get; set;}       
		/// <summary>
		/// 粉2重量
        /// </summary>		
		[Column(Name = "FIL2Weigh")]
        public decimal FIL2Weigh { get; set;}       
		/// <summary>
		/// 沥青重量
        /// </summary>		
		[Column(Name = "BITWeigh")]
        public decimal BITWeigh { get; set;}       
		/// <summary>
		/// 骨1误差
        /// </summary>		
		[Column(Name = "AGG1Dev")]
        public decimal AGG1Dev { get; set;}       
		/// <summary>
		/// 骨2误差
        /// </summary>		
		[Column(Name = "AGG2Dev")]
        public decimal AGG2Dev { get; set;}       
		/// <summary>
		/// 骨3误差
        /// </summary>		
		[Column(Name = "AGG3Dev")]
        public decimal AGG3Dev { get; set;}       
		/// <summary>
		/// 骨4误差
        /// </summary>		
		[Column(Name = "AGG4Dev")]
        public decimal AGG4Dev { get; set;}       
		/// <summary>
		/// 骨5误差
        /// </summary>		
		[Column(Name = "AGG5Dev")]
        public decimal AGG5Dev { get; set;}       
		/// <summary>
		/// 骨6误差
        /// </summary>		
		[Column(Name = "AGG6Dev")]
        public decimal AGG6Dev { get; set;}       
		/// <summary>
		/// 粉1误差
        /// </summary>		
		[Column(Name = "FIL1Dev")]
        public decimal FIL1Dev { get; set;}       
		/// <summary>
		/// 粉2误差
        /// </summary>		
		[Column(Name = "FIL2Dev")]
        public decimal FIL2Dev { get; set;}       
		/// <summary>
		/// 沥青误差
        /// </summary>		
		[Column(Name = "BITDev")]
        public decimal BITDev { get; set;}       
		/// <summary>
		/// 单盘重量
        /// </summary>		
		[Column(Name = "SingleWeigh")]
        public decimal SingleWeigh { get; set;}       
		/// <summary>
		/// 配比名称
        /// </summary>		
		[Column(Name = "RecipeName")]
        public string RecipeName { get; set;}       
		/// <summary>
		/// 骨1目标
        /// </summary>		
		[Column(Name = "Agg1Goal")]
        public decimal Agg1Goal { get; set;}       
		/// <summary>
		/// 骨2目标
        /// </summary>		
		[Column(Name = "Agg2Goal")]
        public decimal Agg2Goal { get; set;}       
		/// <summary>
		/// 骨3目标
        /// </summary>		
		[Column(Name = "Agg3Goal")]
        public decimal Agg3Goal { get; set;}       
		/// <summary>
		/// 骨4目标
        /// </summary>		
		[Column(Name = "Agg4Goal")]
        public decimal Agg4Goal { get; set;}       
		/// <summary>
		/// 骨5目标
        /// </summary>		
		[Column(Name = "Agg5Goal")]
        public decimal Agg5Goal { get; set;}       
		/// <summary>
		/// 骨6目标
        /// </summary>		
		[Column(Name = "Agg6Goal")]
        public decimal Agg6Goal { get; set;}       
		/// <summary>
		/// 粉1目标
        /// </summary>		
		[Column(Name = "Fil1Goal")]
        public decimal Fil1Goal { get; set;}       
		/// <summary>
		/// 粉2目标
        /// </summary>		
		[Column(Name = "Fil2Goal")]
        public decimal Fil2Goal { get; set;}       
		/// <summary>
		/// 沥青目标
        /// </summary>		
		[Column(Name = "BitGoal")]
        public decimal BitGoal { get; set;}       
		/// <summary>
		/// 成品料温
        /// </summary>		
		[Column(Name = "Temperature")]
        public decimal Temperature { get; set;}       
		/// <summary>
		/// 联网标志
        /// </summary>		
		[Column(Name = "NetFlag")]
        public int NetFlag { get; set;}       
		/// <summary>
		/// 干预标志
        /// </summary>		
		[Column(Name = "IntervenceFlag")]
        public int IntervenceFlag { get; set;}       
		/// <summary>
		/// 骨1补料
        /// </summary>		
		[Column(Name = "Agg1Intervence")]
        public int Agg1Intervence { get; set;}       
		/// <summary>
		/// 骨2补料
        /// </summary>		
		[Column(Name = "Agg2Intervence")]
        public int Agg2Intervence { get; set;}       
		/// <summary>
		/// 骨3补料
        /// </summary>		
		[Column(Name = "Agg3Intervence")]
        public int Agg3Intervence { get; set;}       
		/// <summary>
		/// 骨4补料
        /// </summary>		
		[Column(Name = "Agg4Intervence")]
        public int Agg4Intervence { get; set;}       
		/// <summary>
		/// 骨5补料
        /// </summary>		
		[Column(Name = "Agg5Intervence")]
        public int Agg5Intervence { get; set;}       
		/// <summary>
		/// 骨6补料
        /// </summary>		
		[Column(Name = "Agg6Intervence")]
        public int Agg6Intervence { get; set;}       
		
   
	}
}