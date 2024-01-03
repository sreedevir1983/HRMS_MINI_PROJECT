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

public class ScreenshotsHandling 
{
    //public IWebDriver driver;
    //public ITakesScreenshot Iss;
    //public Screenshot ss;
    public string ScreenPath;
    public string screen;

    public void TakeScreenshot(IWebDriver driver, string TCName)
    {
        //Iss = (ITakesScreenshot)driver;
        //ss = Iss.GetScreenshot();
        ITakesScreenshot Iss = (ITakesScreenshot)driver;
        Screenshot ss= Iss.GetScreenshot();
        ScreenPath = System.Configuration.ConfigurationManager.AppSettings["ScreenshotPath"].ToString();
        //ScreenPath = "C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\";
        screen = ScreenPath + TCName + ".jpeg";

        ss.SaveAsFile(screen, ScreenshotImageFormat.Jpeg);
     }
}
