using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[TestFixture]
public class DriverSetup
{
    public IWebDriver driver;

    public ITakesScreenshot Iss;
    public Screenshot ss;
    public string browser;
    public string site;

    public void  OpenBrowser()
    {
        browser = System.Configuration.ConfigurationManager.AppSettings["Browser"];
        switch (browser)
        {
            case "Chrome":
                //driver = new ChromeDriver();
                ChromeOptions optionChrome = new ChromeOptions();
                optionChrome.AddArguments("headless");
                driver = new ChromeDriver(optionChrome);
                break;

            case "Edge":
                driver = new EdgeDriver();
                //EdgeOptions optionEdge = new EdgeOptions();
                //optionEdge.AddArguments("headless");
                //driver = new EdgeDriver(optionEdge);
                break;

            case "Firefox":
                driver = new FirefoxDriver();
                break;

            default:
                break;
        }
        driver.Manage().Window.Maximize();

        site = System.Configuration.ConfigurationManager.AppSettings["Site"].ToString();
        driver.Url = site;            
    }
    public void BrowserClose()
    {
        //Thread.Sleep(2000);
        driver.Close();
    }
    public void BrowserQuit()
    {
        //Thread.Sleep(2000);
        driver.Quit();
    }
    
    public void Dashboardopen()
    {
        IWebElement Dash = driver.FindElement(By.XPath("//span[text()='Dashboard']"));
        Dash.Click();

    }
    /* public void ReportsHandling()
     {
         var path = new ExtentHtmlReporter(@"C:\Users\srrajale\source\repos\HRMS-MINI PROJECT\HRMS-MINI PROJECT\REPORTS\extentReport.html");
         Extreport = new ExtentReports();

         Extreport.AttachReporter(path);

     }
     public void CloseReport()
     {
         Extreport.Flush();
     }
    */
    /*public void screensSetup()
    {
        Iss = (ITakesScreenshot)driver;
        ss = Iss.GetScreenshot();
    }*/

    /*  public void EmployeeReportsChildWindow()
      {        
          List<string> child = driver.WindowHandles.ToList();

          string ch = child[1];
          driver.SwitchTo().Window(ch);
      }
      public void EmpReportBacktoParent()
      {
          driver.SwitchTo().Window(driver.WindowHandles[0]);
      }*/
}

