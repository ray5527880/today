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
    public partial class Prediction : UserControl
    {
        /*
          0=539
          1=威力
          2=大福  
          3=大樂
          4=六合
         */
        public enum tableName
        {
            tMe = 0, PowerLotto = 1, BigLotto = 3, MarkSix = 4
        };
        public int countball;
        int oblique;//斜連號加權
        public static float[] NumberWeighted ;
        public static float[] NumberTail = new float[10];
        public static int[,] NumberAndNumber;
        public int NumberLenght;
        public static int SelectGame;
        public Prediction( int select)
        {
            SelectGame = select;
            InitializeComponent();
        }

        private void Prediction_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox13.Enabled = false;
            textBox14.Enabled = false;
            textBox15.Enabled = false;
            EditXml EXml = new EditXml();
            switch (SelectGame)
            {
                case 0:
                    NumberLenght = 39;
                    countball = 5;
                    break;
                case 1:
                    NumberLenght = 38;
                    countball = 6;
                    break;
                case 2:
                    NumberLenght = 40;
                    countball = 7;
                    break;
                case 3:
                    NumberLenght = 49;
                    countball = 6;
                    break;
                case 4:
                    NumberLenght = 49;
                    countball = 6;
                    break;
            }
            NumberWeighted = new float[NumberLenght];
            NumberAndNumber = new int[NumberLenght, NumberLenght];
            EXml.DetDB();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            periodCompute();
            portText();            
        }
        private void portText()
        {   
            float[] sortNumber = new float[NumberLenght];
            string[] strText = new string[15];
            for (int ii = 0; ii < 10; ii++)
            {
                if (ii != 0)
                    NumberWeighted[ii] /= 4;
                else
                    NumberWeighted[ii] /= 3;
            }
            for(int ii=0;ii<NumberWeighted.Length;ii++)
            {
                sortNumber[ii] = NumberWeighted[ii];            
            }
            
            Array.Sort(sortNumber);
            for (int ii = 0; ii < 5; ii++)
            {
                for (int jj = 0; jj < NumberWeighted.Length; jj++)
                {
                    if (sortNumber[NumberWeighted.Length-ii-1] == NumberWeighted[jj])
                    {
                        strText[ii] = strText[ii] + (jj+1).ToString()+",";
                    }
                }                
            }
            
            //
            for (int ii = 1; ii < NumberWeighted.Length+1; ii++)
            {
                int y = ii % 10;
                float x = NumberWeighted[ii - 1];
                NumberTail[y] = NumberTail[y] + x ;
            }
            //------------------------------------------
            //if (SelectGame == 1)
            //{
            //    NumberTail[9] += 0.7f;
            //    NumberTail[0] += 0.7f;
            //}
            //if (SelectGame == 0)
            //    NumberTail[0] += 0.7f;

            //-------------------------------------------
            double[] sortNumberTail = new double[10];
            for (int ii = 0; ii < NumberTail.Length; ii++)
            {
                sortNumberTail[ii] = Math.Round(NumberTail[ii], 2);
            }
            Array.Sort(sortNumberTail);
            for (int ii = 0; ii < 10; ii++)
            {
                for (int jj = 0; jj < NumberTail.Length; jj++)
                {
                    if (sortNumberTail[NumberTail.Length - ii - 1] == Math.Round(NumberTail[jj], 2))
                    {
                        strText[ii+5] = strText[ii+5] + (jj).ToString() + ",";
                    }
                }
            }
            
            //
            textBox1.Text = strText[0];
            textBox2.Text = strText[1];
            textBox3.Text = strText[2];
            textBox4.Text = strText[3];
            textBox5.Text = strText[4];
            textBox6.Text = strText[5];
            textBox7.Text = strText[6];
            textBox8.Text = strText[7];
            textBox9.Text = strText[8];
            textBox10.Text = strText[9];
            textBox11.Text = strText[10];
            textBox12.Text = strText[11];
            textBox13.Text = strText[12];
            textBox14.Text = strText[13];
            textBox15.Text = strText[14];
            
        }
        //取近X期
        private void RecentStatus()
        {
            int[] BefterNumber = new int[countball];
            int  obliqueL = 0;
            using (var m_sqlConn = new SqlConnection(EditXml.strConnectionSetting))
            {
                m_sqlConn.Open();
                string strSqlCount = "Select TOP(5)* from [" + EditXml.strSettingDBName + "].[dbo].[" + ((tableName)SelectGame).ToString() + "] order by [No] ";
                //斜號 Left
                using (var sqlCmd = new SqlCommand(strSqlCount, m_sqlConn))
                {
                    using (var sqlRdr = sqlCmd.ExecuteReader())
                    {
                        while (sqlRdr.Read())
                        {
                            for (int ii = 0; ii < 5; ii++)
                            {
                                if (BefterNumber[ii] != 0)
                                {
                                    int x = Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]);
                                    for (int jj = 0; jj < 5; jj++)
                                    {
                                        if (x + 1 == BefterNumber[jj])
                                        {
                                            obliqueL++;
                                        }
                                    }
                                }
                            }
                            for (int ii = 0; ii < 5; ii++)
                            {
                                BefterNumber[ii] = Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]);
                            }
                        }
                    }
                }
                //取近一期
                strSqlCount = "Select top(1) * from [" + EditXml.strSettingDBName + "].[dbo].[" + ((tableName)SelectGame).ToString() + "] order by [No] desc";
                using (var sqlCmd = new SqlCommand(strSqlCount, m_sqlConn))
                {
                    using (var sqlRdr = sqlCmd.ExecuteReader())
                    {
                        while (sqlRdr.Read())
                        {
                            //if (obliqueL >= 2)
                            //{
                            //    for (int ii = 0; ii < countball; ii++)
                            //    {
                            //        int x = Convert.ToInt32(sqlRdr["Number" + (ii + 1)]);
                            //        //------------------------------------------------
                            //        if(x!=1)
                            //            NumberWeighted[Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]) - 2] += 0.5f;
                            //    }
                            //}
                            //if (obliqueL > 3)
                            //{
                            //    for (int ii = 0; ii < countball; ii++)
                            //    {
                            //        //------------------------------------------------
                            //        NumberWeighted[Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]) - 2] += 1f;
                            //    }
                            //}
                        }
                    }
                }
            }
        }
        private void NextNumber()
        {
            int[] BefterNumber = new int[countball];
            using (var m_sqlConn = new SqlConnection(EditXml.strConnectionSetting))
            {
                m_sqlConn.Open();
                string strSqlCount = "Select * from [" + EditXml.strSettingDBName + "].[dbo].[" + ((tableName)SelectGame).ToString() + "] order by [No] ";
                using (var sqlCmd = new SqlCommand(strSqlCount, m_sqlConn))
                {
                    using (var sqlRdr = sqlCmd.ExecuteReader())
                    {
                        while (sqlRdr.Read())
                        {
                            //Convert.ToDecimal(sqlRdr["Number" + (ii + 1).ToString()])
                            for (int ii = 0; ii < countball; ii++)
                            {
                                if (BefterNumber[ii] == 0)
                                {
                                    BefterNumber[ii] = Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]);
                                }
                                else
                                {
                                    int x = Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]);
                                    NumberAndNumber[BefterNumber[ii] - 1, x - 1]++;
                                    BefterNumber[ii] = Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]);

                                }
                            }
                        }                       
                    }
                }
                strSqlCount = "Select top(5) * from [" + EditXml.strSettingDBName + "].[dbo].[" + ((tableName)SelectGame).ToString() + "] order by [No] desc";
                using (var sqlCmd = new SqlCommand(strSqlCount, m_sqlConn))
                {
                    using (var sqlRdr = sqlCmd.ExecuteReader())
                    {
                        int x = 0;
                        while (sqlRdr.Read())
                        {
                            x++;
                            for (int ii = 0; ii < countball; ii++)
                            {
                                for (int jj = 0; jj < NumberLenght; jj++)
                                {
                                    //-----------------------------------------
                                    if(x==1)
                                    NumberWeighted[jj] = NumberWeighted[jj] + NumberAndNumber[Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]) - 1, jj] * 0.25f;
                                    else
                                        NumberWeighted[jj] = NumberWeighted[jj] + NumberAndNumber[Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]) - 1, jj] * 0.15f;
                                    //if(Convert.ToInt32(sqlRdr["Number"+(ii+1).ToString()])==(jj+1))
                                    //{
                                    //   // NumberWeighted[jj] = NumberWeighted[jj]+0.5f;
                                    //}
                                    //if (Convert.ToInt32(sqlRdr["Number" + (ii ).ToString()]) == (jj + 1))
                                    //{
                                    //  //  NumberWeighted[jj] = NumberWeighted[jj] + 1f;
                                    //}
                                }
                            }
                        }
                        //MessageBox.Show(x.ToString());
                    }
                }
            }
        }
        private int[] SelectTOP_X(int x)
        {
            int[] NumberCount = new int[NumberLenght];
            using (var m_sqlConn = new SqlConnection(EditXml.strConnectionSetting))
            {
                m_sqlConn.Open();
                string strSqlCount = "Select top(" + x + ") * from [" + EditXml.strSettingDBName + "].[dbo].[" + ((tableName)SelectGame).ToString() + "] order by [No] desc";
                using (var sqlCmd = new SqlCommand(strSqlCount, m_sqlConn))
                {
                    using (var sqlRdr = sqlCmd.ExecuteReader())
                    {
                        int nCount = 0;
                        while (sqlRdr.Read())
                        {
                            for (int ii = 0; ii < countball; ii++)
                            {
                                string str = "Number" + (ii + 1).ToString();
                                for (int jj = 0; jj < NumberLenght; jj++)
                                {
                                    var i = sqlRdr["Number" + (ii + 1).ToString()];
                                    if (Convert.ToDecimal(sqlRdr["Number" + (ii + 1).ToString()]) == (jj + 1))
                                    {
                                        NumberCount[jj]++;
                                    }
                                }
                            }
                            nCount++;
                        }
                    }
                }
            }
            return NumberCount;
        }
        private int[] doublePeriodCompute()
        {
            int[] NumberCount = new int[NumberLenght];
            
            using (var m_sqlConn = new SqlConnection(EditXml.strConnectionSetting))
            {
                m_sqlConn.Open();
                string strSqlCount = "Select * from [" + EditXml.strSettingDBName + "].[dbo].[" + ((tableName)SelectGame).ToString() + "] order by [No] ";
                using (var sqlCmd = new SqlCommand(strSqlCount, m_sqlConn))
                {
                    using (var sqlRdr = sqlCmd.ExecuteReader())
                    {                        
                        while (sqlRdr.Read())
                        {
                            int[] BefterNumber = new int[NumberLenght];
                            for (int ii = 0; ii < countball; ii++)
                            {
                                if (BefterNumber[ii] == 0)
                                {
                                    BefterNumber[ii] = Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]);
                                }
                                else
                                {
                                    for (int jj = 0; jj < NumberLenght; jj++)
                                    {
                                        if (BefterNumber[ii] == Convert.ToInt32(sqlRdr["Number" + (jj + 1).ToString()]))
                                        {
                                            NumberCount[BefterNumber[ii]]++;
                                        }
                                        BefterNumber[ii] = Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return NumberCount;
        }
        private void periodCompute()
        {
            //出現機率[上期,本期]
            for (int ii = 0; ii < NumberLenght; ii++)
            {
                NumberWeighted[ii] = 0;
                for (int jj = 0; jj < NumberLenght; jj++)
                {
                    NumberAndNumber[ii, jj] = 0;
                }
            }
            for (int ii = 0; ii < 10; ii++)
            {
                NumberTail[ii] = 0;
            }
            //---------------------------------------------------------------------------
            NextNumber();  

            //---------------------------------------------------------------------------
            int[] NumberCount10 = SelectTOP_X(10);
            int MaxCount = 0;
            //取出近20期權重最多次權重+0.7 第二多權重+1.3 第三多+1.1
            for (int jj = 0; jj < 2; jj++)
            {
                for (int ii = 0; ii < NumberLenght; ii++)
                {
                    switch (jj)
                    {
                        case 0:                           
                            if (MaxCount < NumberCount10[ii])
                            {
                                MaxCount = NumberCount10[ii];
                            }                            
                            break;
                        case 1:                            
                            if ((MaxCount - 1) == NumberCount10[ii] )
                            {
                                NumberWeighted[ii]=NumberWeighted[ii]+5f;
                            }
                            if (MaxCount == NumberCount10[ii])
                            {
                                NumberWeighted[ii] = NumberWeighted[ii] + 4f;
                            }
                            if ((MaxCount - 2) == NumberCount10[ii])
                            {
                                NumberWeighted[ii] = NumberWeighted[ii] + 4f;
                            }
                            break;
                    }
                }
            }            
            //int[] NumberCount30 = SelectTOP_X(30);
            ////取出近30期權重沒出現 加權-0.5
            //for (int ii = 0; ii < NumberLenght; ii++)
            //{
            //    if (NumberCount30[ii] == 0)
            //    {
            //        NumberWeighted[ii]=NumberWeighted[ii]-1f;
            //    }
            //}
            //RecentStatus();
            int[] NumberCount = doublePeriodCompute();
            //歷史下期出現機率            
                  
        }
        
    }
}
