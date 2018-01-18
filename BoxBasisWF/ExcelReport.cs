using OfficeOpenXml;
using System;

namespace BoxBasisWF
{
    class ExcelReport
    {
        private ExcelPackage report;
        System.IO.FileInfo file = new System.IO.FileInfo(@"C:\report\report.xlsx");

        public ExcelReport()
        {
            report = new ExcelPackage(file);
            
            //var ws = report.Workbook.Worksheets.Add(String.Format("{0:dd.MM.yyyy}", DateTime.Now));
            //ws.Cells[2, 1].Value = "kljlkjlk";
            //report.Save();
        }

    }
}
