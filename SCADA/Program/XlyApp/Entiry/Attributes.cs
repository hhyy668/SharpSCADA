using System;
using System.Collections.Generic;

namespace Easy4net.Entity 
{
    public class DescriptionAttribute : Attribute
    {
        private string _description;
        public string Description { get { return _description; } set { _description = value; } }
        private bool _excludeWhenSelect;//当使用获取枚举项的方法输出到下拉框，列表项的时候，该项是排除的。
        public bool ExcludeWhenSelect { get { return _excludeWhenSelect; } set { _excludeWhenSelect = value; } }
        public DescriptionAttribute(string desc)
        {
            _description = desc;
        }

        public DescriptionAttribute(string desc, bool exclude)
        {
            _description = desc;
            _excludeWhenSelect = exclude;
        }
    }

    public static class AttributesHelper
    {
        public static IDictionary<int, string> GetEnumValueDesc(Type enumType)
        {
            string[] names = Enum.GetNames(enumType);
            IDictionary<int, string> kv = new Dictionary<int, string>();
            foreach (string name in names)
            {
                object[] objs = enumType.GetField(name).GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (objs == null || objs.Length == 0)
                {

                }
                else
                {
                    DescriptionAttribute attr = objs[0] as DescriptionAttribute;
                    if (!attr.ExcludeWhenSelect)
                    {
                        int value = Convert.ToInt32(Enum.Parse(enumType, name));
                        kv.Add(value, attr.Description);
                    }
                }
            }
            return kv;
        }

        /// <summary>
        /// 获取枚举的Description字典
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IDictionary<int, string> GetEnumValueDesc<TEnum>()
        {

            Type enumType = typeof(TEnum);

            return GetEnumValueDesc(enumType);
        }



        /// <summary>
        /// 获取某个枚举某个值的Description
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription<TEnum>(object enumValue)
        {
            IDictionary<int, string> kv = GetEnumValueDesc<TEnum>();
            int value = Convert.ToInt32(enumValue);
            if (kv.ContainsKey(value))
                return kv[value];
            else
                return "";
        }

        /// <summary>
        /// 获取某个枚举某个值的Description
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription(object enumValue,Type type)
        {
            IDictionary<int, string> kv = GetEnumValueDesc(type);
            int value = Convert.ToInt32(enumValue);
            if (kv.ContainsKey(value))
                return kv[value];
            else
                return enumValue.ToString();
        }
    }
}
