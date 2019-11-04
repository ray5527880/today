﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery
{
    public class LotteryMath
    {
        GType GT;
        private LotteryMathDao dao;
        public LotteryMath()
        {
            this.dao = new LotteryMathDao();
        }

        public int Sum(List<Number.Number_539> m539, int No)
        {
            return this.dao.sum_539(m539, No);
        }
        public List<NumberStruct.EndNumber> GetEndNumber(List<Number.Number_539> m539)
        {
            return this.dao.GetEndNumber(m539);
        }
        public List<Number.Number_539> GetTOPList(List<Number.Number_539> m539, int limet)
        {
            return this.dao.GetTOPList(m539, limet);
        }
        public List<Number.Number_539> GetTOPList(List<Number.Number_539> m539, int endNo,int limet)
        {
            return this.dao.GetTOPList(m539,endNo, limet);
        }
    }
}