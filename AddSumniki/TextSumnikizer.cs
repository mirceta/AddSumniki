using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace AddSumniki
{
    class TextSumnikizer
    {

        HashSet<string> dic;

        public TextSumnikizer() {
            dic = DictionaryFactory.ParseDictionary();
        }
        
        public string Rectify(string input) {
            string output = "";
            input = widenPunctuation(input);
            string[] words = input.Split(" ")
                                  .Select(x => RectifyWord(x))
                                  .ToArray();
            output = string.Join(" ", words);
            output = narrowDownPunctuation(output);
            return output;
        }

        string RectifyWord(string word) {
            WordSumnikizer wsum = new WordSumnikizer(dic);
            string ret = wsum.Rectify(word);
            if (ret != null)
                return ret;

            for (int i = 1; i < word.Length / 2; i++) {
                ret = word.Substring(0, word.Length - i);
                ret = wsum.Rectify(ret);
                if (ret != null)
                    return ret + word.Substring(word.Length - i);
            }

            return word;
        }

        string widenPunctuation(string input)
        {
            return input.Replace(".", " . ")
                        .Replace(",", " , ")
                        .Replace("!", " ! ")
                        .Replace("?", " ? ");
        }

        string narrowDownPunctuation(string input)
        {
            return input.Replace(" . ", ".")
                        .Replace(" , ", ",")
                        .Replace(" ! ", "!")
                        .Replace(" ? ", "?");
        }
    }
}
