using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
	 	//通知表
		 [Table(Name = "XC_Notice")] 
	public class ENotice
	{
             public ENotice()
        {
            Status = 1;
            CreateTime = DateTime.Now;
            LastChange = DateTime.Now;
        }   
      	/// <summary>
		/// NoticeID
        /// </summary>		
		//[DisplayName("NoticeID")]
        [Id(Name = "NoticeID", Strategy = GenerationType.INDENTITY)]
        public long NoticeID { get; set;}       
		/// <summary>
		/// 消息标题
        /// </summary>		
		//[DisplayName("消息标题")]
		[Column(Name = "Title")]
        public string Title { get; set;}       
		/// <summary>
		/// 发送时间
        /// </summary>		
		//[DisplayName("发送时间")]
		[Column(Name = "PublishTime")]
        public DateTime PublishTime { get; set;}       
		/// <summary>
		/// 消息内容
        /// </summary>		
		//[DisplayName("消息内容")]
		[Column(Name = "Content")]
        public string Content { get; set;}       
		/// <summary>
		/// 发送方
        /// </summary>		
		//[DisplayName("发送方")]
		[Column(Name = "SendUserID")]
        public int SendUserID { get; set;}       
		/// <summary>
		/// 接收方
        /// </summary>		
		//[DisplayName("接收方")]
		[Column(Name = "AccessUserID")]
        public int AccessUserID { get; set;}       
		/// <summary>
		/// 消息类型
        /// </summary>		
		//[DisplayName("消息类型")]
		[Column(Name = "TypeID")]
        public int TypeID { get; set;}       
		/// <summary>
		/// 消息状态,0未发送、1未读、2已读，未发送使用到PublishTime
        /// </summary>		
		//[DisplayName("消息状态,0未发送、1未读、2已读，未发送使用到PublishTime")]
		[Column(Name = "NoticeStatus")]
        public int NoticeStatus { get; set;}       
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