using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
namespace Lottery
{
    class ImPortExcelDao
    {
        private Number.Number_539[] mNumber;

        private XML _XML;

        public StatusType Load_539(string path)
        {
            Application excel = new Application();
            excel.Visible = false;

            Workbook workbook = excel.Workbooks.Open(path);
            Worksheet sheet = workbook.Sheets[1];
            Range range = sheet.UsedRange;

            var rowCount = range.Rows.Count - 1;
            var colCount = range.Columns.Count;

            this.mNumber = new Number.Number_539[rowCount];

            try
            {
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    this.mNumber[rowIndex].No = Convert.ToInt32(range[rowIndex + 2, 1].Cells.Text);
                    this.mNumber[rowIndex].Date = Convert.ToDateTime(range[rowIndex + 2, 2].Cells.Text);
                    this.mNumber[rowIndex].n_1 = Convert.ToInt32(range[rowIndex + 2, 3].Cells.Text);
                    this.mNumber[rowIndex].n_2 = Convert.ToInt32(range[rowIndex + 2, 4].Cells.Text);
                    this.mNumber[rowIndex].n_3 = Convert.ToInt32(range[rowIndex + 2, 5].Cells.Text);
                    this.mNumber[rowIndex].n_4 = Convert.ToInt32(range[rowIndex + 2, 6].Cells.Text);
                    this.mNumber[rowIndex].n_5 = Convert.ToInt32(range[rowIndex + 2, 7].Cells.Text);
                }
            }
            finally
            {
                if (range != null) Marshal.FinalReleaseComObject(range);

                if (sheet != null) Marshal.FinalReleaseComObject(sheet);

                if (workbook != null)
                {
                    workbook.Close(false);

                    Marshal.FinalReleaseComObject(workbook);
                }

                if (excel != null)
                {
                    excel.Workbooks.Close();
                    excel.Quit();

                    Marshal.FinalReleaseComObject(excel);
                }
            }
            return StatusType.Ok;
        }
        public StatusType Insert_539(XML xml)
        {            
            foreach (var item in mNumber)
            {
                Number.Number_539 m539 = new Number.Number_539();
                m539.No = item.No;
                m539.Date = item.Date;
                m539.n_1 = item.n_1;
                m539.n_2 = item.n_2;
                m539.n_3 = item.n_3;
                m539.n_4 = item.n_4;
                m539.n_5 = item.n_5;
                xml.InsertData_539(m539, "./L539.xml");
            }
           
            return StatusType.Ok;
        }
    }
}
