﻿using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace ShellPlayground.UITests
{
    /// <summary>
    /// This class serves as a base for tests where functionality that is common across many or all tests can be defined.
    /// For example, you could add a method here to log in or dismiss a welcome dialogue
    /// </summary>

    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public abstract class BaseTestFixture
    {
        protected IApp app => AppManager.App;
        protected bool OnAndroid => AppManager.Platform == Platform.Android;
        protected bool OniOS => AppManager.Platform == Platform.iOS;

        protected BaseTestFixture(Platform platform)
        {
            AppManager.Platform = platform;
        }

        [SetUp]
        public virtual void BeforeEachTest()
        {
            AppManager.StartApp();
        }
    }
}
