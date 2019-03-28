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
                for(int i = 0; i < 5; i++)
                {
                    for (int ii = 0; ii < 5; ii++)
                    {
                        x[EditXml.mToday[_index].No[i] - 1, EditXml.mToday[_index - 1].No[ii] - 1]++;
                    }
                }                
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            editXml.SetData();
        }
    }
}
