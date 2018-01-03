using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Engine : IDisposable
    {
        private static IDictionary<Type, object> container = new Dictionary<Type, object>();
        static Engine()
        {
            Register(typeof(FileBLL), new FileBLL());
            Register(typeof(PermissionBLL), new PermissionBLL());
            Register(typeof(PermissionDistributionBLL), new PermissionDistributionBLL());
            Register(typeof(User_RoleBLL), new User_RoleBLL());
            Register(typeof(UserBLL), new UserBLL());
            Register(typeof(NoticeBLL), new NoticeBLL());
            Register(typeof(ReportBLL), new ReportBLL());
            Register(typeof(DepartmentBLL), new DepartmentBLL());
            Register(typeof(RoleBLL), new RoleBLL());
            Register(typeof(UtilityBLL), new UtilityBLL());
            Register(typeof(BridgeCraneBLL), new BridgeCraneBLL());
            Register(typeof(JobOrderBLL), new JobOrderBLL());
            Register(typeof(MaterielBLL), new MaterielBLL());
            Register(typeof(PoolBLL), new PoolBLL());
            Register(typeof(ProcessRouteBLL), new ProcessRouteBLL());
            Register(typeof(ProcessStepsBLL), new ProcessStepsBLL());
            Register(typeof(ProductionOderBLL), new ProductionOderBLL());
            Register(typeof(RacksBLL), new RacksBLL());
            Register(typeof(StationBLL), new StationBLL());
            //重复添加
        }

        static void Register(Type type, object o)
        {
            container.Add(new KeyValuePair<Type, object>(type, o));
        }

        public static T GetProvider<T>()
        {
            return (T)container[typeof(T)];
        }

        public void Dispose()
        {

        }
    }
}
