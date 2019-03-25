using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Worstore.Entities;
using Worstore.Models.GeneralHelperFunctionModels;

namespace Worstore.Helpers.Functions
{
    public static class GeneralHelperFunctions
    {

        public static String DateTimeNow_InFormat()
        {
            return DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        //public List<> ExcelOku(IWorkbook wb, int sayfa_sayisi)
        //{


        //}
        public static List<ExcelSheet> ResolveExcelFile(IFormFile excelFIle, string hostingEnvironment)
        {
            List<ExcelSheet> GroupOfWord = new List<ExcelSheet>();
            if (excelFIle.Length > 0)
            {
                IWorkbook workbook = null;
                string fileExtension = Path.GetExtension(excelFIle.FileName).ToLower();
                ISheet sheet = null;




                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    if (fileExtension == ".xls")
                    {
                        workbook = new HSSFWorkbook(excelFIle.OpenReadStream()); //This will read the Excel 97-2000 formats  

                    }
                    else if (fileExtension == ".xlsx")
                    {
                        workbook = new XSSFWorkbook(excelFIle.OpenReadStream()); //This will read 2007 Excel format  

                    }

                    GroupOfWord = ReadExcelFile(workbook);

                }

            }
            return GroupOfWord;

        }

        public static List<ExcelSheet> ReadExcelFile(IWorkbook workbook)
        {
            List<ExcelSheet> GroupOfWord = new List<ExcelSheet>();//Entity Model


            List<ExcelRow> _row;//temporary object
            List<string> _cell;//temporary object
            List<string> _sheetHeader;//temporary object


            for (int sheetNo = 0; sheetNo < workbook.NumberOfSheets; sheetNo++)
            {
                ISheet sheet = workbook.GetSheetAt(sheetNo);
                _row = new List<ExcelRow>();

                int headingSize = sheet.GetRow(sheet.FirstRowNum).Count() - 1;

                #region Read Sheet Header

                IRow headerRow = sheet.GetRow(sheet.FirstRowNum);
                _sheetHeader = new List<string>();
                for (int cellIndex = 0; cellIndex < headingSize; cellIndex++)
                {
                    //if(string.IsNullOrEmpty(row.GetCell(cellIndex).ToString()))
                    if (headerRow.GetCell(cellIndex) == null)
                    {
                        _sheetHeader.Add("");
                    }
                    else
                    {
                        _sheetHeader.Add(headerRow.GetCell(cellIndex).ToString());
                    }

                }



                #endregion


                #region Read Sheet Content

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel Content
                {

                    IRow row = sheet.GetRow(i);




                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;

                    try
                    {
                        _cell = new List<string>();
                        for (int cellIndex = 0; cellIndex < headingSize; cellIndex++)
                        {
                            //if(string.IsNullOrEmpty(row.GetCell(cellIndex).ToString()))
                            if (row.GetCell(cellIndex) == null)
                            {
                                _cell.Add("");
                            }
                            else
                            {
                                _cell.Add(row.GetCell(cellIndex).ToString());
                            }

                        }
                        _row.Add(new ExcelRow() { ExcelCell = _cell });
                    }
                    catch (Exception e)
                    {

                    }


                }

                #endregion

                GroupOfWord.Add(new ExcelSheet() { ExcelRow = _row, SheetLabel = sheet.SheetName, ExcelHeader = _sheetHeader });



            }

            return GroupOfWord;
        }

    }
}
