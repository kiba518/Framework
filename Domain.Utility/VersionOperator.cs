using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Utility
{
    public class VersionOperator
    {
    //    /// <summary>
    //    /// 变更升大版  A -> B.1
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string UpNDSBigVersion(string version)
    //    {
    //        if (string.IsNullOrEmpty(version))
    //        {
    //            return CommonConst.DefaultBigVersionChar.ToString();
    //        }
    //        string bigVersion = version.Split(new string[] { CommonConst.VersionSeparator }, StringSplitOptions.None)[0];
    //        List<char> charList = bigVersion.ToCharArray().ToList();
    //        charList.Reverse();
    //        UpBigVersion(charList, 0);
    //        charList.Reverse();
    //        return ConvertFromCharArrayToString(charList) + ".1";
    //    }

    //    /// <summary>
    //    /// NDS升大版  A -> B
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string GetNDSBigVersion(string version)
    //    {
    //        if (string.IsNullOrEmpty(version))
    //        {
    //            return CommonConst.DefaultBigVersionChar.ToString();
    //        }
    //        string bigVersion = version.Split(new string[] { CommonConst.VersionSeparator }, StringSplitOptions.None)[0];
    //        List<char> charList = bigVersion.ToCharArray().ToList();
    //        charList.Reverse();
    //        UpBigVersion(charList, 0);
    //        charList.Reverse();
    //        return ConvertFromCharArrayToString(charList);
    //    }

    //    /// <summary>
    //    /// 升NDS小版  A.1 -> A.2
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string UpNDSLittleVersion(string version)
    //    {
    //        string newVersion;
    //        string[] arr = version.Split(new char[] { '.' });
    //        if (arr.Length == 1)
    //        {
    //            newVersion = version + ".1";
    //        }
    //        else
    //        {
    //            newVersion = arr[0] + "." + (Convert.ToInt32(arr[1]) + 1).ToString();
    //        }
    //        return newVersion;
    //    }

    //    /// <summary>
    //    /// 降NDS大版  B.1 -> A
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string DownNDSBigVersion(string version)
    //    {
    //        if (string.IsNullOrEmpty(version))
    //        {
    //            return string.Empty;
    //        }
    //        string bigVersion = version.Split(new string[] { "." }, StringSplitOptions.None)[0];
    //        List<char> charList = bigVersion.ToCharArray().ToList();
    //        charList.Reverse();
    //        DownBigVersion(charList, 0);
    //        charList.Reverse();
    //        return ConvertFromCharArrayToString(charList);
    //    }

    //    /// <summary>
    //    /// 降NDS小版 A.2 -> A.1
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string DownNDSLittleVersion(string version)
    //    {
    //        if (string.IsNullOrEmpty(version) || version == CommonConst.DefaultBigVersionChar + CommonConst.VersionSeparator + CommonConst.DefaultSmallVersion)
    //        {
    //            return string.Empty;
    //        }
    //        string newVersion;
    //        string[] arr = version.Split(new char[] { '.' });
    //        if (arr.Length == 1)
    //        {
    //            newVersion = version + ".1";
    //        }
    //        else
    //        {
    //            newVersion = arr[0] + "." + (Convert.ToInt32(arr[1]) - 1).ToString();
    //        }
    //        return newVersion;
    //    }

    //    //如果没有小版本，末尾补充一个0
    //    private static string PadZero(String version)
    //    {
    //        string s;

    //        string[] items = version.Split(new char[] { '.' });
    //        int digit;
    //        bool bDigit = int.TryParse(items[items.Length - 1], out digit);

    //        if (bDigit == false)
    //            s = version + ".0";
    //        else
    //            s = version;

    //        return s;
    //    }

    //    /// <summary>
    //    /// 版本值转化
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static long GetPartVersionValue(string version)
    //    {
    //        if (version.Length == 0)
    //            return -1;

    //        string[] items = PadZero(version).Split(new char[] { '.' });

    //        //版本大版本为大写字母，最多支持到两位，A到ZZ
    //        for (int i = 0; i < items.Length - 1; i++)
    //        {
    //            if (items[i].Length > 2)
    //                return -1;
    //        }

    //        //版本小版本为数字，最多支持三位
    //        if (items[items.Length - 1].Length > 3)
    //            return -1;

    //        long value = 0;
    //        if (items.Length >= 1)
    //        {
    //            for (int i = 0; i < items.Length - 1; i++)
    //            {
    //                //大写字母转换为数字，A为1，B为2，以此类推
    //                //65 is 'A'
    //                int v = (items[i][0]) - 64;

    //                //两位字母的话，每位占3个数字位
    //                //例如 AA 转换为 1001
    //                if (items[i].Length == 2)
    //                {
    //                    v = v * 100 + ((items[i][1]) - 64);
    //                    value = v + (long)(value * Math.Pow(10000, i));

    //                }
    //                else
    //                {
    //                    value = v + (long)(value * Math.Pow(10000, 1));
    //                }

    //            }

    //            value = value * 1000 + int.Parse(items[items.Length - 1]);
    //        }

    //        return value;
    //    }

    //    /// <summary>
    //    /// 获取当前版本的大版本号 A.8 -> A 如果传入为NULL那么返回A
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string GetNDSMaxVersion(string version)
    //    {
    //        if (string.IsNullOrEmpty(version))
    //            return "A";
    //        else
    //            return version.Remove(version.IndexOf('.'));
    //    }

    //    /// <summary>
    //    /// 返回发放版本
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string GetPublishMaxVersion(string version)
    //    {
    //        if (string.IsNullOrEmpty(version))
    //            return "A";
    //        else
    //        {
    //            if (version.IndexOf(".") == -1)
    //                return version;
    //            else
    //                return version.Split('.')[0];
    //        }
    //    }

    //    /// <summary>
    //    /// 升大版。
    //    /// </summary>
    //    /// <param name="charList">版本Char集合。</param>
    //    /// <param name="index">要升版Char的序号。</param>
    //    private static void UpBigVersion(List<char> charList, int index)
    //    {
    //        //判断要升版的序号是否为新增，如果是则在集合中添加一个默认最大版本Char。
    //        if (index == charList.Count)
    //        {
    //            charList.Add(CommonConst.DefaultBigVersionChar);
    //        }
    //        //如果不是则进行升版操作。
    //        else
    //        {
    //            //获取当前序号的Char。
    //            char currentChar = charList[index];

    //            //计算升版后的Char的编码。
    //            int nextCharCode = (Convert.ToInt16(currentChar) + 1);

    //            //定义一个变量，是否进位。
    //            bool carry = false;

    //            //定义一个变量，进位的数。
    //            int carryCount = 0;

    //            //判断升版后的Char的编码是否超过了Z，如果超过了减去大写字母的个数（即从新从A开始计），并标记进位。
    //            while (nextCharCode > Convert.ToInt32('Z'))
    //            {
    //                nextCharCode -= 26;
    //                carry = true;
    //                carryCount += 1;
    //            }

    //            //将Char的编码转换为Char。
    //            char nextChar = Convert.ToChar(nextCharCode);

    //            //把升版后的Char替换到Char集合中。
    //            charList[index] = nextChar;

    //            //判断是否需要进位，如果需要进位，则递归调用自己，对传序号加一（即下一位）的Char进行升版，升版的次数取决于进位的数。
    //            if (carry)
    //            {
    //                for (int i = 0; i < carryCount; i++)
    //                {
    //                    UpBigVersion(charList, index + 1);
    //                }
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 降大版。
    //    /// </summary>
    //    /// <param name="charList">版本Char集合。</param>
    //    /// <param name="index">要升版Char的序号。</param>
    //    private static void DownBigVersion(List<char> charList, int index)
    //    {
    //        if (charList.Count > 0)
    //        {
    //            //获取当前序号的Char。
    //            char currentChar = charList[index];

    //            //计算升版后的Char的编码。
    //            int nextCharCode = (Convert.ToInt16(currentChar) - 1);

    //            //定义一个变量，是否进位。
    //            bool carry = false;

    //            //定义一个变量，退位的数。
    //            int carryCount = 0;

    //            //判断升版后的Char的编码是否超过了Z，如果超过了减去大写字母的个数（即从新从A开始计），并标记进位。
    //            while (nextCharCode < Convert.ToInt32(CommonConst.MinBigVersionChar))
    //            {
    //                nextCharCode += 26;
    //                carry = true;
    //                carryCount += 1;
    //            }

    //            //将Char的编码转换为Char。
    //            char nextChar = Convert.ToChar(nextCharCode);

    //            //把升版后的Char替换到Char集合中。
    //            charList[index] = nextChar;

    //            //判断是否需要进位，如果需要退位，则递归调用自己，对传序号加一（即下一位）的Char进行升版，升版的次数取决于退位的数。
    //            if (carry)
    //            {
    //                if (index == charList.Count - 1)
    //                {
    //                    charList.RemoveAt(index);
    //                }
    //                else
    //                {
    //                    for (int i = 0; i < carryCount; i++)
    //                    {
    //                        DownBigVersion(charList, index + 1);
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    /// <summary>
    //    /// 把Char集合连接成字符串。
    //    /// </summary>
    //    /// <param name="charList">Char集合。</param>
    //    /// <returns>结果字符串。</returns>
    //    private static string ConvertFromCharArrayToString(List<char> charList)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        foreach (var item in charList)
    //        {
    //            sb.Append(item);
    //        }
    //        return sb.ToString();
    //    }

    //    /// <summary>
    //    /// 字符转整型
    //    /// </summary>
    //    /// <param name="character"></param>
    //    /// <returns></returns>
    //    private static int ChrToInt(char character)
    //    {
    //        if (character.ToString().Length == 1)
    //        {
    //            return ((int)character);
    //        }
    //        throw new Exception("升版降版时，字符转ASCII出错！字符："+character.ToString());
    //    }

    //    /// <summary>
    //    /// 整型转字符
    //    /// </summary>
    //    /// <param name="intValue"></param>
    //    /// <returns></returns>
    //    private static char IntToChr(int intValue)
    //    {
    //        if (intValue > 90)
    //        {
    //            intValue = 65;

    //        }
    //        if (intValue >= 0 && intValue <= 255)
    //        {

    //            return ((char)intValue);
    //        }
    //        throw new Exception("升版降版时，ASCII转字符出错！ASCII：" + intValue.ToString());
    //    }

    //    /// <summary>
    //    /// MDS变更升大版  A.A -> A.B.1
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string UpMDSBigVersion(string version)
    //    {
    //        MDSVersion mdsver = new MDSVersion(version);
    //        mdsver.UpMDSBigVersion();
    //        return mdsver.ToString();
    //    }

    //    /// <summary>
    //    /// MDS升大版  A.A -> A.B
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string GetMDSBigVersion(string version)
    //    {
    //        MDSVersion mdsver = new MDSVersion(version);
    //        mdsver.GetMDSBigVersion();

    //        return mdsver.ToString();
    //    }

    //    /// <summary>
    //    /// 升MDS小版  A.A.1 -> A.A.2
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string UpMDSLittleVersion(string version)
    //    {
    //        MDSVersion mdsver = new MDSVersion(version);
    //        mdsver.UpMDSLittleVersion();

    //        return mdsver.ToString();
    //    }

    //    /// <summary>
    //    /// 降MDS大版  A.B.1 -> A.A
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string DownMDSBigVersion(string version)
    //    {
    //        MDSVersion mdsver = new MDSVersion(version);
    //        mdsver.DownMDSBigVersion();

    //        return mdsver.ToString();
    //    }

    //    /// <summary>
    //    /// 降MDS小版 A.A.2 -> A.A.1
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string DownMDSLittleVersion(string version)
    //    {
    //        MDSVersion mdsver = new MDSVersion(version);
    //        mdsver.DownMDSLittleVersion();

    //        return mdsver.ToString();
    //    }

    //    /// <summary>
    //    /// 获取当前版本的大版本号 A.A.8 -> A.A 如果传入为NULL那么返回A.A
    //    /// </summary>
    //    /// <param name="version"></param>
    //    /// <returns></returns>
    //    public static string GetMDSMaxVersion(string version)
    //    {
    //        if (string.IsNullOrEmpty(version))
    //        {
    //            return "A.A";
    //        }
    //        else
    //        {
    //            MDSVersion mdsver = new MDSVersion(version);
    //            mdsver.DownMDSLittleVersion();

    //            return mdsver.GetMDSMaxVersion();
    //        }
    //    }
    //}


    //public class MDSVersion
    //{
    //    private string NDSVer { get; set; }
    //    private string MDSVer { get; set; }
    //    private int? LittleVer { get; set; }

    //    public MDSVersion(string vesrion)
    //    {
    //        string[] vlist = vesrion.ToUpper().Split(new char[] { '.' });

    //        if (vlist.Count() == 2)
    //        {
    //            NDSVer = vlist[0];
    //            MDSVer = vlist[1];
    //            LittleVer = null;
    //        }

    //        if (vlist.Count() == 3)
    //        {
    //            NDSVer = vlist[0];
    //            MDSVer = vlist[1];
    //            LittleVer = int.Parse(vlist[2]);
    //        }
    //    }

    //    //A->B Z->AA AA->AB AZ->BB
    //    private string getNextVersion(string version)
    //    {
    //        char? firstchar;
    //        char secondchar;

    //        if (version.Length == 1)
    //        {
    //            firstchar = null;
    //            secondchar = version[0];
    //        }
    //        else
    //        {
    //            firstchar = version[0];
    //            secondchar = version[1];
    //        }

    //        if (secondchar == 'Z')
    //        {
    //            secondchar = 'A';

    //            if (firstchar == 'Z')
    //                throw new Exception("Up Version Error!");

    //            if (firstchar == null)
    //                firstchar = 'A';
    //            else
    //                firstchar = (char)((char)firstchar + 1);
    //        }
    //        else
    //        {
    //            secondchar = (char)((char)secondchar + 1);
    //        }

    //        StringBuilder sb = new StringBuilder();
    //        sb.Append(firstchar).Append(secondchar);

    //        return sb.ToString();
    //    }

    //    //B->A AA->Z AB->AA AA->Z 
    //    private string getDownVersion(string version)
    //    {
    //        char? firstchar;
    //        char secondchar;

    //        if (version.Length == 1)
    //        {
    //            firstchar = null;
    //            secondchar = version[0];
    //        }
    //        else
    //        {
    //            firstchar = version[0];
    //            secondchar = version[1];
    //        }

    //        if (secondchar == 'A')
    //        {
    //            secondchar = 'Z';

    //            if (firstchar == null)
    //                throw new Exception("Down Version Error!");

    //            if (firstchar == 'A')
    //                firstchar = null;
    //            else
    //                //null Error
    //                firstchar = (char)((char)firstchar - 1);
    //        }
    //        else
    //        {
    //            secondchar = (char)((char)secondchar - 1);
    //        }

    //        StringBuilder sb = new StringBuilder();
    //        sb.Append(firstchar).Append(secondchar);

    //        return sb.ToString();
    //    }

    //    //A.A -> A.B.1
    //    public void UpMDSBigVersion()
    //    {
    //        this.LittleVer = 1;
    //        MDSVer = getNextVersion(MDSVer);
    //    }

    //    // A.A -> A.B
    //    public void GetMDSBigVersion()
    //    {
    //        this.LittleVer = null;
    //        MDSVer = getNextVersion(MDSVer);

    //    }

    //    // A.A.1 -> A.A.2
    //    public void UpMDSLittleVersion()
    //    {
    //        if (this.LittleVer == null)
    //            this.LittleVer = 1;

    //        this.LittleVer++;
    //    }

    //    //A.B.1 -> A.A
    //    public void DownMDSBigVersion()
    //    {
    //        this.LittleVer = null;
    //        MDSVer = getDownVersion(MDSVer);

    //    }

    //    //A.A.2 -> A.A.1
    //    public void DownMDSLittleVersion()
    //    {
    //        if (this.LittleVer == null)
    //            throw new Exception("Down Little Version Error!");

    //        this.LittleVer--;
    //    }

    //    // A.A.8 -> A.A 
    //    public string GetMDSMaxVersion()
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.Append(NDSVer).Append('.').Append(MDSVer);

    //        return sb.ToString();
    //    }

    //    public override string ToString()
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.Append(NDSVer).Append('.').Append(MDSVer);

    //        if (LittleVer != null)
    //            sb.Append('.').Append(LittleVer);

    //        return sb.ToString();
    //    }

    }
}
