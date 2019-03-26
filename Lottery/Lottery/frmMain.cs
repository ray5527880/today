using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    public partial class frmMain : Form
    {
        EditXml editXml;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            editXml = new EditXml();
            editXml.GetData();
            EditXml.mToday.Sort((x, y) => { return -x.Period.CompareTo(y.Period); });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new UISetData();
            panel1.Controls.Add(frm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] x = new int[39, 39];
            for (int _index = 1; _index <= 100; _index++)
            {
                x[EditXml.mToday[_index].No1 - 1, EditXml.mToday[_index - 1].No1 - 1]++;
                x[EditXml.mToday[_index].No1 - 1, EditXml.mToday[_index - 1].No2 - 1]++;
                x[EditXml.mToday[_index].No1 - 1, EditXml.mToday[_index - 1].No3 - 1]++;
                x[EditXml.mToday[_index].No1 - 1, EditXml.mToday[_index - 1].No4 - 1]++;
                x[EditXml.mToday[_index].No1 - 1, EditXml.mToday[_index - 1].No5 - 1]++;
                x[EditXml.mToday[_index].No2 - 1, EditXml.mToday[_index - 1].No1 - 1]++;
                x[EditXml.mToday[_index].No2 - 1, EditXml.mToday[_index - 1].No2 - 1]++;
                x[EditXml.mToday[_index].No2 - 1, EditXml.mToday[_index - 1].No3 - 1]++;
                x[EditXml.mToday[_index].No2 - 1, EditXml.mToday[_index - 1].No4 - 1]++;
                x[EditXml.mToday[_index].No2 - 1, EditXml.mToday[_index - 1].No5 - 1]++;
                x[EditXml.mToday[_index].No3 - 1, EditXml.mToday[_index - 1].No1 - 1]++;
                x[EditXml.mToday[_index].No3 - 1, EditXml.mToday[_index - 1].No2 - 1]++;
                x[EditXml.mToday[_index].No3 - 1, EditXml.mToday[_index - 1].No3 - 1]++;
                x[EditXml.mToday[_index].No3 - 1, EditXml.mToday[_index - 1].No4 - 1]++;
                x[EditXml.mToday[_index].No3 - 1, EditXml.mToday[_index - 1].No5 - 1]++;
                x[EditXml.mToday[_index].No4 - 1, EditXml.mToday[_index - 1].No1 - 1]++;
                x[EditXml.mToday[_index].No4 - 1, EditXml.mToday[_index - 1].No2 - 1]++;
                x[EditXml.mToday[_index].No4 - 1, EditXml.mToday[_index - 1].No3 - 1]++;
                x[EditXml.mToday[_index].No4 - 1, EditXml.mToday[_index - 1].No4 - 1]++;
                x[EditXml.mToday[_index].No4 - 1, EditXml.mToday[_index - 1].No5 - 1]++;
                x[EditXml.mToday[_index].No5 - 1, EditXml.mToday[_index - 1].No1 - 1]++;
                x[EditXml.mToday[_index].No5 - 1, EditXml.mToday[_index - 1].No2 - 1]++;
                x[EditXml.mToday[_index].No5 - 1, EditXml.mToday[_index - 1].No3 - 1]++;
                x[EditXml.mToday[_index].No5 - 1, EditXml.mToday[_index - 1].No4 - 1]++;
                x[EditXml.mToday[_index].No5 - 1, EditXml.mToday[_index - 1].No5 - 1]++;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            editXml.SetData();
        }
    }
}
