
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;


public class Tickets_Handling
{
    public IWebDriver driver;
    //public Actions act;
    public Tickets_Handling(IWebDriver driver)
    {
        PageFactory.InitElements(driver, this);
    }

    [FindsBy(How = How.XPath, Using = "//div[@class='slimScrollBar']")] IWebElement leftscroll;
    [FindsBy(How = How.XPath, Using = "//span[text()='Tickets']")] IWebElement Ticketsclick;
    [FindsBy(How = How.XPath, Using = "(//span[@class='fa fa-arrow-circle-right'])[1]")] IWebElement ViewTicket1;
    [FindsBy(How = How.XPath, Using = "//textarea[@name='remarks']")] IWebElement remarkupdate;
    [FindsBy(How = How.XPath, Using = "(//button[text()=' Save '])[2]")] IWebElement remarksSave;

    [FindsBy(How = How.XPath, Using = "(//span[@class='fa fa-pencil'])[1]")] IWebElement EditTicket1;
    [FindsBy(How = How.XPath, Using = "(//span[@class='select2-selection__rendered'])[6]")] IWebElement EditPriority;
    [FindsBy(How = How.XPath, Using = "//li[text()='High']")] IWebElement PriorityHigh;
    [FindsBy(How = How.XPath, Using = "//button[text()='Update']")] IWebElement Updatebutton;
    


    public void clickTickets()
    {
        Console.WriteLine("clickTtickets");
        Ticketsclick.Click();
        Thread.Sleep(3000);

    }
    public void TicketsView()
    {
        ViewTicket1.Click();
        Thread.Sleep(3000);        
    }

    public void UpdateRemarks()
    {
        remarkupdate.SendKeys("Remarks test1");
        remarksSave.Click();
        Thread.Sleep(2000);       
    }

    public void ticketEdit()
    {
        EditTicket1.Click();
        Thread.Sleep(3000);

        List<string> child = driver.WindowHandles.ToList();

        string ch = child[1];
        driver.SwitchTo().Window(ch);

        EditPriority.Click();
        Thread.Sleep(1000);
        PriorityHigh.Click();
        Thread.Sleep(3000);
        Updatebutton.Click();
        Thread.Sleep(1000);

    }


}

