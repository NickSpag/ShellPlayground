using System;
using Xamarin.UITest;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery,
                          Xamarin.UITest.Queries.AppQuery>;

namespace ShellPlayground.UITests
{
    public class AboutPage : BasePage
    {
        readonly Query labelInGrid;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked(""),
            iOS = x => x.Marked(""),
        };

        public AboutPage()
        {
            if (OniOS)
            {
                labelInGrid = x => x.Marked("");
            }
        }

    }
}
