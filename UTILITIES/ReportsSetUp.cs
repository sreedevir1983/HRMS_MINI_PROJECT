using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;

public class ReportsSetUp
{
    public ExtentReports Extreport;
    public ExtentTest extTest;
    public string reportpath;
    public void ReportsHandling()
    {
        //var path = new ExtentHtmlReporter(@"C:\Users\srrajale\source\repos\HRMS-MINI PROJECT\HRMS-MINI PROJECT\REPORTS\extentReport.html");
        reportpath = System.Configuration.ConfigurationManager.AppSettings["ReportsPath"];

        var path = new ExtentHtmlReporter(reportpath);
        Extreport = new ExtentReports();

        Extreport.AttachReporter(path);

    }
    public void CloseReport()
    {
        Extreport.Flush();
    }
}

