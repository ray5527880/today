using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Lottery;

namespace Lottery_1
{
    public partial class Prediction : UserControl
    {
        private GType _Type;
        private List<Number.Number_539> List539;
        private LotteryMath LMath;
        private int maxNo = 0;
        private int ccc = 0;
        //private struct L539
        //{
        //    public int count {get;set;}
        //    public int no = 0;
        //}
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
            label4.Text = " 說明：" + (maxNo - ccc).ToString();
            //for (int i = 0; i < 4; i++)
            //{
            //    EndNumber(maxNo - 6 * i);
            //}
            EndNumber(maxNo-ccc);
            ccc++;
        }
        private void EndNumber(int limetNo)
        {
            var _list539 = List539.Where(e => e.No <= limetNo);
            var list100 = LMath.GetTOPList(List539, limetNo, 100);
            var list20 = LMath.GetTOPList(List539, limetNo, 20);
            var list10 = LMath.GetTOPList(List539, limetNo, 10);
            var endnumber = LMath.GetEndNumber(list100);
            string str = string.Empty;
            int max1 = 0;
            int max2 = 0;
            //foreach (var item in endnumber.OrderByDescending(e=>e.count))
            //{
            //    //str += item.No + "：" + item.count+"  ";
            //    if (max1 == 0)
            //        max1 = item.No;
            //    else if (max2 == 0)
            //        max2 = item.No;
            //}
           
            //List<L539> list539 = new List<L539>();
            int count = 0;
            label3.Text =" ";
            foreach (var item in (LMath.GetCountList(list100)).OrderByDescending(e=>e.count))
            {
                label3.Text += " " + item.No + " ";
                count++;
                if (count == 6)
                    break;
            }
            label5.Text = " ";
            count = 0;
            foreach (var item in (LMath.GetCountList(list10)).Where(e=>e.count>1).OrderByDescending(e => e.count))
            {
                count++;
                label5.Text += " " + item.No + " ";
            }
            label6.Text = " ";
            count = 0;
            foreach (var item in LMath.GetNextNumber(list100,list100.ElementAt(0)).OrderByDescending(e=>e.count))
            {
                count++;
                label6.Text += " " + item.No + " ";
                if (count == 6)
                    break;
            }
            label7.Text = "";
            for (int i = 1; i < 40; i++)
            {
                bool t1 = false;
                bool t2 = false;
                bool t3 = false;
                if (label3.Text.IndexOf(" " + i.ToString() + " ") > 0)
                    t1 = true;
                if (label5.Text.IndexOf(" " + i.ToString() + " ") > 0)
                    t2 = true;
                if (label6.Text.IndexOf(" " + i.ToString() + " ") > 0)
                    t3 = true;
                if (t1 && t2 && t3)
                    label7.Text += i.ToString() + " , ";
            }

            if (ccc > 0)
            {
                string st1, st2, st3;
                st1 = st2 = st3 = string.Empty;
                label2.Text = "";
                foreach (var item in List539.Where(e => e.No == maxNo - ccc + 1))
                {
                    label2.Text = " " + item.n_1 + " " + " " + item.n_2 + " " + " " + item.n_3 + " " + " " + item.n_4 + " " + " " + item.n_5 + " ";
                    label8.Text = ch(label3.Text, item);
                    label9.Text = ch(label5.Text, item);
                    label10.Text = ch(label6.Text, item);
                }                    
            }
            count=1;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            foreach (var item in list20.OrderBy(e => e.No))
            {
                int sum = item.n_1 + item.n_2 + item.n_3 + item.n_4 + item.n_5;
                chart1.Series[0].Points.AddXY(count, sum);

                var _list10 = LMath.GetTOPList(List539, limetNo - 11 + count, 10);

                chart1.Series[1].Points.AddXY(count, GetAVG(_list10));
                chart1.Series[2].Points.AddXY(count, GetAVGUP(_list10));
                chart1.Series[3].Points.AddXY(count, GetAVGDOWN(_list10));

                count++;



                //chart1.Series[0].ChartType=SeriesChartType.Line
            }
        }

        private double GetAVG(List<Number.Number_539> m539)
        {
            double reDoub = 0;

            int sum = 0;
            foreach (var item in m539)
            {
                sum += item.n_1 + item.n_2 + item.n_3 + item.n_4 + item.n_5;
            }
            reDoub = sum / 10;

            return reDoub;
        }
        private double GetAVGUP(List<Number.Number_539> m539)
        {
            double reDoub = 0;

            int sum = 0;
            foreach (var item in m539)
            {
                sum += item.n_1 + item.n_2 + item.n_3 + item.n_4 + item.n_5;
            }
            reDoub = sum / 10;

            double dou = 0;
            foreach (var item in m539)
            {
                dou += Math.Pow((item.n_1 + item.n_2 + item.n_3 + item.n_4 + item.n_5 - reDoub), 2);
            }
            dou = dou / 10;
            dou = Math.Sqrt(dou);
            reDoub += dou * 2;

            return reDoub;
        }
        private double GetAVGDOWN(List<Number.Number_539> m539)
        {
            double reDoub = 0;

            int sum = 0;
            foreach (var item in m539)
            {
                sum += item.n_1 + item.n_2 + item.n_3 + item.n_4 + item.n_5;
            }
            reDoub = sum / 10;

            double dou = 0;
            foreach (var item in m539)
            {
                dou += Math.Pow((item.n_1 + item.n_2 + item.n_3 + item.n_4 + item.n_5 - reDoub), 2);
            }
            dou = dou / 10;
            dou = Math.Sqrt(dou);
            reDoub -= dou * 2;

            return reDoub;
        }
        private string ch(string number, Number.Number_539 nowNumber)
        {
            string reStr = string.Empty;

            if (number.IndexOf(" " + nowNumber.n_1 + " ") > 0)
                reStr += nowNumber.n_1 + ",";
            if (number.IndexOf(" " + nowNumber.n_2 + " ") > 0)
                reStr += nowNumber.n_2 + ",";
            if (number.IndexOf(" " + nowNumber.n_3 + " ") > 0)
                reStr += nowNumber.n_3 + ",";
            if (number.IndexOf(" " + nowNumber.n_4 + " ") > 0)
                reStr += nowNumber.n_4 + ",";
            if (number.IndexOf(" " + nowNumber.n_5 + " ") > 0)
                reStr += nowNumber.n_5 + ",";

            return reStr;
        }
    }
}
