using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bigtal
{
    public partial class SplitGraph : UserControl
    {
        public SplitGraph()
        {
            InitializeComponent();
        }
        private int [,] data=new int[39,39];
        private string s1, s2, s3, s4, s5;
        private void SplitGraph_Load(object sender, EventArgs e)
        {
            EditXml EXml = new EditXml();
            EXml.DetDB();
            using (var m_sqlConn = new SqlConnection(EditXml.strConnectionSetting))
            {
                //107000251
                m_sqlConn.Open();
                string str = "Select * from[" + EditXml.strSettingDBName + "].[dbo].[tMe] where [No]>107000212 ";
                using (var sqlcmd = new SqlCommand(str, m_sqlConn))
                {
                    using (var sqlr = sqlcmd.ExecuteReader())
                    {
                        int z = 0;
                        while (sqlr.Read())
                        {
                            z++;
                            for (int i = 1; i < 5; i++)
                            {
                                for (int ii = i+1; ii < 6; ii++)
                                {
                                    int x = Convert.ToInt32(sqlr["Number" + i.ToString()]);
                                    int y = Convert.ToInt32(sqlr["Number" + ii.ToString()]);
                                    data[x - 1, y - 1]++;
                                }
                            }
                        }
                        Console.Write(z.ToString());
                    }
                }
                dataGridView1.ColumnCount = 39;
                for (int i = 1; i < 40; i++)
                {
                    dataGridView1.Columns[i - 1].Name = i.ToString();
                    dataGridView1.Columns[i - 1].Width = 50;
                }
                for (int i = 1; i < 40; i++)
                {
                    string [] x = new string[39];
                    for (int ii = 1; ii < 40; ii++)
                    {                        
                        x[ii - 1] = data[i - 1, ii - 1].ToString();
                        switch (data[i - 1, ii - 1])
                        {
                            case 1:
                                s1 += ",(" + i.ToString() + "," + ii.ToString() + ")";
                                break;
                            case 2:
                                s2 += ",(" + i.ToString() + "," + ii.ToString() + ")";
                                break;
                            case 3:
                                s3 += ",(" + i.ToString() + "," + ii.ToString() + ")";
                                break;
                            case 4:
                                s4 += ",(" + i.ToString() + "," + ii.ToString() + ")";
                                break;
                        }                        
                    }
                    dataGridView1.Rows.Add(x);
                    dataGridView1.Rows[i-1].Cells[i-1].Style.BackColor = Color.Black;
                    for (int y = 0; y < 39; y++)
                    {
                        if (x[y] == "0")
                            dataGridView1.Rows[i - 1].Cells[y].Style.BackColor = Color.Black;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(s2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(s3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(s1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(s4);
        }

    }
}
