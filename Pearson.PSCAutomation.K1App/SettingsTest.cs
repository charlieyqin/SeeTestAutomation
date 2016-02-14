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
    public class SettingsTest
    {
        public AutomationAgent SettingAutomationAgent;

        [TestMethod()]
        [TestCategory("SettingTest"), TestCategory("K1SmokeTests")]
        [WorkItem(25478)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyConfigCodeIsNotEditableAtSettings()
        {
            using (SettingAutomationAgent = new AutomationAgent("TC25478: Verify that the user cannot edit the config code in the settings screen."))
            {
                try
                {
                    LoginCommonMethods.WaitForContentToBeExtracted(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(SettingAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(SettingAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(SettingAutomationAgent);
                    SettingsCommonMethods.VerifyConfigCodeIsNotEditable(SettingAutomationAgent);
                    LoginCommonMethods.Logout(SettingAutomationAgent);
                }

                catch (Exception ex)
                {
                    SettingAutomationAgent.Sleep(2000);
                    SettingAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    SettingAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("SettingTest")]
        [WorkItem(31593)]
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUnitLabelAtSettingsScreen()
        {
            using (SettingAutomationAgent = new AutomationAgent("TC31593: Verify that for both ELA and Math units, unit label should be displayed instead of unit number on Settings page for downloaded units."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(SettingAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(SettingAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    string getDownloadedUnitNumber = NavigationCommonMethods.GetCurrentUnitNumber(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(SettingAutomationAgent, getDownloadedUnitNumber);
                    NavigationCommonMethods.ClickOnSystemTray(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(SettingAutomationAgent);
                    Assert.IsTrue(SettingsCommonMethods.VerifyUnitLableDisplayAtSetting(SettingAutomationAgent, getDownloadedUnitNumber), "Fail if downloaded unit will not display");
                    LoginCommonMethods.Logout(SettingAutomationAgent);
                }

                catch (Exception ex)
                {
                    SettingAutomationAgent.Sleep(2000);
                    SettingAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    SettingAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("SettingTest")]
        [WorkItem(31835)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyHiddenUpdateContentButtonInSettings()
        {
            using (SettingAutomationAgent = new AutomationAgent("TC31835: Verify that  that Update Content button in Settings should be hidden"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(SettingAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(SettingAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    string unitNumber = NavigationCommonMethods.GetCurrentUnitNumber(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnELAUnit(SettingAutomationAgent, unitNumber);
                    NavigationCommonMethods.ClickOnSystemTray(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(SettingAutomationAgent);
                    Assert.IsFalse(SettingsCommonMethods.VerifyUpdateContentLabelPerUnit(SettingAutomationAgent, unitNumber), "Fail if update content button display for downloaded unit");
                    LoginCommonMethods.Logout(SettingAutomationAgent);
                }

                catch (Exception ex)
                {
                    SettingAutomationAgent.Sleep(2000);
                    SettingAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    SettingAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("SettingTest")]
        [WorkItem(30086)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyClickingOnUpdateContentButtonAtSettings()
        {
            using (SettingAutomationAgent = new AutomationAgent("TC30086: Verify that tapping the Update Content button causes the app to queue updates to any installed units"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(SettingAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(SettingAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnUpdateContentButton(SettingAutomationAgent);
                    SettingsCommonMethods.VerifyInProgressContentButton(SettingAutomationAgent);
                    LoginCommonMethods.Logout(SettingAutomationAgent);
                }

                catch (Exception ex)
                {
                    SettingAutomationAgent.Sleep(2000);
                    SettingAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    SettingAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("SettingTest")]
        [WorkItem(22600)]//Pass
        [Priority(2)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyConfigCodeAtAppVersionVsSettingsScreen()
        {
            using (SettingAutomationAgent = new AutomationAgent("TC22600: Verify  that Config code and App version in device settings and app Settings screen are same"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(SettingAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(SettingAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(SettingAutomationAgent);
                    string configCodeAtAppSettings = SettingsCommonMethods.GetConfigCodefromAppSettingsScreen(SettingAutomationAgent);
                    string configCodeAtDeviceSettings = SettingsCommonMethods.GetConfigCodefromDeviceSettingsScreen(SettingAutomationAgent);
                    Assert.IsTrue(configCodeAtAppSettings.Equals(configCodeAtDeviceSettings));
                    SettingAutomationAgent.LaunchApp();
                    LoginCommonMethods.Logout(SettingAutomationAgent);
                }

                catch (Exception ex)
                {
                    SettingAutomationAgent.Sleep(2000);
                    SettingAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    SettingAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("SettingTest")]
        [WorkItem(30085)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUpdateContentButtonDisplayInSettings()
        {
            using (SettingAutomationAgent = new AutomationAgent("TC30085: Verify that Update Content button will be displayed in Settings page."))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(SettingAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(SettingAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    string unitNumber = NavigationCommonMethods.GetCurrentUnitNumber(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnSystemTray(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(SettingAutomationAgent);
                    SettingsCommonMethods.VerifyUpdateContentButton(SettingAutomationAgent);
                    LoginCommonMethods.Logout(SettingAutomationAgent);
                }

                catch (Exception ex)
                {
                    SettingAutomationAgent.Sleep(2000);
                    SettingAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    SettingAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("SettingTest")]
        [WorkItem(30087)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifyUpdateContentChangedIntoInProgress()
        {
            using (SettingAutomationAgent = new AutomationAgent("TC30087: Verify that while any content delta download is in progres"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(SettingAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(SettingAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnUpdateContentButton(SettingAutomationAgent);
                    SettingsCommonMethods.VerifyInProgressContentButton(SettingAutomationAgent);
                    LoginCommonMethods.Logout(SettingAutomationAgent);
                }

                catch (Exception ex)
                {
                    SettingAutomationAgent.Sleep(2000);
                    SettingAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    SettingAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("SettingTest")]
        [WorkItem(19240)]
        [Priority(1)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void VerifySettingsPageUI()
        {
            using (SettingAutomationAgent = new AutomationAgent("TC19240: Verify the UI elements in Settings Page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(SettingAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(SettingAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnSystemTray(SettingAutomationAgent);
                    NavigationCommonMethods.ClickOnSettingsButtons(SettingAutomationAgent);
                    SettingsCommonMethods.VerifySettingsTitle(SettingAutomationAgent);
                    SettingsCommonMethods.VerifyStatusLabelOfSettingsScreen(SettingAutomationAgent);
                    SettingsCommonMethods.VerifyContentInstallationLogsAtSettings(SettingAutomationAgent);
                    SettingsCommonMethods.VerifyDownloadLogsWithSubjectNameAtSettings(SettingAutomationAgent);
                    LoginCommonMethods.Logout(SettingAutomationAgent);
                }

                catch (Exception ex)
                {
                    SettingAutomationAgent.Sleep(2000);
                    SettingAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    SettingAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }
    }
}
