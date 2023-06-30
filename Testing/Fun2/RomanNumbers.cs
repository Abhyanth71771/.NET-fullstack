using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RomanNumbers
    {
        public int RomanToNumber(string roman)
        {
            Dictionary<char, int> map = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };
            if (roman.Length > 0)
            {
                for(int v=0;v<roman.Length;v++)
                {
                    if()
                }
            }
        }
    }
}
