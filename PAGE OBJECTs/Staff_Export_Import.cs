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

public class Staff_Export_Import
{
    IWebDriver driver;
    public Staff_Export_Import(IWebDriver driver)
    {
        PageFactory.InitElements(driver, this);
    }

    [FindsBy(How = How.XPath, Using = "//span[text()='Staff']")] IWebElement staff;
    [FindsBy(How = How.XPath, Using = "//a[text()=' Import Employees']")] IWebElement ImportEmployee;

    [FindsBy(How = How.XPath, Using = "//input[@id='file']")] IWebElement uploadbutton;
    [FindsBy(How = How.XPath, Using = "//button[text()=' Save']")] IWebElement savebutton;
    [FindsBy(How = How.XPath, Using = "//a[text()=' Download sample File ']")] IWebElement downloadbutton;
    
    public void StaffImportEmployee()
    {
        staff.Click();
        Thread.Sleep(1000);

        ImportEmployee.Click();
        Thread.Sleep(1000);

    }
    public void Uploadfile()
    {
        string uploadfilepath = @"C:\Users\srrajale\source\repos\HRMS-MINI PROJECT\HRMS-MINI PROJECT\UTILITIES\Company  Demo HRMS.csv";
        uploadbutton.SendKeys(uploadfilepath);

        Thread.Sleep(2000);
        savebutton.Click();
        Thread.Sleep(2000);
    }

    public void Downloadfile()
    {
        downloadbutton.Click();
        Thread.Sleep(2000);
    }

}

