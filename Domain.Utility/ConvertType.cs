using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Utility
{
  
    public class ConvertType
    {
        /// <summary>
        /// 把a的所有属性值，赋值给b的对应属性。
        /// </summary>
        /// <param name="a">对象a。</param>
        /// <param name="b">对象b。</param>
        public void Convert(object a, object b)
        {
            List<Type> listType = new List<Type> { 
                typeof(Boolean), 
                typeof(Boolean?),
                typeof(Int64),
                typeof(Int64?),
                typeof(Int32), 
                typeof(Int32?), 
                typeof(String), 
                typeof(Double), 
                typeof(Double?), 
                typeof(DateTime), 
                typeof(DateTime?), 
                typeof(Byte[]),
                typeof(Guid),
                typeof(Guid?),
                typeof(Dictionary<string, string>) 
            };
            //循环所有属性，从a中取值并赋给b的对应属性。
            foreach (var item in a.GetType().GetProperties())
            {
                if (listType.Contains(item.PropertyType))
                {
                    object value = item.GetValue(a, null);
                    var property = b.GetType().GetProperty(item.Name);
                    if (property != null)
                    {
                        property.SetValue(b, value, null);
                    }
                }
            }
        }

        /// <summary>
        /// 把a的所有属性值，赋值给b的对应属性。
        /// 除了Guid类型外
        /// </summary>
        /// <param name="a">对象a。</param>
        /// <param name="b">对象b。</param>
        public void ConvertWithoutGuid(object a, object b)
        {
            List<Type> listType = new List<Type> { 
                typeof(Boolean), 
                typeof(Boolean?), 
                typeof(Int32), 
                typeof(Int32?), 
                typeof(String), 
                typeof(Double), 
                typeof(Double?), 
                typeof(DateTime), 
                typeof(DateTime?), 
                typeof(Byte[]),
                //typeof(Guid),
                typeof(Dictionary<string, string>) 
            };
            //循环所有属性，从a中取值并赋给b的对应属性。
            foreach (var item in a.GetType().GetProperties())
            {
                if (listType.Contains(item.PropertyType))
                {
                    object value = item.GetValue(a, null);
                    var property = b.GetType().GetProperty(item.Name);
                    if (property != null)
                    {
                        property.SetValue(b, value, null);
                    }
                }
            }
        }

        /// <summary>
        /// 把a的所有属性值，赋值给b的对应属性。
        /// </summary>
        /// <param name="a">对象a。</param>
        /// <param name="b">对象b。</param>
        public void ConvertWithoutTimeStamp(object a, object b)
        {
            List<Type> listType = new List<Type> { 
                typeof(Boolean), 
                typeof(Boolean?), 
                typeof(Int32), 
                typeof(Int32?), 
                typeof(String), 
                typeof(Double), 
                typeof(Double?), 
                typeof(DateTime), 
                typeof(DateTime?), 
                typeof(Byte[]),
                typeof(Guid),
                typeof(Guid?),
                typeof(Dictionary<string, string>) 
            };
            //循环所有属性，从a中取值并赋给b的对应属性。
            foreach (var item in a.GetType().GetProperties())
            {
                if (item.Name.CompareTo("timestamp") == 0)
                { continue; }
                if (listType.Contains(item.PropertyType))
                {
                    object value = item.GetValue(a, null);
                    var property = b.GetType().GetProperty(item.Name);
                    if (property != null)
                    {
                        property.SetValue(b, value, null);
                    }
                }
            }
        }

        /// <summary>
        /// 复制除某个字段以外的所有字段
        /// </summary>
        /// <param name="a">对象a。</param>
        /// <param name="b">对象b。</param>
        /// <param name="key">字段</param>
        public void ConvertWithoutKey(object a, object b,string key)
        {
            List<Type> listType = new List<Type> { 
                typeof(Boolean), 
                typeof(Boolean?), 
                typeof(Int32), 
                typeof(Int32?), 
                typeof(String), 
                typeof(Double), 
                typeof(Double?), 
                typeof(DateTime), 
                typeof(DateTime?), 
                typeof(Byte[]),
                typeof(Guid),
                typeof(Guid?),
                typeof(Dictionary<string, string>) 
            };
            //循环所有属性，从a中取值并赋给b的对应属性。
            foreach (var item in a.GetType().GetProperties())
            {
                if (item.Name.CompareTo(key) == 0)
                { continue; }
                if (listType.Contains(item.PropertyType))
                {
                    object value = item.GetValue(a, null);
                    var property = b.GetType().GetProperty(item.Name);
                    if (property != null)
                    {
                        property.SetValue(b, value, null);
                    }
                }
            }
        }
    }
}
