using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium.Chrome;

namespace Selenium.Engine
{
    public class WebPageCore
    {
        public string URL { get; set; }
        public string Browser { get; set; }
        public static IWebDriver WebDriver { get; set; }

        public void Init()
        {
            URL = ConfigurationManager.AppSettings["webSiteUrl"];
            Browser = ConfigurationManager.AppSettings["browser"];
            switch (Browser)
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--start-maximized", "disable-infobars");
                    WebDriver = new ChromeDriver(options);
                    WebDriver.Url = URL;
                    break;
                case "firefox":
                    break;
                case "explorer":
                    break;
                case "opera":
                    break;
                case "safari":
                    break;
                default:
                    throw new Exception("Usported browser");
            }
        }

        public void CleanUp()
        {
            WebDriver.Dispose();
        }
    }
}
