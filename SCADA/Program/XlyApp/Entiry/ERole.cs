using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
    //XC_Role
    [Table(Name = "XC_Role")]
    public class ERole
    {
        public ERole()
        {
            Status = 1;
            CreateTime = DateTime.Now;
            LastChange = DateTime.Now;
        }
        /// <summary>
        /// RoleID
        /// </summary>		
        //[DisplayName("RoleID")]
        [Id(Name = "RoleID", Strategy = GenerationType.INDENTITY)]
        public int RoleID { get; set; }
        /// <summary>
        /// RoleName
        /// </summary>		
        //[DisplayName("RoleName")]
        [Column(Name = "RoleName")]
        public string RoleName { get; set; }
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