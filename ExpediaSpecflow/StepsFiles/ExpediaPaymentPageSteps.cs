using TechTalk.SpecFlow;

namespace ExpediaSpecflow
{
    [Binding]
    class ExpediaPaymentPageSteps
    {
        ExpediaPaymentPage ExpediaPP = new ExpediaPaymentPage(WebBrowser.Current);

        [Given(@"input cardholder name (.*)")]
        public void GivenInputCardholderName(string name)
        {
            ExpediaPP.InputCardholderName(name);
        }

        [Given(@"input card number (.*) expiration month (.*) and year (.*) security code (.*)")]
        public void GivenInputCardCredentials(string number, string month, string year, string code)
        {
            ExpediaPP.InputCreditCardNumber(number);
            ExpediaPP.InputExpirationMonth(month);
            ExpediaPP.InputExpirationYear(year);
            ExpediaPP.InputSecurityCode(code);
        }

        [Given(@"choose country (.*) input billing addressone (.*) and addresstwo (.*) input city (.*) input postal code (.*)")]
        public void GivenChooseBillingAddress(string country, string address1, string address2, string city, string code)
        {
            ExpediaPP.InputCountry(country);
            ExpediaPP.InputBillingAddress1(address1);
            ExpediaPP.InputBillingAddress2(address2);
            ExpediaPP.InputPostalCode(code);
            ExpediaPP.InputCity(city);            
        }

        [Given(@"input email (.*)")]
        public void GivenInputEmail(string email)
        {
            ExpediaPP.InputEmailAddress(email);
        }

        [When(@"press complete booking")]
        public void WhenPressCompleteBooking()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"tickets bought")]
        public void ThenTicketsBought()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"check payment page loaded")]
        public void GivenCheckPaymentPageLoaded()
        {
            ExpediaPP.CheckPaymentPageLoad();
        }


        [Given(@"check on payment page (.*)")]
        public void GivenCheckOnPaymentConfirmationPageTicketsCredentials(string values)
        {
            switch (values)
            {
                case "departure ticket credentials":
                    ExpediaPP.CheckDepartureAirportFlyTo();
                    ExpediaPP.CheckArrivalAirportFlyTo();
                    ExpediaPP.CheckDepartureDateFlyTo();
                    ExpediaPP.CheckDepartureTimeFlyTo();
                    ExpediaPP.CheckArrivalTimeFlyTo();
                    break;
                case "returning ticket credentials":
                    ExpediaPP.CheckDepartureAirportFlyFrom();
                    ExpediaPP.CheckArrivalAirportFlyFrom();
                    ExpediaPP.CheckDepartureDateFlyFrom();
                    ExpediaPP.CheckDepartureTimeFlyFrom();
                    ExpediaPP.CheckArrivalTimeFlyFrom();
                    break;
                case "amount of tickets":
                    ExpediaPP.CheckTicketsAmount();
                    break;
                case "total price of tickets":
                    ExpediaPP.CheckTicketsTotalCost();
                    break;
            }
        }
    }
}
