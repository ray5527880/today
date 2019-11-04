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
    public partial class Fall : UserControl
    {
        private GType _Type;
        private List<Number.Number_539> List539;
        private LotteryMath LMath;

        public Fall(GType gType)
        {
            _Type = gType;
            InitializeComponent();
        }

        private void Fall_Load(object sender, EventArgs e)
        {
            if (_Type == GType.L539)
            {
                var mXML = new XML();
                List539 = new List<Number.Number_539>();
                List539 = mXML.GetXML_539("./L539.xml");
                LMath = new LotteryMath();
                SetL539View();
            }        
        }
        private void SetL539View()
        {
            dataGridView1.ColumnCount = 40;
            dataGridView1.Columns[0].Name = "期數";
            for (int i = 0; i < 39; i++)
            {
                dataGridView1.Columns[i + 1].Name = (i + 1).ToString("00");
                dataGridView1.Columns[i + 1].Width = 30;
            }
            //dataGridView1.Width = 600;
            dataGridView1.Height = 330;
        }
        private void updataDGview_539(List<Number.Number_539> m539)
        {
            dataGridView1.Rows.Clear();
            int count = 0;
            foreach (var item in m539.OrderBy(e=>e.Date))
            {
                string[] str = new string[40];
                str[0] = item.No.ToString();
                str[item.n_1] = item.n_1.ToString("00");
                str[item.n_2] = item.n_2.ToString("00");
                str[item.n_3] = item.n_3.ToString("00");
                str[item.n_4] = item.n_4.ToString("00");
                str[item.n_5] = item.n_5.ToString("00");
                dataGridView1.Rows.Add(str);
                dataGridView1.Rows[count].Cells[item.n_1].Style.BackColor = Color.Yellow;
                dataGridView1.Rows[count].Cells[item.n_2].Style.BackColor = Color.Yellow;
                dataGridView1.Rows[count].Cells[item.n_3].Style.BackColor = Color.Yellow;
                dataGridView1.Rows[count].Cells[item.n_4].Style.BackColor = Color.Yellow;
                dataGridView1.Rows[count].Cells[item.n_5].Style.BackColor = Color.Yellow;
                count++;
            }
            string[] _str = new string[40];
            _str[0] = "合計";
            for (int i = 1; i < 40; i++)
            {
                _str[i] = (LMath.Sum(m539, i)).ToString("00") ;
            }
            dataGridView1.Rows.Add(_str);
            dataGridView1.Rows[count].Cells[0].Style.BackColor = Color.GreenYellow;
            for (int i = 1; i < 40; i++)
            {                
                if (Convert.ToInt32(dataGridView1.Rows[count].Cells[i].Value) > 3)
                    dataGridView1.Rows[count].Cells[i].Style.BackColor = Color.OrangeRed;
                else
                    dataGridView1.Rows[count].Cells[i].Style.BackColor = Color.GreenYellow;
            }
            
        }
        private int sum_539(List<Number.Number_539> m539, int No)
        {
            int reNumber = 0;

            return reNumber;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (_Type)
            {
                case GType.L539:
                    View_539(20);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (_Type)
            {
                case GType.L539:
                    View_539(30);
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (_Type)
            {
                case GType.L539:
                    View_539(50);
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (_Type)
            {
                case GType.L539:
                    View_539(dateTimePicker1.Value, Convert.ToInt32(numericUpDown1.Value));
                    break;
            }
        }

        private void View_539(int limet)
        {
            int count = 0;
            var _539 = new List<Number.Number_539>();
            foreach (var item in List539.OrderByDescending(e => e.Date))
            {
                _539.Add(item);
                count++;
                if (count == limet)                   
                    break;
            }
            updataDGview_539(_539);
        }
        private void View_539(DateTime time, int limet)
        {
            int count = 0;
            var _539 = new List<Number.Number_539>();
            foreach (var item in List539.Where(e => e.Date <= time).OrderByDescending(e => e.Date))
            {
                _539.Add(item);
                count++;
                if (count == limet)
                    break;
            }
            updataDGview_539(_539);
        }
    }
}
