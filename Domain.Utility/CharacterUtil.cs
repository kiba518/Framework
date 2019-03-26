using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;


namespace Domain.Utility
{
    public static class CharacterUtil
    {
        public static string ErrorSearchParam = "请确认查询条件，条件中包含特殊字符！";
        /// 转全角的函数(SBC case)
        ///
        ///任意字符串
        ///全角字符串
        ///
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///

        public static String ToDBC(String input)
        {
            // 半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new String(c);
        }

        /**/
        // /
        // / 转半角的函数(DBC case)
        // /
        // /任意字符串
        // /半角字符串
        // /
        // /全角空格为12288，半角空格为32
        // /其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        // /
        public static String ToSBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }

        /// 替换特殊字符。
        /// </summary>
        /// <param name="str">替换特殊字符</param>
        /// <returns>替换特殊字符</returns>
        public static string ReplaceSpecialChar(string str)
        {
            if (string.IsNullOrEmpty(str))
                return String.Empty;

            //"<=&>';,?()@+*#%$"
            //"＜＝＆＞＇；，？（）＠＋＊＃％＄"

            str = str.Replace("'", "＇");
            str = str.Replace(";", "；");
            str = str.Replace(",", "，");
            str = str.Replace("?", "？");
            str = str.Replace("<", "＜");
            str = str.Replace(">", "＞");
            str = str.Replace("(", "（");
            str = str.Replace(")", "）");
            str = str.Replace("@", "＠");
            str = str.Replace("=", "＝");
            str = str.Replace("+", "＋");
            str = str.Replace("*", "＊");
            str = str.Replace("&", "＆");
            str = str.Replace("#", "＃");
            str = str.Replace("%", "％");
            str = str.Replace("$", "＄");

            return str;
        }

        //检查字符串是否包含特殊字符
        public static bool CheckBadWord(string str)
        {
            string pattern1 = @"select|insert|delete|from|count\(|drop table|update|truncate|asc\(|mid\(|char\(|xp_cmdshell|exec   master|netlocalgroup administrators|:|net user|""|or|and";
            //string pattern2 = @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']";
            string pattern2 = @"[;|\[|\]|\}|\{|@|!|\']";  //不包括 百分号和短横线

            //if (Regex.IsMatch(str, pattern1, RegexOptions.IgnoreCase) ||
            //    Regex.IsMatch(str, pattern2))
            //    return true;

            if (String.IsNullOrEmpty(str))
                return false;

            if (Regex.IsMatch(str, pattern2))
            { 
                return true;
            }
            return false;
        }

        //判断查询DTO中是否包含特殊字符
        public static bool IsBadSearchParamDTO(Object obj)
        {
            Type t = obj.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (var prop in props)
            {
                if (prop.PropertyType == typeof(System.String))
                {
                    if (CheckBadWord((String)prop.GetValue(obj, null)) == true)
                        return true;
                }
            }

            return false;
        }

        public static String ReplaceLikeChar(String sql)
        {
            if (CheckBadWord(sql) == true)
                throw new Exception("请确认查询条件，不允许输入星号(*)短横线(-)之外的特殊字符！");

            return sql.Replace('*', '%');
        }
    }
}
