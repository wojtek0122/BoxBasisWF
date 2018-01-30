using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace BoxBasisWF
{
    class ExcelController
    {
        ExcelPackage xlPackage;
        ExcelWorksheets xlWorksheets;
        string filePath = @"C:\report\report.xlsx";
        int rows;
        int columns = 1;

        public ExcelController()
        {
            if(!File.Exists(filePath))
            {
                var newFile = new FileInfo(filePath);
                using (xlPackage = new ExcelPackage(newFile))
                {
                    xlPackage.Workbook.Worksheets.Add(String.Format("{0:dd.MM.yyyy}", DateTime.Now));
                    FillHeader();
                    xlPackage.Save();
                }
            }
        }

        public void FillHeader()
        {
            xlWorksheets = xlPackage.Workbook.Worksheets;

            xlWorksheets[xlWorksheets.Count].Cells[1, 1].Value = "Batch";
            xlWorksheets[xlWorksheets.Count].Cells[1, 2].Value = "Serial";
            xlWorksheets[xlWorksheets.Count].Cells[1, 3].Value = "Voltage";
            xlWorksheets[xlWorksheets.Count].Cells[1, 4].Value = "Motor";
            xlWorksheets[xlWorksheets.Count].Cells[1, 5].Value = "SwitchBox";
            xlWorksheets[xlWorksheets.Count].Cells[1, 6].Value = "SwitchTester";
            xlWorksheets[xlWorksheets.Count].Cells[1, 7].Value = "Coil";
            xlWorksheets[xlWorksheets.Count].Cells[1, 8].Value = "Capacitor";

            ExcelRange row = xlWorksheets[xlWorksheets.Count].Cells["A1:H1"];
            {
                row.Style.Fill.PatternType = ExcelFillStyle.Solid;
                row.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(23, 55, 93));
                row.Style.Font.Color.SetColor(System.Drawing.Color.White);
                row.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

        }

        public void SaveReport()
        {
            xlPackage.Save();
        }

        public void AddData(String data)
        {
            xlWorksheets = xlPackage.Workbook.Worksheets;
            if (columns>9)
            {
                columns = 1;
                rows++;
            }
            columns++;
            xlWorksheets[xlWorksheets.Count].Cells[rows, columns].Value = data;
            xlPackage.Save();
        }

    }
}
