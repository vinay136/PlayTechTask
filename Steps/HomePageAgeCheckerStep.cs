using PayTechTask.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using BoDi;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow.Assist;
using System.Threading;

namespace PayTechTask.Steps
{
    [Binding]
    public sealed class HomePageAgeCheckerStep
    {
        private readonly ScenarioContext _scenarioContext;

        public HomePageAgeCheckerStep(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        HomeAgeCheckerPage homeAgeCheckerPage = null;

        [Given(@"I launch the PlayTech Application")]

        public void GivenILaunchThePlayTechApplication()
        {



            IWebDriver webDriver = new ChromeDriver(@"C:\Users\VChand\Downloads\chromedriver_win32 (1)");
            webDriver.Manage().Cookies.DeleteAllCookies(); //delete all cookies
            Thread.Sleep(7000); //wait 7 seconds to clear cookies

            webDriver.Navigate().GoToUrl("https://www.playtech.com/");
            homeAgeCheckerPage = new HomeAgeCheckerPage(webDriver);
        }

        [Given(@"I select My Age")]
        public void GivenISelectMyAge(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            homeAgeCheckerPage.AgeEntry(Convert.ToString(data.Day), Convert.ToString(data.Month), Convert.ToString(data.Year));
        }



        [Given(@"I Click on Enter Site CTA\.")]
        public void IClickOnEnterSiteCTA_()
        {
            homeAgeCheckerPage.ClickEnterSite();
        }




        [Then(@"I should See HomePage of PlayTech")]
        public void ThenIShouldSeeHomePageOfPlayTech()
        {
            Assert.That(homeAgeCheckerPage.IsloginButtondisplayed(), Is.True);
           
        }

        [Then(@"I should Not See HomePage of PlayTech")]
        public void ThenIShouldNotSeeHomePageOfPlayTech()
        {
            Assert.That(homeAgeCheckerPage.IsAlertTExtisdisplayed(), Is.True);
        }


    }
}
