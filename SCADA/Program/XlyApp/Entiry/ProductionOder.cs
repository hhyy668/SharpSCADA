
using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "ProductionOder")] 
	public class ProductionOder
	{
        public ProductionOder()
        {
            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;
        }
        /// <summary>
        /// 生产单主键
        /// </summary>		
        [Id(Name = "ProductionOderID", Strategy = GenerationType.INDENTITY)]
        public int ProductionOderID { get; set;}       
		/// <summary>
		/// 生产单号
        /// </summary>		
		[Column(Name = "ProductionOderCode")]
        public string ProductionOderCode { get; set;}       
		/// <summary>
		/// 客户名称
        /// </summary>		
		[Column(Name = "CustomerName")]
        public string CustomerName { get; set;}       
		/// <summary>
		/// 物料类型
        /// </summary>		
		[Column(Name = "MaterielID")]
        public string MaterielID { get; set;}
        [Column(Name = "MaterielType")]
        public string MaterielType { get; set; }
        
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