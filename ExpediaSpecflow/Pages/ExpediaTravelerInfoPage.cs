using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ExpediaSpecflow
{
    class ExpediaTravelerInfoPage
    {
        private IWebDriver driver;
        private Helpers Help = new Helpers(WebBrowser.Current);

#pragma warning disable 0649

        [FindsBy(How = How.Id, Using = "firstname[0]")]
        public IWebElement firstNameTextBox;
        [FindsBy(How = How.Id, Using = "middlename[0]")]
        public IWebElement middleNameTextBox;
        [FindsBy(How = How.Id, Using = "lastname[0]")]
        public IWebElement lastNameTextBox;
        [FindsBy(How = How.Id, Using = "country_code[0]")]
        public IWebElement countryCodeList;
        [FindsBy(How = How.Id, Using = "phone-number[0]")]
        public IWebElement phoneNumberTextBox;
        [FindsBy(How = How.Id, Using = "passport[0]")]
        public IWebElement countryPassport;
        [FindsBy(How = How.Id, Using = "continue-booking")]
        public IWebElement buttonContinueBooking;
        [FindsBy(How = How.ClassName, Using = "origin-destination-city")]
        public IWebElement originDestinationCity;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[3]/div/div[1]/span")]
        public IWebElement departureDateFlyTo;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[4]/div/div[1]/span")]
        public IWebElement departureDateFlyFrom;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[3]/div/div[1]/span")]
        public IWebElement departureAirportCodeFlyTo;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[4]/div/div[1]/span")]
        public IWebElement arrivalAirportCodeFlyTo;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[4]/div/div[2]/span[1]")]
        public IWebElement departureAirportCodeFlyFrom;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[4]/div/div[2]/span[5]")]
        public IWebElement arrivalAirportCodeFlyFrom;
        [FindsBy(How = How.ClassName, Using = "toggle-passenger")]
        public IList<IWebElement> adultsChildrenTicketAmount;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[3]/div/div[2]/span[2]")]
        public IWebElement departureTimeFlyTo;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[3]/div/div[2]/span[6]")]
        public IWebElement arrivalTimeFlyTo;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[4]/div/div[2]/span[2]")]
        public IWebElement departureTimeFlyFrom;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[4]/div/div[2]/span[6]")]
        public IWebElement arrivalTimeFlyFrom;
        [FindsBy(How = How.Id, Using = "totalPriceForTrip")]
        public IWebElement totalTicketsCost;
        [FindsBy(How = How.Id, Using = "title[0]")]
        public IWebElement titleDropDown;
        [FindsBy(How = How.CssSelector, Using = CHECK_TREVELER_INFO_PAGE_LOAD)]
        public IWebElement checkTravelerInfoPageLoad;

#pragma warning restore 0649

        public ExpediaTravelerInfoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void InsertTitle(string title)
        {
            try
            {
                Help.SelectFromDropMenu(titleDropDown, title);
                Assert.AreEqual(title, Help.JSExecutorReturn("return $('.title-id-name > option:selected').text()").ToString().Replace(" ", ""));
            }
            catch (NoSuchElementException) { }
        }


        public void InsertFirstName(string name)
        {
            //Help.JSExecutor("$('#firstname[0]').value='" + name + "';");
            firstNameTextBox.Click();
            firstNameTextBox.SendKeys(name);
            Assert.AreEqual(name, firstNameTextBox.GetAttribute("value"));
        }

        public void InsertMiddleName(string middle)
        {
            middleNameTextBox.Click();
            middleNameTextBox.SendKeys(middle);
            Assert.AreEqual(middle, middleNameTextBox.GetAttribute("value"));
        }

        public void InsertLastName(string lastname)
        {
            lastNameTextBox.Click();
            lastNameTextBox.SendKeys(lastname);
            Assert.AreEqual(lastname, lastNameTextBox.GetAttribute("value"));
        }

        public void InsertCountryCode(string code)
        {
            Help.SelectFromDropMenu(countryCodeList, code);
            StringAssert.Contains(code, Help.JSExecutorReturn("return $('[id=\"country_code[0]\"] option:selected').text();").ToString());

        }

        public void InsertPhoneNumber(string number)
        {
            phoneNumberTextBox.SendKeys(number);
            Assert.AreEqual(number, phoneNumberTextBox.GetAttribute("value"));
        }

        public void InsertCountryPassport(string passport)
        {
            Help.SelectFromDropMenu(countryPassport, passport);
            StringAssert.Contains(passport, Help.JSExecutorReturn("return $('[id=\"passport[0]\"] option:selected').text();").ToString());
        }

        public void PressButtonContinue()
        {
            buttonContinueBooking.Click();
        }

        public void CheckTravelerInfoPageLoad()
        {
            Help.WaitForVisible(By.CssSelector(CHECK_TREVELER_INFO_PAGE_LOAD));
            StringAssert.Contains("Who's traveling", checkTravelerInfoPageLoad.Text);
        }

        public const string CHECK_TREVELER_INFO_PAGE_LOAD = "h2[class='faceoff-module-title']";
    }
}
