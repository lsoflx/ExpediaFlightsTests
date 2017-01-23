using TechTalk.SpecFlow;

namespace ExpediaSpecflow
{
    [Binding]
    class ExpediaHomePageSteps
    {
        ExpediaHomePage ExpediaHP = new ExpediaHomePage(WebBrowser.Current);

        [Given(@"on the Expedia home page")]
        public void GivenOnTheExpediaHomePage()
        {
            ExpediaHP.Navigate();
        }

        [Given(@"check home page loaded")]
        public void GivenVerifyRightPageLoad()
        {
            ExpediaHP.CheckHomePageTitle();
        }
    }
}
