using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                string[] str = new string[] {item.Date,item.Period.ToString(),item.No1.ToString(),item.No2.ToString(),
                    item.No3.ToString(),item.No4.ToString(),item.No5.ToString() };
                DGView.Rows.Add(str);

                count++;
            }
            DGView.ReadOnly = true;
            
        }

        private void SetEnable_ADD()
        {
            DGView.Enabled = false;
        }
    }
}
