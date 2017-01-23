using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace ExpediaSpecflow
{
    public class ExpediaSearchResultPage
    {
        public IWebDriver driver;
        private Helpers Help = new Helpers(WebBrowser.Current);

#pragma warning disable 0649

        [FindsBy(How = How.Id, Using = "changeFlights")]
        public IWebElement changeFlightlink;
        [FindsBy(How = How.Id, Using = "FlightUDPBookNowButton1")]
        public IWebElement buttonContinueBooking;
        [FindsBy(How = How.Id, Using = "departure-airport-automation-label-0")]
        public IWebElement departureAirportCodeFlyTo;
        [FindsBy(How = How.Id, Using = "arrival-airportcode-automation-label-0")]
        public IWebElement arrivalAirportCodeFlyTo;
        [FindsBy(How = How.Id, Using = "departure-airport-automation-label-1")]
        public IWebElement departureAirportCodeFlyFrom;
        [FindsBy(How = How.Id, Using = "arrival-airportcode-automation-label-1")]
        public IWebElement arrivalAirportCodeFlyFrom;
        [FindsBy(How = How.Id, Using = "departure-time-automation-label-0")]
        public IWebElement departureTimeFlyTo;
        [FindsBy(How = How.Id, Using = "arrival-time-automation-label-0")]
        public IWebElement arrivalTimeFlyTo;
        [FindsBy(How = How.Id, Using = "departure-time-automation-label-1")]
        public IWebElement departureTimeFlyFrom;
        [FindsBy(How = How.Id, Using = "arrival-time-automation-label-1")]
        public IWebElement arrivalTimeFlyFrom;
        [FindsBy(How = How.Id, Using = "departure-date-1")]
        public IWebElement departureDateFlyFrom;
        [FindsBy(How = How.Id, Using = "departure-date-0")]
        public IWebElement departureDateFlyTo;
        [FindsBy(How = How.ClassName, Using = "toggle-trigger")]
        public IList<IWebElement> adultsChildrenTicketAmount;
        [FindsBy(How = How.Id, Using = "tripTotal")]
        public IWebElement totalTicketsCost;
        [FindsBy(How = How.Id, Using = CHECK_SEARCH_RESULT_PAGE_LOAD)]
        public IWebElement checkSearchResultPageLoad;
        [FindsBy(How = How.Id, Using = "trip-summary-toggle")]
        public IWebElement tripSummaryToggleButton;
        [FindsBy(How = How.XPath, Using = PRICE_CHANGED_TO)]
        public IWebElement priceChangedTo;
        [FindsBy(How = How.XPath, Using = PRICE_CHANGED_FROM)]
        public IWebElement priceChangedFrom;
        [FindsBy(How = How.Id, Using = PRICE_CHANGED_MESSAGE)]
        public IWebElement priceChangedMessage;

#pragma warning restore 0649

        public ExpediaSearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void PressContinueBooking()
        {
            Help.JSExecutor("$('#FlightUDPBookNowButton1 .btn-primary').click();");
        }

        public void PressChangeFlight()
        {
            changeFlightlink.Click();
            //Second click for IE
            Help.TryClick(changeFlightlink);
        }

        public void CheckSearchResultPageLoad()
        {
            Help.WaitForVisible(By.Id(CHECK_SEARCH_RESULT_PAGE_LOAD));
            StringAssert.Contains("Review your trip", checkSearchResultPageLoad.Text);
        }

        public void CheckDepartureAirportFlyTo(string city)
        {
            string actualCityAirportCode = departureAirportCodeFlyTo.Text;
            string cityAirportCodes = Global.cityAirportCodesDict[city];
            StringAssert.Contains(actualCityAirportCode, cityAirportCodes);
        }

        public void CheckDepartureAirportFlyTo()
        {
            string actualCityAirportCode = departureAirportCodeFlyTo.Text;
            string cityAirportCodes = Global.cityAirportCodesDict[Global.OriginCity];
            StringAssert.Contains(actualCityAirportCode, cityAirportCodes);
        }

        public void CheckArrivalAirportFlyTo(string city)
        {            
            string actualCityAirportCode = arrivalAirportCodeFlyTo.Text;
            string cityAirportCodes = Global.cityAirportCodesDict[city];
            StringAssert.Contains(actualCityAirportCode, cityAirportCodes);
        }

        public void CheckArrivalAirportFlyTo()
        {
            string actualCityAirportCode = arrivalAirportCodeFlyTo.Text;
            string cityAirportCodes = Global.cityAirportCodesDict[Global.DestinationCity];
            StringAssert.Contains(actualCityAirportCode, cityAirportCodes);
        }

        public void CheckDepartureAirportFlyFrom(string city)
        {            
            string actualCityAirportCode = departureAirportCodeFlyFrom.Text;
            string cityAirportCodes = Global.cityAirportCodesDict[city];
            StringAssert.Contains(actualCityAirportCode, cityAirportCodes);
        }

        public void CheckDepartureAirportFlyFrom()
        {
            string actualCityAirportCode = departureAirportCodeFlyFrom.Text;
            string cityAirportCodes = Global.cityAirportCodesDict[Global.DestinationCity];
            StringAssert.Contains(actualCityAirportCode, cityAirportCodes);
        }

        public void CheckArrivalAirportFlyFrom(string city)
        {
            string actualCityAirportCode = arrivalAirportCodeFlyFrom.Text;
            string cityAirportCodes = Global.cityAirportCodesDict[city];
            StringAssert.Contains(actualCityAirportCode, cityAirportCodes);
        }

        public void CheckArrivalAirportFlyFrom()
        {
            string actualCityAirportCode = arrivalAirportCodeFlyFrom.Text;
            string cityAirportCodes = Global.cityAirportCodesDict[Global.OriginCity];
            StringAssert.Contains(actualCityAirportCode, cityAirportCodes);
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

        public void CheckDepartureTimeFlyTo(string time)
        {            
            string actualTime = departureTimeFlyTo.Text;
            string expectedTime = time;
            Assert.AreEqual(expectedTime, actualTime);
        }

        public void CheckDepartureTimeFlyTo()
        {
            string actualTime = departureTimeFlyTo.Text;
            string expectedTime = Global.DepurtureTimeFlyTo;
            Assert.AreEqual(expectedTime, actualTime);
        }

        public void CheckArrivalTimeFlyTo(string time)
        {
            string actualTime = arrivalTimeFlyTo.Text;
            string expectedTime = time;
            Assert.AreEqual(expectedTime, actualTime);
        }

        public void CheckArrivalTimeFlyTo()
        {
            string actualTime = arrivalTimeFlyTo.Text;
            string expectedTime = Global.ArriveTimeFlyTo;
            Assert.AreEqual(expectedTime, actualTime);
        }

        public void CheckDepartureTimeFlyFrom(string time)
        {
            string actualTime = departureTimeFlyFrom.Text;
            string expectedTime = time;
            Assert.AreEqual(expectedTime, actualTime);
        }

        public void CheckDepartureTimeFlyFrom()
        {
            string actualTime = departureTimeFlyFrom.Text;
            string expectedTime = Global.DepurtureTimeFlyFrom;
            Assert.AreEqual(expectedTime, actualTime);
        }

        public void CheckArrivalTimeFlyFrom(string time)
        {
            string actualTime = arrivalTimeFlyFrom.Text;
            string expectedTime = time;
            Assert.AreEqual(expectedTime, actualTime);
        }

        public void CheckArrivalTimeFlyFrom()
        {
            string actualTime = arrivalTimeFlyFrom.Text;
            string expectedTime = Global.ArriveTimeFlyFrom;
            Assert.AreEqual(expectedTime, actualTime);
        }

        public void CheckTicketsAmount(string adults, string children)
        {
            tripSummaryToggleButton.Click();
            int adultsAmount = Int32.Parse(adults);
            int childrenAmount = Int32.Parse(children);
            int ticketsAmount = Help.GetAdultsChildren(adultsChildrenTicketAmount);
            Assert.AreEqual(ticketsAmount, adultsAmount + childrenAmount);
        }

        public void CheckTicketsAmount()
        {
            Help.JSExecutor("$('#trip-summary-toggle').click()");
            int adultsAmount = Int32.Parse(Global.AdultsAmount);
            int childrenAmount = Int32.Parse(Global.ChildrenAmount);
            int ticketsAmount = Help.GetAdultsChildren(adultsChildrenTicketAmount);
            Assert.AreEqual(ticketsAmount, adultsAmount + childrenAmount);
        }

        public void CheckTicketsTotalCost(string adults, string children, string ticketCost)
        {
            int adultsAmount = Int32.Parse(adults);
            int childrenAmount = Int32.Parse(children);
            float expectedTotalTicketCost = float.Parse(ticketCost) * (adultsAmount + childrenAmount);
            float actualTotalTicketCost = float.Parse(Help.JSExecutorReturn("return $('#tripTotal').text().replace(\"$\", '')").ToString());
            try
            {
                bool displayed = priceChangedMessage.Displayed;
                float ticketCostChangedFrom = float.Parse(priceChangedFrom.Text.Replace("$", ""));
                float ticketCostChangedTo = float.Parse(priceChangedTo.Text.Replace("$", ""));
                Assert.That(ticketCostChangedFrom, Is.EqualTo(actualTotalTicketCost).Within(1.0));
                Global.TicketCost = priceChangedTo.Text;
                Assert.That(expectedTotalTicketCost, Is.EqualTo(actualTotalTicketCost).Within(1.0));
            }
            catch (NoSuchElementException)
            {
                Assert.That(expectedTotalTicketCost, Is.EqualTo(actualTotalTicketCost).Within(1.0));
            }
        }

        public void CheckTicketsTotalCost()
        {
            int adultsAmount = Int32.Parse(Global.AdultsAmount);
            int childrenAmount = Int32.Parse(Global.ChildrenAmount);
            float expectedTotalTicketCost = float.Parse(Global.TicketCost) * (adultsAmount + childrenAmount);
            float actualTotalTicketCost = float.Parse(Help.JSExecutorReturn("return $('#tripTotal').text().replace(\"$\", '')").ToString());
            try
            {
                bool displayed = priceChangedMessage.Displayed;
                float ticketCostChangedFrom = float.Parse(priceChangedFrom.Text.Replace("$", ""));
                float ticketCostChangedTo = float.Parse(priceChangedTo.Text.Replace("$", ""));
                Assert.That(ticketCostChangedFrom, Is.EqualTo(expectedTotalTicketCost).Within(1.0));
                Global.TicketCost = (float.Parse(priceChangedTo.Text.Replace("$", "")) / (adultsAmount + childrenAmount)).ToString();
                Assert.That(ticketCostChangedTo, Is.EqualTo(actualTotalTicketCost).Within(1.0));
            }
            catch (NoSuchElementException)
            {
                Assert.That(expectedTotalTicketCost, Is.EqualTo(actualTotalTicketCost).Within(1.0));
            }           
        }

        public const string PRICE_CHANGED_MESSAGE = "priceChangeInfoWarn";
        public const string PRICE_CHANGED_FROM = "//*[@id='priceChangeInfoWarn']/div/p/span[1]";
        public const string PRICE_CHANGED_TO = "//*[@id='priceChangeInfoWarn']/div/p/span[2]";
        public const string CHECK_SEARCH_RESULT_PAGE_LOAD = "FlightUDPTripMetaArrivalCity";
    }   
}
