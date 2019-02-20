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
    public partial class Revise : UserControl
    {
        public int SelectGame;
        public int NumberLenght;
        public Boolean bCheck;
        public enum tableName
        {
            tMe = 0, BigLotto = 3, MarkSix = 4
        };
        public struct tMe
        {
            public int No;
            public DateTime DTime;
            public decimal Number1;
            public decimal Number2;
            public decimal Number3;
            public decimal Number4;
            public decimal Number5;
            public decimal Number6;
            public decimal SPNumber;

        }
        public tMe[] m_tMe;
        private int m_nIndex;
        int m_nCount;
        public Revise(int selectGame)
        {
            SelectGame = selectGame;
            InitializeComponent();
            //text11111
            ///jdjjjjf
        }

        private void Revise_Load(object sender, EventArgs e)
        {
            ///ieieie
            EditXml EXml = new EditXml();
            EXml.DetDB();
            bCheck = false;
            textNo.Text = "";
            textNum1.Text = "";
            textNum2.Text = "";
            textNum3.Text = "";
            textNum4.Text = "";
            textNum5.Text = ""; 

            switch (SelectGame)
            {
                case 0:
                    NumberLenght = 39;
                    break;
                case 1:
                    NumberLenght = 38;
                    break;
                case 2:
                    NumberLenght = 40;
                    break;
                case 3:
                    NumberLenght = 49;
                    break;
                case 4:
                    NumberLenght = 49;
                    break;

            }
            dgvDataSet();
            
            
        }
        private void dgvDataSet()
        {
            switch(SelectGame){
                case 0:
                    dgvData.ColumnCount = 7;
                    dgvData.Columns[0].Width = 70;
                    dgvData.Columns[1].Width = 95;
                    dgvData.Columns[2].Width = 50;
                    dgvData.Columns[3].Width = 50;
                    dgvData.Columns[4].Width = 50;
                    dgvData.Columns[5].Width = 50;
                    dgvData.Columns[6].Width = 50;
                    dgvData.Columns[0].Name = "期號";
                    dgvData.Columns[1].Name = "時間";
                    dgvData.Columns[2].Name = "號碼1";
                    dgvData.Columns[3].Name = "號碼2";
                    dgvData.Columns[4].Name = "號碼3";
                    dgvData.Columns[5].Name = "號碼4";
                    dgvData.Columns[6].Name = "號碼5";
                    dgvData.ReadOnly = true;
                    dgvData.Rows.Clear();
                    UpdateDataGridView();
                    break;
                case 1:
                    dgvData.ColumnCount = 8;
                    dgvData.Columns[0].Width = 70;
                    dgvData.Columns[1].Width = 95;
                    dgvData.Columns[2].Width = 50;
                    dgvData.Columns[3].Width = 50;
                    dgvData.Columns[4].Width = 50;
                    dgvData.Columns[5].Width = 50;
                    dgvData.Columns[6].Width = 50;
                    dgvData.Columns[7].Width = 50;
                    dgvData.Columns[0].Name = "期號";
                    dgvData.Columns[1].Name = "時間";
                    dgvData.Columns[2].Name = "號碼1";
                    dgvData.Columns[3].Name = "號碼2";
                    dgvData.Columns[4].Name = "號碼3";
                    dgvData.Columns[5].Name = "號碼4";
                    dgvData.Columns[6].Name = "號碼5";
                    dgvData.Columns[7].Name = "號碼6";
                    dgvData.ReadOnly = true;
                    dgvData.Rows.Clear();
                    UpdateDataGridView();
                    break;
                case 2:
                    dgvData.ColumnCount = 9;
                    dgvData.Columns[0].Width = 70;
                    dgvData.Columns[1].Width = 95;
                    dgvData.Columns[2].Width = 50;
                    dgvData.Columns[3].Width = 50;
                    dgvData.Columns[4].Width = 50;
                    dgvData.Columns[5].Width = 50;
                    dgvData.Columns[6].Width = 50;
                    dgvData.Columns[7].Width = 50;
                    dgvData.Columns[8].Width = 50;
                    dgvData.Columns[0].Name = "期號";
                    dgvData.Columns[1].Name = "時間";
                    dgvData.Columns[2].Name = "號碼1";
                    dgvData.Columns[3].Name = "號碼2";
                    dgvData.Columns[4].Name = "號碼3";
                    dgvData.Columns[5].Name = "號碼4";
                    dgvData.Columns[6].Name = "號碼5";
                    dgvData.Columns[7].Name = "號碼6";
                    dgvData.Columns[8].Name = "號碼7";
                    dgvData.ReadOnly = true;
                    dgvData.Rows.Clear();
                    UpdateDataGridView();
                    break;
               case 3:
                    dgvData.ColumnCount = 9;
                    dgvData.Columns[0].Width = 70;
                    dgvData.Columns[1].Width = 95;
                    dgvData.Columns[2].Width = 50;
                    dgvData.Columns[3].Width = 50;
                    dgvData.Columns[4].Width = 50;
                    dgvData.Columns[5].Width = 50;
                    dgvData.Columns[6].Width = 50;
                    dgvData.Columns[7].Width = 50;
                    dgvData.Columns[8].Width = 50;
                    dgvData.Columns[0].Name = "期號";
                    dgvData.Columns[1].Name = "時間";
                    dgvData.Columns[2].Name = "號碼1";
                    dgvData.Columns[3].Name = "號碼2";
                    dgvData.Columns[4].Name = "號碼3";
                    dgvData.Columns[5].Name = "號碼4";
                    dgvData.Columns[6].Name = "號碼5";
                    dgvData.Columns[7].Name = "號碼6";
                    dgvData.Columns[8].Name = "特別號";
                    dgvData.ReadOnly = true;
                    dgvData.Rows.Clear();
                    UpdateDataGridView();
                    break;
               case 4:
                    dgvData.ColumnCount = 9;
                    dgvData.Columns[0].Width = 70;
                    dgvData.Columns[1].Width = 95;
                    dgvData.Columns[2].Width = 50;
                    dgvData.Columns[3].Width = 50;
                    dgvData.Columns[4].Width = 50;
                    dgvData.Columns[5].Width = 50;
                    dgvData.Columns[6].Width = 50;
                    dgvData.Columns[7].Width = 50;
                    dgvData.Columns[8].Width = 50;
                    dgvData.Columns[0].Name = "期號";
                    dgvData.Columns[1].Name = "時間";
                    dgvData.Columns[2].Name = "號碼1";
                    dgvData.Columns[3].Name = "號碼2";
                    dgvData.Columns[4].Name = "號碼3";
                    dgvData.Columns[5].Name = "號碼4";
                    dgvData.Columns[6].Name = "號碼5";
                    dgvData.Columns[7].Name = "號碼6";
                    dgvData.Columns[8].Name = "特別號";
                    dgvData.ReadOnly = true;
                    dgvData.Rows.Clear();
                    UpdateDataGridView();
                    break;
            }
        }
        private void UpdateDataGridView()
        {
            dgvData.Rows.Clear();
            m_nCount = GetData();
            string[] row;
            if (SelectGame == 0)
            {
                for (int jj = 0; jj < m_nCount; jj++)
                {
                    row = new string[] { m_tMe[jj].No.ToString(), m_tMe[jj].DTime.ToString("yyyy/MM/dd"), m_tMe[jj].Number1.ToString(), m_tMe[jj].Number2.ToString(), m_tMe[jj].Number3.ToString(), m_tMe[jj].Number4.ToString(), m_tMe[jj].Number5.ToString() };
                    dgvData.Rows.Add(row);
                }
            }
            if (SelectGame == 1)
            {
                for (int jj = 0; jj < m_nCount; jj++)
                {
                    row = new string[] { m_tMe[jj].No.ToString(), m_tMe[jj].DTime.ToString("yyyy/MM/dd"), m_tMe[jj].Number1.ToString(), m_tMe[jj].Number2.ToString(), m_tMe[jj].Number3.ToString(), m_tMe[jj].Number4.ToString(), m_tMe[jj].Number5.ToString() };
                    dgvData.Rows.Add(row);
                }
            }
            dgvData.Rows[0].Cells[0].Selected = false;
            dgvData.Rows[m_nCount].Selected = true;
            dgvData.Rows[m_nCount].Cells[0].Value = "新增...";
            m_nIndex = m_nCount;
            dgvData.Refresh();
            btnUpdata.Enabled = false;
            textNo.Text = (Convert.ToDecimal(dgvData.Rows[0].Cells[0].Value) + 1).ToString();
        }
        private int GetData()
        {
            string tbName = ((tableName)SelectGame).ToString();
            SqlConnection m_sqlConn = new SqlConnection(EditXml.strConnectionSetting);
            m_sqlConn.Open();
            string strSqlCount = "Select count(*) as [Count] from [" + EditXml.strSettingDBName + "].[dbo].["+tbName+"]";
            SqlCommand sqlCmdCount = new SqlCommand(strSqlCount, m_sqlConn);
            int nRows = (Int32)sqlCmdCount.ExecuteScalar();
            if (nRows >= 10)
            {
                m_tMe = new tMe[10];                
            }
            else
            {
                m_tMe = new tMe[nRows];
            }
            string strSQL = "SELECT TOP(10) * From [" + EditXml.strSettingDBName + "].[dbo].["+tbName+"] order by [No] desc";
            SqlCommand sqlCmd = new SqlCommand(strSQL, m_sqlConn);
            SqlDataReader sqlRdr = sqlCmd.ExecuteReader();
            int nCount = 0;
            try
            {
                while (sqlRdr.Read())
                {
                    m_tMe[nCount].No = Convert.ToInt32(sqlRdr["No"]);
                    m_tMe[nCount].DTime = Convert.ToDateTime(sqlRdr["Date"]);
                    m_tMe[nCount].Number1 = Convert.ToDecimal(sqlRdr["Number1"]);
                    m_tMe[nCount].Number2 = Convert.ToDecimal(sqlRdr["Number2"]);
                    m_tMe[nCount].Number3 = Convert.ToDecimal(sqlRdr["Number3"]);
                    m_tMe[nCount].Number4 = Convert.ToDecimal(sqlRdr["Number4"]);
                    m_tMe[nCount].Number5 = Convert.ToDecimal(sqlRdr["Number5"]);
                    if (SelectGame == 4)
                    {
                        m_tMe[nCount].Number6 = Convert.ToDecimal(sqlRdr["Number6"]);
                        m_tMe[nCount].SPNumber = Convert.ToDecimal(sqlRdr["SPNumber"]);
                    }
                    nCount++;
                }
                                
            }
            catch
            {
            }
            finally
            {
                sqlRdr.Close();
                sqlCmd.Cancel();
                m_sqlConn.Close();
            }
            return nCount;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {            
            DataCheck();
            DataCheck_Insert();
            if (bCheck)
            {
                bCheck = false;
                Insert(Convert.ToInt32(textNo.Text), dateTime.Value, Convert.ToDecimal(textNum1.Text), Convert.ToDecimal(textNum2.Text), Convert.ToDecimal(textNum3.Text), Convert.ToDecimal(textNum4.Text), Convert.ToDecimal(textNum5.Text));
                UpdateDataGridView();
            }
        }

        private void btnUpdata_Click(object sender, EventArgs e)
        {
            DataCheck();
            if (bCheck)
            {
                bCheck = false;
                Update(Convert.ToInt32(textNo.Text), dateTime.Value, Convert.ToDecimal(textNum1.Text), Convert.ToDecimal(textNum2.Text), Convert.ToDecimal(textNum3.Text), Convert.ToDecimal(textNum4.Text), Convert.ToDecimal(textNum5.Text));
                UpdateDataGridView();
            }
        }
        private void Update(int No, DateTime dTime, Decimal num1, Decimal num2, Decimal num3, Decimal num4, Decimal num5)
        {
            SqlConnection sCon = new SqlConnection(EditXml.strConnectionSetting);
            sCon.Open();
            //string strSQL = "select * from [text].[dbo].[tMe]";
            //SqlCommand sqlCmd = new SqlCommand(strSQL, sCon);
            string strSQL = "Update [" + EditXml.strSettingDBName + "].[dbo].[tMe] "
                          + "set [No]=@V1, [Date]=@V2, [Number1]=@V3, [Number2]=@V4, [Number3]=@V5, [Number4]=@V6, [Number5]=@V7 "
                          + "where [No]='"+No+"'";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sCon);
            sqlCmd.Parameters.AddWithValue("@V1", No);
            sqlCmd.Parameters.AddWithValue("@V2", dTime);
            sqlCmd.Parameters.AddWithValue("@V3", num1);
            sqlCmd.Parameters.AddWithValue("@V4", num2);
            sqlCmd.Parameters.AddWithValue("@V5", num3);
            sqlCmd.Parameters.AddWithValue("@V6", num4);
            sqlCmd.Parameters.AddWithValue("@V7", num5);
            try
            {
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Cancel();
                MessageBox.Show("完成");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCmd.Cancel();
                sCon.Close();
            }
        }
        private void Insert(int No, DateTime dTime, Decimal num1, Decimal num2, Decimal num3, Decimal num4, Decimal num5)
        {
            SqlConnection sCon = new SqlConnection(EditXml.strConnectionSetting);
            sCon.Open();
            //string strSQL = "select * from [text].[dbo].[tMe]";
            //SqlCommand sqlCmd = new SqlCommand(strSQL, sCon);
            string strSQL = "Insert into [" + EditXml.strSettingDBName + "].[dbo].[tMe] "
                          + "([No],[Date],[Number1],[Number2],[Number3],[Number4],[Number5])"
                          + "values(@V1,@V2,@V3,@V4,@V5,@V6,@V7)";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sCon);
            sqlCmd.Parameters.AddWithValue("@V1", No);
            sqlCmd.Parameters.AddWithValue("@V2", dTime);
            sqlCmd.Parameters.AddWithValue("@V3", num1);
            sqlCmd.Parameters.AddWithValue("@V4", num2);
            sqlCmd.Parameters.AddWithValue("@V5", num3);
            sqlCmd.Parameters.AddWithValue("@V6", num4);
            sqlCmd.Parameters.AddWithValue("@V7", num5);
            try
            {
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Cancel();
                MessageBox.Show("完成");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCmd.Cancel();
                sCon.Close();
            }

        }
        private void DataCheck_Insert()
        {
            SqlConnection sCon = new SqlConnection(EditXml.strConnectionSetting);
            sCon.Open();
            string strSQL = "Select count(*) as [Count] From [" + EditXml.strSettingDBName + "].[dbo].[tMe] "
                          + "Where [No]=" + Convert.ToInt32(textNo.Text) + "or [Date]='" + dateTime.Value.ToString("yyyy/MM/dd") + "'";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sCon);
            if ((Int32)sqlCmd.ExecuteScalar() == 0)
            {
                bCheck = true;
            }
            else
            {
                bCheck = false;
                MessageBox.Show("期號、時間不重複");
            }
            sqlCmd.Cancel();
            sCon.Close();
        }
        private void DataCheck()
        {
            DateTime Dt = dateTime.Value;
            if (textNo.Text == "")
            {
                MessageBox.Show("No未輸入");
            }
            else if (textNum1.Text == "")
            {
                MessageBox.Show("數字1未輸入");
            }
            else if (textNum2.Text == "")
            {
                MessageBox.Show("數字2未輸入");

            }
            else if (textNum3.Text == "")
            {
                MessageBox.Show("數字3未輸入");

            }
            else if (textNum4.Text == "")
            {
                MessageBox.Show("數字4未輸入");

            }
            else if (textNum5.Text == "")
            {
                MessageBox.Show("數字5未輸入");

            }
            else if (dateTime.Value.DayOfWeek.ToString() == "Sunday")
            {
                MessageBox.Show("日期不能為禮拜天");
            }
            else
            {
                if ((Convert.ToInt16(textNum1.Text) > 40) || (Convert.ToInt16(textNum1.Text) < 0))
                {
                    MessageBox.Show("請輸入1~39");
                }
                else if ((Convert.ToInt16(textNum2.Text) > 40) || (Convert.ToInt16(textNum2.Text) < 0))
                {
                    MessageBox.Show("請輸入1~39");
                }
                else if ((Convert.ToInt16(textNum3.Text) > 40) || (Convert.ToInt16(textNum3.Text) < 0))
                {
                    MessageBox.Show("請輸入1~39");
                }
                else if ((Convert.ToInt16(textNum4.Text) > 40) || (Convert.ToInt16(textNum4.Text) < 0))
                {
                    MessageBox.Show("請輸入1~39");
                }
                else if ((Convert.ToInt16(textNum5.Text) > 40) || (Convert.ToInt16(textNum5.Text) < 0))
                {
                    MessageBox.Show("請輸入1~39");
                }
                else
                {
                    bCheck = true;
                }
            }
            int[] number = new int[]{Convert.ToInt16(textNum1.Text),Convert.ToInt16(textNum2.Text),Convert.ToInt16(textNum3.Text),
                Convert.ToInt16(textNum4.Text),Convert.ToInt16(textNum5.Text)};
            for (int ii = 0; ii < number.Length - 1; ii++)
            {
                for (int jj = ii+1; jj < number.Length - 1; jj++)
                {
                    if (number[ii] == number[jj])
                    {
                        bCheck = false;
                        MessageBox.Show("同一期獎號不重複");
                    }
                }
            }
            

        }
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            m_nIndex = e.RowIndex;
            if (m_nIndex < m_nCount && m_nIndex > -1)
            {
                btnUpdata.Enabled = true;
                btnInsert.Enabled = false;
                
                textNo.Text = dgvData.Rows[m_nIndex].Cells[0].Value.ToString();
                dateTime.Value = Convert.ToDateTime(dgvData.Rows[m_nIndex].Cells[1].Value);
                textNum1.Text = dgvData.Rows[m_nIndex].Cells[2].Value.ToString();
                textNum2.Text = dgvData.Rows[m_nIndex].Cells[3].Value.ToString();
                textNum3.Text = dgvData.Rows[m_nIndex].Cells[4].Value.ToString();
                textNum4.Text = dgvData.Rows[m_nIndex].Cells[5].Value.ToString();
                textNum5.Text = dgvData.Rows[m_nIndex].Cells[6].Value.ToString();
                textNo.Enabled = false;
            }
            else
            {
                btnUpdata.Enabled = false;
                btnInsert.Enabled = true;
                textNo.Text = "";
                dateTime.Value = DateTime.Today;
                textNum1.Text = "";
                textNum2.Text = "";
                textNum3.Text = "";
                textNum4.Text = "";
                textNum5.Text = "";
                textNo.Enabled = true;

            }
        }
    }
}
