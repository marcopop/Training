using VSBS.Insurance.Automation.PageObjects;

namespace Training.Core.PageObjects.Sections.PopUps
{
    public class Cookies : Component
    {
        public Button AllowAll {  get; set; }

        public Cookies(IElement container) : base(container)
        {
            Initialize();
        }

        private void Initialize()
        {
            AllowAll = new(Element.Find("#CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        }
    }
}
