using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestFixture]
public class DriverSetup
{
    public IWebDriver driver;
    public ExtentReports Extreport;
    public ExtentTest extTest;
    public void  OpenBrowser()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        Thread.Sleep(1000);

        driver.Url = "http://hrm.qabible.in/hrms/admin";
        Thread.Sleep(1000);
        //return (driver);

    }
    public void BrowserClose()
    {
        Thread.Sleep(2000);
        driver.Close();
    }
    public void BrowserQuit()
    {
        Thread.Sleep(2000);
        driver.Quit();
    }
    
    public void Dashboardopen()
    {
        IWebElement Dash = driver.FindElement(By.XPath("//span[text()='Dashboard']"));
        Dash.Click();

    }
    public void ReportsHandling()
    {
        var path = new ExtentHtmlReporter(@"C:\Users\srrajale\source\repos\HRMS-MINI PROJECT\HRMS-MINI PROJECT\REPORTS\extentReport.html");
        Extreport = new ExtentReports();

        Extreport.AttachReporter(path);

    }
    public void CloseReport()
    {
        Extreport.Flush();
    }

    
}

