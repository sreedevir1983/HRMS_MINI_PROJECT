using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V117.DOM;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

public class CoreHRMenu
{
    public ArrayList AwardList;
    public int row, column;
    public IWebDriver driver;
    public string empname;


    public CoreHRMenu(IWebDriver driver)
    {
        PageFactory.InitElements(driver, this);
    }
    public void AwardListRead()
    {
        Excel.Application AwardExcelapp = new Excel.Application();
        Excel.Workbook AwardWorkbook = AwardExcelapp.Workbooks.Open(@"C:\Users\srrajale\source\repos\HRMS-MINI PROJECT\HRMS-MINI PROJECT\UTILITIES\AwardsList.xlsx");
        Excel._Worksheet AwardWorksheet = (Excel._Worksheet)AwardWorkbook.Sheets[1];
        Excel.Range AwardSheetRange = AwardWorksheet.UsedRange;

        row = AwardSheetRange.Rows.Count;
        column = AwardSheetRange.Columns.Count;

        AwardList = new ArrayList();

        for (int i = 2; i <= row; i++)
        {
            for (int j = 1; j <= column; j++)
            {
                AwardList.Add(AwardSheetRange.Cells[i, j].Value2.ToString());
            }
        }
        //return AwardList;
    }
    [FindsBy(How = How.XPath, Using = "//span[text()='Core HR']")] IWebElement LeftCoreHR;
    [FindsBy(How = How.XPath, Using = "//a[text()=' Awards ']")] IWebElement awardmenu;
    [FindsBy(How = How.XPath, Using = "//button[text()=' Add New']")] IWebElement addnewbutton;

    [FindsBy(How = How.XPath, Using = "//span[text()='Company']")] IWebElement companydrop;
    [FindsBy(How = How.XPath, Using = "//li[text()='CRROTHRM']")] IWebElement companydropvalue;

    [FindsBy(How = How.XPath, Using = "//span[text()='Choose an Employee']")] IWebElement employeedrop;
    //[FindsBy(How = How.XPath, Using = "//li[text()=' John Smith']")] IWebElement employeedropvalue;
    [FindsBy(How = How.XPath, Using = "(//li[@class='select2-results__option'])[2]")] IWebElement employeedropvalue;
    
    [FindsBy(How = How.XPath, Using = "//span[text()='Award Type']")] IWebElement awardtypedrop;
    [FindsBy(How = How.XPath, Using = "//li[text()='Performer of the Year']")] IWebElement awardtypedropvalue;

    [FindsBy(How = How.XPath, Using = "//input[@name='award_date']")] IWebElement awarddatepicker;
    [FindsBy(How = How.XPath, Using = "//select[@class='ui-datepicker-year']")] IWebElement awarddateyear;
    [FindsBy(How = How.XPath, Using = "//select[@class='ui-datepicker-month']")] IWebElement awarddatemonth;
    [FindsBy(How = How.XPath, Using = "//a[text()='11']")] IWebElement awarddateday;

    [FindsBy(How = How.XPath, Using = "//textarea[@name='description']")] IWebElement awarddescription;

    [FindsBy(How = How.XPath, Using = "//input[@name='month_year']")] IWebElement awardmonthyear;
    [FindsBy(How = How.XPath, Using = "//select[@class='ui-datepicker-year']")] IWebElement awardyear;
    [FindsBy(How = How.XPath, Using = "//select[@class='ui-datepicker-month']")] IWebElement awardmonth;
    [FindsBy(How = How.XPath, Using = "//button[text()='Done']")] IWebElement monthyeardone;

