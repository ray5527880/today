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
        public struct number10
        {
            public string no { get; set; }
            public decimal value { get; set; }
        }
        private void getTwoNunber()
        {
            decimal[] topArr = new decimal[39];
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

                bool startOn = true;

                str = "Select TOP(100) * from[" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [No] desc";
                using (var sqlcmd = new SqlCommand(str, m_sqlConn))
                {
                    using (var sqlr = sqlcmd.ExecuteReader())
                    {
                        int[] Bnumber = new int[5];
                        while (sqlr.Read())
                        {
                            var x = sqlr["No"];
                            if (startOn)
                            {                                
                                Bnumber[0] = Convert.ToInt32(sqlr["Number1"]);
                                Bnumber[1] = Convert.ToInt32(sqlr["Number2"]);
                                Bnumber[2] = Convert.ToInt32(sqlr["Number3"]);
                                Bnumber[3] = Convert.ToInt32(sqlr["Number4"]);
                                Bnumber[4] = Convert.ToInt32(sqlr["Number5"]);
                                var ss = sqlr["Date"];
                                startOn = false;
                            }
                            else
                            {
                                //for (int i = 0; i < 5; i++)
                                //{
                                    for (int j = 0; j < 5; j++)
                                    {
                                        if (Convert.ToInt32(sqlr["Number1"]) == NewNumber[j])
                                        {
                                            for (int ii = 0; ii < 5; ii++)
                                            {
                                                number[Bnumber[ii] - 1] += 1;
                                            }
                                        }
                                        else if (Convert.ToInt32(sqlr["Number2"]) == NewNumber[j])
                                        {
                                            for (int ii = 0; ii < 5; ii++)
                                            {
                                                number[Bnumber[ii] - 1] += 1;
                                            }
                                        }
                                        else if (Convert.ToInt32(sqlr["Number3"]) == NewNumber[j])
                                        {
                                            for (int ii = 0; ii < 5; ii++)
                                            {
                                                number[Bnumber[ii] - 1] += 1;
                                            }
                                        }
                                        else if (Convert.ToInt32(sqlr["Number4"]) == NewNumber[j])
                                        {
                                            for (int ii = 0; ii < 5; ii++)
                                            {
                                                number[Bnumber[ii] - 1] += 1;
                                            }
                                        }
                                        else if (Convert.ToInt32(sqlr["Number5"]) == NewNumber[j])
                                        {
                                            for (int ii = 0; ii < 5; ii++)
                                            {
                                                number[Bnumber[ii] - 1] += 1;
                                            }
                                        }

                                        //if (Bnumber[i] == NewNumber[j])
                                        //{
                                        //    number[Convert.ToInt32(sqlr["Number1"]) - 1] += 1;
                                        //    number[Convert.ToInt32(sqlr["Number2"]) - 1] += 1;
                                        //    number[Convert.ToInt32(sqlr["Number3"]) - 1] += 1;
                                        //    number[Convert.ToInt32(sqlr["Number4"]) - 1] += 1;
                                        //    number[Convert.ToInt32(sqlr["Number5"]) - 1] += 1;
                                        //}
                                    }
                                //}
                               
                                Bnumber[0] = Convert.ToInt32(sqlr["Number1"]);
                                Bnumber[1] = Convert.ToInt32(sqlr["Number2"]);
                                Bnumber[2] = Convert.ToInt32(sqlr["Number3"]);
                                Bnumber[3] = Convert.ToInt32(sqlr["Number4"]);
                                Bnumber[4] = Convert.ToInt32(sqlr["Number5"]);
                            }
                        }
                    }
                }

                decimal[] sortArr = new decimal[39];
                for (int i = 0; i < 39; i++)
                {
                    sortArr[i] = number[i];
                }
                Array.Sort(sortArr);
                string strlable2 = string.Empty;
                decimal[] top13 = new decimal[13];

                //for (int i = 13; i < 25; i++)
                //{
                //    for (int j = 0; j < 39; j++)
                //    {
                //        if (sortArr[i] == number[j])
                //        {
                //            bool bC = false;
                //            for (int k = 0; k < i - 13; k++)
                //            {
                //                if (top13[k] == j + 1)                                
                //                    bC = true;                                
                //            }
                //            if (bC)
                //                continue;
                //            top13[i - 13] = j + 1;
                //            break;
                //            //bool bC = false;
                //            //for (int l = 0; l <= i; l++)
                //            //{
                //            //    if ((j + 1) == topArr[l])
                //            //        bC = true;
                //            //}
                //            //if (bC)
                //            //    continue;
                //            //else
                //            //{
                //            //    topArr[i] = 39 - j;
                //            //    //strlable2 += (j + 1).ToString() + " , ";
                //            //    break;
                //            //}
                //        }
                //    }
                //}
                //decimal decAvg = 0;
                //for (int i = 0; i < 39; i++)
                //{
                //    decAvg += topArr[i];
                //}
                //decAvg /= 39;
                for (int i = 0; i < 13; i++)
                {
                    for (int j = 0; j < 39; j++)
                    {
                        if (sortArr[38-i] == number[j])
                        {
                            bool bC = false;
                            for (int l = 0; l <= i ; l++)
                            {
                                if ((j + 1) == top13[l])
                                    bC = true;
                            }
                            if (bC)
                                continue;
                            else
                            {
                                top13[i] = j + 1;
                                strlable2 += (j + 1).ToString() + " , ";
                                break;
                            }
                        }
                    }
                }
                //label2.Text = strlable2;
                decimal[] top13H = new decimal[13];
                //decimal[] top10H = new decimal[39];
                //decimal[] decH = new decimal[39];
                //str = "Select TOP(10)* from[" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [Date] desc ";
                //using (var sqlcmd = new SqlCommand(str, m_sqlConn))
                //{
                //    using (var sqlr = sqlcmd.ExecuteReader())
                //    {
                //        int[] Bnumber = new int[5];
                //        while (sqlr.Read())
                //        {                            
                //            top10H[Convert.ToInt32(sqlr["Number1"]) - 1] += 1;
                //            top10H[Convert.ToInt32(sqlr["Number2"]) - 1] += 1;
                //            top10H[Convert.ToInt32(sqlr["Number3"]) - 1] += 1;
                //            top10H[Convert.ToInt32(sqlr["Number4"]) - 1] += 1;
                //            top10H[Convert.ToInt32(sqlr["Number5"]) - 1] += 1;
                //        }
                //    }
                //}
                //for (int i = 0; i < 39; i++)
                //{
                //    decH[i] = top10H[i] + topArr[i] * 2 / 39;
                //}
                number10[] no10 = new number10[9];
                str = "Select TOP(15)* from[" + EditXml.strSettingDBName + "].[dbo].[tMe] order by [Date] desc ";
                using (var sqlcmd = new SqlCommand(str, m_sqlConn))
                {
                    using (var sqlr = sqlcmd.ExecuteReader())
                    {
                        int[] Bnumber = new int[5];
                        while (sqlr.Read())
                        {
                            if (Convert.ToInt32(sqlr["Number1"]) % 10 != 0)
                            {
                                no10[Convert.ToInt32(sqlr["Number1"]) % 10 - 1].value++;
                            }
                            if (Convert.ToInt32(sqlr["Number2"]) % 10 != 0)
                            {
                                no10[Convert.ToInt32(sqlr["Number2"]) % 10 - 1].value++;
                            }
                            if (Convert.ToInt32(sqlr["Number3"]) % 10 != 0)
                            {
                                no10[Convert.ToInt32(sqlr["Number3"]) % 10 - 1].value++;
                            }
                            if (Convert.ToInt32(sqlr["Number4"]) % 10 != 0)
                            {
                                no10[Convert.ToInt32(sqlr["Number4"]) % 10 - 1].value++;
                            }
                            if (Convert.ToInt32(sqlr["Number5"]) % 10 != 0)
                            {
                                no10[Convert.ToInt32(sqlr["Number5"]) % 10 - 1].value++;
                            }
                            for (int i = 0; i < 13; i++)
                            {
                                if (Convert.ToInt32(sqlr["Number1"]) == top13[i])
                                {
                                    top13H[i]++;
                                }
                                if (Convert.ToInt32(sqlr["Number2"]) == top13[i])
                                {
                                    top13H[i]++;
                                }
                                if (Convert.ToInt32(sqlr["Number3"]) == top13[i])
                                {
                                    top13H[i]++;
                                }
                                if (Convert.ToInt32(sqlr["Number4"]) == top13[i])
                                {
                                    top13H[i]++;
                                }
                                if (Convert.ToInt32(sqlr["Number5"]) == top13[i])
                                {
                                    top13H[i]++;
                                }
                            }
                        }
                    }
                }

                decimal top1, top2;
                top1 = top2 = 0;
                //for (int j = 0; j < 39; j++)
                //{
                //    if (top1 < decH[j])
                //        top1 = decH[j];
                //}
                //for (int j = 0; j < 39; j++)
                //{
                //    if (top1 != decH[j])
                //    {
                //        if (top2 < decH[j])
                //            top2 = decH[j];
                //    }
                //}
                //string s = string.Empty;
                //for (int j = 0; j < 39; j++)
                //{
                //    if (top1 == decH[j])
                //    {
                //        s += (j + 1).ToString() + " , ";
                //    }

                //}
                //for (int j = 0; j < 39; j++)
                //{
                //    if (top2 == decH[j])
                //    {
                //        s += (j + 1).ToString() + " , ";
                //    }

                //}

                string s2 = string.Empty;
                for (int i = 0; i < 9; i++)
                {
                    no10[i].no = (i + 1).ToString();
                }
                for (int i = 0; i < 39; i++)
                {
                    if ((i + 1) % 10 != 0)
                        no10[(i + 1) % 10-1].value += number[i];
                }
                foreach (var x in no10.OrderByDescending(e => e.value))
                {
                    s2 += x.no + " , ";
                }

                for (int j = 0; j < 13; j++)
                {
                    if (top1 < top13H[j])
                        top1 = top13H[j];
                }
                for (int j = 0; j < 13; j++)
                {
                    if (top1 != top13H[j])
                    {
                        if (top2 < top13H[j])
                            top2 = top13H[j];
                    }
                }
                string s = string.Empty;
                string s1 = string.Empty;
               
                for (int j = 0; j < 13; j++)
                {
                    if (top1 == top13H[j])
                    {
                        s1 += top13[j].ToString() + " , ";
                    }

                }
                for (int j = 0; j < 13; j++)
                {
                    if (top2 == top13H[j])
                    {
                        s += top13[j].ToString() + " , ";
                    }

                }
          
                label1.Text = s;
                label2.Text = s1;
                label3.Text = s2;
            }

            //decimal top1, top2;
            //top1 = top2 = 0;
            //for (int j = 0; j < 39; j++)
            //{
            //    if (top1 < number[j])
            //        top1 = number[j];
            //}
            //for (int j = 0; j < 39; j++)
            //{
            //    if (top1 != number[j])
            //    {
            //        if (top2 < number[j])
            //            top2 = number[j];
            //    }
            //}
            //string s = string.Empty;
            //for (int j = 0; j < 39; j++)
            //{
            //    if (top2 == number[j] || top1 == number[j])
            //    {
            //        s += (j + 1).ToString()+" , ";
            //    }
                  
            //}
            //label1.Text = s;
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
    }
}
