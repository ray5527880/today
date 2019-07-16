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
    public partial class Prediction2 : UserControl
    {
        int ID = 1;
        int No = 5;
        int period = 6;
        int TopSelect=10;
        decimal [] number;
        public Prediction2()
        {
            InitializeComponent();
        }
        private void Prediction2_Load(object sender, EventArgs e)
        {
            EditXml EXml = new EditXml();
            EXml.DetDB();
            number = new decimal[39];
            getTwoNunber();
            int i = 0;
        }

        private void getTwoNunber()
        {
            using (SqlConnection m_sqlConn = new SqlConnection(EditXml.strConnectionSetting))
            {
                m_sqlConn.Open();
                int[] NewNumber = new int[5];
                string str = "Select TOP(1) * from[" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [Date] desc";
                using (var sqlcmd = new SqlCommand(str, m_sqlConn))
                {
                    using (var sqlr = sqlcmd.ExecuteReader())
                    {
                        int[] Bnumber = new int[5];
                        while (sqlr.Read())
                        {
                            NewNumber[0] = Convert.ToInt32(sqlr["Number1"]);
                            NewNumber[1] = Convert.ToInt32(sqlr["Number2"]);
                            NewNumber[2] = Convert.ToInt32(sqlr["Number3"]);
                            NewNumber[3] = Convert.ToInt32(sqlr["Number4"]);
                            NewNumber[4] = Convert.ToInt32(sqlr["Number5"]);
                        }
                    }
                }

                str = "Select * from[" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [Date] ";
                using (var sqlcmd = new SqlCommand(str, m_sqlConn))
                {
                    using (var sqlr = sqlcmd.ExecuteReader())
                    {
                        int[] Bnumber = new int[5];
                        while (sqlr.Read())
                        {
                            if (Bnumber[0] == null)
                            {
                                Bnumber[0] = Convert.ToInt32(sqlr["Number1"]);
                                Bnumber[1] = Convert.ToInt32(sqlr["Number2"]);
                                Bnumber[2] = Convert.ToInt32(sqlr["Number3"]);
                                Bnumber[3] = Convert.ToInt32(sqlr["Number4"]);
                                Bnumber[4] = Convert.ToInt32(sqlr["Number5"]);
                            }
                            else
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    for (int j = 0; j < 5; j++)
                                    {
                                        if (Bnumber[i] == NewNumber[j])
                                        {
                                            number[Convert.ToInt32(sqlr["Number1"]) - 1] += 1;
                                            number[Convert.ToInt32(sqlr["Number2"]) - 1] += 1;
                                            number[Convert.ToInt32(sqlr["Number3"]) - 1] += 1;
                                            number[Convert.ToInt32(sqlr["Number4"]) - 1] += 1;
                                            number[Convert.ToInt32(sqlr["Number5"]) - 1] += 1;
                                        }
                                    }
                                }
                               
                                Bnumber[0] = Convert.ToInt32(sqlr["Number1"]);
                                Bnumber[1] = Convert.ToInt32(sqlr["Number2"]);
                                Bnumber[2] = Convert.ToInt32(sqlr["Number3"]);
                                Bnumber[3] = Convert.ToInt32(sqlr["Number4"]);
                                Bnumber[4] = Convert.ToInt32(sqlr["Number5"]);
                            }

                        }
                    }
                }str = "Select TOP(15)* from[" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [Date] desc ";
                using (var sqlcmd = new SqlCommand(str, m_sqlConn))
                {
                    using (var sqlr = sqlcmd.ExecuteReader())
                    {
                        int[] Bnumber = new int[5];
                        while (sqlr.Read())
                        {
                            number[Convert.ToInt32(sqlr["Number1"]) - 1] += 2;
                            number[Convert.ToInt32(sqlr["Number2"]) - 1] += 2;
                            number[Convert.ToInt32(sqlr["Number3"]) - 1] += 2;
                            number[Convert.ToInt32(sqlr["Number4"]) - 1] += 2;
                            number[Convert.ToInt32(sqlr["Number5"]) - 1] += 2;
                        }
                    }
                }
            }

            decimal top1, top2;
            top1 = top2 = 0;
            for (int j = 0; j < 39; j++)
            {
                if (top1 < number[j])
                    top1 = number[j];
            }
            for (int j = 0; j < 39; j++)
            {
                if (top1 != number[j])
                {
                    if (top2 < number[j])
                        top2 = number[j];
                }
            }
            string s = string.Empty;
            for (int j = 0; j < 39; j++)
            {
                if (top2 == number[j] || top1 == number[j])
                {
                    s += (j + 1).ToString()+" , ";
                }
                  
            }
            label1.Text = s;
        }
        private void cloerHMV()
        {
            using (SqlConnection sCon = new SqlConnection(EditXml.strConnectionSetting))
            {
                sCon.Open();
                //string strSQL = " DELETE FROM [" + EditXml.strSettingDBName + "].[dbo].[tHMV] WHERE [No]!=0";
                string strSQL = "Update [" + EditXml.strSettingDBName + "].[dbo].[tHMV] set [No]=1";
                for (int i = 0; i < 39; i++)
                {
                    strSQL += " ,No" + (i + 1).ToString() + "=" + 0;
                }
                strSQL += "where[No]=1";
                using (SqlCommand sqlCmd = new SqlCommand(strSQL, sCon))
                {
                    sqlCmd.ExecuteNonQuery();
                    sqlCmd.Cancel();
                    //                    
                }
                ID++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cloerHMV();
            SetHMM();
            GetHMM();
        }
       
        public void GetHMM()
        {
            float[] start1 = new float[39];//群組一
            float[] HB = new float[39];//隱含值累積
            using (var m_sqlConn = new SqlConnection(EditXml.strConnectionSetting))
            {
                m_sqlConn.Open();
                //取得累積隱含值
                string str = "Select * from[" + EditXml.strSettingDBName + "].[dbo].[tHMV]  ";
                using (var sqlcmd = new SqlCommand(str, m_sqlConn))
                {
                    using (var sqlr = sqlcmd.ExecuteReader())
                    {
                        while (sqlr.Read())
                        {
                            for (int i = 1; i < 40; i++)
                            {
                                HB[i - 1] = float.Parse(sqlr["No" + (i).ToString()].ToString());
                            }
                        }
                    }
                }

                string strSqlCount = "Select TOP(" + TopSelect + ")* from [" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [No] desc";
                using (var sqlCmd = new SqlCommand(strSqlCount, m_sqlConn))
                {
                    int[] nowNumber = new int[5];
                    using (var sqlRdr = sqlCmd.ExecuteReader())
                    {
                        int flot = 0;
                        while (sqlRdr.Read())
                        {
                            for (int i = 0; i < No; i++)
                            {
                                start1[Convert.ToInt32(sqlRdr["Number" + (i + 1).ToString()]) - 1]++;
                            }

                            flot++;
                        }
                    }
                }
            }
            float[] t = new float[10];
            float[] sortT = new float[10];
            float[] sortf = new float[39];
            for (int i = 0; i < 39; i++)
            {
                start1[i] = start1[i] / (No * TopSelect);
                start1[i] += HB[i];
                sortf[i] = start1[i];
                t[(i + 1) % 10] = start1[i];
                sortT[(i + 1) % 10] = start1[i];
            }
            string outstr = "";
            Array.Sort(sortf);
            for (int i = 38; i > 33; i--)
            {
                for (int ii = 0; ii < 39; ii++)
                {
                    if (sortf[i] == start1[ii])
                    {
                        outstr += (ii + 1).ToString() + "[" + start1[ii].ToString() + "],";
                    }
                }
            }
            Array.Sort(sortT);
            for (int i = 9; i > 6; i--)
            {
                for (int ii = 0; ii < 10; ii++)
                {
                    if(sortT[i]==t[ii])
                        outstr += " " + ii + "=[" + t[ii] + "]";
                }
            }
            MessageBox.Show(outstr);
        }
        private void upDataRowData(float[] rowData)
        {
            using (SqlConnection sCon = new SqlConnection(EditXml.strConnectionSetting))
            {
                sCon.Open();
                //string strSQL = "Update [" + EditXml.strSettingDBName + "].[dbo].[tHMV] set [No]=1";
                //for (int i = 0; i < 39; i++)
                //{
                //    strSQL += " ,No"+(i+1).ToString()+"="+HMV[i].ToString();
                //}
                //strSQL += "where[No]=1";

                string strSQL = "Insert into [" + EditXml.strSettingDBName + "].[dbo].[tRowData] ([No]";
                for (int i = 0; i < 39; i++)
                {
                    strSQL += ",[No" + (i + 1).ToString() + "]";
                }
                strSQL += ") values(" + ID;
                for (int i = 0; i < 39; i++)
                {
                    strSQL += "," + rowData[i].ToString();
                }
                strSQL += ")";
                //+ "([No],[Date],[Number1],[Number2],[Number3],[Number4],[Number5])"
                //+ "values(@V1,@V2,@V3,@V4,@V5,@V6,@V7)";
                using (SqlCommand sqlCmd = new SqlCommand(strSQL, sCon))
                {
                    sqlCmd.ExecuteNonQuery();
                    sqlCmd.Cancel();
                    //                    
                }
                ID++;
            }
        }

        public float[] GetHMV()//取得隱含值
        {
            float[] HB = new float[39];//隱含值累積
            using (var m_sqlConn = new SqlConnection(EditXml.strConnectionSetting))
            {
                m_sqlConn.Open();
                //取得累積隱含值
                string str = "Select * from[" + EditXml.strSettingDBName + "].[dbo].[tHMV]  ";
                using (var sqlcmd = new SqlCommand(str, m_sqlConn))
                {
                    using (var sqlr = sqlcmd.ExecuteReader())
                    {
                        while (sqlr.Read())
                        {
                            for (int i = 1; i < 40; i++)
                            {
                                HB[i - 1] = float.Parse(sqlr["No" + (i).ToString()].ToString());
                            }
                        }
                    }
                }
            }
            return HB;
        }
        public float[] GetHMV10()//取得隱含值
        {
            float[] HB = new float[10];//隱含值累積
            using (var m_sqlConn = new SqlConnection(EditXml.strConnectionSetting))
            {
                m_sqlConn.Open();
                //取得累積隱含值
                string str = "Select * from[" + EditXml.strSettingDBName + "].[dbo].[tHMV10]  ";
                using (var sqlcmd = new SqlCommand(str, m_sqlConn))
                {
                    using (var sqlr = sqlcmd.ExecuteReader())
                    {
                        while (sqlr.Read())
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                HB[i] = float.Parse(sqlr["No" + (i).ToString()].ToString());
                            }
                        }
                    }
                }
            }
            return HB;
        }
        public void SetHMM()
        {                
            float[] start1 = new float[39];//群組一
            float[] start2 = new float[39];//群組二
            float[] start3 = new float[39];//差值
            float[] start10_1 = new float[10];
            float[] start10_2 = new float[10];
            float[] start10_3 = new float[10];

            float[] HB = new float[39];//隱含值累積
            float[] HB10 = new float[10];
            float[] HA = new float[39];//隱含值下期
            float[] HA10 = new float[10];
            using (var m_sqlConn = new SqlConnection(EditXml.strConnectionSetting))
            {
                m_sqlConn.Open();
                string strSqlCount = "Select * from [" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [No]";
                using (var sqlCmd = new SqlCommand(strSqlCount, m_sqlConn))
                {
                    int[] nowNumber = new int[5];
                    using (var sqlRdr = sqlCmd.ExecuteReader())
                    {
                        int flot = 0;
                        while (sqlRdr.Read())
                        {
                            if ((flot % period == 0) && (flot != 0))
                            {
                                if (flot >= period*2)
                                {
                                    HB = GetHMV();
                                    for (int i = 0; i < 39; i++)
                                    {                                        
                                        start3[i] = (start2[i] / (No * period)) - (start1[i] / (No * period));
                                        HA[i] = (HB[i] + start3[i]) / 2;
                                    }
                                    updata(HA);
                                }    
                                for (int i = 0; i < 39; i++)
                                {
                                    start2[i] = start1[i];
                                    start1[i] = 0;
                                }                                                           
                            }
                             for (int i = 0; i < No; i++)
                             {
                                 start1[Convert.ToInt32(sqlRdr["Number" + (i + 1).ToString()]) - 1]++;
                             }                     
                            flot++;
                        }
                    }
                }
            }
        }
        private void updata(float[] HMV)
        {
            using(SqlConnection sCon = new SqlConnection(EditXml.strConnectionSetting))
            {
                sCon.Open();
                string strSQL = "Update [" + EditXml.strSettingDBName + "].[dbo].[tHMV] set [No]=1";
                for (int i = 0; i < 39; i++)
                {
                    strSQL += " ,No" + (i + 1).ToString() + "=" + HMV[i].ToString();
                }
                strSQL += "where[No]=1";

                //string strSQL = "Insert into [" + EditXml.strSettingDBName + "].[dbo].[tHMV] ([No]";
                //for (int i = 0; i < 39; i++)
                //{
                //    strSQL += ",[No" + (i + 1).ToString() + "]";
                //}
                //strSQL += ") values(" +ID;
                //for (int i = 0; i < 39; i++)
                //{
                //    strSQL += ","+HMV[i].ToString();
                //}
                //strSQL += ")";
                          //+ "([No],[Date],[Number1],[Number2],[Number3],[Number4],[Number5])"
                          //+ "values(@V1,@V2,@V3,@V4,@V5,@V6,@V7)";
                using (SqlCommand sqlCmd = new SqlCommand(strSQL, sCon))
                {
                    sqlCmd.ExecuteNonQuery();
                    sqlCmd.Cancel();
                    //                    
                }
                ID++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NextNumber();
        }
        private void NextNumber()
        {
            int countball = 5;
            float[] NumberWeighted = new float[39];
            int[,] NumberAndNumber = new int[39, 39];


            int[] BefterNumber = new int[countball];
            using (var m_sqlConn = new SqlConnection(EditXml.strConnectionSetting))
            {
                m_sqlConn.Open();
                string strSqlCount = "Select * from [" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [No] ";
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
                strSqlCount = "Select top(1) * from [" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [No] desc";
                using (var sqlCmd = new SqlCommand(strSqlCount, m_sqlConn))
                {
                    using (var sqlRdr = sqlCmd.ExecuteReader())
                    {
                        while (sqlRdr.Read())
                        {
                            for (int ii = 0; ii < countball; ii++)
                            {
                                for (int jj = 0; jj < 39; jj++)
                                {
                                    //-----------------------------------------
                                    NumberWeighted[jj] = NumberWeighted[jj] + NumberAndNumber[Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]) - 1, jj] ;
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
                    }
                }
                float[] sortArray=new float [39];
                for (int i = 0; i < 39; i++)
                {
                    sortArray[i] = NumberWeighted[i];
                }
                List<int> sss=new List<int>();
                Array.Sort(sortArray);
                string str="";
                for (int i = 38; i > 28; i--)
                {
                    for (int ii = 0; ii < 39; ii++)
                    {
                        if (sortArray[i] == NumberWeighted[ii])
                        {          
                            bool c = true;
                            foreach (var x in sss)
                            {
                                if (x == (ii+1))
                                    c = false;
                            }
                            if (c)
                            {
                                str += (ii + 1).ToString() + ",";
                                sss.Add(ii + 1);
                            }
                        }
                    }
                }
                MessageBox.Show(str);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int countball = 5;
            float[] NumberWeighted = new float[39];
            int[,] NumberAndNumber = new int[39, 39];


            int[] BefterNumber = new int[countball];
            using (var m_sqlConn = new SqlConnection(EditXml.strConnectionSetting))
            {
                m_sqlConn.Open();
                string strSqlCount = "Select * from [" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [No] desc";
                using (var sqlCmd = new SqlCommand(strSqlCount, m_sqlConn))
                {
                    using (var sqlRdr = sqlCmd.ExecuteReader())
                    {
                        int count = 0;
                        while (sqlRdr.Read())
                        {
                            if (count > 99)
                                break;
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
                            count++;
                        }
                    }
                }
                strSqlCount = "Select top(1) * from [" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [No] desc";
                using (var sqlCmd = new SqlCommand(strSqlCount, m_sqlConn))
                {
                    using (var sqlRdr = sqlCmd.ExecuteReader())
                    {
                        while (sqlRdr.Read())
                        {
                            for (int ii = 0; ii < countball; ii++)
                            {
                                for (int jj = 0; jj < 39; jj++)
                                {
                                    //-----------------------------------------                                    
                                    NumberWeighted[jj] = NumberWeighted[jj] + NumberAndNumber[Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]) - 1, jj];                                   
                                }
                            }
                        }
                    }
                }
                strSqlCount = "Select top(10) * from [" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [No] desc";
                using (var sqlCmd = new SqlCommand(strSqlCount, m_sqlConn))
                {
                    using (var sqlRdr = sqlCmd.ExecuteReader())
                    {
                        while (sqlRdr.Read())
                        {
                            for (int ii = 0; ii < countball; ii++)
                            {
                                var x = Convert.ToInt32(sqlRdr["Number" + (ii + 1).ToString()]) - 1;
                                NumberWeighted[x] += 1f;
                                
                            }
                        }
                    }
                }
                float[] sortArray = new float[39];
                for (int i = 0; i < 39; i++)
                {
                    sortArray[i] = NumberWeighted[i];
                }
                List<int> sss = new List<int>();
                Array.Sort(sortArray);
                string str = "";
                for (int i = 38; i > 33; i--)
                {
                    for (int ii = 0; ii < 39; ii++)
                    {
                        if (sortArray[i] == NumberWeighted[ii])
                        {
                            bool c = true;
                            foreach (var x in sss)
                            {
                                if (x == (ii + 1))
                                    c = false;
                            }
                            if (c)
                            {
                                str += (ii + 1).ToString() + ",";
                                sss.Add(ii + 1);
                            }
                        }
                    }
                }
                MessageBox.Show(str);
            }
        }
    }
}
