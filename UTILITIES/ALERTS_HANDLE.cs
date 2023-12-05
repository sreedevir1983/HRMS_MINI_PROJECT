using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ALERTS_HANDLE:DriverSetup
{
    public void AwardDELETEALert()
    {
        IAlert alert = driver.SwitchTo().Alert();
        Console.WriteLine(alert.Text);
        Thread.Sleep(1000);
        alert.Accept();
        Thread.Sleep(5000);
    }
}

