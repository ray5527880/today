using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery
{
    public class LotteryMath
    {
        GType GT;
        LotteryMathDao dao;
        public LotteryMath()
        {
            this.dao = new LotteryMathDao();
        }

        public int Sum(List<Number.Number_539> m539, int No)
        {
            return this.dao.sum_539(m539, No);
        }
    }
}
