using TechTalk.SpecFlow;

namespace ExpediaSpecflow
{
    [Binding]
    class ExpediaSearchPageSteps
    {
        ExpediaSearchPage ExpediaSP = new ExpediaSearchPage(WebBrowser.Current);
        Helpers Help = new Helpers(WebBrowser.Current);

        [Given(@"press flight button")]
        public void GivenChooseWhatToSearch()
        {
            ExpediaSP.PressFlightsButton();
        }

        [Given(@"press round-trip ticket button")]
        public void GivenChooseTypeOfSearch()
        {
            ExpediaSP.PressRoundTripButton();
        }

        [Given(@"input and store content of flyght from (.*) and to (.*)")]
        public void GivenChooseFlyingFromAndToAndStore(string orCity, string destCity)
        {
            ExpediaSP.InputOriginCity(orCity);
            Global.OriginCity = orCity;
            ExpediaSP.InputDestinationCity(destCity);
            Global.DestinationCity = destCity;
            Help.ImportFileWithCityAirportsForCheckTickets();
        }

        [Given(@"input flyght from (.*) and to (.*)")]
        public void GivenChooseFlyingFromAndTo(string orCity, string destCity)
        {
            ExpediaSP.InputOriginCity(orCity);
            ExpediaSP.InputDestinationCity(destCity);
            Help.ImportFileWithCityAirportsForCheckTickets();
        }

        [Given(@"input and store content of departing (.*) and returning (.*) date")]
        public void GivenChooseDepartingAndReturningAndStore(string depDate, string retDate)
        {
            ExpediaSP.InputDepartureDate(depDate);
            Global.DepartureDate = depDate;
            ExpediaSP.InputReturngDate(retDate);
            Global.ReturningDate = retDate;
        }

        [Given(@"input departing (.*) and returning (.*) date")]
        public void GivenChooseDepartingAndReturning(string depDate, string retDate)
        {
            ExpediaSP.InputDepartureDate(depDate);
            ExpediaSP.InputReturngDate(retDate);
        }

        [Given(@"input and store content of departing date (.*) days from today and returning date (.*) days from today")]
        public void GivenInputDepartingDateDaysFromTodayAndReturningDateDaysFromTodayStore(int depDays, int returnDays)
        {
            Global.DepartureDate = ExpediaSP.InputRelativeDepartureDate(depDays);
            Global.ReturningDate = ExpediaSP.InputRelativeReturnDate(returnDays);
        }

        [Given(@"input departing date (.*) days from today and returning date (.*) days from today")]
        public void GivenInputDepartingDateDaysFromTodayAndReturningDateDaysFromToday(int depDays, int returnDays)
        {
            ExpediaSP.InputRelativeDepartureDate(depDays);
            ExpediaSP.InputRelativeReturnDate(returnDays);
        }


        [Given(@"input and store content of adults (.*) and children (.*) amount")]
        public void GivenChooseAdultsAndChildrenAmountAndStore(string adults, string children)
        {
            ExpediaSP.ChooseAdultsAmount(adults);
            Global.AdultsAmount = adults;
            ExpediaSP.ChooseChildrenAmount(children);
            Global.ChildrenAmount = children;
        }

        [Given(@"input adults (.*) and children (.*) amount")]
        public void GivenChooseAdultsAndChildrenAmount(string adults, string children)
        {
            ExpediaSP.ChooseAdultsAmount(adults);
            ExpediaSP.ChooseChildrenAmount(children);
        }

        [Given(@"press search button")]
        public void GivenPressSearch()
        {
            ExpediaSP.PressSearchButton();
        }
    }
}
