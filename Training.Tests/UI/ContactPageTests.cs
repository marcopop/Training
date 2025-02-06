using Training.Core.PageObjects.Helpers;
using Training.Core.PageObjects.Pages;

namespace Training.Tests.UI
{
    [Parallelizable(ParallelScope.Self)]
    public class ContactPageTests : UIBasePageTest
    {
        private ContactPage ContactPage { get; set; }
        
        private LandingPage? LandingPage { get; set; }

        [SetUp]
        public async Task TestSetup()
        {
            ContactPage = new ContactPage(BrowserTab, "contact");
            LandingPage = new LandingPage(BrowserTab, string.Empty);

            await LandingPage.NavigateTo();
            await LandingPage.AcceptCookies();

            // Navigate to login page without login
            await ContactPage.NavigateTo(false);
        }

        [Test]
        public async Task MandatoryLabelContainsAsterisk()
        {
            await Expect(ContactPage.Name.Element).ToContainTextAsync("*");
            await Expect(ContactPage.Email.Element).ToContainTextAsync("*");
            await Expect(ContactPage.Company.Element).ToContainTextAsync("*");
            await Expect(ContactPage.Message.Element).ToContainTextAsync("*");
            await Expect(ContactPage.Enquiry.Element).ToContainTextAsync("*");
        }

        [Test]
        public async Task CheckEnquiryTypeDropdown()
        {
            // Enquiry Type dropdown values are displayed
            foreach (var type in EnquiryTypes.types)
            {
                await Expect(ContactPage.EnquirySelect.Element).ToContainTextAsync(type);
            }
        }

        [Test]
        public async Task CheckErrorMessageValidation()
        {
            // The error validation messages are displayed after clicking on submit
            await ContactPage.Submit.Click();
            await Expect(ContactPage.Name.Error.Element).ToHaveTextAsync("Please provide a value for Full Name");
            await Expect(ContactPage.Email.Error.Element).ToHaveTextAsync("Please provide a value for Work email");
            await Expect(ContactPage.Company.Error.Element).ToHaveTextAsync("Please provide a value for Company");
            await Expect(ContactPage.Message.Error.Element).ToHaveTextAsync("Please provide a value for Message");
            await Expect(ContactPage.Enquiry.Error.Element).ToHaveTextAsync("Please provide a value for Enquiry Type");
        }

        [Test]
        public async Task CheckEmailValidationMessage()
        {
            await ContactPage.FillInvalidEmail();
            await ContactPage.Submit.Click();
            await Expect(ContactPage.Email.Error.Element).ToHaveTextAsync("Please provide a valid email address");
        }
    }
}
