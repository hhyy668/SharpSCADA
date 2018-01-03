using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
    //XC_PermissionDistribution
    [Table(Name = "XC_PermissionDistribution")]
    public class EPermissionDistribution
    {
        public EPermissionDistribution()
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
        /// RoleID
        /// </summary>		
        //[DisplayName("RoleID")]
        [Column(Name = "RoleID")]
        public int RoleID { get; set; }
        /// <summary>
        /// 权限id
        /// </summary>		
        //[DisplayName("权限id")]
        [Column(Name = "PermissionID")]
        public int PermissionID { get; set; }
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