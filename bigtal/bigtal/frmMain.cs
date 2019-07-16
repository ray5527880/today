using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bigtal
{
    public partial class frmMain : Form
    {        
        public int SelectType = 0;
        public int SelectGame = 0;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            if (rdoRevise.Checked)
            {
                Revise frmRevise = new Revise();
                panel1.Controls.Add(frmRevise);
            }
            else if (rdoSearch.Checked)
            {
                Search frmSearch = new Search();
                panel1.Controls.Add(frmSearch);
            }
            else if (rdoPrediction.Checked)
            {
                Prediction frmPrediction = new Prediction(SelectGame);
                panel1.Controls.Add(frmPrediction);
            }
            else if (rdoPrediction2.Checked)
            {
                Prediction2 frmPrediction2 = new Prediction2();
                panel1.Controls.Add(frmPrediction2);
            }
            else if (radioButton1.Checked)
            {
                SplitGraph frmSplitGraph = new SplitGraph();
                panel1.Controls.Add(frmSplitGraph);
            }
        }
    }
}
