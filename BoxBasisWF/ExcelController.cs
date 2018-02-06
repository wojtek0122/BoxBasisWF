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
        ExcelWorksheet xlWorksheet;
        string filePath = @"C:\report\";
        int rows = 2;

        public void SaveBatchData(List<String> list)
        {
            if (!File.Exists(filePath + list[0].ToString() + ".xlsx"))
            {
                var newFile = new FileInfo(filePath+list[0].ToString()+".xlsx");
                xlPackage = new ExcelPackage(newFile);
                xlWorksheet = xlPackage.Workbook.Worksheets.Add(list[0].ToString());
            }
            else
            {
                FileInfo existingFile = new FileInfo(filePath + list[0].ToString() + ".xlsx");
                xlPackage = new ExcelPackage(existingFile);
                xlWorksheet = xlPackage.Workbook.Worksheets[1];
            }
            FillHeader();
            FillData(list);
            xlPackage.Save();
        }

        public void FillData(List<String> list)
        {
            for (int i=0; i<16; i++)
            {
                xlWorksheet.Cells[rows, i+1].Value = list[i].ToString();
            }
            rows++;
        }

        public void FillHeader()
        {

            xlWorksheet.Cells[1, 1].Value = "Batch";
            xlWorksheet.Cells[1, 2].Value = "Serial";
            xlWorksheet.Cells[1, 3].Value = "MainVoltage";
            xlWorksheet.Cells[1, 4].Value = "BasisVoltage";
            xlWorksheet.Cells[1, 5].Value = "SwitchTester";
            xlWorksheet.Cells[1, 6].Value = "SwitchBox";
            xlWorksheet.Cells[1, 7].Value = "CoilState1";
            xlWorksheet.Cells[1, 8].Value = "CoilState2";
            xlWorksheet.Cells[1, 9].Value = "BasisVoltage";
            xlWorksheet.Cells[1, 10].Value = "SwitchTester";
            xlWorksheet.Cells[1, 11].Value = "SwitchBox";
            xlWorksheet.Cells[1, 12].Value = "MotorState1";
            xlWorksheet.Cells[1, 13].Value = "MotorState2";
            xlWorksheet.Cells[1, 14].Value = "SwitchTester";
            xlWorksheet.Cells[1, 15].Value = "SwitchBox";
            xlWorksheet.Cells[1, 16].Value = "Result";

            ExcelRange row = xlWorksheet.Cells["A1:P1"];
            {
                row.Style.Fill.PatternType = ExcelFillStyle.Solid;
                row.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(23, 55, 93));
                row.Style.Font.Color.SetColor(System.Drawing.Color.White);
                row.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                row.AutoFitColumns();
            }

        }
        
        public void SaveReport()
        {
            xlPackage.Save();
        }
    }
}
