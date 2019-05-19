using Selenium.Pages;

namespace Selenium.Engine
{
    public class PageObjectsFactory : WebPageCore
    {
        public HomePage HomePage
        {
            get
            {
                return new HomePage();
            }
        }

        public PostPage PostPage
        {
            get
            {
                return new PostPage();
            }
        }

        public DiscussionsPage DiscussionsPage
        {
            get
            {
                return new DiscussionsPage();
            }
        }
    }
}
