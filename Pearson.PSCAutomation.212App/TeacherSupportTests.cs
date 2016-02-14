using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation._212App
{
    [TestClass]
    public class TeacherSupportTests
    {
        public AutomationAgent teachersupportAutomationAgent;
        public TeacherSupportTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        ////[AssemblyInitialize]
        ////public static void _212AssemblyInitialize(TestContext testContext)
        ////{

        ////}

        //[ClassInitialize]
        //public static void TeacherSupportTestsClassInitialize(TestContext testContext)
        //{
        //}
        //[TestInitialize]
        //public void TeacherSupportTestsTestInitialize()
        //{

        //}


        //[AssemblyCleanup]
        //public static void _212AssemblyCleanup()
        //{

        //}

        //[ClassCleanup]
        //public static void TeacherSupportTestsClassCleanup()
        //{

        //}
        //[TestCleanup]
        //public void TeacherSupportTestsTestCleanup()
        //{

        //}
        #endregion

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(1)]
        [WorkItem(15857)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SystemTrayTeacherSupportButtonOpensLandingPageInPSoCChrome()
        {

            using (teachersupportAutomationAgent = new AutomationAgent("TC15857: SYSTEM TRAY - Teacher Support button opens landing page in PSoC chrome"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachersupportAutomationAgent, login);
                    NavigationCommonMethods.OpenSystemTray(teachersupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyTeacherSupportButtonInSystemTray(teachersupportAutomationAgent);
                    NavigationCommonMethods.ClickSystemTrayButton(teachersupportAutomationAgent);
                    NavigationCommonMethods.NavigateTeacherSupport(teachersupportAutomationAgent);
                    NavigationCommonMethods.VerifyTeacherSupportPage(teachersupportAutomationAgent);
                    NavigationCommonMethods.Logout(teachersupportAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachersupportAutomationAgent.Sleep(2000);
                    teachersupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachersupportAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(1)]
        [WorkItem(15860)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardTeacheSupportButtonOpensLandingPageInPsocChrome()
        {

            using (teachersupportAutomationAgent = new AutomationAgent("TC15860: TEACHER DASHBOARD - Teacher Support button opens langing page in PSoC chrome"))
            {
                try
                {
                    NavigationCommonMethods.Login(teachersupportAutomationAgent, Login.GetLogin("Sec9Apatton"));
                    NavigationCommonMethods.VerifyDashboard(teachersupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyTeacherSupportButtonDashboard(teachersupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickTeacherSupportButtonDashboard(teachersupportAutomationAgent);
                    NavigationCommonMethods.VerifyTeacherSupportPage(teachersupportAutomationAgent);
                    NavigationCommonMethods.Logout(teachersupportAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachersupportAutomationAgent.Sleep(2000);
                    teachersupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachersupportAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }




        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(15859)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherSupportLinksOnLandingPageDirectUserToExternalResourceSites()
        {

            using (teachersupportAutomationAgent = new AutomationAgent("TC15859: Teacher Support - links on landing page direct user to external resource sites"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachersupportAutomationAgent, login);
                    NavigationCommonMethods.NavigateTeacherSupport(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportPage(teachersupportAutomationAgent));
                    TeacherSupportCommonMethods.ClickOnFirstUrl(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyExternalBrowserOpen(teachersupportAutomationAgent));
                    teachersupportAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.ClickOnSecondUrl(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyExternalBrowserOpen(teachersupportAutomationAgent));
                    teachersupportAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.ClickOnThirdUrl(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyExternalBrowserOpen(teachersupportAutomationAgent));
                    teachersupportAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Logout(teachersupportAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachersupportAutomationAgent.Sleep(2000);
                    teachersupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachersupportAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(3)]
        [WorkItem(19058)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void TeacherSupportPageChromeTitleSaysTeacherSupport()
        {

            using (teachersupportAutomationAgent = new AutomationAgent("TC19058: Teacher Support page chrome title says Teacher Support"))
            {
                try
                {
                    Login login = Login.GetLogin("GustadMody");
                    NavigationCommonMethods.Login(teachersupportAutomationAgent, login);
                    NavigationCommonMethods.NavigateTeacherSupport(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportPageTitle(teachersupportAutomationAgent), "Teacher support page title not present");
                    NavigationCommonMethods.Logout(teachersupportAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachersupportAutomationAgent.Sleep(2000);
                    teachersupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachersupportAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(34062)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void CAWhenTeacherTapsTeacherSupportInTrayThenCASpecificTecherGuideSiteOpensInWebview()
        {

            using (teachersupportAutomationAgent = new AutomationAgent("TC34062: CA - WHEN teacher taps Teacher Support in Tray THEN CA-specific techer guide site opens in webview"))
            {
                try
                {
                    NavigationCommonMethods.Login(teachersupportAutomationAgent, Login.GetLogin("GustadMody"));
                    NavigationCommonMethods.NavigateTeacherSupport(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportPage(teachersupportAutomationAgent), "Teacher Support Page not present");
                    NavigationCommonMethods.Logout(teachersupportAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachersupportAutomationAgent.Sleep(2000);
                    teachersupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachersupportAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(18572)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void URLsOnTeacherSupportPageLinkTo()
        {

            using (teachersupportAutomationAgent = new AutomationAgent("TC18572: 3 URLs on Teacher Support page link to..."))
            {
                try
                {
                    NavigationCommonMethods.Login(teachersupportAutomationAgent, Login.GetLogin("GustadMody"));
                    NavigationCommonMethods.NavigateTeacherSupport(teachersupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnFirstUrl(teachersupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyFirstUrlInWebView(teachersupportAutomationAgent);
                    teachersupportAutomationAgent.LaunchApp();
                    teachersupportAutomationAgent.Sleep();
                    TeacherSupportCommonMethods.ClickOnSecondUrl(teachersupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifySecondUrlInWebView(teachersupportAutomationAgent);
                    teachersupportAutomationAgent.LaunchApp();
                    teachersupportAutomationAgent.Sleep();
                    TeacherSupportCommonMethods.ClickOnThirdUrl(teachersupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyThirdUrlInWebView(teachersupportAutomationAgent);
                    teachersupportAutomationAgent.LaunchApp();
                    teachersupportAutomationAgent.Sleep();
                    NavigationCommonMethods.Logout(teachersupportAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachersupportAutomationAgent.Sleep(2000);
                    teachersupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachersupportAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(3)]
        [WorkItem(16028)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void WhenYouTapAnyLinkWhileWiFiOffThenErrorMessageAppears()
        {

            using (teachersupportAutomationAgent = new AutomationAgent("TC16028: WHEN you tap any link while wi-fi is off THEN error message appears"))
            {
                try
                {
                    NavigationCommonMethods.ChangeWiFiConnectivity(teachersupportAutomationAgent, true);
                    teachersupportAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Login(teachersupportAutomationAgent, Login.GetLogin("GustadMody"));
                    NavigationCommonMethods.NavigateTeacherSupport(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportPage(teachersupportAutomationAgent), "Teacher Support Page not present");
                    TeacherSupportCommonMethods.ClickOnFirstUrl(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoInternetConnectionPopUp(teachersupportAutomationAgent), "No Internet Connection pop up not present");
                    LoginLogoutCommonMethods.ClickOnOkButton(teachersupportAutomationAgent);
                    Assert.IsFalse(TeacherSupportCommonMethods.VerifyNoInternetConnectionPopUp(teachersupportAutomationAgent), "No Internet Connection pop up still present");
                    TeacherSupportCommonMethods.ClickOnSecondUrl(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoInternetConnectionPopUp(teachersupportAutomationAgent), "No Internet Connection pop up not present");
                    LoginLogoutCommonMethods.ClickOnOkButton(teachersupportAutomationAgent);
                    Assert.IsFalse(TeacherSupportCommonMethods.VerifyNoInternetConnectionPopUp(teachersupportAutomationAgent), "No Internet Connection pop up still present");
                    TeacherSupportCommonMethods.ClickOnThirdUrl(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoInternetConnectionPopUp(teachersupportAutomationAgent), "No Internet Connection pop up not present");
                    LoginLogoutCommonMethods.ClickOnOkButton(teachersupportAutomationAgent);
                    Assert.IsFalse(TeacherSupportCommonMethods.VerifyNoInternetConnectionPopUp(teachersupportAutomationAgent), "No Internet Connection pop up still present");
                    NavigationCommonMethods.Logout(teachersupportAutomationAgent);
                    NavigationCommonMethods.ChangeWiFiConnectivity(teachersupportAutomationAgent, false);
                }
                catch (Exception ex)
                {
                    teachersupportAutomationAgent.Sleep(2000);
                    teachersupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachersupportAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(1)]
        [WorkItem(15861)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherSupportLandingPageStylingAlignedToSpecs()
        {

            using (teachersupportAutomationAgent = new AutomationAgent("TC15861: Teacher Support: Landing page styling aligned to specs"))
            {
                try
                {
                    NavigationCommonMethods.Login(teachersupportAutomationAgent, Login.GetLogin("Sec9Apatton"));
                    NavigationCommonMethods.VerifyDashboard(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportButtonDashboard(teachersupportAutomationAgent), "Teacher support button not found");
                    TeacherSupportCommonMethods.ClickTeacherSupportButtonDashboard(teachersupportAutomationAgent);
                    NavigationCommonMethods.VerifyTeacherSupportPage(teachersupportAutomationAgent);
                    NavigationCommonMethods.Logout(teachersupportAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachersupportAutomationAgent.Sleep(2000);
                    teachersupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachersupportAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(3)]
        [WorkItem(16029)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void SingleSignOnWorksCorrect()
        {

            using (teachersupportAutomationAgent = new AutomationAgent("TC16029: Single-sign-on - works correct"))
            {
                try
                {
                    NavigationCommonMethods.Login(teachersupportAutomationAgent, Login.GetLogin("Sec9Apatton"));
                    NavigationCommonMethods.NavigateTeacherSupport(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportPage(teachersupportAutomationAgent), "Teacher Support Page not present");
                    TeacherSupportCommonMethods.ClickOnSecondUrl(teachersupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifySecondUrlInWebView(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyLogoutInUrlTeacherAlreadyLoggedIn(teachersupportAutomationAgent), "Log out button not present");
                    teachersupportAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.ClickOnThirdUrl(teachersupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyThirdUrlInWebView(teachersupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyLogoutInUrlTeacherAlreadyLoggedIn(teachersupportAutomationAgent), "Log out button not present");
                    teachersupportAutomationAgent.LaunchApp();
                    NavigationCommonMethods.Logout(teachersupportAutomationAgent);
                }
                catch (Exception ex)
                {
                    teachersupportAutomationAgent.Sleep(2000);
                    teachersupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    teachersupportAutomationAgent.ApplicationClose();
                    throw;
                }
            }
        }

    }
}
