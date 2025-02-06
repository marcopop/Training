using Training.Core.PageObjects.Sections.PopUps;
using VSBS.Insurance.Automation.PageObjects;

namespace Training.Core.PageObjects.Pages
{
    public class ContactPage : WebPage
    {
        public TextField Name { get; set; }

        public EmailField Email { get; set; }

        public TextField Phone { get; set; }

        public TextField Company { get; set; }

        public TextField Message { get; set; }

        public DropdownField Enquiry { get; set; }

        public DropdownField EnquirySelect { get; set; }

        public Button Submit { get; set; }

        public ContactPage(IBrowserTab browserTab, string urlPath) : base(browserTab, urlPath)
        {
            Initialize();
        }

        public void Initialize()
        {
            Name = new(BrowserTab.Find("#umbraco_form_3c139a6cca2a40048d9ef95bf8ae5b59").Find(".fullname"));
            Email = new(BrowserTab.Find("#umbraco_form_3c139a6cca2a40048d9ef95bf8ae5b59").Find(".workemail"));
            Phone = new(BrowserTab.Find("#umbraco_form_3c139a6cca2a40048d9ef95bf8ae5b59").Find(".phone"));
            Company = new(BrowserTab.Find("#umbraco_form_3c139a6cca2a40048d9ef95bf8ae5b59").Find(".company"));
            Message = new(BrowserTab.Find("#umbraco_form_3c139a6cca2a40048d9ef95bf8ae5b59").Find(".message"));
            Enquiry = new(BrowserTab.Find("#umbraco_form_3c139a6cca2a40048d9ef95bf8ae5b59").Find(".enquirytype"));
            EnquirySelect = new(BrowserTab.Find("#umbraco_form_3c139a6cca2a40048d9ef95bf8ae5b59").Find(".enquirytype").Find("select"));
            Submit = new(BrowserTab.Find("#umbraco_form_3c139a6cca2a40048d9ef95bf8ae5b59").Find("input").FilterByText("Submit"));
            Name.Error = new(Name.Element.Find(".field-validation-error"));
            Email.Error = new(Email.Element.Find(".field-validation-error"));
            Phone.Error = new(Phone.Element.Find(".field-validation-error"));
            Company.Error = new(Company.Element.Find(".field-validation-error"));
            Message.Error = new(Message.Element.Find(".field-validation-error"));
            Enquiry.Error = new(Enquiry.Element.Find(".field-validation-error"));
        }

        public async Task FillInvalidEmail()
        {
            await Email.Value.Fill("ENDAVA");
        }
    }
}
