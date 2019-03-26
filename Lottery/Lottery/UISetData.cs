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
                string[] str = new string[] {item.Date,item.Period.ToString(),String.Format("{0:00}", item.No1),String.Format("{0:00}", item.No2),
                    String.Format("{0:00}", item.No3),String.Format("{0:00}", item.No4),String.Format("{0:00}", item.No5) };
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
                if (NunberCheck(textBox2.Text) && NunberCheck(textBox3.Text) && NunberCheck(textBox4.Text) && NunberCheck(textBox4.Text) && NunberCheck(textBox5.Text) && NunberCheck(textBox6.Text))
                {
                    var _ToDay = new EditXml.Today
                    {
                        Date = dateTimePicker1.Text,
                        Period = Convert.ToInt32(textBox1.Text),
                        No1 = Convert.ToInt32(textBox2.Text),
                        No2 = Convert.ToInt32(textBox3.Text),
                        No3 = Convert.ToInt32(textBox4.Text),
                        No4 = Convert.ToInt32(textBox5.Text),
                        No5 = Convert.ToInt32(textBox6.Text)
                    };
                    EditXml.mToday.Add(_ToDay);
                }
            }
            SetDGView();
        }
        private bool NunberCheck(string _NO)
        {
            if (!Regex.IsMatch(_NO, "^[0-9]{2,}$"))
                return false;
            if (Convert.ToInt32(_NO) < 0)
                return false;
            if (Convert.ToInt32(_NO) > 40)
                return false;
            return true;
        }
    }
}
