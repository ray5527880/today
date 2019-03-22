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
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            EditXml editXml = new EditXml();
            editXml.GetData();
            foreach(var item in EditXml.mToday)
            {
                Console.Write("");
            }
            Console.Write("");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new UISetData();
            panel1.Controls.Add(frm);
        }
    }
}
