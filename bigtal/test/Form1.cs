using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<string> number;
        public decimal decProfit;
        public decimal decOutlay;
        public decimal decOdds = 22.3m;
        public decimal decBase = 10;
        public List<int> pu;
         
        private void Form1_Load(object sender, EventArgs e)
        {
            number = new List<string>();
            pu = new List<int>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text.Length == 5)
            {
                if (number.Count >= 5)
                {
                    count();
                }
                else
                {
                    number.Add(txtNumber.Text);
                    txtNumber.Text = "";
                }
                UpdataView();
            }
            else
            {
                MessageBox.Show("輸入錯誤");
            }
        }
        public void UpdataView()
        {
            if (number.Count >= 5)
            {

            }
            string strOut = "獎號："+"\n";

            foreach (var item in number)
            {
                strOut += item.ToString() + "\n";
            }
            label5.Text = strOut;
        }
        public void count()
        {
            if (pu.Count > 0)
            {
                int countNumber = 0;
                foreach (var item in pu)
                {
                    if (txtNumber.Text.IndexOf(item.ToString()) > -1)
                    {
                        countNumber++;
                    }
                }
                decOutlay += decBase * 4;
                if (countNumber == 3)
                    decProfit += decBase * decOdds;
                if (countNumber == 4)
                    decProfit += decBase * decOdds * 3;
                label1.Text = "支出：" + decOutlay;
                label2.Text = "獲利：" + decProfit;
            }
            
            if (number.Count >= 5)
            {
                int[] m = new int[10];
                foreach (var item in number)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if ((item.ToString()).Substring(j, 1) == i.ToString())
                            {
                                m[i]++;
                            }
                        }
                    }
                }
                pu.Clear();
                int no1 = -1;
                int no2 = -1;
                int no3 = -1;
                int no4 = -1;
                for (int j = 0; j < 4; j++)
                {
                    int max = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        if (no1 != i && no2 != i && no3 != i)
                        {
                            if (m[i] > max)
                            {
                                if (j == 0)
                                    no1 = i;
                                if (j == 1)
                                    no2 = i;
                                if (j == 2)
                                    no3 = i;
                                if (j == 3)
                                    no4 = i;
                                max = m[i];
                            }

                        }
                    }
                }
                pu.Add(no1);
                pu.Add(no2);
                pu.Add(no3);
                pu.Add(no4);
                label4.Text = "推薦下注：" + pu[0].ToString() + pu[1].ToString() + pu[2].ToString() + pu[3].ToString();
                number.RemoveAt(0);
                number.Add(txtNumber.Text);
                txtNumber.Text = "";
            }
        }
    }
}
