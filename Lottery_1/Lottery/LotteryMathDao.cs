using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery
{
     class LotteryMathDao
    {
        public int sum_539(List<Number.Number_539> m539, int No)
        {
            int reNumber = 0;
            foreach (var item in m539)
            {
                if (item.n_1 == No)
                    reNumber++;
                else if (item.n_2 == No)
                    reNumber++;
                else if (item.n_3 == No)
                    reNumber++;
                else if (item.n_4 == No)
                    reNumber++;
                else if (item.n_5 == No)
                    reNumber++;
            }
            return reNumber;
        }
    }
}
