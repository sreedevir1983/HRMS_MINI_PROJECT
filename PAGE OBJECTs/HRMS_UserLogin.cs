using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

public class HRMS_UserLogin
{
    IWebDriver driver;
    public ArrayList Userlist;
    public int row, column;
    public string excelpath;
    public HRMS_UserLogin(IWebDriver driver) 
    {
        PageFactory.InitElements(driver,this);
    }

    [FindsBy(How = How.XPath, Using = "//input[@id='iusername']")] IWebElement username;
    [FindsBy(How = How.XPath, Using = "//input[@id='ipassword']")] IWebElement password;
    [FindsBy(How = How.XPath, Using = "//button[text()=' Login']")] IWebElement loginbutton;

    public void userLoginRead()
    {
        excelpath = System.Configuration.ConfigurationManager.AppSettings["UserLoginFile"];

        Excel.Application UserExcelapp = new Excel.Application();
        //Excel.Workbook EmpWorkbook = EmpExcelapp.Workbooks.Open(@"C:\Users\srrajale\source\repos\HRMS-MINI PROJECT\HRMS-MINI PROJECT\UTILITIES\NewEmployeeFile.xlsx");      
        Excel.Workbook UserWorkbook = UserExcelapp.Workbooks.Open(excelpath);
        Excel._Worksheet UserWorksheet = (Excel._Worksheet)UserWorkbook.Sheets[1];
        Excel.Range UserSheetRange = UserWorksheet.UsedRange;

        row = UserSheetRange.Rows.Count;
        column=UserSheetRange.Columns.Count;

        Userlist=new ArrayList();

        for (int i=1; i<=row; i++)
        {
            for (int j=1;j<=column;j++)
            {
                Userlist.Add(UserSheetRange.Cells[i,j].Value2.ToString());
            }

        }

    }
    public void UserLogin()
    {
        /*username.SendKeys("admin");
        //Thread.Sleep(1000);
        password.SendKeys("123456");
        //Thread.Sleep(2000);
        */

        username.SendKeys(Convert.ToString(Userlist[0]));
        password.SendKeys(Convert.ToString(Userlist[1]));


        loginbutton.Click();
        //Thread.Sleep(3000);
    }

}

