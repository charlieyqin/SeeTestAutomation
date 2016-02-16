using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest.Automation.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pearson.PSCAutomation.K1App
{
    [TestClass]
    public class AssessmentOngoing
    {
        public AutomationAgent OngoingAssessmentAutomationAgent;


        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10345"), TestCategory("US10224"), TestCategory("US10343")]
        [Priority(1)]
        [WorkItem(53895), WorkItem(53896), WorkItem(53897), WorkItem(54267), WorkItem(54269), WorkItem(54279),WorkItem(53981), WorkItem(54597), WorkItem(54608)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyChecklistAssessmentNameStatusAndPreviewStandards()
        {
            using (OngoingAssessmentAutomationAgent = new AutomationAgent("TC53895,TC53896,TC53897,TC54267,TC54269,TC53981,TC54279,TC54597,TC54608:Verify status,substatus of checklist assessment and the preview standards availability"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CheckListAssessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(OngoingAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(OngoingAssessmentAutomationAgent, Login.GetLogin("AssessmentTeacher"));
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(OngoingAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);                    
                    AssessmentCommonMethods.ClickAssessmentInAssessmentManager(OngoingAssessmentAutomationAgent, testData[0]);
                    AssessmentCommonMethods.AssessmentUnitSelection(OngoingAssessmentAutomationAgent, testData[2]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentPendingStatusInManagerPresent(OngoingAssessmentAutomationAgent,testData[1]),"Pending State Not Found");
                    Assert.IsFalse(AssessmentCommonMethods.VerifyAssessmentScoredSubStatusInManagerPresent(OngoingAssessmentAutomationAgent, testData[1]),"Sub Status Found");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyFixedAssessmentPresentInManagerScreen(OngoingAssessmentAutomationAgent, testData[1]), "Ongoing Assessment Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyNavigationCellArrowInManagerScreen(OngoingAssessmentAutomationAgent),"> icon not displayed");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53895", true);
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53896", true);
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53897", true);
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54597", true);
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54608", true);

                    Assert.IsTrue(AssessmentCommonMethods.VerifyOngoingAssessmentTablePresentInManagerScreen(OngoingAssessmentAutomationAgent,testData[1]),"Ongoing Assessment List not present");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC53981", true);

                    AssessmentCommonMethods.ClickFixedAssessmentInManager(OngoingAssessmentAutomationAgent, testData[1]);
                    AssessmentCommonMethods.ClickPreviewAssessmentInAssessmentOverview(OngoingAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickStandardTabInPreviewAssessment(OngoingAssessmentAutomationAgent);
                    AssessmentCommonMethods.VerifyStandardDisplayedInPreviewAssessment(OngoingAssessmentAutomationAgent);
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54267", true);
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54269", true);
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54279", true);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(OngoingAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(OngoingAssessmentAutomationAgent);
                    LoginCommonMethods.Logout(OngoingAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    OngoingAssessmentAutomationAgent.Sleep(2000);
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    OngoingAssessmentAutomationAgent.ApplicationClose();
                    OngoingAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }


        [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US10285")]
        [Priority(1)]
        [WorkItem(54638), WorkItem(54639), WorkItem(54641), WorkItem(54643), WorkItem(54648), WorkItem(54649), WorkItem(54651), WorkItem(54652), WorkItem(54654), WorkItem(54655), WorkItem(54656)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyAssessmentOverviewScreenForChecklistAssesment()
        {
            using (OngoingAssessmentAutomationAgent = new AutomationAgent("TC54638,TC54639,TC54641,TC54643,TC54648,TC54649,TC54651,TC54652,TC54654,TC54655,TC54656:Verify the Assessment Overview Screen in Checklist Assessment"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CheckListAssessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(OngoingAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(OngoingAssessmentAutomationAgent, Login.GetLogin("AssessmentTeacher"));
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(OngoingAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentInAssessmentManager(OngoingAssessmentAutomationAgent, testData[0]);
                    AssessmentCommonMethods.AssessmentUnitSelection(OngoingAssessmentAutomationAgent, testData[2]);        
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(OngoingAssessmentAutomationAgent, testData[1]);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentProgressOverviewTitlePresent(OngoingAssessmentAutomationAgent),"Overview Title Not Present");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54638", true);
                    AssessmentCommonMethods.VerifyAssessmentNameInOverviewScreen(OngoingAssessmentAutomationAgent,testData[1]);
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54641", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifySectionTitleInProgressOverviewScreen(OngoingAssessmentAutomationAgent,testData[0]),"Section Title Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyTotalStudentsInProgressOverviewScreen(OngoingAssessmentAutomationAgent, testData[13]));
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54643", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoredTabTabInOngoingAssessmentOverview(OngoingAssessmentAutomationAgent),"Scored Tab Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyNotScoredTabTabInOngoingAssessmentOverview(OngoingAssessmentAutomationAgent), "Not Scored Tab Not Present");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54648", true);
                    int notScoredCount = AssessmentCommonMethods.GetNotScoredCountFromAssessmentOverviewAccomplishment(OngoingAssessmentAutomationAgent);
                    ArrayList notScoredStudentList = AssessmentCommonMethods.GetNotScoredStudentListFromAssessmentAccomplishment(OngoingAssessmentAutomationAgent, notScoredCount);
                    if (notScoredCount > 0)
                    {
                        Assert.IsFalse(notScoredStudentList[0].Equals(""), "Not Scored Student List Is Empty");
                    }
                    else
                    {
                        Assert.IsTrue(notScoredStudentList[0].Equals(""), "Not Scored Student List Is Not Empty");
                    }
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54649", true);
                    AssessmentCommonMethods.Swipe(OngoingAssessmentAutomationAgent, Direction.Right, 500, 500);
                    OngoingAssessmentAutomationAgent.Sleep(3000);
                    ArrayList afterSwipe = AssessmentCommonMethods.GetNotScoredStudentListFromAssessmentAccomplishment(OngoingAssessmentAutomationAgent, notScoredCount);
                    if (notScoredCount > 24)
                    {
                        Assert.AreNotEqual(notScoredStudentList[0], afterSwipe[0], "Not able to do the Horizontal swipe.");
                    }
                    else
                    {
                        Assert.AreEqual(notScoredStudentList[0], afterSwipe[0], "Able to swipe when student count is less than 24.");
                    }
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54652", true);
                    AssessmentCommonMethods.ClickScoredTabInOngoingAssessmentOverview(OngoingAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyNoStudentsMessageInAssessmentOverview(OngoingAssessmentAutomationAgent),"No Students Message");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54651", true);
                    Assert.IsFalse(AssessmentCommonMethods.VerifyUnlockAssessmentsLinkPresent(OngoingAssessmentAutomationAgent),"Unlock Link Present");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54654", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyPreviewAssessmentInAssessmentOverview(OngoingAssessmentAutomationAgent),"Preview Link not present");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54655", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoreButtonPresentInOverviewScreen(OngoingAssessmentAutomationAgent),"Score Button Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyViewReportButtonPresentInOverviewScreen(OngoingAssessmentAutomationAgent), "View Report Button Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoreButtonPresentInOverviewScreen(OngoingAssessmentAutomationAgent), "Release Score Not Present");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54656", true);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(OngoingAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerTitlePresent(OngoingAssessmentAutomationAgent),"Manager Title Not Present");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC54639", true);
                    LoginCommonMethods.Logout(OngoingAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    OngoingAssessmentAutomationAgent.Sleep(2000);
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    OngoingAssessmentAutomationAgent.ApplicationClose();
                    OngoingAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }

        [TestMethod()]
        [TestCategory("Assessment"),TestCategory("US10672")]
        [Priority(1)]
        [WorkItem(55090), WorkItem(55093), WorkItem(55094), WorkItem(55099), WorkItem(55100), WorkItem(55190), WorkItem(55191)]
        [Owner("Godwin Terence(Godwin.Terence)")]
        public void VerifyChecklistAssessmentStopScoringDialog()
        {
            using (OngoingAssessmentAutomationAgent = new AutomationAgent("TC55090,TC55093,TC55094,TC55099,TC55100,TC55190,TC55191:Verify Checklist Assessment Stop Scoring Screen"))
            {
                try
                {
                    Login login = Login.GetLogin("AssessmentTeacher");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CheckListAssessment");
                    String[] testData = AssessmentCommonMethods.LoadTestDataFromAdditionalInfo(taskInfo);
                    NavigationCommonMethods.ClickOnTeacherAdminLogin(OngoingAssessmentAutomationAgent);
                    LoginCommonMethods.TeacherAdminLogin(OngoingAssessmentAutomationAgent, Login.GetLogin("AssessmentTeacher"));
                    AssessmentCommonMethods.SelectUnitFromUnitSelectionScreen(OngoingAssessmentAutomationAgent, taskInfo.Grade, taskInfo.Unit);
                    AssessmentCommonMethods.ClickAssessmentInAssessmentManager(OngoingAssessmentAutomationAgent, testData[0]);
                    AssessmentCommonMethods.AssessmentUnitSelection(OngoingAssessmentAutomationAgent, testData[2]);                    
                    AssessmentCommonMethods.ClickFixedAssessmentInManager(OngoingAssessmentAutomationAgent, testData[1]);
                    AssessmentCommonMethods.ClickScoreButtonInAssessmentOverview(OngoingAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewTitlePresent(OngoingAssessmentAutomationAgent),"Scoring Overview Title Not Present");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55099", true);
                    AssessmentCommonMethods.ClickQuestionOneChecklist(OngoingAssessmentAutomationAgent,testData[10]);
                    AssessmentCommonMethods.ClickChecklistDoneButton(OngoingAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickNotScoredTabInOngoingStopScoring(OngoingAssessmentAutomationAgent);
                    int notScoredCountStopScoring = AssessmentCommonMethods.GetNotScoredCountFromStopScoringOngoing(OngoingAssessmentAutomationAgent);
                    ArrayList notScoredStudentList = AssessmentCommonMethods.GetNotScoredStudentListFromAssessmentAccomplishment(OngoingAssessmentAutomationAgent, notScoredCountStopScoring);
                    if (notScoredCountStopScoring > 0)
                    {
                        Assert.IsFalse(notScoredStudentList[0].Equals(""), "Not Scored Student List Is Empty");
                    }
                    else
                    {
                        Assert.IsTrue(notScoredStudentList[0].Equals(""), "Not Scored Student List Is Not Empty");
                    }
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55090", true);                    
                    if (notScoredCountStopScoring > 0)
                    {
                        Assert.IsFalse(AssessmentCommonMethods.VerifyNoStudentsMessageInAssessmentOverview(OngoingAssessmentAutomationAgent), "Student message is present");
                    }
                    else
                    {
                        Assert.IsTrue(AssessmentCommonMethods.VerifyNoStudentsMessageInAssessmentOverview(OngoingAssessmentAutomationAgent), "Student message is not present");
                    }                                                         
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55093", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifySectionTitleInStopScoring(OngoingAssessmentAutomationAgent,testData[0]),"Course name Not found");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentCountInStopScoring(OngoingAssessmentAutomationAgent, testData[13]), "Student Count Not found");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55094", true);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringTextPresent(OngoingAssessmentAutomationAgent),"Stop Scoring ? Not Present");
                    Assert.IsTrue(AssessmentCommonMethods.VerifyYesAndNoButtonPresentInStopScoring(OngoingAssessmentAutomationAgent),"Yes And No button Not present");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55100", true);
                    AssessmentCommonMethods.ClickNoButtonInStopScoringDialog(OngoingAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyChecklistItemScoringTitlePresent(OngoingAssessmentAutomationAgent),"Item Scoring Title Not Present");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55191", true);
                    AssessmentCommonMethods.ClickChecklistDoneButton(OngoingAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickYesButtonInStopScoringDialog(OngoingAssessmentAutomationAgent);
                    Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewTitlePresent(OngoingAssessmentAutomationAgent), "Scoring Overview Title Not Present");
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport("TC55190", true);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(OngoingAssessmentAutomationAgent);
                    AssessmentCommonMethods.ClickBackButtonInAssessment(OngoingAssessmentAutomationAgent);
                    LoginCommonMethods.Logout(OngoingAssessmentAutomationAgent);
                }
                catch (Exception ex)
                {
                    OngoingAssessmentAutomationAgent.Sleep(2000);
                    OngoingAssessmentAutomationAgent.AddSteptoSeeTestReport(ex.Message, false);
                    OngoingAssessmentAutomationAgent.ApplicationClose();
                    OngoingAssessmentAutomationAgent.GenerateReportAndReleaseClient();
                    throw;
                }
            }
        }
    }
}
