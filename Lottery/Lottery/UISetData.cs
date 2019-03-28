using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Lottery
{
    public partial class UISetData : UserControl
    {
        public UISetData()
        {
            InitializeComponent();
        }

        private void UISetData_Load(object sender, EventArgs e)
        {
            
            DGView.ColumnCount = 7;
            DGView.Columns[0].Name = "日期";
            DGView.Columns[1].Name = "期數";
            DGView.Columns[2].Name = "號碼一";
            DGView.Columns[3].Name = "號碼二";
            DGView.Columns[4].Name = "號碼三";
            DGView.Columns[5].Name = "號碼四";
            DGView.Columns[6].Name = "號碼五";
            DGView.Columns[0].Width = 150;
            DGView.Columns[1].Width = 100;
            for (int i = 2; i < 7; i++)
            {
                DGView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            DGView.ReadOnly = true;
            SetDGView();
        }

        private void DGView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void SetDGView()
        {            
            DGView.Rows.Clear();

            EditXml.mToday.Sort((x, y)=>{ return -x.Period.CompareTo(y.Period); });

            int count = 0;
            foreach (var item in EditXml.mToday )
            {
                if (count > 20)
                    return;
                string[] str = new string[] {item.Date,item.Period.ToString(),String.Format("{0:00}", item.No[0]),String.Format("{0:00}", item.No[1]),
                    String.Format("{0:00}", item.No[2]),String.Format("{0:00}", item.No[3]),String.Format("{0:00}", item.No[4]) };
                DGView.Rows.Add(str);
                count++;
            }
            DGView.ReadOnly = true;            
        }

        private void SetEnable_ADD()
        {
            DGView.Enabled = false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var Date = dateTimePicker1.Value.Year + string.Format("{0:00}", dateTimePicker1.Value.Month)
                + string.Format("{0:00}", dateTimePicker1.Value.Day);
            if (Regex.IsMatch(textBox1.Text, "^[0-9]{6,}$"))
            {
                var _ToDay = new EditXml.Today
                {
                    Date = Date,
                    Period = Convert.ToInt32(textBox1.Text),
                    No = new int[]
                    {
                        Convert.ToInt32(textBox2.Text),
                        Convert.ToInt32(textBox3.Text),
                        Convert.ToInt32(textBox4.Text),
                        Convert.ToInt32(textBox5.Text),
                        Convert.ToInt32(textBox6.Text)
                    }
                };
                EditXml.mToday.Add(_ToDay);
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
            }
            SetDGView();
        }
    }
}
