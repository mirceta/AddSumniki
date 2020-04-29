using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AddSumniki
{
    public class DictionaryFactory
    {
        public static HashSet<string> ParseDictionary()
        {
            HttpClient cl = new HttpClient();
            var h = cl.GetAsync("http://bos.zrc-sazu.si/sbsj.html").GetAwaiter().GetResult();
            string content = h.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            HashSet<string> hs = new HashSet<string>();

            int curridx = content.IndexOf("</center>") + "</center>".Length;

            do
            {
                int next = content.IndexOf("<br>", curridx);
                string curr = content.Substring(curridx, next - curridx).Replace("\r", "").Replace("\n", "");
                if (SumnikTools.ContainsSumnik(curr)) {
                    hs.Add(curr);
                    if (curr.Length > 5) {
                        hs.Add(curr.Substring(0, curr.Length - 1));
                        hs.Add(curr.Substring(0, curr.Length - 2));
                        hs.Add(curr.Substring(0, curr.Length - 3));
                    }
                }
                curridx = next + "<br>".Length;
            } while (content.IndexOf("<br>", curridx) != -1);

            return hs;
        }
    }
}
