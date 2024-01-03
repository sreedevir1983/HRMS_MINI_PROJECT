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
public class HRMS_MAIN : DriverSetup
{

    public IJavaScriptExecutor js;
    public HRMS_UserLogin Adlogin;
    public DashboardEmployee DEmp;
    public STAFF_ADDEMP staffEmp;
    public HRMS_LOGOUT logout22;
    public Staff_Export_Import StImpExp;
    public ProfileUpdate profupd;

    public ReportsSetUp reportobj;

    public ScreenshotsHandling screenObj;
    public ChildWindowHandling windowobj;

    public string TCScreen;

    public Apply_Waits waitObj;

    public CoreHRMenu corehrobj;
    //public READandADD_Award corehrobj;

    public string EmployeeName;

    public ExtentReports Extreport;
    public ExtentTest extTest;

    bool val;


    //OneTimeSetUp -> Report set up, Browser launch and Opening browser
    [OneTimeSetUp]
    public void LaunchSite()
    {
        reportobj = new ReportsSetUp();
        reportobj.ReportsHandling();

        OpenBrowser();
    }
    public void WaitHandling()
    {
        waitObj = new Apply_Waits();
        waitObj.ImplicitWaitHandling();
    }

    //OneTimeTearDown -> Browser close and Reports close
    [OneTimeTearDown]
    public void CloseDriver()
    {
        BrowserClose();
        BrowserQuit();

        reportobj.CloseReport();

    }

