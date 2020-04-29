using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddSumniki
{
    class SumnikTools
    {
        public static char toSumnik(char a)
        {
            if (a == 'z')
            {
                return 'ž';
            }
            else if (a == 's')
            {
                return 'š';
            }
            else if (a == 'c')
            {
                return 'č';
            }
            return a;
        }

        public static char toSicnik(char a)
        {
            if (a == 'ž')
            {
                return 'z';
            }
            else if (a == 'š')
            {
                return 's';
            }
            else if (a == 'č')
            {
                return 'c';
            }
            return a;
        }

        public static bool isSumnik(char a)
        {
            var set = new[] { 'č', 'ž', 'š' }.ToHashSet();
            return set.Contains(a);
        }

        public static bool isSicnik(char a)
        {
            var set = new[] { 'c', 's', 'z' }.ToHashSet();
            return set.Contains(a);
        }

        public static bool isSumnikable(char a)
        {
            var set = new[] { 'c', 's', 'z', 'č', 'ž', 'š' }.ToHashSet();
            return set.Contains(a);
        }

        public static bool ContainsSumnik(string str) {
            return str.Where(x => isSumnik(x)).Count() > 0;
        }
    }
}
