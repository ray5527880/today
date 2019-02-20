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
            comboBox1.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            if (rdoRevise.Checked)
            {
                SelectType = 0;
            }
            else if (rdoSearch.Checked)
            {
                SelectType = 1;
            }
            else if (rdoPrediction.Checked)
            {
                SelectType = 2;
            }
                else if (rdoPrediction2.Checked)
            {
                SelectType = 3;
            }
             else if (radioButton1.Checked)
             {
                 SelectType = 4;
             }
            switch (SelectType)
                {
                    case 0:

                        Revise frmRevise = new Revise(SelectGame);
                        panel1.Controls.Add(frmRevise);
                        break;
                    case 1:
                        Search frmSearch = new Search();
                        panel1.Controls.Add(frmSearch);
                        break;
                    case 2:
                        Prediction frmPrediction = new Prediction(SelectGame);
                        panel1.Controls.Add(frmPrediction);
                        break;
                    case 3:
                        Prediction2 frmPrediction2 = new Prediction2();
                        panel1.Controls.Add(frmPrediction2);
                        break;
                    case 4:
                        SplitGraph frmSplitGraph = new SplitGraph();
                        panel1.Controls.Add(frmSplitGraph);
                        break;
                }            
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                SelectGame = 0;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                SelectGame = 1;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                SelectGame = 2;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                SelectGame = 3;
            }
            if (comboBox1.SelectedIndex == 4)
            {
                SelectGame = 4;
            }
        }
    }
}
