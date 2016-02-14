using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Pearson.PSCAutomation.Framework;


namespace Pearson.PSCAutomation.K1App
{
    [TestClass]
    public class NavigationTest
    {
        public AutomationAgent navigationAutomationAgent;

        [AssemblyInitialize]
        public static void K1AssemblyInitialize(TestContext testContext)
        {
            if (bool.Parse(ConfigurationManager.AppSettings["ReportFolderPerRun"]))
            {
                AutomationAgent.CreateAndSetReportsFolder("K1");
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(20022)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMTECCIconPressedState()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC20022: Verify whether the PRESSED STATE is displayed on MTE/CC icon when tapped on it"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    Assert.AreEqual<bool>(false, NavigationCommonMethods.VerifyMTEIconIsInPressedState(navigationAutomationAgent));
                    NavigationCommonMethods.LongClickOnMTECCNavIcon(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyMTEIconIsInPressedState(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    Assert.AreEqual<bool>(false, NavigationCommonMethods.VerifyMTEIconIsInPressedState(navigationAutomationAgent));
                    NavigationCommonMethods.LongClickOnMTECCNavIcon(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyMTEIconIsInPressedState(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest"), TestCategory("K1SmokeTests")]
        [WorkItem(22306)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyGlobalNavBarIconsAsStudent()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC22306: Ensure that Global Navigation bar is displayed properly in appropriate screens for Student"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.VerifyIconsInNavigationBar(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyNotebookIconIsInPressedState(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NavigationTest"), TestCategory("K1SmokeTests")]
        [WorkItem(22308)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyGlobalNavBarIconsAsTeacher()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC22308:Ensure that Global Navigation bar is displayed properly in appropriate screens for Teacher"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.VerifyIconsInNavigationBar(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyNotebookIconIsInPressedState(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(29990)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySizeOfIconsInNavigationBar()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC29990:Ensure that the icons in Global navigation bar are equally sized in every screen and verify the transition of screens when opened"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconsSize(navigationAutomationAgent));
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconEquallySpaced(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconsSize(navigationAutomationAgent));
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconEquallySpaced(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconsSize(navigationAutomationAgent));
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconEquallySpaced(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconsSize(navigationAutomationAgent));
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconEquallySpaced(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(27053)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyGlobalNavBarIconsHighlighted()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC27053:Verify the display of Previously selected/highlighted icon when the user is transitioning to other view/screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyNotebookIconIsInPressedState(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(navigationAutomationAgent);
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyNotebookIconIsInPressedState(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(navigationAutomationAgent);
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.AreEqual<bool>(false, NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(23206)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTermsOfUseOnHomeScreen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC23206: Verify terms of use and Privacy statement should be available on the welcome landing page of K1 app."))
            {
                try
                {
                    NavigationCommonMethods.VerifyTermsOfUseLinkOnHomeScreen(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnTermsOfUse(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyTermsOfUseOpensInDialogBox(navigationAutomationAgent));
                    NavigationCommonMethods.VerifyGradientAtBottomInBox(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnCrossButton(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifyTermsOfUseOpensInDialogBox(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnTermsOfUse(navigationAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(navigationAutomationAgent, 1600, 1200);
                    Assert.IsFalse(NavigationCommonMethods.VerifyTermsOfUseOpensInDialogBox(navigationAutomationAgent));
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(23207)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyPrivacyStatementOnHomeScreen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC23207: Verify terms of use and Privacy statement should be available on the welcome landing page of K1 app."))
            {
                try
                {
                    NavigationCommonMethods.VerifyPrivacyStatement(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnPrivacyStatementLink(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyPrivacyStatementOpensInDialogBox(navigationAutomationAgent));
                    NavigationCommonMethods.VerifyGradientAtBottomInBox(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnCrossButton(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifyPrivacyStatementOpensInDialogBox(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnPrivacyStatementLink(navigationAutomationAgent);
                    NavigationCommonMethods.TapOnScreen(navigationAutomationAgent, 1600, 1200);
                    Assert.IsFalse(NavigationCommonMethods.VerifyPrivacyStatementOpensInDialogBox(navigationAutomationAgent));
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19255)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyGlobalNavBarIcons()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19255: UI elements should be present in the navigation bar of student home screen: "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.VerifyIconsInNavigationBar(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19256)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyGlobalNavBarIconAsTeacher()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19256: UI elements should be present in the navigation bar of teacher home screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.VerifyIconsInNavigationBar(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19258)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyHomeScreenIsInPressedState()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19258:Verify that only the Home icon in Navigation bar is highlighted when the user is in Home screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyNotebookIconIsInPressedState(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19259)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMedialibraryIconIsInPressedState()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19259:Verify that only the Media Library icon in Navigation bar is highlighted when the Student is in Media library screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(navigationAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyNotebookIconIsInPressedState(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19500)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyNavigationBarActiveWhenSystemTrayOpen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19500:Verify whether the Navigation bar is only active/tappable when tray is closed when logged in as student"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifyNavigationBarActive(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19531)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyHomeScreenIsInPressedStateASTeacher()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19531:Verify that only the Home icon in Navigation bar is highlighted when the Teacher is in Home screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyNotebookIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19532)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMedialibraryIconIsInPressedStateAsTeacher()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19532: Verify that only the Media Library icon in Navigation bar is highlighted when the teacher is in Media library screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(navigationAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyNotebookIconIsInPressedState(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19533)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyNavigationBarActiveWhenSystemTrayOpenAsTeacher()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19533: Verify whether the Navigation bar is only active/tappable when tray is closed when logged in as teacher"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifyNavigationBarActive(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19542)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyLoadingIndicatorInCCScreen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19542: Verify that loading indicator is displayed when CC screen is loading for MATH units."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnMathUnit(navigationAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnMTE_CCIcon(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyLoadingIndicator(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnBackButtonatMTE(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19543)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyLoadingIndicatorInMTEScreen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19543: Verify that loading indicator is displayed when MTE screen is loading for ELA units"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMTE_CCIcon(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyLoadingIndicator(navigationAutomationAgent));
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19544)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBackButtonInMTEScreen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19544: Verify that back button is present on top left corner for MTE screen of ELA units"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMTE_CCIcon(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInMTEscreen(navigationAutomationAgent));
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackButtonatMTE(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19545)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBAckButtonInCCScreen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19545: Verify that back button is present on top left corner for CC screen of MATH units"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnMathUnit(navigationAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnMTE_CCIcon(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInCCScreen(navigationAutomationAgent));
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackButtonatMTE(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19580)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyRedirectionFromSettingsScreen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19580: Verify that the tray should NOT remain open,when clicking back button from settings screen."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyUserOnSettingsscreen(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnGoBackIcon(navigationAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUnitSlectionScreen(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySystemTrayOpen(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);

                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest"), TestCategory("K1SmokeTests")]
        [WorkItem(19540)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyMTEScreenOpen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19540: Verify navigation bar in ELA units opens More To Explore screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMTE_CCIcon(navigationAutomationAgent);
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyMTEscreenOpen(navigationAutomationAgent), "Fail if MTE screen is not open");
                    Assert.IsTrue(NavigationCommonMethods.VerifyMTETextTopCentered(navigationAutomationAgent), "Fail if MTE screen is not centered");
                    NavigationCommonMethods.ClickOnGoBackIcon(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19541)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyCCScreenOpen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19541: Verify navigation bar in MATH units opens concept corner"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnMathUnit(navigationAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnMTE_CCIcon(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifyCCscreenOpen(navigationAutomationAgent));
                    Assert.IsTrue(NavigationCommonMethods.VerifyCCTextTopCentered(navigationAutomationAgent));
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackButtonatMTE(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19547)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMessageOnCCScreenWhenWiFiOff()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19547: Verify that error message No internet connection. is displayed when user clicks on CC icon in navigation bar of MATH units having no internet connectivity"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnMathUnit(navigationAutomationAgent, "0");
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(navigationAutomationAgent, TurnWifiOff);
                    navigationAutomationAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnMTE_CCIcon(navigationAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyNoInternetAlertMessageOnMathUnit(navigationAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(navigationAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19546)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMessageOnELAScreenWhenWiFiOff()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19546: Verify that error message No internet connection. is displayed when user clicks on MTE icon in navigation bar of ELA units having no internet connectivity"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(navigationAutomationAgent, TurnWifiOff);
                    navigationAutomationAgent.LaunchApp();
                    NavigationCommonMethods.ClickOnMTE_CCIcon(navigationAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyNoInternetAlertMessageOnELAUnit(navigationAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(navigationAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(22680)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyClickingOnBackIconFromBookBuilder()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC22680: Verify that tapping on back button in the book browser, the screen from which the book builder was launched gets displayed."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUnitSlectionScreen(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyUserIsOnHomeScreen(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnMediaLibrary(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                    TeacherSupportCommonMethods.VerifyUserOnMediaLibrary(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnNotebookBrowser(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyUserOnNoteBookBrowser(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);

                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(22681)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyBookBrowserDisplayAfterClickingBackButtonInPageBrowser()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC22681: Verify that tapping on back button in page browser saves the book and book browser is displayed"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBookBuilder(navigationAutomationAgent);
                    BookBuilderCommonMethods.ClickOnBookEditButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                    BookBuilderCommonMethods.VerifyBookBrowserScreen(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(22860)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyCLickingBackAfterAttemptingWrongPicPwd()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC22860:Verify that while logging in using picture password, if we keep on entering wrong password and then we hit back. It should takes us to Student login startup page."))
            {
                try
                {
                    LoginCommonMethods.VerifyAndSetupStudent(navigationAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnStudentLogin(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnLogInButton(navigationAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(navigationAutomationAgent, 1, 2, 3);
                    LoginCommonMethods.VerifyTryAgainErrorPopup(navigationAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(navigationAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(navigationAutomationAgent, 1, 2, 3);
                    LoginCommonMethods.VerifyTryAgainErrorPopup(navigationAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                    LoginCommonMethods.VerifyLoginStartUpScreen(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(22861)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyClickingOnCancelBeforePracticeMode()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC22861: Verify redirection when hitting on back icon after password setup process"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(navigationAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(navigationAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnResetPassword(navigationAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(navigationAutomationAgent, 1, 1, 1);
                    LoginCommonMethods.ClickCrossMarkAtPicturePasswordScreen(navigationAutomationAgent);
                    LoginCommonMethods.VerifyLoginStartUpScreen(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                    LoginCommonMethods.VerifyStudentSetUpTitle(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(navigationAutomationAgent, 3);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(22862)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyClickingOnBackIconAfterPasswordReset()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC22862: Verify redirection when hitting on back icon after password reset process"))
            {
                try
                {

                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(navigationAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(navigationAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnResetPassword(navigationAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(navigationAutomationAgent, 1, 1, 1);
                    LoginCommonMethods.ClickGreenMarkPicturePasswordScreen(navigationAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(navigationAutomationAgent, 1, 1, 1);
                    NavigationCommonMethods.ClickOnNextArrowAtLetsPractice(navigationAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(navigationAutomationAgent, 1, 1, 1);
                    NavigationCommonMethods.ClickOnLetsLoginArrow(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                    LoginCommonMethods.VerifyStudentSetUpTitle(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(navigationAutomationAgent, 2);

                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(22863)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyClickingOnBackIconAfterPasswordSetUp()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC22863: Verify redirection when hitting on back icon after password setup process for fresh user"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(navigationAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(navigationAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.SelectPicPassword(navigationAutomationAgent, 1, 1, 1);
                    LoginCommonMethods.ClickGreenMarkPicturePasswordScreen(navigationAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(navigationAutomationAgent, 1, 1, 1);
                    NavigationCommonMethods.ClickOnNextArrowAtLetsPractice(navigationAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(navigationAutomationAgent, 1, 1, 1);
                    NavigationCommonMethods.ClickOnLetsLoginArrow(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                    LoginCommonMethods.VerifyStudentSetUpTitle(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(navigationAutomationAgent, 2);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(22309)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyGlobalNavBarEquallySized()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC22309:Ensure that the icons in Global navigation bar are equally sized in every screen and verify the transition of screens when opened"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconsSize(navigationAutomationAgent));
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconEquallySpaced(navigationAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyNotebookIconIsInPressedState(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconsSize(navigationAutomationAgent));
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconEquallySpaced(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconsSize(navigationAutomationAgent));
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconEquallySpaced(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyNotebookIconIsInPressedState(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnNotebookBrowser(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconsSize(navigationAutomationAgent));
                    Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyGlobalNavIconEquallySpaced(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyHomeNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsFalse(NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookIconIsInPressedState(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19782)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTeacherModeIconPressedState()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19782: Verify whether the PRESSED STATE is displayed on TEACHER MODE icon when tapped on it"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherMode(navigationAutomationAgent);
                    TeacherModeCommonMethods.ClickOnUnitOverview(navigationAutomationAgent);
                    Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyTeacherModeIconPressedState(navigationAutomationAgent));
                    NavigationCommonMethods.TapOnScreen(navigationAutomationAgent, 100, 100);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(19771)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyMedialibraryIconIsInPressedStateForTeacherAndStudent()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC19771: Verify the Media Library icon in Navigation bar is highlighted when the Student/teacher is in Media library screen"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentKevin"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(navigationAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(navigationAutomationAgent);
                    Assert.IsTrue(NotebookCommonMethods.VerifyMediaLibraryNavIconIsInPressedState(navigationAutomationAgent));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(22859)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTappingOnBackAfterSelectingUser()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC22859: Verify Tapping on back button after selecting teacher name and student name using Im not link"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnStudentLogin(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnIamNot(navigationAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(navigationAutomationAgent, Login.GetLogin("TeacherJoshalyn"));
                    LoginCommonMethods.ClickGreenMark(navigationAutomationAgent);
                    LoginCommonMethods.SelectSpecificUserFromList(navigationAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.ClickGreenMark(navigationAutomationAgent);
                    LoginCommonMethods.VerifyStudentNameAtHelloScreen(navigationAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                    LoginCommonMethods.VerifyStudentAvatar(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("UnitSelectionTest"), TestCategory("K1SmokeTests")]
        [WorkItem(29862)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySystemTrayElementsForTeacher()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC29862: Verify Elements on System tray for teacher"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    UnitSelectionCommonMethods.VerifyUnitSlectionScreen(navigationAutomationAgent);
                    LoginCommonMethods.VerifyDisplayNameAtSystemTray(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    UnitSelectionCommonMethods.VerifyStudentImageAtSystemTray(navigationAutomationAgent);
                    Assert.IsTrue(UnitSelectionCommonMethods.VerifyTeacherSupportAtSystemTray(navigationAutomationAgent), "Fail if teacher support will be available for student");
                    Assert.IsTrue(SystemTrayCommonMethods.VerifyAssessmentManager(navigationAutomationAgent), "Assessment Manager tab not found");
                    Assert.IsTrue(SystemTrayCommonMethods.VerifyAssessmentReports(navigationAutomationAgent), "Assessment Reports tab not found");
                    UnitSelectionCommonMethods.VerifySettingsAtSystemTray(navigationAutomationAgent);
                    UnitSelectionCommonMethods.VerifyBookBuilderAtSystemTray(navigationAutomationAgent);
                    UnitSelectionCommonMethods.VerifyInboxAtSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyUnitSlectionButton(navigationAutomationAgent);
                    LoginCommonMethods.ClickOnLogoutButton(navigationAutomationAgent);
                    LoginCommonMethods.VerifyLogoutPopupUI(navigationAutomationAgent);
                    LoginCommonMethods.ClicktoCancelLogout(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("UnitSelectionTest")]
        [WorkItem(23890)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTappingOnBackButtonFromInteractiveNotebook()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC23890: Verify tapping on back button when interactive added to notebook"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnTodayButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickToOpenInteractiveFromTodaysShelf(navigationAutomationAgent);
                    int dragableElementCount = InteractiveCommonMethods.GetDragableElementCount(navigationAutomationAgent);
                    InteractiveCommonMethods.ClickOnSendToNotebookButton(navigationAutomationAgent);
                    NotebookCommonMethods.ClickOnYesbutton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnIntercativeImageFromNotebook(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(navigationAutomationAgent);
                    NotebookCommonMethods.VerifyNotebookdrawRegionExists(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(navigationAutomationAgent);
                    Assert.IsTrue(InteractiveCommonMethods.VerifyDraggableElement(navigationAutomationAgent, dragableElementCount), "Fail when same interactive will not open");
                    NavigationCommonMethods.ClickOnGoBackIcon(navigationAutomationAgent);
                    UnitSelectionCommonMethods.VerifyTodayShelfOpen(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(31839)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySpinnerForMTEAndCCScreen()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC31839: Verify that K1-specific spinner is displayed when user taps on MTE/CC icon from GNB and waiting for external website to open in the app within a frame"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    NavigationCommonMethods.ClickOnELAUnit(navigationAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnMTE_CCIcon(navigationAutomationAgent);
                    LoginCommonMethods.VerifySunSpinnerInCentre(navigationAutomationAgent);
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnUnitSlectionButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(navigationAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnMTE_CCIcon(navigationAutomationAgent);
                    LoginCommonMethods.VerifySunSpinnerInCentre(navigationAutomationAgent);
                    LoginCommonMethods.WaitForSpinnerToBeDisappeared(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnGoBackIcon(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(46633)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyAssessmentManagerSubMenu()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC46633: Verify Assessment manger sub menu"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickonAssessmentManager(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyItemsInAssessmentManagersubmenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(46634)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyAssessmentReportsSubMenu()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC46634: Verify Assessment Reports sub menu"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickonAssessmentReports(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyItemsInAssessmentReportssubmenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(46535)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAssessmentReportsKindergartenELASubMenu()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC46535: Verify teacher is able to click on the System Tray icon & click on the Kindergarten ELA sub menu item to load the assessment report view for this grade and subject."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickonAssessmentReports(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyItemsInAssessmentReportssubmenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnKindergartenAssessmentReportButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyKindergartenAssessmentReportViewOpen(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    navigationAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(46536)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyAssessmentReportsGradeELASubMenu()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC46536: Verify teacher is able to click on the System Tray icon & click on the 1st Grade ELA sub menu item to load the assessment report view for this grade and subject."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickonAssessmentReports(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyItemsInAssessmentReportssubmenu(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnGradeELAAssessmentReportButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyGradeELAAssessmentReportViewOpen(navigationAutomationAgent);
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    navigationAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTest")]
        [WorkItem(55825)]
        [Priority(1)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyCollapseOfSystemTraySubSections()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC55825: VerifyUpdate System tray to collapse subsections that were previously opened and accessed"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(navigationAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(navigationAutomationAgent, Login.GetLogin("TeacherAbdul"));
                    TaskInfo taskInfo = Login.GetLogin("TeacherAbdul").GetTaskInfo("ELA", "Notebook");
                    String[] UnitStatus = BackUpAndRestoreCommonMethods.LoadUnitStatusFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    NavigationCommonMethods.ClickonAssessmentManager(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));

                    //Tap  On Inbox
                    NavigationCommonMethods.ClickOnInboxButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));

                    //Tap On Unit Selection
                    NavigationCommonMethods.ClickonAssessmentManager(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnUnitSlectionButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));

                    //Tap On Settings
                    NavigationCommonMethods.ClickonAssessmentManager(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnSettingsButtons(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));

                    //Tap On Book Builder
                    NavigationCommonMethods.ClickonAssessmentManager(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnBookBuilder(navigationAutomationAgent);
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));

                    //Tap On Teacher Support
                    NavigationCommonMethods.ClickonAssessmentManager(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherSupport(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));

                    //For Reports Flow
                    NavigationCommonMethods.ClickonAssessmentReports(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));

                    //Tap  On Inbox
                    NavigationCommonMethods.ClickOnInboxButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));

                    //Tap On Unit Selection
                    NavigationCommonMethods.ClickonAssessmentReports(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnUnitSlectionButton(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));

                    //Tap On Settings
                    NavigationCommonMethods.ClickonAssessmentReports(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnSettingsButtons(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));

                    //Tap On Book Builder
                    NavigationCommonMethods.ClickonAssessmentReports(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnBookBuilder(navigationAutomationAgent);
                    EreaderCommonMethod.ClickOnBackIconInNoteBookReview(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));

                    //Tap On Teacher Support
                    NavigationCommonMethods.ClickonAssessmentReports(navigationAutomationAgent);
                    Assert.IsTrue(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));
                    NavigationCommonMethods.ClickOnTeacherSupport(navigationAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(navigationAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySubMenuOfAssessmentManagerAndReports(navigationAutomationAgent));                    
                    LoginCommonMethods.Logout(navigationAutomationAgent);
                }

                catch (Exception ex)
                {
                    navigationAutomationAgent.Sleep(2000);
                    navigationAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    navigationAutomationAgent.CloseApplication();
                    navigationAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }


    }
}
