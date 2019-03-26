using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Utility
{
    /// <summary>
    /// 对象比对类
    /// </summary>
    public class ObjectCompare
    {
        public bool Compare(object a, object b)
        {
            Type type = a.GetType();
            if (b.GetType() == type)
            {
                foreach (var propertyInfo in type.GetProperties())
                {
                    object valueA = propertyInfo.GetValue(a, null);
                    object valueB = propertyInfo.GetValue(b, null);
                    if ((valueA != null && valueB == null) || (valueA == null && valueB != null))
                    {
                        return false;
                    }
                    else if (valueA != null && valueB != null)
                    {
                        if (!propertyInfo.GetValue(a, null).Equals(propertyInfo.GetValue(b, null)))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 对象之间进行比较 排除p_listBeside列表中的参数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="p_listBeside"></param>
        /// <returns></returns>
        public bool Compare(object a, object b, List<string> p_listBeside)
        {
            Type type = a.GetType();
            if (b.GetType() == type)
            {
                foreach (var propertyInfo in type.GetProperties())
                {
                    object valueA = propertyInfo.GetValue(a, null);
                    object valueB = propertyInfo.GetValue(b, null);
                    if (((valueA != null && valueB == null) || (valueA == null && valueB != null)) && GetIsBeside(propertyInfo.Name, p_listBeside))
                    {
                        return false;
                    }
                    else if (valueA != null && valueB != null && GetIsBeside(propertyInfo.Name, p_listBeside))
                    {
                        if (!propertyInfo.GetValue(a, null).Equals(propertyInfo.GetValue(b, null)))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查看KEY是否包含在集合中 包含返回false 不包含返回true
        /// </summary>
        /// <param name="p_key"></param>
        /// <param name="p_list"></param>
        /// <returns></returns>
        private bool GetIsBeside(string p_key, List<string> p_list)
        {
            foreach (var tempList in p_list)
            {
                if (p_key.Equals(tempList))
                    return false;
            }
            return true;
        }

        public string GetObjectString(object item)
        {
            if (item == null)
            {
                return string.Empty;
            }
            else
            {
                return item.ToString();
            }
        }
    }
}
