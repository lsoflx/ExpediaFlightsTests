using TechTalk.SpecFlow;

namespace ExpediaSpecflow
{
    [Binding]
    class ExpediaSearchResultPageSteps
    {
        ExpediaSearchResultPage ExpediaSRP = new ExpediaSearchResultPage(WebBrowser.Current);

        [Given(@"press return to search")]
        public void WhenPressReturnToSearch()
        {
            ExpediaSRP.PressChangeFlight();
        }


        [Given(@"press continue booking button")]
        public void GivenPressContinueBooking()
        {
            ExpediaSRP.PressContinueBooking();
        }

        [Given(@"check search result page loaded")]
        public void GivenCheckSearchResultPageLoaded()
        {
            ExpediaSRP.CheckSearchResultPageLoad();
        }

        [Given(@"check on result page (.*)")]
        public void GivenCheckOnResultPageTicketsCredentials(string values)
        {
            switch (values)
            {
                case "departure ticket credentials":
                    ExpediaSRP.CheckDepartureAirportFlyTo();
                    ExpediaSRP.CheckArrivalAirportFlyTo();
                    ExpediaSRP.CheckDepartureDateFlyTo();
                    ExpediaSRP.CheckDepartureTimeFlyTo();
                    ExpediaSRP.CheckArrivalTimeFlyTo();
                    break;
                case "returning ticket credentials":
                    ExpediaSRP.CheckDepartureAirportFlyFrom();
                    ExpediaSRP.CheckArrivalAirportFlyFrom();
                    ExpediaSRP.CheckDepartureDateFlyFrom();
                    ExpediaSRP.CheckDepartureTimeFlyFrom();
                    ExpediaSRP.CheckArrivalTimeFlyFrom();
                    break;
                case "amount of travelers(tickets)":
                    ExpediaSRP.CheckTicketsAmount();
                    break;
                case "total price of tickets":
                    ExpediaSRP.CheckTicketsTotalCost();
                    break;
            }
        }
    }
}
