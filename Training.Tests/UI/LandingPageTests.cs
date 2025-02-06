using Training.Core.PageObjects.Pages;

namespace Training.Tests.UI
{
    [Parallelizable(ParallelScope.Self)]
    public class LandingPageTests : UIBasePageTest
    {
        private LandingPage? LandingPage { get; set; }

        [Test]
        public async Task PageDisplayedCorrectly()
        {
            // Navigate to homepage
            LandingPage = new LandingPage(BrowserTab, string.Empty);
            await LandingPage.NavigateTo();
            await LandingPage.AcceptCookies();

            // The logo is displayed
            await LandingPage.Logo.Visible();

            // The Menu and menu bar elements are displayed
            await LandingPage.Menu.Visible();
            await LandingPage.Menu.Solutions.Visible();
            await LandingPage.Menu.Products.Visible();
            await LandingPage.Menu.Company.Visible();
            await LandingPage.Menu.Careers.Visible();
            await LandingPage.Menu.Contact.Visible();

            // Menu items contains correct text
            await Expect(LandingPage.Menu.Solutions.Element).ToContainTextAsync("Solutions");
            await Expect(LandingPage.Menu.Products.Element).ToContainTextAsync("Products");
            await Expect(LandingPage.Menu.News.Element).ToContainTextAsync("News");
            await Expect(LandingPage.Menu.Company.Element).ToContainTextAsync("Company");
            await Expect(LandingPage.Menu.Careers.Element).ToContainTextAsync("Careers");
            await Expect(LandingPage.Menu.Contact.Element).ToContainTextAsync("Contact");
        }
    }
}
