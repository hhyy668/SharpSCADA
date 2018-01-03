using Easy4net.CustomAttributes;
using System;
using System.Linq;
namespace Easy4net.Entity
{
    //XC_Permission
    [Table(Name = "XC_Permission")]
    public class EPermission
    {
        public EPermission()
        {
            Status = 1;
            CreateTime = DateTime.Now;
            LastChange = DateTime.Now;
        }
        /// <summary>
        /// PermissionID
        /// </summary>		
        [Id(Name = "PermissionID", Strategy = GenerationType.INDENTITY)]
        public int PermissionID { get; set; }
        /// <summary>
        /// 权限类型1菜单权限 2操作权限
        /// </summary>		
        //[DisplayName("权限类型1菜单权限 2操作权限")]
        [Column(Name = "Type")]
        public int Type { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>		
        //[DisplayName("权限名称")]
        [Column(Name = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>		
        //[DisplayName("控制器")]
        [Column(Name = "Controller")]
        public string Controller { get; set; }
        /// <summary>
        /// 方法
        /// </summary>		
        //[DisplayName("方法")]
        [Column(Name = "Action")]
        public string Action { get; set; }
        /// <summary>
        /// 参数集
        /// </summary>		
        //[DisplayName("参数集")]
        [Column(Name = "Parameter")]
        public string Parameter { get; set; }
        /// <summary>
        /// navTab标签页 dialog开窗
        /// </summary>		
        //[DisplayName("navTab标签页 dialog开窗")]
        [Column(Name = "Target")]
        public string Target { get; set; }
        /// <summary>
        /// 用来区分标签页的代号
        /// </summary>		
        //[DisplayName("用来区分标签页的代号")]
        [Column(Name = "Rel")]
        public string Rel { get; set; }
        /// <summary>
        /// 模块名称1、销售模块、2采购模块
        /// </summary>		
        //[DisplayName("模块名称1、销售模块、2采购模块")]
        [Column(Name = "Class")]
        public int Class { get; set; }
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