    [FindsBy(How = How.XPath, Using = "//input[@name='gift']")] IWebElement awardgift;
    [FindsBy(How = How.XPath, Using = "//input[@name='cash']")] IWebElement awardcash;
    [FindsBy(How = How.XPath, Using = "//input[@name='award_picture']")] IWebElement awardpicture;
    [FindsBy(How = How.XPath, Using = "//textarea[@name='award_information']")] IWebElement awardinfo;
    [FindsBy(How = How.XPath, Using = "//input[@name='asd']")] IWebElement awardFRT;
    [FindsBy(How = How.XPath, Using = "//button[text()=' Save']")] IWebElement awardsave;

           
    public void CoreHRAward()
    {
        Thread.Sleep(2000);
        LeftCoreHR.Click();
        Thread.Sleep(2000);

        awardmenu.Click();
        Thread.Sleep(2000);

        addnewbutton.Click();
        Thread.Sleep(2000);
    }

    public void addnewaward()
    {
        companydrop.Click();
        companydropvalue.Click();
        Thread.Sleep(4000);

        employeedrop.Click();
        empname = employeedropvalue.Text;
        //employeedropvalue.SendKeys(EmpName1);
        //employeedrop.SendKeys(EmpName1);

        Console.WriteLine(empname);
        employeedropvalue.Click();        

        Thread.Sleep(2000);

        awardtypedrop.Click();
        awardtypedropvalue.Click();
        Thread.Sleep(2000);

        //Date
        awarddatepicker.Click();
        SelectElement awardY = new SelectElement(awarddateyear);
        awardY.SelectByValue("2023");
        SelectElement awardM = new SelectElement(awarddatemonth);
        awardM.SelectByValue("11");
        awarddateday.Click();
        Thread.Sleep(2000);

        awarddescription.SendKeys(Convert.ToString(AwardList[4]));
        Thread.Sleep(2000);
        //dateyear
        awardmonthyear.Click();
        Thread.Sleep(2000);
        SelectElement AYear = new SelectElement(awardyear);
        AYear.SelectByValue("2023");
        SelectElement AMonth = new SelectElement(awardmonth);
        AMonth.SelectByValue("11");
        monthyeardone.Click();
        Thread.Sleep(2000);

        awardgift.SendKeys(Convert.ToString(AwardList[6]));
        awardcash.SendKeys(Convert.ToString(AwardList[7]));
        Thread.Sleep(2000);

        string awardpickpath = @"C:\Users\srrajale\source\repos\HRMS-MINI PROJECT\HRMS-MINI PROJECT\UTILITIES\PerformerAward.jpg";
        awardpicture.SendKeys(awardpickpath);
        Thread.Sleep(2000);

        awardinfo.SendKeys(Convert.ToString(AwardList[9]));
        awardFRT.SendKeys(Convert.ToString(AwardList[10]));
        Thread.Sleep(2000);

        awardsave.Click();
        Thread.Sleep(2000);
    }
    [FindsBy(How = How.XPath, Using = "//input[@type='search']")] IWebElement awardsearch;
    [FindsBy(How = How.XPath, Using = "//span[@class='fa fa-eye']")] IWebElement awardsview;
    [FindsBy(How = How.XPath, Using = "//button[text()='Close']")] IWebElement awardsclose;

    //div[contains(text(),'Showing 0 to 0 of 0 entries')]
    public void ViewAddedAward()
    {
        awardsearch.SendKeys(empname);
        Thread.Sleep(4000);

        awardsview.Click();
        Thread.Sleep(4000);

        awardsclose.Click();
        Thread.Sleep(4000);
                
    }

    [FindsBy(How = How.XPath, Using = "//span[@class='fa fa-trash']")] IWebElement awardsdelete;
    [FindsBy(How = How.XPath, Using = "//button[text()=' Confirm']")] IWebElement deleteconfirm;
    [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Showing 0 to 0 of 0 entries')]")] IWebElement norecord;
    public void DeleteAward()
    {
        awardsdelete.Click();
        Thread.Sleep(3000);

        deleteconfirm.Click();
        Thread.Sleep(3000);

        awardsearch.Clear();
        Thread.Sleep(2000);

        awardsearch.SendKeys(empname);
        Thread.Sleep(4000);

        if (norecord.Displayed) 
        {
            Console.WriteLine("Delete Award successful!");
            Assert.Pass();
        }
        else 
        {
            Console.WriteLine("Record still exists!");
            Assert.Fail();
        }

    }
}
