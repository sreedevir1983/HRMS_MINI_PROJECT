using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HRMS_UserLogin
{
    IWebDriver driver;
    public HRMS_UserLogin(IWebDriver driver) 
    {
        PageFactory.InitElements(driver,this);
    }

    [FindsBy(How = How.XPath, Using = "//input[@id='iusername']")] IWebElement username;
    [FindsBy(How = How.XPath, Using = "//input[@id='ipassword']")] IWebElement password;
    [FindsBy(How = How.XPath, Using = "//button[text()=' Login']")] IWebElement loginbutton;

    public void UserLogin()
    {
        username.SendKeys("admin");
        Thread.Sleep(1000);
        password.SendKeys("123456");
        Thread.Sleep(2000);

        loginbutton.Click();
        Thread.Sleep(3000);
    }

}

