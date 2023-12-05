using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

public class STAFF_ADDEMP : NewEmployeeExcelData
{
    IWebDriver driver;
    public string empName;
    int r, c;
    public STAFF_ADDEMP(IWebDriver driver) 
    {
        PageFactory.InitElements(driver,this);
    }

    [FindsBy(How = How.XPath, Using = "//span[text()='Staff']")] IWebElement staff;
    [FindsBy(How = How.XPath, Using = "//a[text()=' Employees']")] IWebElement employee;
    [FindsBy(How = How.XPath, Using = " //button[text()=' Add New']")] IWebElement AddnewEmp;

    [FindsBy(How = How.XPath, Using = "//input[@name='first_name']")] IWebElement firstname;
    [FindsBy(How = How.XPath, Using = "//input[@name='last_name']")] IWebElement lastname;
    [FindsBy(How = How.XPath, Using = "//span[@id='select2-aj_company-container']")] IWebElement Company;
    [FindsBy(How = How.XPath, Using = "//li[text()='CRROTHRM']")] IWebElement CompanyValue;
    [FindsBy(How = How.XPath, Using = "//span[text()='Location']")] IWebElement Location;
    [FindsBy(How = How.XPath, Using = "//li[text()='Chennai Branch']")] IWebElement LocationValue;

    [FindsBy(How = How.XPath, Using = "//span[text()='Select Department']")] IWebElement Department;
    [FindsBy(How = How.XPath, Using = "//li[text()='Accounts and  Finances']")] IWebElement DepartmentValue;
    //[FindsBy(How = How.XPath, Using = "//span[@id='select2-designation_id-0u-container']")] IWebElement Designation;
    [FindsBy(How = How.XPath, Using = "//span[text()='Designation']")] IWebElement Designation;
    [FindsBy(How = How.XPath, Using = "//li[text()='Developer']")] IWebElement DesignationValue;

    [FindsBy(How = How.XPath, Using = "//input[@name='username']")] IWebElement username;
    [FindsBy(How = How.XPath, Using = "//input[@name='email']")] IWebElement email;

    [FindsBy(How = How.XPath, Using = "//input[@name='date_of_birth']")] IWebElement dateofbirth;
    [FindsBy(How = How.XPath, Using = "//select[@class='ui-datepicker-year']")] IWebElement DOBYear;
    [FindsBy(How = How.XPath, Using = "//select[@class='ui-datepicker-month']")] IWebElement DOBMonth;
    [FindsBy(How = How.XPath, Using = "//a[text()='18']")] IWebElement DOBDay;

    [FindsBy(How = How.XPath, Using = "//input[@name='contact_no']")] IWebElement ContactNum;
    [FindsBy(How = How.XPath, Using = "//input[@name='employee_id']")] IWebElement EMPID;

    [FindsBy(How = How.XPath, Using = "//input[@name='date_of_joining']")] IWebElement dateofjoining;
    [FindsBy(How = How.XPath, Using = "//select[@class='ui-datepicker-year']")] IWebElement DOJYear;
    [FindsBy(How = How.XPath, Using = "//select[@class='ui-datepicker-month']")] IWebElement DOJMonth;
    [FindsBy(How = How.XPath, Using = "//a[text()='3']")] IWebElement DOJDay;

    [FindsBy(How = How.XPath, Using = "(//span[@class='select2-selection__arrow'])[9]")] IWebElement Gender;
    [FindsBy(How = How.XPath, Using = "//li[text()='Female']")] IWebElement female;

    [FindsBy(How = How.XPath, Using = "(//span[@class='select2-selection__arrow'])[10]")] IWebElement OfficeShift;
    [FindsBy(How = How.XPath, Using = "//li[text()='Morning Shift']")] IWebElement MorningShift;
    [FindsBy(How = How.XPath, Using = "//input[@name='password']")] IWebElement password;
    [FindsBy(How = How.XPath, Using = "//input[@name='confirm_password']")] IWebElement confirmpassword;

    [FindsBy(How = How.XPath, Using = "(//span[@class='select2-selection__arrow'])[11]")] IWebElement Roledrop;
    [FindsBy(How = How.XPath, Using = "//li[text()='Admin']")] IWebElement roledrop1;

    [FindsBy(How = How.XPath, Using = "//span[@class='select2-selection select2-selection--multiple']")] IWebElement LeaveCatDrop;
    [FindsBy(How= How.XPath, Using = "//li[text()='Casual Leave']")] IWebElement LeaveCatedrop1;
    [FindsBy(How = How.XPath, Using = "//li[text()='Medical']")] IWebElement LeaveCatedrop2;

    [FindsBy(How = How.XPath, Using = "//input[@name='address']")] IWebElement address;
    [FindsBy(How = How.XPath, Using = "(//button[@name='hrsale_form'])[2]")] IWebElement savebutton;

    public void StaffClick()
    {
        Thread.Sleep(2000);
        staff.Click();
        //staff.Click();
    }

    public void StaffEmployye()
    { 
        Thread.Sleep(2000);
        employee.Click();

        Thread.Sleep(1000);        
    }

