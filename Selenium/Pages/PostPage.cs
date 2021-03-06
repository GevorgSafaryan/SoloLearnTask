﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.Pages
{
    public class PostPage : HomePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@id = 'discussionPost']//p[@class = 'answersCount']//span[@class = 'count']")]
        private IWebElement Answers;

        public int GetNumberOfAnswers()
        {
            return int.Parse(Answers.Text);
        }
    }
}
