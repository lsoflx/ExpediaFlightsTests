using TechTalk.SpecFlow;

namespace ExpediaSpecflow
{
    [Binding]
    class ExpediaTravelerInfoPageSteps
    {
        ExpediaTravelerInfoPage ExpediaTIP = new ExpediaTravelerInfoPage(WebBrowser.Current);

        [Given(@"input title (.*) first name (.*) middle name (.*) last name (.*)")]
        public void GivenInputFirstName(string title, string name, string middle, string last)
        {
            ExpediaTIP.InsertTitle(title);
            ExpediaTIP.InsertFirstName(name);
            ExpediaTIP.InsertMiddleName(middle);
            ExpediaTIP.InsertLastName(last);
        }

        [Given(@"input country code (.*) phone number (.*) country (.*)")]
        public void GivenInputCountryAndPhone(string code, string number, string country)
        {
            ExpediaTIP.InsertCountryCode(code);
            ExpediaTIP.InsertPhoneNumber(number);
            ExpediaTIP.InsertCountryPassport(country);
        }

        [Given(@"input passport country (.*)")]
        public void GivenInputCountryPassport(string country)
        {
            ExpediaTIP.InsertCountryPassport(country);
        }

        [Given(@"press continue button")]
        public void GivenPressContinue()
        {
            ExpediaTIP.PressButtonContinue();
        }

        [Given(@"check traveler info page loaded")]
        public void GivenCheckTravelerInfoPageLoaded()
        {
            ExpediaTIP.CheckTravelerInfoPageLoad();
        }

    }
}
