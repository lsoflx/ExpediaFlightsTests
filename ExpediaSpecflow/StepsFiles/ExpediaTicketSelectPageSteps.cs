using TechTalk.SpecFlow;

namespace ExpediaSpecflow
{
    [Binding]
    class ExpediaTicketSelectPageSteps
    {
        ExpediaTicketSelectPage ExpediaTSP = new ExpediaTicketSelectPage(WebBrowser.Current);

        [Given(@"change and store content of departure (.*) and return (.*) date")]
        public void ChangeDepartingDateStore(string depDate, string retDate)
        {
            ExpediaTSP.ChangeDepartureDate(depDate);
            Global.DepartureDate = depDate;
            ExpediaTSP.ChangeReturnDate(retDate);
            Global.ReturningDate = retDate;
        }

        [Given(@"change departure (.*) and return (.*) date")]
        public void ChangeDepartingDate(string depDate, string retDate)
        {
            ExpediaTSP.PressPopUpEmailSingUpClose();
            ExpediaTSP.ChangeDepartureDate(depDate);
            ExpediaTSP.ChangeReturnDate(retDate);
        }

        [Given(@"change and store content of departure (.*) and return (.*) city")]
        public void GivenChangeDepartureAndReturnCityStore(string orCity, string destCity)
        {
            ExpediaTSP.ChangeOriginCity(orCity);
            Global.OriginCity = orCity;
            ExpediaTSP.ChangeDestinationCity(destCity);
            Global.DestinationCity = destCity;
        }

        [Given(@"change departure Kiev and return Madrid city")]
        public void GivenChangeDepartureAndReturnCity()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"press search with diff info")]
        public void PressSearchWithDiffInfo()
        {
            ExpediaTSP.PressSearchWithChangedInfo();
        }

        [Given(@"select and store content of cheapest departing ticket")]
        public void GivenSelectDepartingTicketAndStore()
        {
            ExpediaTSP.StoreCheapestDepartingTicketContent();
            ExpediaTSP.SelectCheapestDepartingTicket();
        }

        [Given(@"select cheapest departing ticket")]
        public void GivenSelectDepartingTicket()
        {
            ExpediaTSP.SelectCheapestDepartingTicket();
        }

        [Given(@"select and store content of cheapest returning ticket")]
        public void GivenSelectReturningTicketAndStore()
        {
            ExpediaTSP.StoreCheapestReturningTicketContent();
            ExpediaTSP.SelectCheapestReturningTicket();
        }

        [Given(@"select cheapest returning ticket")]
        public void GivenSelectReturningTicket()
        {
            ExpediaTSP.SelectCheapestReturningTicket();
        }

        [Given(@"close pop up email sing up")]
        public void GivenClosePopUpEmailSingUp()
        {
            ExpediaTSP.PressPopUpEmailSingUpClose();
        }

        [Given(@"press no thanks on pop up")]
        public void GivenPressOnPopUp()
        {
            ExpediaTSP.PressPopUpNoThanks();
        }

        [Given(@"check departure select tickets page loaded")]
        public void GivenVerifyDepartureSelectTicketsPageLoaded()
        {
            ExpediaTSP.CheckDepartureTicketSelectPageLoad();
        }

        [Given(@"check returning select tickets page loaded")]
        public void GivenCheckReturningSelectTicketsPageLoaded()
        {
            ExpediaTSP.CheckReturningTicketSelectPageLoad();
        }

        [Given(@"check departure date")]
        public void GivenCheckDepartureDate()
        {
            ExpediaTSP.CheckDepartureDateFlyTo();
        }

        [Given(@"check return date")]
        public void GivenCheckReturnDate()
        {
            ExpediaTSP.CheckDepartureDateFlyFrom();
        }

        [Given(@"check destination city")]
        public void GivenCheckDepartureCity()
        {
            ExpediaTSP.CheckDestinationCity();
        }

        [Given(@"check origin city")]
        public void GivenCheckReturnCity()
        {
            ExpediaTSP.CheckOriginCity();
        }
    }
}
