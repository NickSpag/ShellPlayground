using System;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace ShellPlayground.UITests
{
    public class ScrollPage : BasePage
    {
        private readonly Query headerLabel;
        private readonly Query scrollView;
        private readonly Query bottomLabel;

        //grab a UI element unique to this page to determine the page has loaded properly
        //WARN: in this property, dont use any of your queries defined in this page as it's is called in the base constructor.
        protected override PlatformQuery Trait => new PlatformQuery()
        {
            Android = x => x.Marked("CarImage"),
            iOS = x => x.Marked("CarImage"),
        };

        public ScrollPage()
        {
            if (OniOS || OniOS)
            {
                headerLabel = x => x.Marked("FixedHeaderTextLabel");
                scrollView = x => x.Marked("Scroller");
                bottomLabel = x => x.Marked("FinalTextBox");
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public ScrollPage ScrollTo(VerticalSection section)
        {
            switch (section)
            {
                case VerticalSection.Bottom:
                    app.WaitForElement(scrollView);
                    app.ScrollDownTo(bottomLabel);
                    break;
                default:
                    break;
            }

            return this;
        }

        public void VerifyFixedHeaderShown()
        {
            app.WaitForElement(headerLabel, "Timed out after .2 seconds", TimeSpan.FromMilliseconds(200));
        }
    }
}
