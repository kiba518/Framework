using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Domain.Utility
{
    public class SingleQuoteStringParser
    {
        private static int[] comma = new int[] { -1, 3, 0, 3 },
                     other = new int[] { -1, 3, -1, 3 };

        private static int[] quote = new int[] { 1, 2, 3, 2 };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool Unpack(string text, out List<string> list)
        {
            return ParseHelper<List<string>, ListStringCollection<List<string>>>.Parse(text, out list);
        }

        public static bool Pack(List<string> list, out string text)
        {
            return PackageHelper<List<string>>.Pack(out text, list);
        }

        public static bool Unpack(string text, out List<KeyValuePair<string, string>> list)
        {
            return ParseHelper<List<KeyValuePair<string, string>>, ListPairStringColllection>.Parse(text, out list);
        }

        public static bool Pack(List<KeyValuePair<string, string>> list, out string text)
        {
            return PackageHelper<List<KeyValuePair<string, string>>>.Pack2(out text, list);
        }

        //public static bool Pack(SortedList<string, string> sortlist, out string text)
        //{
        //    return PackageHelper<SortedList<string, string>>.Pack2(out text, sortlist);
        //}

        public static bool Unpack(string text, out Dictionary<string, string> dic)
        {
            return ParseHelper<Dictionary<string, string>, DictionaryStringCollection>.Parse(text, out dic);
        }

        public static bool Pack(Dictionary<string, string> dic, out string text)
        {
            return PackageHelper<Dictionary<string, string>>.Pack2(out text, dic);
        }

        public static List<string> UnpackListString(string text)
        {
            List<string> list;
            ParseHelper<List<string>, ListStringCollection<List<string>>>.Parse(text, out list);
            return list;
        }

        public static string PackString(List<string> list)
        {
            string text;
            PackageHelper<List<string>>.Pack(out text, list);
            return text;
        }

        public static List<KeyValuePair<string, string>> UnpackListStringString(string text)
        {
            List<KeyValuePair<string, string>> list;
            ParseHelper<List<KeyValuePair<string, string>>, ListPairStringColllection>.Parse(text, out list);
            return list;
        }

        public static string PackString(List<KeyValuePair<string, string>> list)
        {
            string text;
            PackageHelper<List<KeyValuePair<string, string>>>.Pack2(out text, list);
            return text;
        }

        //public static string PackString(SortedList<string, string> sortlist)
        //{
        //    string text;
        //    PackageHelper<SortedList<string, string>>.Pack2(out text, sortlist);
        //    return text;
        //}

        /////////////////////////////////////////

        public static Dictionary<string, string> UnpackDictionary(string text)
        {
            Dictionary<string, string> dic;
            ParseHelper<Dictionary<string, string>, DictionaryStringCollection>.Parse(text, out dic);
            return dic;
        }

        public static string PackString(Dictionary<string, string> dic)
        {
            string text;
            PackageHelper<Dictionary<string, string>>.Pack2(out text, dic);
            return text;
        }

        //////////////////////////////////////////

        private static bool Parse(string text, IParseCollection coll)
        {
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }

            int n = 0;
            StringBuilder elemCache = new StringBuilder(512);

            foreach (char ch in text)
            {
                switch (ch)
                {
                    case '\'':
                        n = quote[n];
                        break;
                    case ',':
                        n = comma[n];
                        if (n == 0)
                        {
                            coll.AddElem(elemCache.ToString());
                            elemCache.Remove(0, elemCache.Length);
                        }
                        break;
                    default:
                        n = other[n];
                        break;
                }

                if (3 == n)
                {
                    elemCache.Append(ch);
                }
                else if (n < 0)
                {
                    break;
                    //throw new ApplicationException("待分析文本的格式不正确!");
                }
            }

            if (n == 2)
            {
                coll.AddElem(elemCache.ToString());

                return true;
            }
            else if (n == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void PackageString(StringBuilder build, string str)
        {
            build.Append('\'');
            build.Append(str.Replace("'", "''"));
            build.Append('\'');

            build.Append(',');
        }

        #region Nested type: DictionaryStringCollection

        /// <summary>
        /// 字典
        /// </summary>
        private class DictionaryStringCollection : PairStringCollection<Dictionary<string, string>>
        {
            private Dictionary<string, string> dic;

            public DictionaryStringCollection()
            {
                this.dic = new Dictionary<string, string>();
            }

            /// <summary>
            /// Container
            /// </summary>
            public override Dictionary<string, string> Container
            {
                get { return this.dic; }
            }

            /// <summary>
            /// Collection
            /// </summary>
            protected override ICollection<KeyValuePair<string, string>> Collection
            {
                get { return this.dic; }
            }
        }

        #endregion

        #region Nested type: IElemCollection

        private interface IElemCollection<TContainer> : IParseCollection
        {
            TContainer Container { get; }
        }

        #endregion

        #region Nested type: IParseCollection

        private interface IParseCollection
        {
            void AddElem(string str);
            bool IsValid();
        }

        #endregion

        #region Nested type: ListPairStringColllection

        /// <summary>
        /// 双值列表集合
        /// </summary>
        private class ListPairStringColllection : PairStringCollection<List<KeyValuePair<string, string>>>
        {
            private List<KeyValuePair<string, string>> listPair;

            public ListPairStringColllection()
            {
                this.listPair = new List<KeyValuePair<string, string>>();
            }

            /// <summary>
            /// Container
            /// </summary>
            public override List<KeyValuePair<string, string>> Container
            {
                get { return this.listPair; }
            }

            protected override ICollection<KeyValuePair<string, string>> Collection
            {
                get { return this.listPair; }
            }
        }

        #endregion

        #region Nested type: ListStringCollection

        /// <summary>
        /// 单值集合类
        /// </summary>
        /// <typeparam name="TCollection">集合类类型</typeparam>
        private class ListStringCollection<TCollection> : IElemCollection<TCollection>
            where TCollection : IList, new()
        {
            private TCollection list;

            public ListStringCollection()
            {
                this.list = new TCollection();
            }

            #region IElemCollection 成员

            public void AddElem(string str)
            {
                this.list.Add(str);
            }

            public bool IsValid()
            {
                return true;
            }

            public TCollection Container
            {
                get { return this.list; }
            }

            #endregion
        }

        #endregion

        #region Nested type: PackageHelper

        private class PackageHelper<T>
            where T : ICollection
        {
            public static bool Pack(out string strPackage, T enumberator)
            {
                if (enumberator == null)
                {
                    strPackage = "";
                    return false;
                }

                StringBuilder build = new StringBuilder(1024);

                foreach (string str in enumberator)
                {
                    PackageString(build, str);
                }

                //移除最后一个逗号
                if (build.Length > 1)
                {
                    build.Remove(build.Length - 1, 1);
                }

                strPackage = build.ToString();

                return true;
            }

            public static bool Pack2(out string strPackage, IEnumerable<KeyValuePair<string, string>> enumberator)
            {
                if (enumberator == null)
                {
                    strPackage = "";
                    return false;
                }

                StringBuilder build = new StringBuilder(1024);

                foreach (KeyValuePair<string, string> pair in enumberator)
                {
                    PackageString(build, pair.Key);
                    PackageString(build, pair.Value);
                }

                //移除最后一个逗号
                if (build.Length > 1)
                {
                    build.Remove(build.Length - 1, 1);
                }

                strPackage = build.ToString();
                return true;
            }
        }

        #endregion

        #region Nested type: PairStringCollection

        /// <summary>
        /// 双值集合基类, 集合中元素用KeyValuePair<string, string>存储
        /// </summary>
        private abstract class PairStringCollection<TCollection> : IElemCollection<TCollection>
        {
            #region IElemCollection 成员

            public void AddElem(string str)
            {
                if (this.isPair)
                {
                    this.key = str;
                }
                else
                {
                    KeyValuePair<string, string> pair = new KeyValuePair<string, string>(this.key, str);
                    this.Collection.Add(pair);
                }

                this.isPair = !this.isPair;
            }

            public bool IsValid()
            {
                return this.isPair;
            }

            public abstract TCollection Container { get; }

            #endregion

            private bool isPair = true;
            private string key;
            protected abstract ICollection<KeyValuePair<string, string>> Collection { get; }
        }

        #endregion

        #region Nested type: ParseHelper

        /// <summary>
        ///分析辅助类
        /// </summary>
        /// <typeparam name="TOutCollection">out参数类型</typeparam>
        /// <typeparam name="TParseCollection">分析用的集合类型</typeparam>
        private class ParseHelper<TOutCollection, TParseCollection>
            where TParseCollection : IElemCollection<TOutCollection>, new()
        {
            public static bool Parse(string text, out TOutCollection list)
            {
                TParseCollection coll = new TParseCollection();

                bool b = SingleQuoteStringParser.Parse(text, coll);

                list = coll.Container;

                if (b) return coll.IsValid();
                return false;
            }
        }

        #endregion
    }
}
