using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	 	//文件表
		 [Table(Name = "XC_File")] 
	public class EFile
	{
             public EFile()
        {
            Status = 1;
            CreateTime = DateTime.Now;
            LastChange = DateTime.Now;
        }
      	/// <summary>
		/// 游戏1、商品2、订单3、进度4
        /// </summary>		
		//[DisplayName("游戏1、商品2、订单3、进度4")]
        [Id(Name = "FileID", Strategy = GenerationType.INDENTITY)]
        public long FileID { get; set;}       
		/// <summary>
		/// FileName
        /// </summary>		
		//[DisplayName("FileName")]
		[Column(Name = "FileName")]
        public string FileName { get; set;}       
		/// <summary>
		/// OriginalName
        /// </summary>		
		//[DisplayName("OriginalName")]
		[Column(Name = "OriginalName")]
        public string OriginalName { get; set;}       
		/// <summary>
		/// 表示此文件隶属于那个实体的图片：订单、商品、进度等等
        /// </summary>		
		//[DisplayName("表示此文件隶属于那个实体的图片：订单、商品、进度等等")]
		[Column(Name = "FileType")]
        public int FileType { get; set;}       
		/// <summary>
		/// 用来标识某一类文件（作备用）
        /// </summary>		
		//[DisplayName("用来标识某一类文件（作备用）")]
		[Column(Name = "DefineID")]
        public int DefineID { get; set;}       
		/// <summary>
		/// ReferID
        /// </summary>		
		//[DisplayName("ReferID")]
		[Column(Name = "ReferID")]
        public string ReferID { get; set;}       
		/// <summary>
		/// 非图片文件的存放路径
        /// </summary>		
		//[DisplayName("非图片文件的存放路径")]
		[Column(Name = "FileDiskPath")]
        public string FileDiskPath { get; set;}       
		/// <summary>
		/// 大图路径
        /// </summary>		
		//[DisplayName("大图路径")]
		[Column(Name = "FullImgSrc")]
        public string FullImgSrc { get; set;}       
		/// <summary>
		/// 缩略图路径
        /// </summary>		
		//[DisplayName("缩略图路径")]
		[Column(Name = "ViewImgSrc")]
        public string ViewImgSrc { get; set;}       
		/// <summary>
		/// CreateTime
        /// </summary>		
		//[DisplayName("CreateTime")]
		[Column(Name = "CreateTime")]
        public DateTime CreateTime { get; set;}       
		/// <summary>
		/// LastChange
        /// </summary>		
		//[DisplayName("LastChange")]
		[Column(Name = "LastChange")]
        public DateTime LastChange { get; set;}       
		/// <summary>
		/// Status
        /// </summary>		
		//[DisplayName("Status")]
		[Column(Name = "Status")]
        public int Status { get; set;}       
		   
	}
}