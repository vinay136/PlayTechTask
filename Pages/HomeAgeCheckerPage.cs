using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace PayTechTask.Pages
{
    [Binding]
    public class HomeAgeCheckerPage
    {
        public IWebDriver WebDriver { get; }

        public HomeAgeCheckerPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        //Ui Elements

        public IWebElement DayDropDownElement => WebDriver.FindElement(By.Name("day"));
        public IWebElement MonthDropDownElement => WebDriver.FindElement(By.Name("month"));
        public IWebElement YearDropDownElement => WebDriver.FindElement(By.Name("year"));
        
        public IWebElement EnterSiteElement => WebDriver.FindElement(By.XPath("//*[@id='age-verification']/div[1]/div/div/div[2]/div[4]/button"));
        public IWebElement LoginCTA => WebDriver.FindElement(By.XPath("//a[text()='Log in']"));
        
        public IWebElement UnderAgeAlertText => WebDriver.FindElement(By.XPath("//span[text()='Sorry you must be over 18 to enter.']"));


        public void AgeEntry(string day, string month, string year)
        {


            SelectElement SelectDay = new SelectElement(DayDropDownElement);
            SelectDay.SelectByValue(day);
            SelectElement Selectmonth = new SelectElement(MonthDropDownElement);
            Selectmonth.SelectByValue(month);
            SelectElement SelectYear = new SelectElement(YearDropDownElement);
            SelectYear.SelectByValue(year);

        }

        public void ClickEnterSite() => EnterSiteElement.Click();
        public bool IsloginButtondisplayed() => LoginCTA.Displayed;
        public bool IsAlertTExtisdisplayed() => UnderAgeAlertText.Displayed;

    }
}
