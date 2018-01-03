using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
    //XC_User_Role
    [Table(Name = "XC_User_Role")]
    public class EUser_Role
    {
        public EUser_Role()
        {
            Status = 1;
            CreateTime = DateTime.Now;
            LastChange = DateTime.Now;
        }
        /// <summary>
        /// ID
        /// </summary>		
        //[DisplayName("ID")]
        [Id(Name = "ID", Strategy = GenerationType.INDENTITY)]
        public int ID { get; set; }
        /// <summary>
        /// UserID
        /// </summary>		
        //[DisplayName("UserID")]
        [Column(Name = "UserID")]
        public int UserID { get; set; }
        /// <summary>
        /// RoleID
        /// </summary>		
        //[DisplayName("RoleID")]
        [Column(Name = "RoleID")]
        public int RoleID { get; set; }
        /// <summary>
        /// Description
        /// </summary>		
        //[DisplayName("Description")]
        [Column(Name = "Description")]
        public string Description { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>		
        //[DisplayName("CreateTime")]
        [Column(Name = "CreateTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// LastChange
        /// </summary>		
        //[DisplayName("LastChange")]
        [Column(Name = "LastChange")]
        public DateTime LastChange { get; set; }
        /// <summary>
        /// Status
        /// </summary>		
        //[DisplayName("Status")]
        [Column(Name = "Status")]
        public int Status { get; set; }

    }
}