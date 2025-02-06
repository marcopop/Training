using VSBS.Insurance.Automation.PageObjects;

namespace Training.Core.PageObjects.Components
{
    public class MenuItems : Component
    {
        public IElement container;
        public LinkField Solutions { get; set; }
        public LinkField Products { get; set; }
        public LinkField News { get; set; }
        public LinkField Company { get; set; }
        public LinkField Careers { get; set; }
        public LinkField Contact { get; set; }

        public MenuItems(IElement menuItems) : base(menuItems)
        {
            container = menuItems;
            Initialize();
        }

        private void Initialize()
        {
            Solutions = new(container.Find("li").Nth(1));
            Products = new(container.Find("li").Nth(2));
            News = new(container.Find("li").Nth(3));
            Company = new(container.Find("li").Nth(4));
            Careers = new(container.Find("li").Nth(5));
            Contact = new(container.Find("li").Nth(6));
        }
    }
}
