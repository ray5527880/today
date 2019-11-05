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
        public List<NumberStruct.EndNumber> GetEndNumber(List<Number.Number_539> m539)
        {
            List<NumberStruct.EndNumber> endList = new List<NumberStruct.EndNumber>();
            for (int i = 1; i < 10; i++)
            {
                NumberStruct.EndNumber _endNumber = new NumberStruct.EndNumber();
                _endNumber.No = i;
                foreach (var item in m539)
                {
                    if (item.n_1 % 10 == i)
                        _endNumber.count++;
                    else if (item.n_2 % 10 == i)
                        _endNumber.count++;
                    else if (item.n_3 % 10 == i)
                        _endNumber.count++;
                    else if (item.n_4 % 10 == i)
                        _endNumber.count++;
                    else if (item.n_5 % 10 == i)
                        _endNumber.count++;
                }
                endList.Add(_endNumber);
            }
            return endList;
        }
        public List<Number.Number_539> GetTOPList(List<Number.Number_539> m539, int limit)
        {
            int count = 0;
            List<Number.Number_539> _539 = new List<Number.Number_539>();
            foreach (var item in m539.OrderByDescending(e=>e.Date))
            {
                _539.Add(item);
                count++;
                if (count == limit)
                    break;                
            }
            return _539;
        }
        public List<Number.Number_539> GetTOPList(List<Number.Number_539> m539,int EndNo, int limit)
        {
            int count = 0;
            List<Number.Number_539> _539 = new List<Number.Number_539>();
            foreach (var item in m539.Where(e=>e.No<=EndNo).OrderByDescending(e => e.Date))
            {
                _539.Add(item);
                count++;
                if (count == limit)
                    break;
            }
            return _539;
        }
        public List<NumberStruct.EndNumber> GetCountList(List<Number.Number_539> m539)
        {
            List<NumberStruct.EndNumber> list = new List<NumberStruct.EndNumber>();

            for (int i = 0; i < 39; i++)
            {
                var _list = new NumberStruct.EndNumber();
                _list.No = i + 1;
                _list.count = 0;
                foreach (var item in m539)
                {
                    if (item.n_1 == i + 1)
                        _list.count++;
                    if (item.n_2 == i + 1)
                        _list.count++;
                    if (item.n_3 == i + 1)
                        _list.count++;
                    if (item.n_4 == i + 1)
                        _list.count++;
                    if (item.n_5 == i + 1)
                        _list.count++;
                }
                list.Add(_list);
            }

            return list;
        }
    }
}
