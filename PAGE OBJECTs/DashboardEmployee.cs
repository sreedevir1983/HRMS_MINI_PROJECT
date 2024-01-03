using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class DashboardEmployee
{
    IWebDriver driver;
    public bool bool1;
    public DashboardEmployee(IWebDriver driver) 
    {
        PageFactory.InitElements(driver,this);
    }

    [FindsBy(How = How.XPath, Using = "//small[text()='Employees']")] IWebElement EmpDash;
    public void EmployeeDash()
    {
        Thread.Sleep(1000);
        EmpDash.Click();

    }

    [FindsBy(How = How.XPath, Using = "//button[text()=' Report ']")] IWebElement Ereport;
    [FindsBy(How = How.XPath, Using = "//a[text()='Employement Report']")] IWebElement drop1;
    public void OpenReport()
    {
        //Thread.Sleep(1000);
        Ereport.Click();
        
        //Thread.Sleep(2000);
        drop1.Click();
        //Thread.Sleep(3000);

    }
    [FindsBy(How = How.XPath, Using = "//span[@id='select2-aj_company-container']")] IWebElement Companydrop;
    [FindsBy(How = How.XPath, Using = "//li[text()='CRROTHRM']")] IWebElement Companydropvalue;
    [FindsBy(How = How.XPath, Using = "//button[text()=' Get ']")] IWebElement getButton;
    [FindsBy(How = How.XPath, Using = "//li[text()='Employees Report']")] IWebElement EmpReportPage;

    public bool Reportwindowhandle()
    {
        if (EmpReportPage.Text== "Employees Report")
        {
            bool1 = true;
            Companydrop.Click();
            //Thread.Sleep(2000);

            Companydropvalue.Click();
            //Thread.Sleep(2000);

            getButton.Click();
            //Thread.Sleep(4000);

        }
        else 
        {
            bool1 = false;
        }
        return bool1;

    }
    
}
