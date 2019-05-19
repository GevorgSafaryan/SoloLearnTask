using OpenQA.Selenium;
using Selenium.Engine;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Pages
{
    public class HomePage : WebPageCore
    {
        [FindsBy(How = How.LinkText, Using = "Start Learning Now")]
        private IWebElement StartLearningNow;
        [FindsBy(How = How.LinkText, Using = "DISCUSS")]
        private IWebElement Discuss;

        public HomePage()
        {
            PageFactory.InitElements(WebDriver, this);
        }

        public void ClickOnStartLearningNow()
        {
            StartLearningNow.Click();
        }

        public void GoToDiscussSection()
        {
            Discuss.Click();
        }
    }
}
