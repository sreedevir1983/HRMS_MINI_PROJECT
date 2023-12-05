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
    public ITakesScreenshot screenshot;
    Screenshot scr;
    public ScreenshotsHandles(IWebDriver driver)
    {
        PageFactory.InitElements(driver,this);
    }



}
