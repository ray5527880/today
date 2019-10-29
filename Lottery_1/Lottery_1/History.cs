using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading.Tasks;
using Lottery;
namespace Lottery_1
{
    public partial class History : UserControl
    {
        private GType _Type;

        private XML mXML;

        public List<Number.Number_539> m539 { get; set; }

        private int nSelectNo = 0;

        public History(GType _type)
        {
            InitializeComponent();
            _Type = _type;
            m539 = new List<Number.Number_539>();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            mXML = new XML();
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
            updataDGview();
        }
        private void updataDGview()
        {
            switch (_Type)
            {
                case GType.L539:
                    updataDGview_539();
                    break;
            }
        }
        private void AddData()
        {
            switch (_Type)
            {
                case GType.L539:
                    AddData_539();
                    break;
            }
        }
        private void UpData()
        {
            switch (_Type)
            {
                case GType.L539:
                    UpData_539();
                    break;
            }
        }
        private void updataDGview_539()
        {
            dgView.Rows.Clear();
            m539 = new List<Number.Number_539>();
            m539 = mXML.GetXML_539("./L539.xml");
            int count = 0;
            foreach (var item in m539.OrderByDescending(data=>data.Date))
            {
                if (count > 20)
                    break;

                string[] str = new string[] { item.Date.ToString("yyyy-MM-dd"), item.No.ToString(), item.n_1.ToString(), item.n_2.ToString(), item.n_3.ToString(), item.n_4.ToString(), item.n_5.ToString() };
                dgView.Rows.Add(str);

                count++;
            }
        }
        private void AddData_539()
        {
            Number.Number_539 m539 = new Number.Number_539();
            m539.No = Convert.ToInt32(txtNo.Text);
            m539.Date = dtpDate.Value;
            m539.n_1 = Convert.ToInt32(nud_n1.Value);
            m539.n_2 = Convert.ToInt32(nud_n2.Value);
            m539.n_3 = Convert.ToInt32(nud_n3.Value);
            m539.n_4 = Convert.ToInt32(nud_n4.Value);
            m539.n_5 = Convert.ToInt32(nud_n5.Value);
            string str = mXML.InsertData_539(m539, "./L539.xml") == StatusType.Ok ? "成功" : "失敗";
            MessageBox.Show(str);
        }
        private void UpData_539()
        {
            Number.Number_539 m539 = new Number.Number_539();
            m539.No = Convert.ToInt32(txtNo.Text);
            m539.Date = dtpDate.Value;
            m539.n_1 = Convert.ToInt32(nud_n1.Value);
            m539.n_2 = Convert.ToInt32(nud_n2.Value);
            m539.n_3 = Convert.ToInt32(nud_n3.Value);
            m539.n_4 = Convert.ToInt32(nud_n4.Value);
            m539.n_5 = Convert.ToInt32(nud_n5.Value);
            string str = mXML.UpData_539(m539, nSelectNo, "./L539.xml") == StatusType.Ok ? "成功" : "失敗";
            MessageBox.Show(str);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddData(); 
            updataDGview();
            button2.Enabled = false;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            UpData();
            updataDGview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            if (this.openExcelFile.ShowDialog() != DialogResult.OK)
            {
                (sender as Button).Enabled = true;
                return;
            }

            var _ImportExcel = new ImPortExcel(_Type);
            Task.Factory.StartNew(() => { _ImportExcel.Load(this.openExcelFile.FileName); })
                .ContinueWith(antecedent =>
                {
                    _ImportExcel.Insert(mXML);
                })
                .ContinueWith(antecedent =>
                {
                    (sender as Button).Enabled = true;
                });

            this.Enabled = false;
        }

        private void dgView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgView.Rows[e.RowIndex].Cells[0].Value == null)
                return;
            nSelectNo = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells[1].Value);
            dtpDate.Value = Convert.ToDateTime(dgView.Rows[e.RowIndex].Cells[0].Value);
            txtNo.Text = dgView.Rows[e.RowIndex].Cells[1].Value.ToString();
            nud_n1.Value = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells[2].Value);
            nud_n2.Value = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells[3].Value);
            nud_n3.Value = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells[4].Value);
            nud_n4.Value = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells[5].Value);
            nud_n5.Value = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells[6].Value);
            button2.Enabled = true;
        }
    }
}
