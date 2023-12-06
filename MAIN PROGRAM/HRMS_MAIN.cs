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
    public Tickets_Handling tickethandle;
    public CoreHRMenu corehrobj;

    //public ITakesScreenshot Iss;
    //public Screenshot ss;

    public string EmployeeName;

    //OneTimeSetUp -> Report set up, Browser launch and Opening browser
    [OneTimeSetUp]
    public void LaunchSite()
    {
        ReportsHandling();
        OpenBrowser();
        screensSetup();
    }

    //OneTimeTearDown -> Browser close and Reports close
    [OneTimeTearDown]
    public void CloseDriver()
    {                
        BrowserClose();        
        BrowserQuit();
        CloseReport();
        //Extreport.Flush();
    }

    //Test Case 1- Verify that the user can login the site using valid credentials.
    [Test, Order(1)]
    public void TC1_HRMSLogin()
    {
        extTest = Extreport.CreateTest("Admin Login").Info("Login as Admin user");

        Adlogin=new HRMS_UserLogin(driver);
        Adlogin.UserLogin();
        Thread.Sleep(3000);
        screensSetup();
        ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\1-Dashboard1.jpeg",ScreenshotImageFormat.Jpeg);

        extTest.Log(Status.Info,"Logged in as Admin");

        Thread.Sleep(1000);
    }

    //Test Case 2- Verify the user can open the Employees page from Dashboard and Open the Employee report.
    [Test, Order(2)]
    public void TC2_HRMSDashboard()
    {
        extTest = Extreport.CreateTest("Employee Dashboard").Info("Go to Dashboard and Open Employee-> See reports");

        DEmp = new DashboardEmployee(driver);
        DEmp.EmployeeDash();
        DEmp.OpenReport();
        Thread.Sleep(3000);

        EmployeeReportsChildWindow();
        Thread.Sleep(2000);
        DEmp.Reportwindowhandle();

        screensSetup();
        ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\2-EMP_Report1.jpeg", ScreenshotImageFormat.Jpeg);
        Thread.Sleep(1000);

        EmpReportBacktoParent();
        Thread.Sleep(2000);

        Dashboardopen();
        Thread.Sleep(1000);

        extTest.Log(Status.Info, "Employee Opened from Dashboard and reports viewed ");
    }

    //Test Case 3- Verify the user can add a new Employee from Left menu -> Staff -> Employees.
    [Test,Order(3)]
    public void TC3_StaffEmployeeADD()
    {
        extTest = Extreport.CreateTest("Add New Employee ").Info("Staff-> Add new Employee");

        staffEmp =new STAFF_ADDEMP(driver);        
        Thread.Sleep(1000);

        staffEmp.StaffClick();
        Thread.Sleep(1000);

        staffEmp.StaffEmployye();
        Thread.Sleep(1000);
        screensSetup();
        ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\3-StaffEmployee.jpeg", ScreenshotImageFormat.Jpeg);
        
        Thread.Sleep(1000);
        EmployeeName= staffEmp.AddNewEmployee();
        Thread.Sleep(1000);
        screensSetup();
        ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\4-NewEmployeeForm.jpeg", ScreenshotImageFormat.Jpeg);

        Dashboardopen();
        Thread.Sleep(1000);

        extTest.Log(Status.Pass, "Employee Opened from Staff menu and added new Employee ");
    }

    //Test case 4 - Verify that the user can Export Employee file
    [Test,Order(4)]
    public void TC4_StaffExport()
    {
        extTest = Extreport.CreateTest("Employee Export").Info("Staff-> Export Employee file");

        StImpExp = new Staff_Export_Import(driver);
        StImpExp.StaffImportEmployee();
        StImpExp.Downloadfile();

        extTest.Log(Status.Pass, "Employee Data exported ");

    }

    //Test case 5 - Verify that the user can Import Employee file
    [Test, Order(5)]
    public void TC5_StaffImport()
    {
        extTest = Extreport.CreateTest("Employee Import").Info("Staff-> Import Employee file");

        StImpExp = new Staff_Export_Import(driver);
        StImpExp.Uploadfile();

        Dashboardopen();
        Thread.Sleep(1000);

        extTest.Log(Status.Pass, "Employee Data imported ");
    }

    //Test case 6 - Verify that the user can update the Profile details
    [Test, Order(6)]
    public void TC6_MyProUpdate()
    {
        profupd = new ProfileUpdate(driver);
        Thread.Sleep(1000);

        profupd.MyProfileUpdate();
        Thread.Sleep(2000);
        screensSetup();
        ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\6-ProfileUpdate.jpeg", ScreenshotImageFormat.Jpeg);
        Dashboardopen();

        Thread.Sleep(1000);
    }

    //Test case 7 - Verify that the user can Add an award through CoreHR menu
    [Test, Order(7)]
    public void TC7_CoreHRAddAward()
    {
        extTest = Extreport.CreateTest("Add Award").Info("Core HR -> Add a new award");
        corehrobj =new CoreHRMenu(driver);
        corehrobj.AwardListRead();
        corehrobj.CoreHRAward();
        Thread.Sleep(2000);
        screensSetup();
        ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\7-Award-NewAward.jpeg", ScreenshotImageFormat.Jpeg);

        corehrobj.addnewaward();
        Thread.Sleep(2000);
        screensSetup();
        ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\8-AwardAdded.jpeg", ScreenshotImageFormat.Jpeg);
        extTest.Log(Status.Pass, "Award is added for an employee ");
    }

    //Test case 8 - Verify that the user can Search and view teh added award
    [Test, Order(8)]
    public void TC8_CoreHRViewAward()
    {
        extTest = Extreport.CreateTest("Search/View Award").Info("Core HR -> View and Search the added Award");
        corehrobj.ViewAddedAward();
        Thread.Sleep(2000);
        screensSetup();
        ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\9-AwardViewed.jpeg", ScreenshotImageFormat.Jpeg);

        extTest.Log(Status.Pass, "Added award detail is viewed ");
    }

    //Test case 9 - Verify that the user can Delete the added award 
    [Test, Order(9)]
    public void TC9_CoreHRDeleteAward()
    {
        extTest = Extreport.CreateTest("Delete Award").Info("Core HR -> Delete the added Award");
        //corehrobj.ViewAddedAward();
        corehrobj.DeleteAward();
        Thread.Sleep(2000);
        screensSetup();
        ss.SaveAsFile("C:\\Users\\srrajale\\source\\repos\\HRMS-MINI PROJECT\\HRMS-MINI PROJECT\\SCREENSHOTS\\10-AwardDeleted.jpeg", ScreenshotImageFormat.Jpeg);


        Dashboardopen();
        Thread.Sleep(1000);

        extTest.Log(Status.Pass, "Added award is deleted ");
    }

    //Test case 10 - Verify that the user can logout from the HRMS site.
    [Test, Order(10)]
    public void TC10_HRMSLogout()
    {
        extTest = Extreport.CreateTest("Logout HRMS").Info("Logout from the HRMS app");
        logout22 =new HRMS_LOGOUT(driver);
        Thread.Sleep(1000);
        logout22.HRMSLogout();
        Thread.Sleep(1000);
        extTest.Log(Status.Pass, "Logged out from the HRMS ");
    }


}

