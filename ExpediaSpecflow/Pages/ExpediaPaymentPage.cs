using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace ExpediaSpecflow
{
    class ExpediaPaymentPage
    {
        private IWebDriver driver;
        private PopupWindowFinder PopUpWF = new PopupWindowFinder(WebBrowser.Current);
        private Helpers Help = new Helpers(WebBrowser.Current);

#pragma warning disable 0649

        [FindsBy(How = How.ClassName, Using = "billing-cardholder-name")]
        public IWebElement cardholderNameTextBox;
        [FindsBy(How = How.CssSelector, Using = "input[name='card_number']")]
        public IWebElement creditCardNumberTextBox;
        [FindsBy(How = How.CssSelector, Using = "select[name='expiration_month']")]
        public IWebElement expirationMonthList;
        [FindsBy(How = How.CssSelector, Using = "select[name='expiration_year']")]
        public IWebElement expirationYearList;
        [FindsBy(How = How.Id, Using = "new_cc_security_code")]
        public IWebElement securityCodeTextBox;
        [FindsBy(How = How.CssSelector, Using = "select[name='country']")]
        public IWebElement countryList;
        [FindsBy(How = How.ClassName, Using = "billing-address-one")]
        public IWebElement billingAddress1TextBox;
        [FindsBy(How = How.ClassName, Using = "billing-address-two")]
        public IWebElement billingAddress2TextBox;
        [FindsBy(How = How.CssSelector, Using = "input[class='text billing-city cko-field']")]
        public IWebElement cityTextBox;
        [FindsBy(How = How.CssSelector, Using = "input[name='zipcode']")]
        public IWebElement postalCodeTextBox;
        [FindsBy(How = How.CssSelector, Using = "input[data-tealeaf-name='email']")]
        public IWebElement emailAddressTextBox;
        [FindsBy(How = How.Id, Using = "complete-booking")]
        public IWebElement completeBookingButton;
        [FindsBy(How = How.ClassName, Using = "origin-destination-city")]
        public IWebElement originDestinationCity;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[3]/div/div[1]/span")]
        public IWebElement departureDateFlyTo;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[4]/div/div[1]/span")]
        public IWebElement departureDateFlyFrom;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[3]/div/div[2]/span[1]")]
        public IWebElement departureAirportCodeFlyTo;
        [FindsBy(How = How.XPath, Using = "//*[@id='trip-summary']/div[1]/div[3]/div/div[2]/span[5]")]
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
        [FindsBy(How = How.ClassName, Using = CHECK_PAYMENT_PAGE_LOAD)]
        public IWebElement checkPaymentPageLoad;

#pragma warning restore 0649

        public ExpediaPaymentPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void InputCardholderName(string name)
        {
            //Help.WaitImplicit(2000, 30);
            cardholderNameTextBox.Clear();
            cardholderNameTextBox.SendKeys(name);
            Assert.AreEqual(name, cardholderNameTextBox.GetAttribute("value"));
        }

        public void InputCreditCardNumber(string number)
        {
            creditCardNumberTextBox.SendKeys(number);
            Assert.AreEqual(number, creditCardNumberTextBox.GetAttribute("value"));
        }

        public void InputExpirationMonth(string month)
        {
            Help.SelectFromDropMenu(expirationMonthList, month);
            Assert.AreEqual(month, Help.JSExecutorReturn("return $('.cc-expiry-month > option:selected').text()"));
        }

        public void InputExpirationYear(string year)
        {
            Help.SelectFromDropMenu(expirationYearList, year);
            Assert.AreEqual(year, Help.JSExecutorReturn("return $('.cc-expiry-year > option:selected').text()"));
        }

        public void InputSecurityCode(string code)
        {
            securityCodeTextBox.SendKeys(code);
            Assert.AreEqual(code, securityCodeTextBox.GetAttribute("value"));
        }

        public void InputCountry(string country)
        {
            Help.SelectFromDropMenu(countryList, country);
            Assert.AreEqual(country, Help.JSExecutorReturn("return $('.billing-country > option:selected').text()"));
        }

        public void InputBillingAddress1(string address)
        {
            billingAddress1TextBox.SendKeys(address);
            Assert.AreEqual(address, billingAddress1TextBox.GetAttribute("value"));
        }

        public void InputBillingAddress2(string address)
        {
            billingAddress2TextBox.SendKeys(address);
            Assert.AreEqual(address, billingAddress2TextBox.GetAttribute("value"));
        }

        public void InputCity(string city)
        {
            //Help.JSExecutor("document.getElementByCssSelector('flight-origin').value='" + city + "';");
            //cityTextBox.Click();
            cityTextBox.SendKeys(city);
            Assert.AreEqual(city, cityTextBox.GetAttribute("value"));
        }

        public void InputPostalCode(string code)
        {
            postalCodeTextBox.SendKeys(code);
            Assert.AreEqual(code, postalCodeTextBox.GetAttribute("value"));
        }

        public void InputEmailAddress(string email)
        {
            emailAddressTextBox.SendKeys(email);
            Assert.AreEqual(email, emailAddressTextBox.GetAttribute("value"));
        }

        public void PressCompleteBooking()
        {
            completeBookingButton.Click();
        }

        public void CheckPaymentPageLoad()
        {
            Help.WaitForVisible(By.ClassName(CHECK_PAYMENT_PAGE_LOAD));
            StringAssert.Contains("How would you like to pay", checkPaymentPageLoad.Text);
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

        public void CheckDepartureDateFlyTo(string depDate)
        {
            string actualDate = Help.DateConvertToMMddyyyy(departureDateFlyTo.Text.Replace(",", ""), depDate);
            string dateFromInput = depDate;
            Assert.AreEqual(actualDate, dateFromInput);
        }

        public void CheckDepartureDateFlyTo()
        {
            string actualDate = Help.DateConvertToMMddyyyy(departureDateFlyTo.Text.Replace(",", ""), Global.DepartureDate);
            string dateFromInput = Global.DepartureDate;
            Assert.AreEqual(actualDate, dateFromInput);
        }

        public void CheckDepartureDateFlyFrom(string retDate)
        {
            string actualDate = Help.DateConvertToMMddyyyy(departureDateFlyFrom.Text.Replace(",", ""), retDate);
            string dateFromInput = retDate;
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
            int adultsAmount = Int32.Parse(adults);
            int childrenAmount = Int32.Parse(children);
            int ticketsAmount = Help.GetAdultsChildren(adultsChildrenTicketAmount);
            Assert.AreEqual(ticketsAmount, adultsAmount + childrenAmount);
        }

        public void CheckTicketsAmount()
        {
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
            float actualTotalTicketCost = float.Parse(totalTicketsCost.Text.Replace("$", ""));
            Assert.That(expectedTotalTicketCost, Is.EqualTo(actualTotalTicketCost).Within(1.0));
        }

        public void CheckTicketsTotalCost()
        {
            int adultsAmount = Int32.Parse(Global.AdultsAmount);
            int childrenAmount = Int32.Parse(Global.ChildrenAmount);
            float expectedTotalTicketCost = float.Parse(Global.TicketCost) * (adultsAmount + childrenAmount);
            float actualTotalTicketCost = float.Parse(totalTicketsCost.Text.Replace("$", ""));
            Assert.That(expectedTotalTicketCost, Is.EqualTo(actualTotalTicketCost).Within(1.0));
        }

        public const string CHECK_PAYMENT_PAGE_LOAD = "module-title-urgency";
    }
}
