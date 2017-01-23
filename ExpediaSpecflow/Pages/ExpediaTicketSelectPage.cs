using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;

namespace ExpediaSpecflow
{
    class ExpediaTicketSelectPage
    {
        private IWebDriver driver;
        private Helpers Help = new Helpers(WebBrowser.Current);        

#pragma warning disable 0649

        [FindsBy(How = How.XPath, Using = CHEAPEST_BUTTON)]
        public IWebElement cheapestButton;
        [FindsBy(How = How.Id, Using = "flight-wizard-search-button")]
        public IWebElement searchWithChangedInfo;
        [FindsBy(How = How.Id, Using = "departure-date-1")]
        public IWebElement departureDate;
        [FindsBy(How = How.Id, Using = "return-date-1")]
        public IWebElement returnDate;
        [FindsBy(How = How.XPath, Using = "//h3[contains(text(), 'Result 1,')]")]
        public IWebElement cheapestTicketValue;
        [FindsBy(How = How.Id, Using = POP_UP_EMAIL_SING_UP_CLOSE)]
        public IWebElement popUpEmailSingUpClose;
        [FindsBy(How = How.XPath, Using = DEPARTURE_TIME)]
        public IWebElement departureTimeFlyTo;
        [FindsBy(How = How.XPath, Using = RETURN_TIME)]
        public IWebElement arrivalTimeFlyTo;
        [FindsBy(How = How.XPath, Using = DEPARTURE_TIME)]
        public IWebElement departureTimeFlyFrom;
        [FindsBy(How = How.XPath, Using = RETURN_TIME)]
        public IWebElement arrivalTimeFlyFrom;
        [FindsBy(How = How.Id, Using = NO_THANKS_POP_UP)]
        public IWebElement noThanksPopUp;
        [FindsBy(How = How.ClassName, Using = CHECK_DEPARTURE_SELECT_TICKET_PAGE_LOAD)]
        public IWebElement checkDepurtureSelectTicketPageLoad;
        [FindsBy(How = How.ClassName, Using = CHECK_RETURNING_SELECT_TICKET_PAGE_LOAD)]
        public IWebElement checkReturningSelectTicketPageLoad;
        [FindsBy(How = How.ClassName, Using = "title-date-rtv")]
        public IWebElement departureDateFlyTo;
        [FindsBy(How = How.ClassName, Using = "title-date-rtv")]
        public IWebElement departureDateFlyFrom;
        [FindsBy(How = How.ClassName, Using = "title-city-text")]
        public IWebElement arrivalCityFlyTo;
        [FindsBy(How = How.ClassName, Using = "title-city-text")]
        public IWebElement arrivalCityFlyFrom;
        [FindsBy(How = How.Id, Using = "departure-airport-1")]
        public IWebElement originCityTextBox;
        [FindsBy(How = How.Id, Using = "arrival-airport-1")]
        public IWebElement arrivalCityTextBox;

#pragma warning restore 0649

        public ExpediaTicketSelectPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void SelectCheapestDepartingTicket()
        {
            Help.WaitForClickable(By.XPath(CHEAPEST_BUTTON));
            cheapestButton.Click();
        }

        public void StoreCheapestDepartingTicketContent()
        {
            Help.WaitForClickable(By.XPath(CHEAPEST_BUTTON));
            Global.TicketCost = cheapestTicketValue.Text.Replace("Result 1, $", "");
            Global.DepurtureTimeFlyTo = departureTimeFlyTo.Text + "m";
            Global.ArriveTimeFlyTo = arrivalTimeFlyTo.Text + "m";           
        }

        public void SelectCheapestReturningTicket()
        {
            try
            {
                Help.WaitForClickable(By.XPath(CHEAPEST_BUTTON));
                Help.SwitchToPopUpOnClick(cheapestButton);
            }
            catch (WebDriverTimeoutException) { }
        }

        public void StoreCheapestReturningTicketContent()
        {
            Help.WaitForClickable(By.XPath(CHEAPEST_BUTTON));
            Global.DepurtureTimeFlyFrom = departureTimeFlyFrom.Text + "m";
            Global.ArriveTimeFlyFrom = arrivalTimeFlyFrom.Text + "m";
        }

        public void PressSearchWithChangedInfo()
        {
            searchWithChangedInfo.Click();
        }

        public void ChangeDepartureDate(string depDate)
        {
            Help.HighlightAndDeleteAllTextInWebelemnt(departureDate);
            departureDate.SendKeys(depDate);
            Assert.AreEqual(depDate, departureDate.GetAttribute("value"));
        }

