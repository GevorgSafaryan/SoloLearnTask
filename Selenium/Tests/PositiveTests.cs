using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Selenium.Tests
{
    public class PositiveTests : BaseTest
    {
        [TestCase("python", 1, TestName = "Search results validation")]
        public void Test(string searchContext, int searchResultnumber)
        {
            HomePage.ClickOnStartLearningNow();
            HomePage.GoToDiscussSection();
            DiscussionsPage.MakeASearch(searchContext);
            DiscussionsPage.ClickOnSearchResult(searchResultnumber);
            Assert.Greater(PostPage.GetNumberOfAnswers(), 5);
        }
    }
}