    public string AddNewEmployee() 
    {
        AddnewEmp.Click();
        Thread.Sleep(3000);
      
        //NewEmpdata = new NewEmployeeExcelData();
        ArrayList NewEmplist = new ArrayList();

        NewEmplist = NewEmployeeRead();

        firstname.SendKeys(Convert.ToString(NewEmplist[0]));
        Thread.Sleep(2000);
        lastname.SendKeys(Convert.ToString(NewEmplist[1]));
        Thread.Sleep(2000);

        empName = Convert.ToString(NewEmplist[0]) +" "+ Convert.ToString(NewEmplist[1]);
        Console.WriteLine(empName);

        Company.Click();
        //Company.SendKeys(Convert.ToString(NewEmplist[2]));
        CompanyValue.Click();
        Thread.Sleep(2000);

        Location.Click();
        LocationValue.Click();
        Thread.Sleep(2000);

        username.SendKeys(Convert.ToString(NewEmplist[4]));
        Thread.Sleep(2000);
        email.SendKeys(Convert.ToString(NewEmplist[5]));
            Thread.Sleep(2000);

        //Date of Birth
        dateofbirth.Click();

        SelectElement dobY = new SelectElement(DOBYear);
        dobY.SelectByValue("2013");
        Thread.Sleep(1000);

        SelectElement dobM = new SelectElement(DOBMonth);
        dobM.SelectByValue("5");
        Thread.Sleep(1000);

        DOBDay.Click();
        Thread.Sleep(1000);//

        ContactNum.SendKeys(Convert.ToString(NewEmplist[7]));
        EMPID.SendKeys(Convert.ToString(NewEmplist[8]));

        //Date of joining
        dateofjoining.Click();

        SelectElement dojY = new SelectElement(DOJYear);
        dojY.SelectByValue("2023");
        Thread.Sleep(1000);

        SelectElement dojM = new SelectElement(DOJMonth);
        dojM.SelectByValue("6");
        Thread.Sleep(1000);

        DOJDay.Click();
        Thread.Sleep(1000);
        //
        Department.Click();
        DepartmentValue.Click();
        Thread.Sleep(1000);

        Designation.Click();
        DesignationValue.Click();
        Thread.Sleep(1000);

        Gender.Click();
        Thread.Sleep(1000);
        female.Click();
        Thread.Sleep(1000);

        OfficeShift.Click();
        MorningShift.Click();
        Thread.Sleep(1000);

        password.SendKeys(Convert.ToString(NewEmplist[14])); 
        confirmpassword.SendKeys(Convert.ToString(NewEmplist[15])); 

        Roledrop.Click();
        roledrop1.Click();
        Thread.Sleep(1000);

        LeaveCatDrop.Click();
        LeaveCatedrop1.Click();
        Thread.Sleep(1000);

        LeaveCatDrop.Click();
        LeaveCatedrop2.Click();
        Thread.Sleep(1000);

        address.SendKeys(Convert.ToString(NewEmplist[18]));
        Thread.Sleep(1000);

        savebutton.Click();
        Thread.Sleep(10000);

        return (empName);
     /*   firstname.SendKeys("Sreedevi");
        lastname.SendKeys("R");
        Company.Click();
        CompanyValue.Click();

        username.SendKeys("sreedevir");
        email.SendKeys("sreetest@gmail.com");
        Thread.Sleep(2000);
        //Date of Birth
        dateofbirth.Click();

        SelectElement dobY = new SelectElement(DOBYear);
        dobY.SelectByValue("2013");
        Thread.Sleep(1000);

        SelectElement dobM = new SelectElement(DOBMonth);
        dobM.SelectByValue("5");
        Thread.Sleep(1000);

        DOBDay.Click();
        Thread.Sleep(1000);
        

        ContactNum.SendKeys("9898989898");
        EMPID.SendKeys("sree2023");

        //Date of joining
        dateofjoining.Click();

        SelectElement dojY = new SelectElement(DOJYear);
        dojY.SelectByValue("2013");
        Thread.Sleep(1000);

        SelectElement dojM = new SelectElement(DOJMonth);
        dojM.SelectByValue("5");
        Thread.Sleep(1000);

        DOJDay.Click();
        Thread.Sleep(1000);
        //
        Gender.Click();
        female.Click();

        OfficeShift.Click();
        MorningShift.Click();
        Thread.Sleep(1000);

        password.SendKeys("Sreepass@123");
        confirmpassword.SendKeys("Sreepass@123");

        Roledrop.Click();
        roledrop1.Click();
        Thread.Sleep(1000);

        LeaveCatDrop.Click();
        LeaveCatedrop1.Click();

        address.SendKeys("street1, Location1, District1, State1, 695555");
        Thread.Sleep(1000);
     */
     
    }


    /*public void AddNewEmployee() 
    {
        AddnewEmp.Click();
        Thread.Sleep(3000);

        firstname.SendKeys("Ameyaa");
        lastname.SendKeys("AS");

        Thread.Sleep(1000);
        Company.Click();
        Thread.Sleep(1000);
        CompanyValue.Click();

        //Date of Birth
        SelectElement dobY = new SelectElement(DOBYear);
        dobY.SelectByValue("2013");
        Thread.Sleep(1000);

        SelectElement dobM = new SelectElement(DOBMonth);
        dobM.SelectByValue("5");
        Thread.Sleep(1000);

        DOBDay.Click();
        Thread.Sleep(1000);

        //Date of joining
        SelectElement dojY = new SelectElement(DOJYear);
        dojY.SelectByValue("2013");
        Thread.Sleep(1000);

        SelectElement dojM = new SelectElement(DOJMonth);
        dojM.SelectByValue("5");
        Thread.Sleep(1000);

        DOJDay.Click();
        Thread.Sleep(1000);
    

    }*/

}

