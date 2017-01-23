using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ExpediaSpecflow
{
    public class ExpediaHomePage
    {        
        private readonly IWebDriver driver;
        private readonly string url = @"http://www.expedia.com";
        private Helpers Help = new Helpers(WebBrowser.Current);

#pragma warning disable 0649

        [FindsBy(How = How.XPath, Using = EXPEDIA_HEADER_LOGO)]
        public IWebElement expediaHeaderLogo;

#pragma warning restore 0649

        public ExpediaHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Navigate to the site
        public void Navigate()
        {
            WebBrowser.Current.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        //Check that the Title is what we are expecting
        public void CheckHomePageTitle()
        {
            Help.WaitForClickable(By.XPath(EXPEDIA_HEADER_LOGO));        
            StringAssert.Contains("Expedia", driver.Title, "Title "+driver.Title+ "is not 'Expedia'");
        }

        public const string EXPEDIA_HEADER_LOGO = "//*[@id='header-logo']/img";
    }
}
