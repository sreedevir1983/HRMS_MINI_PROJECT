using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ChildWindowHandling
{
    //public IWebDriver driver;
    public void ChildWindows(IWebDriver driver)
    {
        List<string> child = driver.WindowHandles.ToList();

        string ch = child[1];
        driver.SwitchTo().Window(ch);
    }
    public void ControlBacktoParent(IWebDriver driver)
    {
        driver.SwitchTo().Window(driver.WindowHandles[0]);
    }

}

