using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
    //XC_User
    [Table(Name = "XC_User")]
    public class EUser
    {
        public EUser()
        {
            Status = 1;
            CreateTime = DateTime.Now;
            LastChange = DateTime.Now;
        }
        /// <summary>
        /// UserID
        /// </summary>		
        [Id(Name = "UserID", Strategy = GenerationType.INDENTITY)]
        public int UserID { get; set; }
        /// <summary>
        /// UserName
        /// </summary>		
        [Column(Name = "UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// Password
        /// </summary>		
        [Column(Name = "Password")]
        public string Password { get; set; }
        /// <summary>
        /// 辅助密码
        /// </summary>		
        [Column(Name = "PasswordSalt")]
        public string PasswordSalt { get; set; }
        /// <summary>
        /// Sex
        /// </summary>		
        [Column(Name = "Sex")]
        public string Sex { get; set; }
        /// <summary>
        /// Phone
        /// </summary>		
        [Column(Name = "Phone")]
        public string Phone { get; set; }
        /// <summary>
        /// DepartmentID
        /// </summary>		
        [Column(Name = "DepartmentID")]
        public int DepartmentID { get; set; }
        /// <summary>
        /// RoleID
        /// </summary>		
        //[DisplayName("RoleID")]
        [Column(Name = "RoleID")]
        public int RoleID { get; set; }
        /// <summary>
        /// Description
        /// </summary>		
        [Column(Name = "Description")]
        public string Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        //[DisplayName("创建时间")]
        [Column(Name = "CreateTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 数据状态 1有效 -1 无效
        /// </summary>		
        //[DisplayName("数据状态 1有效 -1 无效")]
        [Column(Name = "Status")]
        public int Status { get; set; }
        /// <summary>
        /// 最后改动时间
        /// </summary>		
        //[DisplayName("最后改动时间")]
        [Column(Name = "LastChange")]
        public DateTime LastChange { get; set; }

    }
}