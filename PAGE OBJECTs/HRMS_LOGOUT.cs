using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HRMS_LOGOUT
{
    IWebDriver driver;
    public HRMS_LOGOUT(IWebDriver driver) 
    {
        PageFactory.InitElements(driver,this);
    }

    [FindsBy(How = How.XPath, Using = "(//i[@class='fa fa-power-off'])[2]")] IWebElement logout;

    public void HRMSLogout()
    {
        Thread.Sleep(3000);
        logout.Click(); 

    }

}