        public void ChangeReturnDate(string retDate)
        {
            Help.HighlightAndDeleteAllTextInWebelemnt(returnDate);
            returnDate.SendKeys(retDate);
            Assert.AreEqual(retDate, returnDate.GetAttribute("value"));
        }

        public void ChangeOriginCity(string orCity)
        {
            originCityTextBox.Clear();
            originCityTextBox.SendKeys(orCity);
            Assert.AreEqual(orCity, originCityTextBox.GetAttribute("value"));
        }

        public void ChangeDestinationCity(string destCity)
        {
            arrivalCityTextBox.Clear();
            arrivalCityTextBox.SendKeys(destCity);
            Assert.AreEqual(destCity, arrivalCityTextBox.GetAttribute("value"));
        }

        public void PressPopUpEmailSingUpClose()
        {
            try
            {
                Help.WaitForClickable(By.Id(POP_UP_EMAIL_SING_UP_CLOSE), 10);
                popUpEmailSingUpClose.Click();
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is WebDriverTimeoutException)
                {
                    return;
                }
                throw;
            }
        }

        public void PressPopUpNoThanks()
        {
            try
            {
                Help.WaitForClickable(By.Id(NO_THANKS_POP_UP), 10);
                Help.SwitchToPopUpOnClick(noThanksPopUp);
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is WebDriverTimeoutException)
                {
                    return;
                }
                throw;
            }
        }

        public void CheckDepartureTicketSelectPageLoad()
        {
            Help.WaitForVisible(By.ClassName(CHECK_DEPARTURE_SELECT_TICKET_PAGE_LOAD));
            try
            {
                StringAssert.Contains("Select your departure", checkDepurtureSelectTicketPageLoad.Text);
            }
            catch (AssertionException)
            {
                Thread.Sleep(2000);
                StringAssert.Contains("Select your departure", checkDepurtureSelectTicketPageLoad.Text);
            }
        }

        public void CheckReturningTicketSelectPageLoad()
        {
            Help.WaitForVisible(By.ClassName(CHECK_RETURNING_SELECT_TICKET_PAGE_LOAD));
            StringAssert.Contains("Select your return", checkReturningSelectTicketPageLoad.Text);
        }

        public void CheckDepartureDateFlyTo(string date)
        {
            string actualDate = Help.DateConvertToMMddyyyy(departureDateFlyTo.Text.Replace(",", ""), date);
            string dateFromInput = date;
            Assert.AreEqual(actualDate, dateFromInput);
        }

        public void CheckDepartureDateFlyTo()
        {
            string actualDate = Help.DateConvertToMMddyyyy(departureDateFlyTo.Text.Replace(",", ""), Global.DepartureDate);
            string dateFromInput = Global.DepartureDate;
            Assert.AreEqual(actualDate, dateFromInput);
        }

        public void CheckDepartureDateFlyFrom(string date)
        {
            string actualDate = Help.DateConvertToMMddyyyy(departureDateFlyFrom.Text.Replace(",", ""), date);
            string dateFromInput = date;
            Assert.AreEqual(actualDate, dateFromInput);
        }

        public void CheckDepartureDateFlyFrom()
        {
            string actualDate = Help.DateConvertToMMddyyyy(departureDateFlyFrom.Text.Replace(",", ""), Global.ReturningDate);
            string dateFromInput = Global.ReturningDate;
            Assert.AreEqual(actualDate, dateFromInput);
        }

        public void CheckDestinationCity()
        {
            //Help.Wait(2000);
            StringAssert.Contains(Global.destCity, arrivalCityFlyTo.Text);
        }

        public void CheckOriginCity()
        {
            //Help.Wait(2000);
            StringAssert.Contains(Global.orCity, arrivalCityFlyFrom.Text);
        }

        public const string CHEAPEST_BUTTON = "//*[@id='flightModuleList']/div/li[1]//div[2]/div/div[2]/div/button";
        public const string CHECK_DEPARTURE_SELECT_TICKET_PAGE_LOAD = "title-departure";
        public const string CHECK_RETURNING_SELECT_TICKET_PAGE_LOAD = "title-departure";
        public const string NO_THANKS_POP_UP = "forcedChoiceNoThanks";
        public const string POP_UP_EMAIL_SING_UP_CLOSE = "modalCloseButton";
        public const string DEPARTURE_TIME = "//*[@id='flightModuleList']/div/li[1]/div[2]/div/div[1]/div/div[2]/div/div/div[1]/div[1]/span[1]";
        public const string RETURN_TIME = "//*[@id='flightModuleList']/div/li[1]/div[2]/div/div[1]/div/div[2]/div/div/div[1]/div[1]/span[2]";
    }
}
