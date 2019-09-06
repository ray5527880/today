using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lottery;

namespace Lottery_1
{
    public partial class Lottery : Form
    {
        public struct test
        {
            public int no;
            public int no1;
            public int no2;
        }

        public List<Number.Number_539> m539 = new List<Number.Number_539>();

        public string userName = string.Empty;

        public Lottery()
        {
            InitializeComponent();
        }



        private void Lottery_Load(object sender, EventArgs e)
        {
            XML _xml = new XML();
            m539 = _xml.GetXML_539("./L539.xml");


            List<test> t = new List<test>();
            for (int i = 1; i < 5; i++)
            {
                var tt = new test();
                tt.no = i;
                tt.no1 = i * 1;
                tt.no2 = i + i;
                t.Add(tt);
            }
            var x = from data in t
                    orderby data.no descending
                    select data;

            
            var item = x.GetEnumerator();
            while (item.MoveNext())
            {
                //item.Current.no;
            }
            int s = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdoL539.Checked)
            {
                var frm = new History(GType.L539);
                frm.m539 = m539;
                if (userName != string.Empty)
                {
                    this.Controls.RemoveByKey(userName);                    
                    userName = frm.Name;
                }
                this.Controls.Add(frm);
                frm.Location = new Point(10, 80);                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rdoL539.Checked)
            {
                var frm = new History(GType.L539);
                if (userName != string.Empty)
                {
                    this.Controls.RemoveByKey(userName);
                    frm.m539 = m539;
                    userName = frm.Name;
                }

                frm.Location = new Point(10, 80);
            }
        }
    }
}
