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

public class ProfileUpdate 
{
    public IWebDriver driver;
    
    public ProfileUpdate(IWebDriver driver)
    {
        PageFactory.InitElements(driver, this);
    }

    [FindsBy(How = How.XPath, Using = "//img[@class='user-image-top']")] IWebElement profilePic;
    [FindsBy(How = How.XPath, Using = "//a[text()='My Profile']")] IWebElement myProfile;
    [FindsBy(How = How.XPath, Using = "//input[@name='contact_no']")] IWebElement contactnumber;
    [FindsBy(How = How.XPath, Using = "//button[text()=' Save']")] IWebElement savebutton;

    public void MyProfileUpdate()
    {
        profilePic.Click();
        Thread.Sleep(1000);

        myProfile.Click();
        Thread.Sleep(1000);

        contactnumber.Clear();
        Thread.Sleep(2000);
        contactnumber.SendKeys("4567843201");
        Thread.Sleep(1000);

        savebutton.Click();
        Thread.Sleep(5000);

    }

}

