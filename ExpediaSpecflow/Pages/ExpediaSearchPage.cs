using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ExpediaSpecflow
{
    class ExpediaSearchPage
    {
        private IWebDriver driver;
        private Helpers Help = new Helpers(WebBrowser.Current);

#pragma warning disable 0649

        [FindsBy(How = How.Id, Using = FLIGHTS_BUTTON)]
        public IWebElement flightsButton;
        [FindsBy(How = How.Id, Using = ROUND_TRIP_BUTTON)]
        public IWebElement roundTripButton;
        [FindsBy(How = How.Id, Using = OROGIN_TEXT_FIELD)]
        public IWebElement originTextField;
        [FindsBy(How = How.Id, Using = DESTINATION_TEXT_FIELD)]
        public IWebElement destinationTextField;
        [FindsBy(How = How.Id, Using = DEPARTING_DATE_TEXT_FIELD)]
        public IWebElement departinDateTextField;
        [FindsBy(How = How.Id, Using = RETURNING_DATE_TEXT_FIELD)]
        public IWebElement returningDateTextField;
        [FindsBy(How = How.Id, Using = ADULTS_AMOUNT_TEXT_FIELD)]
        public IWebElement adultsAmountTextField;
        [FindsBy(How = How.Id, Using = CHILDREN_AMOUNT_TEXT_FIELD)]
        public IWebElement childrenAmountTextField;
        [FindsBy(How = How.Id, Using = SEARCH_BUTTON)]
        public IWebElement searchButton;

#pragma warning restore 0649

        public ExpediaSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void PressFlightsButton()
        {
            flightsButton.Click();
        }

        public void PressRoundTripButton()
        {
            roundTripButton.Click();
        }

        public void InputOriginCity(string orCity)
        {
            originTextField.Clear();
            originTextField.SendKeys(orCity);
            StringAssert.Contains(orCity, originTextField.GetAttribute("value"));
        }

        public void InputDestinationCity(string destCity)
        {
            destinationTextField.Clear();
            destinationTextField.SendKeys(destCity);
            StringAssert.Contains(destCity, destinationTextField.GetAttribute("value"));
        }

        public void InputDepartureDate(string depDate)
        {
            Help.JSExecutor("document.getElementById('flight-departing').value='" + depDate + "';");
            departinDateTextField.Click();
            Assert.AreEqual(depDate, departinDateTextField.GetAttribute("value"));
        }

        public void InputReturngDate(string retDate)
        {
            Help.JSExecutor("document.getElementById('flight-returning').value='" + retDate + "';");
            returningDateTextField.Click();            
            Assert.AreEqual(retDate, returningDateTextField.GetAttribute("value"));
        }

        public string InputRelativeDepartureDate(int days)
        {
            string depDate = DateTime.Now.AddDays(days).ToString("MM/dd/yyyy");
            Help.JSExecutor("document.getElementById('flight-departing').value='" + depDate + "';");
            departinDateTextField.Click();
            Assert.AreEqual(depDate, departinDateTextField.GetAttribute("value"));
            return depDate;
        }

        public string InputRelativeReturnDate(int days)
        {
            string retDate = DateTime.Now.AddDays(days).ToString("MM/dd/yyyy");
            Help.JSExecutor("document.getElementById('flight-returning').value='" + retDate + "';");
            returningDateTextField.Click();
            Assert.AreEqual(retDate, returningDateTextField.GetAttribute("value"));
            return retDate;
        }

        public void ChooseAdultsAmount(string adults)
        {
            adultsAmountTextField.SendKeys(adults);
            Assert.AreEqual(adults, adultsAmountTextField.GetAttribute("value"));
        }

        public void ChooseChildrenAmount(string children)
        {
            childrenAmountTextField.SendKeys(children);
            Assert.AreEqual(children, childrenAmountTextField.GetAttribute("value"));
        }

        public void PressSearchButton()
        {
            searchButton.Click();
        }

        public const string FLIGHTS_BUTTON = "tab-flight-tab";
        public const string ROUND_TRIP_BUTTON = "flight-type-roundtrip-label";
        public const string OROGIN_TEXT_FIELD = "flight-origin";
        public const string DESTINATION_TEXT_FIELD = "flight-destination";
        public const string DEPARTING_DATE_TEXT_FIELD = "flight-departing";
        public const string RETURNING_DATE_TEXT_FIELD = "flight-returning";
        public const string ADULTS_AMOUNT_TEXT_FIELD = "flight-adults";
        public const string CHILDREN_AMOUNT_TEXT_FIELD = "flight-children";
        public const string SEARCH_BUTTON = "search-button";
    }
}
