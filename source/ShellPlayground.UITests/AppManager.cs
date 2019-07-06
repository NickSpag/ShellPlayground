using System;
using Xamarin.UITest;

namespace ShellPlayground.UITests
{
    internal static class AppManager
    {
        const string ApkPath = "../../../binaries/com.nickspag.shellplayground.apk";
        const string AppPath = "../../../binaries/ShellPlayground.iOS.app";
        //const string IpaBundleId = "";

        static IApp app;
        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return app;
            }
        }

        static Platform? platform;
        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        public static void StartApp()
        {
            if (Platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    // Used to run a .apk file:
                    .ApkFile(ApkPath)
                    .StartApp();
            }

            if (Platform == Platform.iOS)
            {
                app = ConfigureApp
                    .iOS
                    // Used to run a .app file on an ios simulator:
                    .EnableLocalScreenshots()
                    .AppBundle(AppPath)
                    // Used to run a .ipa file on a physical ios device:
                    //.InstalledApp(ipaBundleId)
                    .StartApp();
            }
        }
    }
}
