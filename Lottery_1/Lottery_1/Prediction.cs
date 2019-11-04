using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Lottery;

namespace Lottery_1
{
    public partial class Prediction : UserControl
    {
        private GType _Type;
        private List<Number.Number_539> List539;
        private LotteryMath LMath;
        private int maxNo = 0;
        private struct L539
        {
            public int count {get;set;}
            public int no;
        }
        public Prediction(GType gType)
        {
            _Type = gType;
            InitializeComponent();
        }

        private void Prediction_Load(object sender, EventArgs e)
        {
            if (_Type == GType.L539)
            {
                var mXML = new XML();
                List539 = new List<Number.Number_539>();
                List539 = mXML.GetXML_539("./L539.xml");
                LMath = new LotteryMath();
                label4.Text = "";
            }
            maxNo = List539.Max(ee => ee.No);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = " 說明：";
            //for (int i = 0; i < 4; i++)
            //{
            //    EndNumber(maxNo - 6 * i);
            //}
            EndNumber(maxNo-18);
        }
        private void EndNumber(int limetNo)
        {
            var _list539 = List539.Where(e => e.No <= limetNo);
            var list100 = LMath.GetTOPList(List539, limetNo, 100);
            var list20 = LMath.GetTOPList(List539, limetNo, 20);
            var endnumber = LMath.GetEndNumber(list100);
            string str = string.Empty;
            int max1 = 0;
            int max2 = 0;
            foreach (var item in endnumber.OrderByDescending(e=>e.count))
            {
                str += item.No + "：" + item.count+"  ";
                if (max1 == 0)
                    max1 = item.No;
                else if (max2 == 0)
                    max2 = item.No;
            }
            label2.Text = str;
            
            List<L539> list539 = new List<L539>();

            for (int i = 0; i < 39; i++) 
            {
                L539 _539 = new L539();
                _539.no = i + 1;
                int c = 0;
                foreach (var item in list20)
                {
                    if (item.n_1 % 10 == max1 && item.n_1 == i + 1)
                    {
                        c++;
                    }
                    else if (item.n_2 % 10 == max1 && item.n_2 == i + 1)
                    {
                        c++;
                    }
                    else if (item.n_3 % 10 == max1 && item.n_3 == i + 1)
                    {
                        c++;
                    }
                    else if (item.n_4 % 10 == max1 && item.n_4 == i + 1)
                    {
                        c++;
                    }
                    else if (item.n_5 % 10 == max1 && item.n_5 == i + 1)
                    {
                        c++;
                    }
                    if (item.n_1 % 10 == max2 && item.n_1 == i + 1)
                    {
                        c++;
                    }
                    else if (item.n_2 % 10 == max2 && item.n_2 == i + 1)
                    {
                        c++;
                    }
                    else if (item.n_3 % 10 == max2 && item.n_3 == i + 1)
                    {
                        c++;
                    }
                    else if (item.n_4 % 10 == max2 && item.n_4 == i + 1)
                    {
                        c++;
                    }
                    else if (item.n_5 % 10 == max2 && item.n_5 == i + 1)
                    {
                        c++;
                    }
                }
                _539.count = c;
                list539.Add(_539);
            }
            var itttt = list539.OrderByDescending(e => e.count);
            string strlable = string.Empty;
            int c2 = 0;
            foreach(var item in itttt)
            {
                strlable += item.no.ToString() + " ";
                c2++;
                if (c2 == 4)
                    break;
            }
            label3.Text = strlable;
        }
    }
}
