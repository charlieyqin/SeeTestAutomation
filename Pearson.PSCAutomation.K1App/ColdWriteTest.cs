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
    public class ColdWriteTest
    {

        public AutomationAgent coldwriteAutomationAgent;

        [TestMethod()]
        [TestCategory("ColdWriteTest")]
        [WorkItem(53629)]
        [Priority(2)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyColdWriteIsNotDisplayedInMediaLibrary()
        {
            using (coldwriteAutomationAgent = new AutomationAgent("TC53629: Verify whether the Cold write will be hidden from Media Library; it will only appear on Today Shelf"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(coldwriteAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(coldwriteAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(coldwriteAutomationAgent, "7");
                    NavigationCommonMethods.ClickOnMediaLibrary(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.DragMediaLibraryScreenToSearchColdWrite(coldwriteAutomationAgent);
                    LoginCommonMethods.Logout(coldwriteAutomationAgent);                 

                }

                catch (Exception ex)
                {
                    coldwriteAutomationAgent.Sleep(2000);
                    coldwriteAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    coldwriteAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ColdWriteTest")]
        [WorkItem(53622)]
        [Priority(2)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyToolsInNotebookpageofColdWrite()
        {
            using (coldwriteAutomationAgent = new AutomationAgent("TC53622: Verify the display and functionality of Cold Write Notebook page"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(coldwriteAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(coldwriteAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(coldwriteAutomationAgent,"7");
                    NavigationCommonMethods.ClickOnTodayButton(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.ClickOnColdWrite(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.ClickOnOpenYourNotebook(coldwriteAutomationAgent);
                    BookBuilderCommonMethods.VerifyRightSideToolsOfCanvas(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.VerifyLeftSideToolsOfCanvas(coldwriteAutomationAgent);
                    Assert.IsFalse(ColdWriteCommonMethods.VerifyAddPageIconIsPresent(coldwriteAutomationAgent));

                    ColdWriteCommonMethods.ClickAeroplaneToSend(coldwriteAutomationAgent);
                    Assert.IsTrue(ColdWriteCommonMethods.VerifyStandardSendBoxIsPresent(coldwriteAutomationAgent));

                    ColdWriteCommonMethods.SelectTeacherName(coldwriteAutomationAgent, "Ms. JENNIFER Kemble");
                    Assert.IsTrue(ColdWriteCommonMethods.VerifySentMessageIsPresent(coldwriteAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(coldwriteAutomationAgent);
                    LoginCommonMethods.Logout(coldwriteAutomationAgent);

                }

                catch (Exception ex)
                {
                    coldwriteAutomationAgent.Sleep(2000);
                    coldwriteAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    coldwriteAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ColdWriteTest")]
        [WorkItem(53623)]
        [Priority(2)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyColdWriteOpenedAsOverlay()
        {
            using (coldwriteAutomationAgent = new AutomationAgent("TC53623: Verify the UI of Cold Write Prompt displayed after tapping on cold write icon in Today's shelf"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(coldwriteAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(coldwriteAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(coldwriteAutomationAgent, "7");
                    NavigationCommonMethods.ClickOnTodayButton(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.ClickOnColdWrite(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.VerifyColdWriteOverlay(coldwriteAutomationAgent);
                    string header = ColdWriteCommonMethods.GetOpenYourNoteBookText(coldwriteAutomationAgent);
                    Assert.IsTrue(header.Contains("Open Your Notebook"), "Header not displayed");
                    Assert.IsTrue(ColdWriteCommonMethods.VerifyNoteBookIconCenteredInColdWriteOverlay(coldwriteAutomationAgent), "Not Center Aligned");
                    LoginCommonMethods.Logout(coldwriteAutomationAgent);

                }

                catch (Exception ex)
                {
                    coldwriteAutomationAgent.Sleep(2000);
                    coldwriteAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    coldwriteAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ColdWriteTest")]
        [WorkItem(53624)]
        [Priority(2)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyColdWriteNotebookWhileOffline()
        {
            using (coldwriteAutomationAgent = new AutomationAgent("TC53624: Verify the display of Error message when the user tries to submit Cold Write Notebook while offline"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(coldwriteAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(coldwriteAutomationAgent, Login.GetLogin("StudentSophia"));
                    NavigationCommonMethods.ClickOnELAUnit(coldwriteAutomationAgent, "7");
                    NavigationCommonMethods.ClickOnTodayButton(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.ClickOnColdWrite(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.ClickOnOpenYourNotebook(coldwriteAutomationAgent);
                    bool TurnWifiOff = true;
                    NavigationCommonMethods.ChangeWiFiConnectivity(coldwriteAutomationAgent, TurnWifiOff);
                    coldwriteAutomationAgent.LaunchApp();
                    ColdWriteCommonMethods.ClickAeroplaneToSend(coldwriteAutomationAgent);
                    if (ColdWriteCommonMethods.VerifySendIconIsPresent(coldwriteAutomationAgent))
                        ColdWriteCommonMethods.ClickOnSendButton(coldwriteAutomationAgent);
                    Assert.IsTrue(ColdWriteCommonMethods.VerifyHelpMessageIsPresentwhenOffline(coldwriteAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(coldwriteAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(coldwriteAutomationAgent, 1);
                    LoginCommonMethods.Logout(coldwriteAutomationAgent);

                }

                catch (Exception ex)
                {
                    coldwriteAutomationAgent.Sleep(2000);
                    coldwriteAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    coldwriteAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ColdWriteTest")]
        [WorkItem(53628)]
        [Priority(2)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyColdWriteOpenedAsOverlayForTeacher()
        {
            using (coldwriteAutomationAgent = new AutomationAgent("TC53628:Verify the display of Error message when the user tries to submit Cold Write Notebook while offline"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(coldwriteAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(coldwriteAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(coldwriteAutomationAgent, "7");
                    NavigationCommonMethods.ClickOnTodayButton(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.ClickOnColdWrite(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.VerifyColdWriteOverlay(coldwriteAutomationAgent);
                    string header = ColdWriteCommonMethods.GetOpenYourNoteBookText(coldwriteAutomationAgent);
                    Assert.IsTrue(header.Contains("Open Your Notebook"), "Header not displayed");
                    Assert.IsTrue(ColdWriteCommonMethods.VerifyNoteBookIconCenteredInColdWriteOverlay(coldwriteAutomationAgent), "Not Center Aligned");
                    LoginCommonMethods.Logout(coldwriteAutomationAgent);

                }

                catch (Exception ex)
                {
                    coldwriteAutomationAgent.Sleep(2000);
                    coldwriteAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    coldwriteAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("ColdWriteTest")]
        [WorkItem(53625)]
        [Priority(2)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyStudentNotAbleToShareWhenDataLossIsSet()
        {
            using (coldwriteAutomationAgent = new AutomationAgent("TC53625:Verify the display of Error message when the server is not responding while student tries to submit Cold Write Notebook to Teacher"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(coldwriteAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(coldwriteAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(coldwriteAutomationAgent, "7");
                    NavigationCommonMethods.ClickOnTodayButton(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.ClickOnColdWrite(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.ClickOnOpenYourNotebook(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.ChangeTo100PercentDataLoss(coldwriteAutomationAgent);
                    LoginCommonMethods.Logout(coldwriteAutomationAgent);
                    coldwriteAutomationAgent.LaunchApp();
                    ColdWriteCommonMethods.ClickAeroplaneToSend(coldwriteAutomationAgent);
                    if (ColdWriteCommonMethods.VerifySendIconIsPresent(coldwriteAutomationAgent))
                        ColdWriteCommonMethods.ClickOnSendButton(coldwriteAutomationAgent);
                    Assert.IsTrue(ColdWriteCommonMethods.VerifyHelpMessageIsPresentwhenOffline(coldwriteAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(coldwriteAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(coldwriteAutomationAgent, 1);
                    LoginCommonMethods.Logout(coldwriteAutomationAgent);
                }

                catch (Exception ex)
                {
                    coldwriteAutomationAgent.Sleep(2000);
                    coldwriteAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    coldwriteAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }

        //US10338 [Blocked]

        [TestMethod()]
        [TestCategory("ColdWriteTest")]
        [WorkItem(53908)]
        [Priority(2)]
        [Owner("Lakshmi Brunda(lakshmi.brunda)")]
        public void VerifyColdWriteSaveLocallyStudent()
        {
            using (coldwriteAutomationAgent = new AutomationAgent("TC53908:Cold Write_Save Locally_Student"))
            {
                try
                {
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(coldwriteAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(coldwriteAutomationAgent, Login.GetLogin("TeacherAdbul"));
                    NavigationCommonMethods.ClickOnELAUnit(coldwriteAutomationAgent, "G-I");
                    NavigationCommonMethods.ClickOnTodayButton(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.ClickOnColdWrite(coldwriteAutomationAgent);
                    ColdWriteCommonMethods.ClickOnOpenYourNotebook(coldwriteAutomationAgent);
                    
                    LoginCommonMethods.Logout(coldwriteAutomationAgent);
                    coldwriteAutomationAgent.LaunchApp();
                    ColdWriteCommonMethods.ClickAeroplaneToSend(coldwriteAutomationAgent);
                    if (ColdWriteCommonMethods.VerifySendIconIsPresent(coldwriteAutomationAgent))
                        ColdWriteCommonMethods.ClickOnSendButton(coldwriteAutomationAgent);
                    Assert.IsTrue(ColdWriteCommonMethods.VerifyHelpMessageIsPresentwhenOffline(coldwriteAutomationAgent));
                    LoginCommonMethods.CloseErrorPopUp(coldwriteAutomationAgent);
                    NavigationCommonMethods.NavigateToHome(coldwriteAutomationAgent, 1);
                    LoginCommonMethods.Logout(coldwriteAutomationAgent);
                }

                catch (Exception ex)
                {
                    coldwriteAutomationAgent.Sleep(2000);
                    coldwriteAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    coldwriteAutomationAgent.CloseApplication();
                    throw;
                }
            }
        }




    }
}
