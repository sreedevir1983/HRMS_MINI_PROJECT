using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CloseBrowser
{
    IWebDriver driver;
    public CloseBrowser(IWebDriver driver)  
    {
        PageFactory.InitElements(driver,this);
    }
    public void BrowserClose()
    {
        Thread.Sleep(2000);
        driver.Close();
    }
    public void CloseReports()
    {
        Thread.Sleep(2000);
        driver.Close();
    }
}

