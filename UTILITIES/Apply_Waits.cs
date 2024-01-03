using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

public class Apply_Waits : DriverSetup
{
    public void ImplicitWaitHandling()
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
    }
    public void ExplicitWaitHandling(string loc)
    {
        WebDriverWait w = new WebDriverWait(driver,TimeSpan.FromSeconds(15));
        w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(loc)));

    }

}

