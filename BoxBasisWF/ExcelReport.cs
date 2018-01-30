using OfficeOpenXml;
using System;

namespace BoxBasisWF
{
    class ExcelReport
    {
        private ExcelPackage report;
        System.IO.FileInfo file = new System.IO.FileInfo(@"C:\report\report.xlsx");
        ExcelWorksheet worksheet;

        public ExcelReport()
        {
            report = new ExcelPackage(file);

            if(report.Workbook.Worksheets.Count == 0)
            {
                report.Workbook.Worksheets.Add(String.Format("{0:dd.MM.yyyy}", DateTime.Now));
            }
            else
            {
                if(report.Workbook.Worksheets[report.Workbook.Worksheets.Count].Name != String.Format("{0:dd.MM.yyyy}", DateTime.Now))
                {
                    report.Workbook.Worksheets.Add(String.Format("{0:dd.MM.yyyy}", DateTime.Now));
                }
            }

            SaveReport();
        }

        public void FillHeader()
        {
            for(int i=0; i<10; i++)
            {

            }
        }

        public void SaveReport()
        {
            report.Save();
        }

    }
}
