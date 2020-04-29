using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddSumniki
{
    class WordSumnikizer
    {

        HashSet<string> dic;

        public WordSumnikizer(HashSet<string> dictionary) {
            dic = dictionary;
        }

        public string Rectify(string word)
        {
            string curr = word;
            while (curr != null)
            {
                if (dic.Contains(curr))
                {
                    Console.WriteLine(curr + " is contained!");
                    return curr;
                }
                curr = NextCandidate(curr);
            }
            return null;
        }

        string NextCandidate(string some)
        {
            StringBuilder result = new StringBuilder(some);
            var indices = some
                .Select((x, i) => new { x = x, i = i })
                .Where(x => SumnikTools.isSumnikable(x.x))
                .ToArray();

            string binary = string.Join("", 
                            indices.Select(x => SumnikTools.isSumnik(x.x) ? "1" : "0")
                                   .ToArray());
            if (binary.IndexOf("0") == -1)
                return null; // the highest one is already achieved!
            string tmp = new string(binary.ToString().Reverse().ToArray());
            int newval = Convert.ToInt32(tmp, 2) + 1;
            string binary_next = Convert.ToString(newval, 2);
            binary_next = Enumerable.Range(0, indices.Length - binary_next.Length)
                                    .Aggregate("", (x, y) => x + "0") + binary_next;
            binary_next = new string(binary_next.Reverse().ToArray());

            binary_next.Zip(indices, (n, x) =>
            {
                if (n == '1')
                {
                    result[x.i] = SumnikTools.toSumnik(x.x);
                }
                else
                {
                    result[x.i] = SumnikTools.toSicnik(x.x);
                }
                return "";
            }).ToArray();

            return result.ToString();
        }
    }
}
