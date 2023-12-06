using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ScreenshotsHandles
{
    IWebDriver driver;



    public ScreenshotsHandles(IWebDriver driver)
    {
        PageFactory.InitElements(driver,this);
    }



}
