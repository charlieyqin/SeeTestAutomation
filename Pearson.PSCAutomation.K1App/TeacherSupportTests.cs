using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using SeeTest.Automation.Framework;


namespace Pearson.PSCAutomation.K1App
{
    [TestClass]
    public class TeacherSupportTest
    {

        public AutomationAgent TeacherSupportAutomationAgent;

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(19649)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyTappingOnBackToMediaLibraryFromTeacherSupport()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19649: Verify whether the back button is displayed on top left and When back button is pressed, the returns to MEDIA LIBRARY view with System Tray closed"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnMediaLibrary(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyBackIcon(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyUserOnMediaLibrary(TeacherSupportAutomationAgent);
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(29958)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyOfflineAlertMessageOnTeacherSupportForELAUNit()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC29958: Verify Offline Alert Message when clicking on links under welcome from ELA Unit Teacher Support"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                    TeacherSupportAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.ClickOnGrowYourSkill(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyGrowYourSkillOfflineAlertMessage(TeacherSupportAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnPrepareYourLessonLink(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyPrepareYourLessonOfflineAlertMessage(TeacherSupportAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnGetHelpLink(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyGetHelpOfflineAlertMessage(TeacherSupportAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(25139)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyOfflineAlertMessageOnTeacherSupportForMathUnit()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC25139: Verify Offline Alert Message when clicking on links On Teacher Support for Math Unit "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnUnitSlectionButton(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(TeacherSupportAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                    TeacherSupportAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.ClickOnGrowYourSkill(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyGrowYourSkillOfflineAlertMessage(TeacherSupportAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnPrepareYourLessonLink(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyPrepareYourLessonOfflineAlertMessage(TeacherSupportAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnGetHelpLink(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyGetHelpOfflineAlertMessage(TeacherSupportAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(20415)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyTappingOnScreenCloseTheOfflineAlertPopup()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC20415: Verify where tapping on offline alert popup or outside the overlay should close the alert"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                    TeacherSupportAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.ClickOnGrowYourSkill(TeacherSupportAutomationAgent);
                    Assert.AreEqual<bool>(true, TeacherSupportCommonMethods.VerifyGrowYourSkillOfflineAlertMessage(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.TapOnScreen(TeacherSupportAutomationAgent, 1600, 500);
                    Assert.AreEqual<bool>(false, TeacherSupportCommonMethods.VerifyGrowYourSkillOfflineAlertMessage(TeacherSupportAutomationAgent));
                    TeacherSupportCommonMethods.ClickOnPrepareYourLessonLink(TeacherSupportAutomationAgent);
                    Assert.AreEqual<bool>(true, TeacherSupportCommonMethods.VerifyPrepareYourLessonOfflineAlertMessage(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.TapOnScreen(TeacherSupportAutomationAgent, 1600, 500);
                    Assert.AreEqual<bool>(false, TeacherSupportCommonMethods.VerifyPrepareYourLessonOfflineAlertMessage(TeacherSupportAutomationAgent));
                    TeacherSupportCommonMethods.ClickOnGetHelpLink(TeacherSupportAutomationAgent);
                    Assert.AreEqual<bool>(true, TeacherSupportCommonMethods.VerifyGetHelpOfflineAlertMessage(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.TapOnScreen(TeacherSupportAutomationAgent, 1600, 500);
                    Assert.AreEqual<bool>(false, TeacherSupportCommonMethods.VerifyGetHelpOfflineAlertMessage(TeacherSupportAutomationAgent));
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest"), TestCategory("K1SmokeTests")]
        [WorkItem(19548)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyGrowYourSkillLinkOpenInMobileSafari()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19548: Verify when GROW YOUR SKILLS URL is opened in Mobile Safari"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnGrowYourSkill(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyLinkOpenInMobileSafari(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportCommonMethods.ClickInsideURL(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyGrowYourSkillURL(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportAutomationAgent.LaunchApp();
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest"), TestCategory("K1SmokeTests")]
        [WorkItem(19549)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPrepareYourLessonLinkOpenInMobileSafari()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19549: Verify when Prepare Your Lessons URL is opened in Mobile Safari"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnPrepareYourLessonLink(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyLinkOpenInMobileSafari(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportCommonMethods.ClickInsideURL(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyPrepareYourLessonURL(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportAutomationAgent.LaunchApp();
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest"), TestCategory("K1SmokeTests")]
        [WorkItem(19550)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyGetHelpLinkOpenInMobileSafari()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19550: Verify when Get Help URL is opened in Mobile Safari"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnGetHelpLink(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyLinkOpenInMobileSafari(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportCommonMethods.ClickInsideURL(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyGetHelpURL(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportAutomationAgent.LaunchApp();
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(19924)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyOfflineOnlineModeInTeacherSupport()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19924: Verify Offline Online mode on Grow Your SKill link in teacher support"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyUserOnTeacherSupport(TeacherSupportAutomationAgent), "Teacher support screen not open");
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                    TeacherSupportAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.ClickOnGrowYourSkill(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyGrowYourSkillOfflineAlertMessage(TeacherSupportAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                    TeacherSupportAutomationAgent.LaunchApp();
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnGrowYourSkill(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyLinkOpenInMobileSafari(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportCommonMethods.ClickInsideURL(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyGrowYourSkillURL(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportAutomationAgent.LaunchApp();
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(19925)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyOfflineOnlineModeInPrepareYourLessonLink()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19925: Verify Offline Online mode on Prepare Your Lesson link in teacher support"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyUserOnTeacherSupport(TeacherSupportAutomationAgent), "Teacher support screen not open");
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                    TeacherSupportAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.ClickOnPrepareYourLessonLink(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyPrepareYourLessonOfflineAlertMessage(TeacherSupportAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                    TeacherSupportAutomationAgent.LaunchApp();
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnPrepareYourLessonLink(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyLinkOpenInMobileSafari(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportCommonMethods.ClickInsideURL(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyPrepareYourLessonURL(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportAutomationAgent.LaunchApp();
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(19926)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyOfflineOnlineModeInGetHelpLink()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19926: Verify Offline Online mode on Get Help link in teacher support"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyUserOnTeacherSupport(TeacherSupportAutomationAgent), "Teacher support screen not open");
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                    TeacherSupportAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.ClickOnGetHelpLink(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyGetHelpOfflineAlertMessage(TeacherSupportAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                    TeacherSupportAutomationAgent.LaunchApp();
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnGetHelpLink(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyLinkOpenInMobileSafari(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportCommonMethods.ClickInsideURL(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyGetHelpURL(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportAutomationAgent.LaunchApp();
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(19554)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyWelcomeScreenOfTeacherSupport()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19554: Verify whether the Welcome Screen is displayed when Teacher support button is tapped from system tray"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyWelcomeScreen(TeacherSupportAutomationAgent), "Fail to find the Welcome screen of teacher support");
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(19648)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifySystemTrayOpenWhenComingFromTeachersupport()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19648: Verify whether the Welcome Screen is displayed when Teacher support button is tapped from system tray"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.VerifyUserIsOnHomeScreen(TeacherSupportAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySystemTrayOpen(TeacherSupportAutomationAgent), "System tray is open after returning back from teacher support screen");
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(19556)]
        [Priority(2)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyRedirectinFromSettingsScreen()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19556: Verify whether the back button is displayed on top left and When back button is pressed, the returns to UNIT SELECTION SCREEN with System Tray closed"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyBackIcon(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnBackIcon(TeacherSupportAutomationAgent);
                    UnitSelectionCommonMethods.VerifyUnitSlectionScreen(TeacherSupportAutomationAgent);
                    Assert.IsFalse(NavigationCommonMethods.VerifySystemTrayOpen(TeacherSupportAutomationAgent), "System tray found open");
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(19923)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySingleSignOnMathOfflineMessage()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19923: Verify Offline Alert Message when clicking on links On Teacher Support for Math Unit "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnUnitSlectionButton(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnMathUnit(TeacherSupportAutomationAgent, "0");
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                    TeacherSupportAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.ClickOnGrowYourSkill(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyGrowYourSkillOfflineAlertMessage(TeacherSupportAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnPrepareYourLessonLink(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyPrepareYourLessonOfflineAlertMessage(TeacherSupportAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnGetHelpLink(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyGetHelpOfflineAlertMessage(TeacherSupportAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(19908)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyPrepareYourLessonLinkThroughMathUnit()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19908: Verify when \"Prepare Your Lessons\" is tapped, the URL should be opened in Mobile Safari with user authenticated to given URL"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnMathUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnPrepareYourLessonLink(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyLinkOpenInMobileSafari(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportCommonMethods.ClickInsideURL(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyPrepareYourLessonURL(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportAutomationAgent.LaunchApp();
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(19907)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyGrowYourSkillLinkOpenInMobileSafariThroughMath()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19907: Verify when GROW YOUR SKILLS URL is opened in Mobile Safari through mobile safari"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnMathUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnGrowYourSkill(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyLinkOpenInMobileSafari(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportCommonMethods.ClickInsideURL(TeacherSupportAutomationAgent);
                    TeacherSupportAutomationAgent.Sleep();
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyGrowYourSkillURL(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportAutomationAgent.LaunchApp();
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(19922)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyOfflineOnlineModeInTeacherSupportAndAlsoWelcomeScreen()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19922: Verify Offline Online mode on Grow Your SKill link in teacher support"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyUserOnTeacherSupport(TeacherSupportAutomationAgent), "Teacher support screen not open");
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                    TeacherSupportAutomationAgent.LaunchApp();
                    TeacherSupportCommonMethods.VerifyWelcomeScreen(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnGrowYourSkill(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.VerifyGrowYourSkillOfflineAlertMessage(TeacherSupportAutomationAgent);
                    LoginCommonMethods.CloseErrorPopUp(TeacherSupportAutomationAgent);
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                    TurnWifiOff = false;
                    NavigationCommonMethods.ChangeWiFiConnectivity(TeacherSupportAutomationAgent, TurnWifiOff);
                    TeacherSupportAutomationAgent.LaunchApp();
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(19927)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyGetHelpLinkOpenInMobileSafariThroughMathUnit()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC19927: Verify when Get Help URL is opened in Mobile Safari"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnMathUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnGetHelpLink(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyLinkOpenInMobileSafari(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportCommonMethods.ClickInsideURL(TeacherSupportAutomationAgent);
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyGetHelpURL(TeacherSupportAutomationAgent), "Link not found");
                    TeacherSupportAutomationAgent.LaunchApp();
                    TeacherSupportAutomationAgent.Sleep();
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTest")]
        [WorkItem(45057)]
        [Priority(1)]
        [Owner("Namrita (namrita.agarwal)")]
        public void VerifyNewSSOAuthentication()
        {
            using (TeacherSupportAutomationAgent = new AutomationAgent("TC45057: Verify new SSO authentication."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(TeacherSupportAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(TeacherSupportAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(TeacherSupportAutomationAgent, NavigationCommonMethods.GetCurrentUnitNumber(TeacherSupportAutomationAgent));
                    NavigationCommonMethods.ClickOnSystemTray(TeacherSupportAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherSupport(TeacherSupportAutomationAgent);
                    TeacherSupportCommonMethods.ClickOnGrowYourSkill(TeacherSupportAutomationAgent);
                    TeacherSupportAutomationAgent.Sleep();
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifySSOAuthentication(TeacherSupportAutomationAgent), "single sign on not found");
                    TeacherSupportAutomationAgent.LaunchApp();
                    LoginCommonMethods.Logout(TeacherSupportAutomationAgent);
                }

                catch (Exception ex)
                {
                    TeacherSupportAutomationAgent.Sleep(2000);
                    TeacherSupportAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    TeacherSupportAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
    }
}
