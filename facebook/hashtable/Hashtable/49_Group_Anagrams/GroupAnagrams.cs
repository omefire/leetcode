using System;
using System.Collections.Generic;
using System.Text;

namespace _49_Group_Anagrams
{
    public class GroupAnagrams1
    {
        public static IList<IList<string>> Group(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return new List<IList<string>>();
            }
            var dict = new Dictionary<string, List<string>>();
            foreach (var s in strs)
            {
                var keyStr = s.GetHashCode().ToString();
                if (dict.ContainsKey(keyStr))
                {
                    dict[keyStr].Add(s);
                }
                else
                {
                    var l = new List<string>();
                    l.Add(s);
                    dict.Add(keyStr, l);
                }
            }

            IList<IList<string>> results = new List<IList<string>>();
            foreach (var kv in dict)
            {
                results.Add(kv.Value);
            }

            return results;
        }
    }

    public class GroupAnagrams2
    {
        // Note: This doesn't work as the strings "ibb" and "ic" have the same key: ibb == 8 + 1 + 1 = 10 and ic = 8 + 2 = 10
        public static IList<IList<string>> Group(string[] strs) {
            if (strs == null || strs.Length == 0)
            {
                return new List<IList<string>>();
            }
            var dict = new Dictionary<string, List<string>>();
            foreach (var s in strs)
            {
                // Calculate key from string
                int[] count = new int[26];
                foreach (var ch in s)
                {
                    count[ch - 'a']++;
                }
                var keyBld = new StringBuilder();
                foreach(var cnt in count) {
                    keyBld.Append("#");
                    keyBld.Append(cnt);
                }
                var key = keyBld.ToString();
                if (dict.ContainsKey(key))
                {
                    dict[key].Add(s);
                }
                else
                {
                    var l = new List<string>();
                    l.Add(s);
                    dict.Add(key, l);
                }
            }

            IList<IList<string>> results = new List<IList<string>>();
            foreach (var kv in dict)
            {
                results.Add(kv.Value);
            }

            return results;
        }
    }
}
