using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace ShellPlayground.UITests
{
    public class ScrollPageTests : BaseTestFixture
    {
        public ScrollPageTests(Platform platform) : base(platform)
        {

        }

        [Test]
        public void Repl()
        {
            if (TestEnvironment.IsTestCloud)
            {
                Assert.Ignore("Local only");
            }

            app.Repl();
        }

        [Test]
        public void VerifyHeaderSticksDuringScroll()
        {
            new ScrollPage()
                .ScrollTo(VerticalSection.Bottom)
                .VerifyFixedHeaderShown();

        }
    }
}
