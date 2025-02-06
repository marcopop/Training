using Training.Core.PageObjects.Components;
using Training.Core.PageObjects.Sections.PopUps;
using VSBS.Insurance.Automation.PageObjects;

namespace Training.Core.PageObjects.Pages
{
    public class LandingPage : WebPage
    {
        public IElement Logo { get; set; }

        public MenuItems Menu
        { get; set; }

        public Cookies Cookies { get; set; }

        public LandingPage(IBrowserTab browserTab, string empty) : base(browserTab, urlPath: string.Empty)
        {
            Initialize();
        }

        private void Initialize()
        {
            Logo = BrowserTab.Find(".cc-header-logo");
            Menu = new MenuItems(BrowserTab.Find("nav").Nth(0));
            Cookies = new Cookies(BrowserTab.Find("#CybotCookiebotDialogBodyButtonsWrapper"));
        }

        public async Task NavigateTo()
        {
            await base.NavigateTo(login: false);
        }

        public async Task AcceptCookies()
        {
            await Cookies.AllowAll.Click();
        }
    }
}
