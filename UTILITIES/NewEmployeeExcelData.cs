using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

public class NewEmployeeExcelData
{
    public ArrayList Emplist;
    public int row, column;
    public string excelpath;
    public ArrayList NewEmployeeRead() 
    {
        //excelpath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName; // GetCurrentDirectory()+ @"\Excel Files\NewEmployeeFile.xlsx";
        //System.Configuration.ConfigurationManager.AppSettings["EmployeeExcelfilePath"];
        //string pathstr= "\\Excel Files"

        excelpath = System.Configuration.ConfigurationManager.AppSettings["EmployeeExcelfilePath"];
        Excel.Application EmpExcelapp=new Excel.Application();
        //Excel.Workbook EmpWorkbook = EmpExcelapp.Workbooks.Open(@"C:\Users\srrajale\source\repos\HRMS-MINI PROJECT\HRMS-MINI PROJECT\UTILITIES\NewEmployeeFile.xlsx");      
        Excel.Workbook EmpWorkbook = EmpExcelapp.Workbooks.Open(excelpath);
        Excel._Worksheet EmpWorksheet = (Excel._Worksheet)EmpWorkbook.Sheets[1];
        Excel.Range EmpSheetRange = EmpWorksheet.UsedRange;

        row = EmpSheetRange.Rows.Count;
        column = EmpSheetRange.Columns.Count;

        Emplist = new ArrayList();

        for (int i=2;i<=row;i++)
        {
            for (int j=1; j<=column;j++)
            {
                Emplist.Add(EmpSheetRange.Cells[i, j].Value2.ToString());                
            }           
        }
        
        return Emplist;            
    }
    
}
