using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Pages
{
    public class DiscussionsPage : HomePage
    {
        [FindsBy(How = How.Id, Using = "tagsInput")]
        private IWebElement SearchBox;
        [FindsBy(How = How.ClassName, Using = "submitSearch")]
        private IWebElement Submit;
        [FindsBy(How = How.XPath, Using = "//div[@id = 'questions']//div[@class = 'postDetails']//a")]
        private IList<IWebElement> Posts;
        public void MakeASearch(string searchContext)
        {
            SearchBox.Clear();
            SearchBox.SendKeys(searchContext);
            Submit.Click();
        }

        public void ClickOnSearchResult(int searchResultnumber)
        {
            Posts[searchResultnumber - 1].Click();
        }
    }
}
