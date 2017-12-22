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
            Register(typeof(UtilityBLL), new UtilityBLL());
            Register(typeof(BridgeCraneBLL), new BridgeCraneBLL());
            Register(typeof(JobOrderBLL), new JobOrderBLL());
            Register(typeof(PoolBLL), new PoolBLL());
            Register(typeof(ProcessStepsBLL), new ProcessStepsBLL());
            Register(typeof(ProductionOderBLL), new ProductionOderBLL());
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
