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
    public class SystemTrayTest
    {

        public AutomationAgent systemTrayAutomationAgent;

        [TestMethod()]
        [TestCategory("SystemTrayTest")]
        [WorkItem(53919)]
        [Priority(2)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyTabsInSystemTray()
        {
            using (systemTrayAutomationAgent = new AutomationAgent("TC53919: To verify the tabs present in system tray  when logs in as  Sectioned Teacher"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(systemTrayAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(systemTrayAutomationAgent, Login.GetLogin("TeacherJennifer"));
                    
                    NavigationCommonMethods.ClickOnSystemTray(systemTrayAutomationAgent);
                    Assert.IsTrue(SystemTrayCommonMethods.VerifyAssessmentManager(systemTrayAutomationAgent),"Assessment Manager tab not found");
                    Assert.IsTrue(SystemTrayCommonMethods.VerifyAssessmentReports(systemTrayAutomationAgent), "Assessment Reports tab not found");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(systemTrayAutomationAgent);
                }

                catch (Exception ex)
                {
                    systemTrayAutomationAgent.Sleep(2000);
                    systemTrayAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    systemTrayAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("SystemTrayTest")]
        [WorkItem(53920)]
        [Priority(2)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyItemsDispayedUnderAssessmentManager()
        {
            using (systemTrayAutomationAgent = new AutomationAgent("TC53920: To verify the functionality when Sectioned Teacher taps on Assessment Manager "))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(systemTrayAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(systemTrayAutomationAgent, Login.GetLogin("TeacherJennifer"));
                    
                    NavigationCommonMethods.ClickOnSystemTray(systemTrayAutomationAgent);
                    SystemTrayCommonMethods.ClickAssessmentManager(systemTrayAutomationAgent);
                    Assert.IsTrue(SystemTrayCommonMethods.VerifyAssessmentManagerMenu(systemTrayAutomationAgent), "Format didn't match");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(systemTrayAutomationAgent);
                }

                catch (Exception ex)
                {
                    systemTrayAutomationAgent.Sleep(2000);
                    systemTrayAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    systemTrayAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("SystemTrayTest")]
        [WorkItem(53921)]
        [Priority(2)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyItemsDispayedUnderAssessmentReports()
        {
            using (systemTrayAutomationAgent = new AutomationAgent("TC53921:To verify the functionality when Sectioned Teacher taps on Assessment Reports"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(systemTrayAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(systemTrayAutomationAgent, Login.GetLogin("TeacherJennifer"));
                 
                    NavigationCommonMethods.ClickOnSystemTray(systemTrayAutomationAgent);
                    SystemTrayCommonMethods.ClickAssessmentReports(systemTrayAutomationAgent);
                    Assert.IsTrue(SystemTrayCommonMethods.VerifyAssessmentManagerMenu(systemTrayAutomationAgent), "Format didn't match");
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(systemTrayAutomationAgent);
                }

                catch (Exception ex)
                {
                    systemTrayAutomationAgent.Sleep(2000);
                    systemTrayAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    systemTrayAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("SystemTrayTest")]
        [WorkItem(53922)]
        [Priority(3)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyIdenticalItemsInReportsAndManager()
        {
            using (systemTrayAutomationAgent = new AutomationAgent("TC53922:To  verify Assessment Manager and Assessment Reports dropdowns are identical and to verify whether the dropdown menu items will be non-clickable / non-functional"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(systemTrayAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(systemTrayAutomationAgent, Login.GetLogin("TeacherJennifer"));
                  
                    NavigationCommonMethods.ClickOnSystemTray(systemTrayAutomationAgent);
                    SystemTrayCommonMethods.ClickAssessmentManager(systemTrayAutomationAgent);
                    string managerSubMenu = SystemTrayCommonMethods.GetTextOfAssessmentMenu(systemTrayAutomationAgent);
                    SystemTrayCommonMethods.ClickSubMenuInAssessmentReports(systemTrayAutomationAgent);

                    NavigationCommonMethods.ClickOnSystemTray(systemTrayAutomationAgent);
                    SystemTrayCommonMethods.ClickAssessmentReports(systemTrayAutomationAgent);
                    string reportsSubMenu = SystemTrayCommonMethods.GetTextOfAssessmentMenu(systemTrayAutomationAgent);
                    Assert.AreEqual(managerSubMenu,reportsSubMenu, "Dropdowns are not identical");
                    SystemTrayCommonMethods.ClickSubMenuInAssessmentReports(systemTrayAutomationAgent);
                    systemTrayAutomationAgent.Sleep(3000);
                    
                    
                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(systemTrayAutomationAgent);
                }

                catch (Exception ex)
                {
                    systemTrayAutomationAgent.Sleep(2000);
                    systemTrayAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    systemTrayAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("SystemTrayTest")]
        [WorkItem(53923)]
        [Priority(3)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void AppCrashdueToRepeatedTapping()
        {
            using (systemTrayAutomationAgent = new AutomationAgent("TC53923:To  verify Assessment Manager and Assessment Reports dropdowns are identical and to verify whether the dropdown menu items will be non-clickable / non-functional"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(systemTrayAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(systemTrayAutomationAgent, Login.GetLogin("TeacherJennifer"));
                   
                    NavigationCommonMethods.ClickOnSystemTray(systemTrayAutomationAgent);
                    for (int i = 0; i < 5; i++)
                    {
                        NavigationCommonMethods.ClickOnInboxButton(systemTrayAutomationAgent);
                        NavigationCommonMethods.ClickOnSystemTray(systemTrayAutomationAgent);

                        SystemTrayCommonMethods.ClickAssessmentManager(systemTrayAutomationAgent);
                        if (SystemTrayCommonMethods.VerifyRefreshButton(systemTrayAutomationAgent))
                            NavigationCommonMethods.ClickOnSystemTray(systemTrayAutomationAgent);
                        SystemTrayCommonMethods.ClickAssessmentReports(systemTrayAutomationAgent);
                    }

                    Assert.IsTrue(SystemTrayCommonMethods.VerifySettingsButton(systemTrayAutomationAgent), "App is Crashed");
                    if (SystemTrayCommonMethods.VerifyRefreshButton(systemTrayAutomationAgent))
                        NavigationCommonMethods.ClickOnSystemTray(systemTrayAutomationAgent);

                    BackUpAndRestoreCommonMethods.ClickOnLogoutButton(systemTrayAutomationAgent);
                }

                catch (Exception ex)
                {
                    systemTrayAutomationAgent.Sleep(2000);
                    systemTrayAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    systemTrayAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        //US10426

        [TestMethod()]
        [TestCategory("SystemTrayTest")]
        [WorkItem(54375)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyInboxCountBadgeOnSystemTray()
        {
            using (systemTrayAutomationAgent = new AutomationAgent("TC54375: Verify redirection when hitting on back icon after password setup process for fresh user"))
            {
                try
                {
                    InboxCommonMethods.NavigateTillInbox(systemTrayAutomationAgent, "TeacherELA");
                    if (!InboxCommonMethods.VerifyStackedItemIsPresent(systemTrayAutomationAgent))
                    {
                        LoginCommonMethods.Logout(systemTrayAutomationAgent);
                        InboxCommonMethods.sendELANoteBooKForReview(systemTrayAutomationAgent, "StudentSec01",1);
                    }
                    InboxCommonMethods.sendELANoteBooKReviewToStudent(systemTrayAutomationAgent, "TeacherELA");                   
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(systemTrayAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(systemTrayAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(systemTrayAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.SelectPicPassword(systemTrayAutomationAgent, 1, 1, 1);
                    LoginCommonMethods.ClickGreenMarkPicturePasswordScreen(systemTrayAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(systemTrayAutomationAgent, 1, 1, 1);
                    NavigationCommonMethods.ClickOnNextArrowAtLetsPractice(systemTrayAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(systemTrayAutomationAgent, 1, 1, 1);
                    NavigationCommonMethods.ClickOnLetsLoginArrow(systemTrayAutomationAgent);
                    SystemTrayCommonMethods.ClickLoginButtonInStudentScreen(systemTrayAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(systemTrayAutomationAgent, 1, 1, 1);
                    while (!systemTrayAutomationAgent.IsElementFound("UnitSelection", "SystemTray"))
                    {
                        systemTrayAutomationAgent.Sleep(5000);
                    }
                    int count = SystemTrayCommonMethods.GetInboxCountInSystemTray(systemTrayAutomationAgent);
                    int realCount = InboxCommonMethods.countOfNewBannerTilesInELAAndMath(systemTrayAutomationAgent);
                    Assert.AreEqual<int>(count, realCount, "NewBanner Image holding tiles mismatch");
                    LoginCommonMethods.Logout(systemTrayAutomationAgent);                    
                   
                }

                catch (Exception ex)
                {
                    systemTrayAutomationAgent.Sleep(2000);
                    systemTrayAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    systemTrayAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("SystemTrayTest")]
        [WorkItem(54376)]
        [Priority(2)]
        [Owner("Lakshmi Brunda (lakshmi.brunda)")]
        public void VerifyInboxCountBadgeIncrementedInSystemTray()
        {
            using (systemTrayAutomationAgent = new AutomationAgent("TC54375: Verify redirection when hitting on back icon after password setup process for fresh user"))
            {
                try
                {
                    InboxCommonMethods.NavigateTillInbox(systemTrayAutomationAgent, "StudentSec01");
                    while (!InboxCommonMethods.VerifyStackedItemIsPresent(systemTrayAutomationAgent))
                    {
                        LoginCommonMethods.Logout(systemTrayAutomationAgent);
                        InboxCommonMethods.sendELANoteBooKForReview(systemTrayAutomationAgent,"StudentSec01",1);
                       
                    }
                    int realCount = InboxCommonMethods.countOfNewBannerTilesInELAAndMath(systemTrayAutomationAgent);
                    LoginCommonMethods.Logout(systemTrayAutomationAgent);
                    InboxCommonMethods.sendELANoteBooKReviewToStudent(systemTrayAutomationAgent, "TeacherELA");
                    
                    //Student Pic Password Flow Login                    
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(systemTrayAutomationAgent);
                    NavigationCommonMethods.ClickOnSetUp(systemTrayAutomationAgent);
                    LoginCommonMethods.StudentSetupLogin(systemTrayAutomationAgent, Login.GetLogin("StudentAzyiah"));
                    LoginCommonMethods.SelectPicPassword(systemTrayAutomationAgent, 1, 1, 1);
                    LoginCommonMethods.ClickGreenMarkPicturePasswordScreen(systemTrayAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(systemTrayAutomationAgent, 1, 1, 1);
                    NavigationCommonMethods.ClickOnNextArrowAtLetsPractice(systemTrayAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(systemTrayAutomationAgent, 1, 1, 1);
                    NavigationCommonMethods.ClickOnLetsLoginArrow(systemTrayAutomationAgent);
                    SystemTrayCommonMethods.ClickLoginButtonInStudentScreen(systemTrayAutomationAgent);
                    LoginCommonMethods.SelectPicPassword(systemTrayAutomationAgent, 1, 1, 1);
                    while (!systemTrayAutomationAgent.IsElementFound("UnitSelection", "SystemTray"))
                    {
                        systemTrayAutomationAgent.Sleep(5000);
                    }
                    int count = SystemTrayCommonMethods.GetInboxCountInSystemTray(systemTrayAutomationAgent);

                    Assert.IsTrue(count.Equals(realCount + 1), "Badge Count is not incremented");
                    LoginCommonMethods.Logout(systemTrayAutomationAgent);

                }

                catch (Exception ex)
                {
                    systemTrayAutomationAgent.Sleep(2000);
                    systemTrayAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    systemTrayAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

    }
}
