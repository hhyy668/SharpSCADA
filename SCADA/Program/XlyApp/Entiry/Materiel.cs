


using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	
	[Table(Name = "Materiel")] 
	public class Materiel
	{    
      	/// <summary>
		/// 物料类型主键
        /// </summary>		
        [Id(Name = "MaterielID", Strategy = GenerationType.INDENTITY)]
        public int MaterielID { get; set;}       
		/// <summary>
		/// 物料类型
        /// </summary>		
		[Column(Name = "MaterielType")]
        public string MaterielType { get; set;}
        /// <summary>
		/// 工位类型
        /// </summary>		
		[Column(Name = "StationType")]
        public int StationType { get; set; }
        
        /// <summary>
        /// 规格
        /// </summary>		
        [Column(Name = "Spec")]
        public string Spec { get; set;}       
		/// <summary>
		/// 描述
        /// </summary>		
		[Column(Name = "Depict")]
        public string Depict { get; set;}       
		/// <summary>
		/// 脱脂
        /// </summary>		
		[Column(Name = "Skim")]
        public int Skim { get; set;}       
		/// <summary>
		/// 一次水洗
        /// </summary>		
		[Column(Name = "OneWash")]
        public int OneWash { get; set;}       
		/// <summary>
		/// 酸洗
        /// </summary>		
		[Column(Name = "Pickling")]
        public int Pickling { get; set;}       
		/// <summary>
		/// 二次水洗
        /// </summary>		
		[Column(Name = "TwoWash")]
        public int TwoWash { get; set;}       
		/// <summary>
		/// 助剂
        /// </summary>		
		[Column(Name = "Auxiliary")]
        public int Auxiliary { get; set;}       
		/// <summary>
		/// 烘干
        /// </summary>		
		[Column(Name = "Dry")]
        public int Dry { get; set;}       
		
   
	}
}