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
    public partial class History : UserControl
    {
        private GType _Type;

        public History(GType _type)
        {
            InitializeComponent();
            _Type = _type;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            if (_Type == GType.L539)
            {
                SetL539View();
            }
        }

        private void SetL539View()
        {
            dgView.ColumnCount = 7;
            dgView.Columns[0].Name = "日期";
            dgView.Columns[1].Name = "期數";
            dgView.Columns[2].Name = "獎號1";
            dgView.Columns[3].Name = "獎號2";
            dgView.Columns[4].Name = "獎號3";
            dgView.Columns[5].Name = "獎號4";
            dgView.Columns[6].Name = "獎號5";
            dgView.Columns[0].Width = 100;
            dgView.Columns[1].Width = 90;
            dgView.Columns[2].Width = 70;
            dgView.Columns[3].Width = 70;
            dgView.Columns[4].Width = 70;
            dgView.Columns[5].Width = 70;
            dgView.Columns[6].Width = 70;
            dgView.Width = 600;
            dgView.Height = 290;
        }
    }
}