    [TearDown]
    public void tearDown()
    {
        screenObj = new ScreenshotsHandling();
        string TCName = TestContext.CurrentContext.Test.Name;
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            screenObj.TakeScreenshot(driver, TCName);
        }
    }
    //Test Case 1- Verify that the user can login the site using valid credentials.
    [Test, Order(1)]
    public void TC1_HRMSLogin()
    {
        reportobj.extTest = reportobj.Extreport.CreateTest("Admin Login").Info("Login as Admin user");

        Adlogin = new HRMS_UserLogin(driver);

        Adlogin.userLoginRead();
        Adlogin.UserLogin();

        reportobj.extTest.Log(Status.Info, "Logged in as Admin");

    }

    //Test Case 2- Verify the user can open the Employees page from Dashboard and Open the Employee report.
    [Test, Order(2)]        //, Ignore("Ignore this")]
    public void TC2_HRMSDashboard()
    {
        reportobj.extTest = reportobj.Extreport.CreateTest("Employee Dashboard").Info("Go to Dashboard and Open Employee-> See reports");

        DEmp = new DashboardEmployee(driver);
        DEmp.EmployeeDash();

        DEmp.OpenReport();

        windowobj = new ChildWindowHandling();
        windowobj.ChildWindows(driver);

        bool b = DEmp.Reportwindowhandle();

        if (b == true)
        {
            windowobj.ControlBacktoParent(driver);
            reportobj.extTest.Log(Status.Pass, "Employee Opened from Dashboard and reports viewed ");
            Assert.Pass();
        }
        else
        {
            reportobj.extTest.Log(Status.Fail, "Employee reports page not opened!");
            Assert.Fail();
        }

        Dashboardopen();

    }

    //Test Case 3- Verify the user can add a new Employee from Left menu -> Staff -> Employees.
    [Test, Order(3)]        //, Ignore("Ignore this")]
    public void TC3_StaffEmployeeADD()
    {
        reportobj.extTest = reportobj.Extreport.CreateTest("Add New Employee ").Info("Staff-> Add new Employee");

        staffEmp = new STAFF_ADDEMP(driver);

        staffEmp.StaffClick();

        staffEmp.StaffEmployye();

        EmployeeName = staffEmp.AddNewEmployee();

        Dashboardopen();

        reportobj.extTest.Log(Status.Pass, "Employee Opened from Staff menu and added new Employee ");
    }

    //Test case 4 - Verify that the user can Export Employee file
    [Test, Order(4)]    //, Ignore("Ignore this")]
    public void TC4_StaffExport()
    {
        reportobj.extTest = reportobj.Extreport.CreateTest("Employee Export").Info("Staff-> Export Employee file");

        StImpExp = new Staff_Export_Import(driver);
        StImpExp.StaffImportEmployee();
        StImpExp.Downloadfile();

        reportobj.extTest.Log(Status.Pass, "Employee Data exported ");

    }

    //Test case 5 - Verify that the user can Import Employee file
    [Test, Order(5)]    //, Ignore("Ignore this")]
    public void TC5_StaffImport()
    {
        reportobj.extTest = reportobj.Extreport.CreateTest("Employee Import").Info("Staff-> Import Employee file");

        StImpExp = new Staff_Export_Import(driver);
        StImpExp.Uploadfile();

        Dashboardopen();

        reportobj.extTest.Log(Status.Pass, "Employee Data imported ");
    }

    //Test case 6 - Verify that the user can update the Profile details
    [Test, Order(6)]         //, Ignore("Ignore this")]
    public void TC6_MyProUpdate()
    {
        reportobj.extTest = reportobj.Extreport.CreateTest("Profile Update").Info("Update user profile");
        profupd = new ProfileUpdate(driver);
      
        profupd.MyProfileUpdate();
       
        //screensSetup();
        //ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\6-ProfileUpdate.jpeg", ScreenshotImageFormat.Jpeg);
        Dashboardopen();

        reportobj.extTest.Log(Status.Pass, "Profile data updated");
        //Thread.Sleep(1000);
    }

    //Test case 7 - Verify that the user can Add an award through CoreHR menu
    [Test, Order(7), Category("Parallel Testing")]   //,Ignore("Ignore this")
    public void TC7_CoreHRAddAward()
    {
        reportobj.extTest = reportobj.Extreport.CreateTest("Add Award").Info("Core HR -> Add a new award");
        corehrobj = new CoreHRMenu(driver);
        //corehrobj=new READandADD_Award(driver);


        corehrobj.CoreHRAward();

        corehrobj.AwardListRead();

        //screensSetup();
        //ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\7-Award-NewAward.jpeg", ScreenshotImageFormat.Jpeg);

        corehrobj.addnewaward();

        //screensSetup();
        // ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\8-AwardAdded.jpeg", ScreenshotImageFormat.Jpeg);
        reportobj.extTest.Log(Status.Pass, "Award is added for an employee ");
    }

    //Test case 8 - Verify that the user can Search and view teh added award
    [Test, Order(8)]  //, Ignore("Ignore this")]
    public void TC8_CoreHRViewAward()
    {
        reportobj.extTest = reportobj.Extreport.CreateTest("Search/View Award").Info("Core HR -> View and Search the added Award");
        corehrobj.ViewAddedAward();
       
        //screensSetup();
        //ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\9-AwardViewed.jpeg", ScreenshotImageFormat.Jpeg);

        reportobj.extTest.Log(Status.Pass, "Added award detail is viewed ");
    }

    //Test case 9 - Verify that the user can Delete the added award 
    [Test, Order(9)]    //, Ignore("Ignore this")]
    public void TC9_CoreHRDeleteAward()
    {
        reportobj.extTest = reportobj.Extreport.CreateTest("Delete Award").Info("Core HR -> Delete the added Award");
        
        val=corehrobj.DeleteAward();
        

        if (val=true)
        {
            reportobj.extTest.Log(Status.Fail, "Added award is deleted ");
            Assert.Fail();
        }
        else 
        {
            reportobj.extTest.Log(Status.Pass, "Added award is deleted ");
            Assert.Pass();
        }

        //screensSetup();
        //ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\10-AwardDeleted.jpeg", ScreenshotImageFormat.Jpeg);

        Dashboardopen();
        
        //extTest.Log(Status.Pass, "Added award is deleted ");
    }

    //Test case 10 - Verify that the user can logout from the HRMS site.
    [Test, Order(10)]
    public void TC10_HRMSLogout()
    {
        reportobj.extTest = reportobj.Extreport.CreateTest("Logout HRMS").Info("Logout from the HRMS app");
        logout22 =new HRMS_LOGOUT(driver);
        
        logout22.HRMSLogout();
       
        reportobj.extTest.Log(Status.Pass, "Logged out from the HRMS ");
    }


}

